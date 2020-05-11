using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using IVisio = Microsoft.Office.Interop.Visio;
using Microsoft.Office.Interop.Visio;
using System.Runtime.Remoting;
using System.Globalization;

namespace VisioFromExcel
{
    public partial class Form1 : Form
    {
        public class Connection
        {
            public Connection(string aName)
            {
                this.Children = new List<Connection>();
                this.Name = aName;
                IsAnker = false;
                clients = new List<Tuple<string, bool>>();
            }
            //public Connection Parent { get; }
            public String Name { get; set; }
            public String ParentName { get; set; }
            public String lineType { get; set; }
            public List<Tuple<string, bool>> clients { get; set; }
            public List<Connection> Children { get; set; }
            public bool IsRoot => Name == "0";
            public bool IsAnker { get; set; }
            //public bool IsLeaf => Children.Count == 0;

            public bool AddChild(string _name, Connection _newChild)
            {
                //Console.WriteLine(Name);
                if (Name == _name)
                {
                    Children.Add(_newChild);
                    return true;
                }
                foreach (Connection child in Children)
                {
                    if (child.AddChild(_name, _newChild)==true)
                        return true;
                }
                return false;
            }
        }

        Connection mainNode;
        IVisio.InvisibleApp visapp;
        //Dictionary<string, int> _routes;
        List<Tuple<string, int>> _routes;
        List<Tuple<string, int, int>> lineTypeList;
        //List<Tuple<string, bool>> clientsList;
        Dictionary<string, List<Tuple<string, bool>>> clientsList;
        public int[,] dirArr;
        int maxNodes;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            makeDate.Text = DateTime.Today.ToString("dd.MM.yy");
            chekedDate.Text = DateTime.Today.ToString("dd.MM.yy");
            dirArr = new int[3,4]  {{0,1,2,3},
                                    {1,0,0,1},
                                    {2,3,3,2}};

        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.Contains(".kml"))
                {
                    string aFileName = file;
                    string aFilePath = "";
                    int slashPos = file.LastIndexOf('\\');
                    if (slashPos != -1)
                    {
                        aFileName = file.Substring(slashPos + 1, file.Length - slashPos - 1);
                        aFilePath = file.Substring(0, slashPos);
                    }
                    fileName.Text = file;
                    LogTextEvent(System.Drawing.Color.Black, "Добавлен файл " + file);
                }
                else
                    LogTextEvent(System.Drawing.Color.Red, "Расширение файла должно быть KLM: " + file);
            }
        }

        public void LogTextEvent(System.Drawing.Color TextColor, string EventText)
        {
            RichTextBox TextEventLog = logBox;
            if (TextEventLog.InvokeRequired)
            {
                TextEventLog.BeginInvoke(new Action(delegate {
                    LogTextEvent(TextColor, EventText);
                }));
                return;
            }

            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

            // color text.
            TextEventLog.SelectionStart = TextEventLog.Text.Length;
            TextEventLog.SelectionColor = TextColor;

            // newline if first line, append if else.
            if (TextEventLog.Lines.Length == 0)
            {
                TextEventLog.AppendText(nDateTime + EventText);
                TextEventLog.ScrollToCaret();
                TextEventLog.AppendText(System.Environment.NewLine);
            }
            else
            {
                TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                TextEventLog.ScrollToCaret();
            }
        }

        private bool searchInRouteTuple(List<Tuple<string, int>> routList, string key, out int value)
        {
            foreach (Tuple<string, int> route in routList)
                if (route.Item1 == key)
                {
                    routList.Remove(route);
                    value = route.Item2;
                    return true;
                }
            value = 0;
            return false;
        }
        private bool searchInLineTypeTuple( int _node, int _startNode, int _stopNode, out string value)
        {
            int upper = Int32.MaxValue;
            int lower = Int32.MaxValue;
            int lineTypeIndex = -1;
            for (int i = 0; i < lineTypeList.Count; i++)
            {
                
                if (_startNode <= lineTypeList[i].Item2 & _stopNode >= lineTypeList[i].Item3)
                {
                    int _upper = _node - lineTypeList[i].Item2;
                    int _lower = lineTypeList[i].Item3 - _node;
                    if (_upper > 0 & _lower >= 0)
                    {
                        if (_upper < upper)
                        {
                            upper = _upper;
                            lineTypeIndex = i;
                        }
                        if (_lower < lower)
                        {
                            lower = _lower;
                            lineTypeIndex = i;
                        }
                    }
                }
            }
            if (lineTypeIndex < 0)
            {
                value = "";
                return false;
            }
            else
            {
                value = lineTypeList[lineTypeIndex].Item1;
                return true;
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
                logBox.Clear();

                if (fileName.Text == "")
                    throw new Exception("Не указан входной файл");

                if (tpType.Text == "")
                    throw new Exception("Не указан тип трансформатора");

                LogTextEvent(System.Drawing.Color.Green, "Начало");

                _routes = new List<Tuple<string, int>>();
                lineTypeList = new List<Tuple<string, int, int>>();
                clientsList = new Dictionary<string, List<Tuple<string, bool>>>();


                foreach (DataGridViewRow row in routes.Rows)
                    if (row.Cells[0].Value != null & row.Cells[1].Value != null)
                        _routes.Add(new Tuple<string, int>(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value)));
                
                foreach (DataGridViewRow row in lineType.Rows)
                    if (row.Cells[0].Value != null & row.Cells[1].Value != null)
                        lineTypeList.Add(new Tuple<string, int, int>(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value), Convert.ToInt32(row.Cells[2].Value)));

                clientsList = new Dictionary<string, List<Tuple<string, bool>>>();
                string[] clientsAfterSplit = clients.Text.Split(' ');
                for (int i=0; i< clientsAfterSplit.Count();i++)
                {
                    string tmpNode = clientsAfterSplit[i].Replace("+", "");
                    if (!clientsList.ContainsKey(tmpNode))
                        clientsList.Add(tmpNode, new List<Tuple<string, bool>>());

                    clientsList[tmpNode].Add(new Tuple<string, bool>((i+1).ToString(), clientsAfterSplit[i].Contains("+")));
                }

                
                mainNode = new Connection("0");
                
                maxNodes = 0;
                int aDepth = 0;
                try { aDepth = Convert.ToInt32(mainLine.Text); }
                catch { }
                generageTree("0", 0, aDepth+1);
                generateVisio(mainNode);
                LogTextEvent(System.Drawing.Color.Green, "Завершено");
            }
            catch  (Exception ex)
            {
                LogTextEvent(System.Drawing.Color.Red, ex.Message);
                LogTextEvent(System.Drawing.Color.Red, "Завершено с ошибкой");
            }       
        }


        private void generageTree( string parentName, int nodeReservedCount, int depth)
        {
            maxNodes = maxNodes + depth;
            int firstNodeIndex = Convert.ToInt32(parentName);
            int lastNodeIndex = nodeReservedCount + depth;
            for (int i = 1; i <= depth; i++)
            {      

                string innerNodeName = (nodeReservedCount + i).ToString();
                Connection newCon = new Connection(innerNodeName);
                if (searchInLineTypeTuple(nodeReservedCount + i, firstNodeIndex, lastNodeIndex, out string _lineType))
                    newCon.lineType = _lineType;
                else
                    LogTextEvent(System.Drawing.Color.Red, $"Не указан тип линии мужду узлами {parentName} и {innerNodeName}");
                newCon.ParentName = parentName;
                newCon.IsAnker = ankers.Text.Split(' ').Contains(innerNodeName);
                if (clientsList.ContainsKey(innerNodeName))
                    newCon.clients.AddRange(clientsList[innerNodeName]);
                mainNode.AddChild(parentName, newCon);
                if (searchInRouteTuple(_routes,parentName, out int aDepth))
                    generageTree(parentName, maxNodes, aDepth);
                parentName = innerNodeName;
            }            
        }
        private void generateVisio(Connection treeNode)
        {
            visapp = new IVisio.InvisibleApp();
            visapp.AlertResponse = 7; //autoAnswer NO on any alert
            visapp.Visible = false;
            bool errorCatch = false;
            try
            {
                string _fileName = fileName.Text.Split('\\').Last();
                string _filePath = fileName.Text.Replace(_fileName, "");

                string templateFileName = Directory.GetCurrentDirectory() + "\\template.vss";
                string shapesFileName = Directory.GetCurrentDirectory() + "\\shapes.vss";
                string newFullfileName = _filePath + "\\result\\" + _fileName.Replace(".kml", ".vsd");

                if (!File.Exists(templateFileName))
                    throw new Exception("Не найден шаблон выходного файла: " + templateFileName);

                Directory.CreateDirectory(_filePath + "\\result\\");

                string caption = "Поопорная схема ВЛ 0,4 кВ от ";
                string firstTmp = "";
                int tpPos = _fileName.IndexOf("ТП");
                if (tpPos >= 0)
                {
                    firstTmp = _fileName.Substring(tpPos, _fileName.Length - tpPos).Replace('_', '/').Replace(".kml", "");
                    string secondTmp = _fileName.Substring(0, tpPos - 1);
                    _fileName = firstTmp + " кВА " + secondTmp;
                }
                else
                    throw new Exception("Не корректное название файла: " + fileName);
                caption = caption + _fileName + " " + city.Text;

                IVisio.Document doc = visapp.Documents.Open(templateFileName);// (short)IVisio.VisOpenSaveArgs.visAddHidden + (short)IVisio.VisOpenSaveArgs.visOpenNoWorkspace);
                IVisio.Document shapesDoc = visapp.Documents.Open(shapesFileName);// (short)IVisio.VisOpenSaveArgs.visAddHidden + (short)IVisio.VisOpenSaveArgs.visOpenNoWorkspace);
                IVisio.Page page = doc.Pages[1];

                IVisio.Shape visioRectMaster = page.Shapes.get_ItemU("Sheet.1");
                visioRectMaster.Text = caption;

                visioRectMaster = page.Shapes.get_ItemU("Sheet.509");
                visioRectMaster.Text = caption;

                visioRectMaster = page.Shapes.get_ItemU("Sheet.496");
                visioRectMaster.Text = make.Text;

                visioRectMaster = page.Shapes.get_ItemU("Sheet.508");
                visioRectMaster.Text = makeDate.Text;

                visioRectMaster = page.Shapes.get_ItemU("Sheet.495");
                visioRectMaster.Text = chekedM.Text;

                visioRectMaster = page.Shapes.get_ItemU("Sheet.507");
                visioRectMaster.Text = chekedDate.Text;

                int pos2 = firstTmp.LastIndexOf('-');
                int pos3 = firstTmp.LastIndexOf('/');
                string tmp2 = "?";
                if (pos2 != -1 & pos3 != -1 & pos3 > pos2)
                    tmp2 = firstTmp.Substring(pos2 + 1, pos3 - pos2 - 1);

                //visioRectMaster = page.Shapes.get_ItemU("Sheet.314");
                //visioRectMaster.Text = "РЛНД - " + tmp2;

                double newX = 5.9;
                double newY = 6.85;                

                GenerateShapes(shapesDoc.Masters, ref page, mainNode, 0, newX, newY, firstTmp);

                doc.SaveAs(newFullfileName);
                doc.Close();
            }
            catch (Exception ex)
            {
                LogTextEvent(System.Drawing.Color.Red, ex.Message);
                errorCatch = true;
            }
        
            foreach (IVisio.Document aDoc in visapp.Documents)
                aDoc.Close();
            visapp.Quit();
            if (errorCatch) throw new Exception("Ошибка формирвания выходного файла");
        }

        private void GenerateShapes(in IVisio.Masters shapes, ref IVisio.Page page, Connection node, int _direction, double X, double Y, string tpCaption)
        {

            IVisio.Master aMaster;
            IVisio.Shape aShape;
            IVisio.Shape aParentShape;
            //IVisio.Shape aConnectorShape;
            if (node.Name == "0")
            {
                switch (tpType.Text)
                {
                    case "Столбовая":
                        aMaster = shapes.get_ItemU(@"stolb_tp");                        
                        aShape = page.Drop(aMaster, X, Y);
                        aShape.Text = "С" + tpCaption;
                        aShape.NameU = "0";
                        break;
                    case "Мачтовая":
                        aMaster = shapes.get_ItemU(@"macht_tp");
                        aShape = page.Drop(aMaster, X, Y);
                        aShape.Text = "М" + tpCaption;
                        aShape.NameU = "0";
                        break;
                    case "Закрытая":
                        aMaster = shapes.get_ItemU(@"closed_tp");
                        aShape = page.Drop(aMaster, X, Y);
                        aShape.Text = "З" + tpCaption;
                        aShape.NameU = "0";
                        break;
                    case "Комплектная":
                        aMaster = shapes.get_ItemU(@"comp_tp");
                        aShape = page.Drop(aMaster, X, Y);
                        aShape.Text = "К" + tpCaption;
                        aShape.NameU = "0";
                        break;
                }
            }
            else
            {
                //calculateNewCoordinates(ref X, ref Y, _direction);
                string materialTypePrefix = node.IsAnker ? "ank_" : "";
                string materialType = radioButtonMetal.Checked ? materialTypePrefix + "jb" : materialTypePrefix + "d";
               

                string parentName = node.ParentName;
                string lineType = (parentName == "0") ? node.lineType + Environment.NewLine + "Ф1" : node.lineType;// + Environment.NewLine
                aParentShape = page.Shapes.get_ItemU(parentName);

                aMaster = shapes.get_ItemU(materialType);
                calculateNewCoordinates(ref X, ref Y, _direction, aMaster.Shapes[1], aParentShape);
                aShape = page.Drop(aMaster, X, Y);
                aShape.Name = node.Name;
                aShape.Text = node.Name;

                

                aMaster = shapes.get_ItemU(@"Dynamic connector");
                aMaster.Shapes[1].Text = lineType;
                aMaster.Shapes[1].Characters.CharProps[7] = 6;
                aMaster.Shapes[1].Characters.CharProps[0] = 23;
                if (parentName == "0")
                    aMaster.Shapes[1].CellsU["TextBkgnd"].FormulaForceU = "0";
                else
                    aMaster.Shapes[1].CellsU["TextBkgnd"].FormulaForceU = "2";
                aMaster.Shapes[1].CellsU["ShapeRouteStyle"].FormulaForceU = "16";
                aMaster.Shapes[1].CellsU["ConLineRouteExt"].FormulaForceU = "1";
                aMaster.Shapes[1].CellsU["TxtAngle"].FormulaForceU = "ANGLEALONGPATH(Geometry1.Path,1)+IF(COS(ANGLEALONGPATH(Geometry1.Path,1))>=0,0,180°)";

                
                aShape.AutoConnect(aParentShape, IVisio.VisAutoConnectDir.visAutoConnectDirNone, aMaster.Shapes[1]);


                for (int i = 0; i < node.clients.Count; i++)
                {
                    calculateNewClientCoordinates(X, Y, out double cX, out double cY, i, aShape);
                    aMaster = shapes.get_ItemU(@"unit");
                    IVisio.Shape clietShape = page.Drop(aMaster, cX, cY);
                    clietShape.Name = "client_" + node.clients[i].Item1;
                    clietShape.Text = node.clients[i].Item1;
                    aMaster = shapes.get_ItemU(@"Dynamic connector");
                    if (node.clients[i].Item2)
                    {
                        aMaster.Shapes[1].Characters.CharProps[7] = 4;
                        aMaster.Shapes[1].CellsU["TextBkgnd"].FormulaForceU = "0";
                        aMaster.Shapes[1].Text = "|||";
                    }
                    else
                        aMaster.Shapes[1].Text = "";

                    clietShape.AutoConnect(aShape, IVisio.VisAutoConnectDir.visAutoConnectDirNone, aMaster.Shapes[1]);
                }
            }
            for (int i = 0; i < node.Children.Count; i++)
            {
                Connection child = node.Children[i];
                int newDirection = dirArr[i, _direction];
                GenerateShapes(in shapes, ref page, child, newDirection, X, Y,"");
            }                
        }

        private void calculateNewCoordinates(ref double x, ref double y, int direction, IVisio.Shape shape, IVisio.Shape parentShape)
        {
            double w1 = shape.CellsU["angle"].ResultIU ==0 ? shape.CellsU["width"].ResultIU : shape.CellsU["height"].ResultIU;
            double w2 = parentShape.CellsU["angle"].ResultIU == 0 ? parentShape.CellsU["width"].ResultIU : parentShape.CellsU["height"].ResultIU;
            
            double h1 = shape.CellsU["angle"].ResultIU == 0 ? shape.CellsU["height"].ResultIU : shape.CellsU["width"].ResultIU;
            double h2 = parentShape.CellsU["angle"].ResultIU == 0 ? parentShape.CellsU["height"].ResultIU : parentShape.CellsU["width"].ResultIU;

            double shapeDiam = 0.15748;
            double xFac = 2;
            double yFac = 2;
            
            switch (direction)
            {
                case 0:
                    y = y - (shapeDiam * yFac + (h1 / 2 + h2 / 2));
                    break;
                case 1:
                    x = x - (shapeDiam * xFac + (w1 / 2 + w2 / 2));
                    break;
                case 2:
                    x = x + (shapeDiam * xFac + (w1 / 2 + w2 / 2));
                    break;
                case 3:
                    y = y + (shapeDiam * yFac + (h1 / 2 + h2 / 2));
                    break;
            }
        }

        private void calculateNewClientCoordinates(double x, double y, out double cX, out double cY, int direction, IVisio.Shape shape)
        {
            double w1 = shape.CellsU["angle"].ResultIU == 0 ? shape.CellsU["width"].ResultIU : shape.CellsU["height"].ResultIU;
            //double h1 = shape.CellsU["angle"].ResultIU == 0 ? shape.CellsU["height"].ResultIU : shape.CellsU["width"].ResultIU;

            double shapeDiam = 0.15748;
            double xDif = 0.24;
            double yDif = 0.14;
            cY = y;
            cX = x;
            switch (direction)
            {
                case 0:
                    cY = y + (yDif);
                    cX = x + (xDif + (w1 - shapeDiam)/2);
                    break;
                case 1:
                    cY = y + (yDif);
                    cX = x - (xDif + (w1 - shapeDiam)/2);
                    break;
                case 2:
                    cY = y - (yDif);
                    cX = x - (xDif + (w1 - shapeDiam)/2);
                    break;
                case 3:
                    cY = y - (yDif);
                    cX = x + (xDif + (w1 - shapeDiam)/2);
                    break;
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string _folder = Directory.GetCurrentDirectory();
                string _fileName = "\\settings.txt";
                string fullPath = _folder + _fileName;
                using (StreamWriter writer = File.CreateText(fullPath))
                {
                    writer.WriteLine(fileName.Text);
                    writer.WriteLine(make.Text);
                    writer.WriteLine(chekedM.Text);
                    writer.WriteLine(mainLine.Text);
                    writer.WriteLine(clients.Text);
                    writer.WriteLine(ankers.Text);
                    writer.WriteLine(tpType.Text);
                    string lineTypeString = "";
                    foreach (DataGridViewRow row in lineType.Rows)
                        if (!row.IsNewRow)
                        {
                            lineTypeString += (row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString()) + "*";
                            lineTypeString += (row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString()) + "*";
                            lineTypeString += (row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString()) + ";";
                        }
                    writer.WriteLine(lineTypeString);

                    string routesString = "";
                    foreach (DataGridViewRow row in routes.Rows)
                        if (!row.IsNewRow)
                        {
                            routesString += (row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString()) + "*";
                            routesString += (row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString()) + ";";
                        }

                    writer.WriteLine(routesString);
                }
                LogTextEvent(System.Drawing.Color.Black, "Настройки успешно сохранены");
            }
            catch (Exception ex)
            {
                LogTextEvent(System.Drawing.Color.Red, "Ошибка сохранения настроек. " + ex.Message);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string _folder = Directory.GetCurrentDirectory();
                string _fileName = "\\settings.txt";
                string fullPath = _folder + _fileName;
                if (!File.Exists(fullPath))
                    throw new Exception("Не найден файл с настройками.");
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    fileName.Text = reader.ReadLine();
                    make.Text = reader.ReadLine();
                    chekedM.Text = reader.ReadLine();
                    mainLine.Text = reader.ReadLine();
                    clients.Text = reader.ReadLine();
                    ankers.Text = reader.ReadLine();
                    tpType.Text = reader.ReadLine();
                    lineType.Rows.Clear();
                    string lineTypeString = reader.ReadLine();
                    foreach (string lineTypeRow in lineTypeString.Split(';'))
                    {
                        if (lineTypeRow != "")
                        {
                            string[] lineTypeRowValues = lineTypeRow.Split('*');
                            lineType.Rows.Add(new string[] { lineTypeRowValues[0], lineTypeRowValues[1], lineTypeRowValues[2] });
                        }
                    }
                    routes.Rows.Clear();
                    string routesString = reader.ReadLine();
                    foreach (string routesRow in routesString.Split(';'))
                    {
                        if (routesRow != "")
                        {
                            string[] routesValues = routesRow.Split('*');
                            routes.Rows.Add(new string[] { routesValues[0], routesValues[1] });
                        }
                    }
                }
                LogTextEvent(System.Drawing.Color.Black, "Настройки успешно загружены");
            }
            catch (Exception ex)
            {
                LogTextEvent(System.Drawing.Color.Red, "Ошибка загрузки настроек. "+ex.Message);
            }
        }
    }
}
