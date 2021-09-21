using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestTask.Models;

namespace TestTask.Services
{
    public static class TreePopulatorService
    {
        /// <summary>
        /// Наполняем нативное дерево для TreeView и кастомное дерево с переводами
        /// </summary>
        /// <param name="records"></param>
        public static void PopulateTree(TreeView treeView, List<FileRecord> records)
        {
            var rootNode = new TranslationNode("(root)");
            var rootTvNode = new TreeNode(rootNode.Name);
            rootTvNode.Tag = rootNode;

            treeView.Nodes.Add(rootTvNode);

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
