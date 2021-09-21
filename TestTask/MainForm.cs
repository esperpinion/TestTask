using System.Windows.Forms;
using TestTask.Models;
using TestTask.Services;

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

                var fileRecords = FileReaderService.GetRecordsFromFile(openFileDialog.FileName);

                if (fileRecords != null)
                    TreePopulatorService.PopulateTree(tvContexts, fileRecords);
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

    }
}
