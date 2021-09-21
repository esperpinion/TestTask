using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TestTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                tvContexts.Nodes.Clear();

                var fileRecords = GetRecordsFromFile(openFileDialog.FileName);

                if (fileRecords != null)
                    PopulateTree(fileRecords);
            }

        }

        private void tvContexts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tbTranslationList.Text = string.Empty;

            if (e.Node.Tag != null)
            {
                TranslationNode tNode = (TranslationNode)e.Node.Tag;
                foreach (var translation in tNode.Translations)
                {
                    tbTranslationList.Text += translation.Key + "\r\n";
                }
            }
        }

        public List<FileRecord> GetRecordsFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var fileRecords = new List<FileRecord>();

            FileRecord fileRecord = new FileRecord();
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.IndexOf(' ') < 0)
                    {
                        MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return fileRecords;
                    }

                    string command = line.Substring(0, line.IndexOf(' '));
                    string record = line.Substring(line.IndexOf(' ') + 1).Trim('"');

                    switch (command)
                    {
                        case "msgctxt":
                            fileRecord.Context = record;
                            break;
                        case "msgid":
                            fileRecord.Id = record;
                            break;
                        case "msgstr":
                            fileRecord.Text = record;
                            break;
                        default:
                            MessageBox.Show(
                                $"В строке {Array.IndexOf(lines, line)} найдена неизвестная команда {command}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                            break;
                    }
                }
                else
                {
                    //пустая строка - разделитель записей
                    if (fileRecord.Id != null)
                    {
                        fileRecords.Add(fileRecord);
                        fileRecord = new FileRecord();
                    }
                }
            }

            if (fileRecord.Id != null) //последняя запись
            {
                fileRecords.Add(fileRecord);
            }

            return fileRecords;
        }

        /// <summary>
        /// Наполняем нативное дерево для TreeView и кастомное дерево с переводами
        /// </summary>
        /// <param name="records"></param>
        public void PopulateTree(List<FileRecord> records)
        {
            var rootNode = new TranslationNode("(root)");
            var rootTvNode = new TreeNode(rootNode.Name);
            rootTvNode.Tag = rootNode;

            tvContexts.Nodes.Add(rootTvNode);

            foreach (var record in records)
            {
                if (string.IsNullOrWhiteSpace(record.Context)) //запись без контекста идет в корневой элемент
                {
                    rootNode.AddTranslation(record.Id, record.Text);
                }
                else
                {
                    var currentNode = rootNode;
                    var currentTvNode = rootTvNode;

                    var treePath = record.Context.Split('.');
                    foreach (string nodeName in treePath)
                    {
                        var childNode = currentNode.GetChild(nodeName);
                        if (childNode != null)
                        {
                            //Linq т.к. нативный только через Name экземпляра
                            currentTvNode = currentTvNode.Nodes
                                .Cast<TreeNode>()
                                .FirstOrDefault(n => n.Text == nodeName);
                            currentNode = childNode;
                        }
                        else
                        {
                            childNode = new TranslationNode(nodeName);
                            var childTvNode = new TreeNode(nodeName);
                            childTvNode.Tag = childNode;

                            currentTvNode?.Nodes.Add(childTvNode);
                            currentNode.AddChild(childNode);

                            currentTvNode = childTvNode;
                            currentNode = childNode;
                        }
                    }
                    currentNode.AddTranslation(record.Id, record.Text);
                }
            }
        }
    }
}
