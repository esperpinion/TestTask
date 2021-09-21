
namespace TestTask
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvContexts = new System.Windows.Forms.TreeView();
            this.tbTranslationList = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvContexts
            // 
            this.tvContexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContexts.Location = new System.Drawing.Point(0, 0);
            this.tvContexts.Name = "tvContexts";
            this.tvContexts.Size = new System.Drawing.Size(400, 359);
            this.tvContexts.TabIndex = 0;
            this.tvContexts.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvContexts_NodeMouseClick);
            // 
            // tbTranslationList
            // 
            this.tbTranslationList.BackColor = System.Drawing.SystemColors.Window;
            this.tbTranslationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTranslationList.Location = new System.Drawing.Point(0, 0);
            this.tbTranslationList.Multiline = true;
            this.tbTranslationList.Name = "tbTranslationList";
            this.tbTranslationList.ReadOnly = true;
            this.tbTranslationList.Size = new System.Drawing.Size(154, 359);
            this.tbTranslationList.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tvContexts);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbTranslationList);
            this.splitContainer.Size = new System.Drawing.Size(557, 359);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(12, 377);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(126, 30);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Открыть .po файл";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Файлы переводов|*.po";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 419);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Тестовое задание";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvContexts;
        private System.Windows.Forms.TextBox tbTranslationList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

