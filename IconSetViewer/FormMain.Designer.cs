namespace IconSetViewer
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            IconSetViewer.IconSet iconSet2 = new IconSetViewer.IconSet();
            IconSetViewer.IconSet iconSet1 = new IconSetViewer.IconSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImageBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.buttonIconSave = new System.Windows.Forms.Button();
            this.buttonIconChange = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelScroll = new AutoScrollPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.iconSetViewControl = new IconSetViewer.IconSetViewControl();
            this.iconViewControl = new IconSetViewer.IconViewControl();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemOption});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuItemFile
            // 
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItemClose});
            this.menuItemFile.Name = "menuItemFile";
            // 
            // menuItemOpen
            // 
            resources.ApplyResources(this.menuItemOpen, "menuItemOpen");
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // menuItemSave
            // 
            resources.ApplyResources(this.menuItemSave, "menuItemSave");
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Click += new System.EventHandler(this.OnButtonSaveClick);
            // 
            // menuItemSaveAs
            // 
            resources.ApplyResources(this.menuItemSaveAs, "menuItemSaveAs");
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Click += new System.EventHandler(this.OnMenuItemSaveAsClick);
            // 
            // menuItemClose
            // 
            resources.ApplyResources(this.menuItemClose, "menuItemClose");
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Click += new System.EventHandler(this.OnExitMenuClick);
            // 
            // menuItemOption
            // 
            resources.ApplyResources(this.menuItemOption, "menuItemOption");
            this.menuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImageBackground});
            this.menuItemOption.Name = "menuItemOption";
            // 
            // menuItemImageBackground
            // 
            resources.ApplyResources(this.menuItemImageBackground, "menuItemImageBackground");
            this.menuItemImageBackground.Name = "menuItemImageBackground";
            this.menuItemImageBackground.Click += new System.EventHandler(this.OnMenuItemImageBackgroundClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "IconSet.png";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.buttonIconSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonIconChange);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.iconViewControl);
            this.panel2.Controls.Add(this.flowLayoutPanel3);
            this.panel2.Name = "panel2";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.comboBoxNumber);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxNumber
            // 
            resources.ApplyResources(this.comboBoxNumber, "comboBoxNumber");
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.SelectionChangeCommitted += new System.EventHandler(this.OnComboBoxNumberSelectionChangeCommitted);
            this.comboBoxNumber.TextUpdate += new System.EventHandler(this.OnComboBoxNumberTextUpdate);
            // 
            // buttonIconSave
            // 
            resources.ApplyResources(this.buttonIconSave, "buttonIconSave");
            this.buttonIconSave.Name = "buttonIconSave";
            this.buttonIconSave.UseVisualStyleBackColor = true;
            this.buttonIconSave.Click += new System.EventHandler(this.OnButtonIconSaveClick);
            // 
            // buttonIconChange
            // 
            resources.ApplyResources(this.buttonIconChange, "buttonIconChange");
            this.buttonIconChange.Name = "buttonIconChange";
            this.buttonIconChange.UseVisualStyleBackColor = true;
            this.buttonIconChange.Click += new System.EventHandler(this.OnButtonIconChangeClick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.panelScroll);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Name = "panel1";
            // 
            // panelScroll
            // 
            resources.ApplyResources(this.panelScroll, "panelScroll");
            this.panelScroll.BackColor = System.Drawing.Color.Black;
            this.panelScroll.Controls.Add(this.iconSetViewControl);
            this.panelScroll.Name = "panelScroll";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // iconSetViewControl
            // 
            resources.ApplyResources(this.iconSetViewControl, "iconSetViewControl");
            this.iconSetViewControl.BackColor = System.Drawing.Color.Transparent;
            this.iconSetViewControl.CorsorColor = System.Drawing.Color.Red;
            iconSet2.IconSize = new System.Drawing.Size(32, 32);
            iconSet2.Image = null;
            this.iconSetViewControl.IconSet = iconSet2;
            this.iconSetViewControl.Name = "iconSetViewControl";
            this.iconSetViewControl.SelectedIndex = -1;
            // 
            // iconViewControl
            // 
            resources.ApplyResources(this.iconViewControl, "iconViewControl");
            this.iconViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            iconSet1.IconSize = new System.Drawing.Size(32, 32);
            iconSet1.Image = null;
            this.iconViewControl.IconSet = iconSet1;
            this.iconViewControl.Name = "iconViewControl";
            this.iconViewControl.SelectedIndex = -1;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnFormDragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelScroll.ResumeLayout(false);
            this.panelScroll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNumber;
        private System.Windows.Forms.Panel panel1;
        private IconViewControl iconViewControl;
        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private IconSetViewControl iconSetViewControl;
        private System.Windows.Forms.ToolStripMenuItem menuItemOption;
        private System.Windows.Forms.ToolStripMenuItem menuItemImageBackground;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonIconSave;
        private System.Windows.Forms.Button buttonIconChange;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
    }
}

