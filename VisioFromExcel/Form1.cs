using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            }
            public Connection Parent { get; }
            public String Name { get; set; }
            public int clients { get; set; }
            public List<Connection> Children { get; set; }
            public bool IsRoot => Parent == null;
            public bool IsLeaf => Children.Count == 0;

            public bool AddChild(string _name, Connection _newChild)
            {
                Console.WriteLine(Name);
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
        Dictionary<string, int> _routes;
        int maxNodes;

        public Form1()
        {
            InitializeComponent();
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
                    fileName.Text = aFileName;
                    LogTextEvent(Color.Black, "Добавлен файл " + file);
                }
                else
                    LogTextEvent(Color.Red, "Расширение файла должно быть KLM: " + file);
            }
        }

        public void LogTextEvent(Color TextColor, string EventText)
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

        private void Run_Click(object sender, EventArgs e)
        {
            _routes = new Dictionary<string, int>();

            foreach (DataGridViewRow row in routes.Rows)
                if (row.Cells[0].Value != null & row.Cells[1].Value != null)
                    _routes.Add(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));

            mainNode = new Connection("root");
            generageTree("root", 0, Convert.ToInt32(mainLine.Text));

            Connection rootNode = new Connection("root");
            string parentName = "root";
            Connection newCon;
            ref Connection currentCon = ref rootNode;
            int nodeReservedCount = Convert.ToInt32(mainLine.Text);
            for (int i = 1; i <= Convert.ToInt32(mainLine.Text); i++)
            {
                string newNodeName = i.ToString();
                newCon = new Connection(newNodeName);                
                rootNode.AddChild(parentName, newCon);
                parentName = newNodeName;
                if (_routes.TryGetValue(parentName, out int childCount))
                {
                    string innerParentName = parentName;
                    for (int j = 1; j <= childCount; j++)
                    {
                        string innerNodeName = (nodeReservedCount + j).ToString();
                        newCon = new Connection(innerNodeName);
                        rootNode.AddChild(innerParentName, newCon);
                        innerParentName = innerNodeName;
                    }
                    nodeReservedCount = nodeReservedCount + childCount;
                }
            }
        }
        private void generageTree( string parentName, int nodeReservedCount, int depth)
        {
            maxNodes = maxNodes + depth;
            for (int i = 1; i <= depth; i++)
            {
                string innerNodeName = (nodeReservedCount + i).ToString();
                Connection newCon = new Connection(innerNodeName);
                mainNode.AddChild(parentName, newCon);
                parentName = innerNodeName;
                if (_routes.TryGetValue(innerNodeName, out int aDepth))
                {
                    generageTree(innerNodeName, maxNodes, aDepth);
                }
            }            
        }
        private void generateVisio(Connection treeNode)
        {
            
        }
    }
}
