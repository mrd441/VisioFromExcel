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
                    string fileName = file;
                    string filePath = "";
                    int slashPos = file.LastIndexOf('\\');
                    if (slashPos != -1)
                    {
                        fileName = file.Substring(slashPos + 1, file.Length - slashPos - 1);
                        filePath = file.Substring(0, slashPos);
                    }
                    fileListElement fle = new fileListElement();
                    fle.fileName = fileName;
                    fle.filePath = filePath;
                    if (!fileList.Contains(fle))
                    {
                        fileList.Add(fle);
                        LogTextEvent(Color.Black, "Добавлен файл " + file);
                    }
                    else
                        LogTextEvent(Color.Red, "Файл с таким название уже добавлен: " + file);
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
    }
}
