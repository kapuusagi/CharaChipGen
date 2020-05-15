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
            IconSetViewer.IconSet iconSet2 = new IconSetViewer.IconSet();
            IconSetViewer.IconSet iconSet1 = new IconSetViewer.IconSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImageBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonIconSave = new System.Windows.Forms.Button();
            this.buttonIconChange = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSetViewControl = new IconSetViewer.IconSetViewControl();
            this.iconViewControl = new IconSetViewer.IconViewControl();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItemClose});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(53, 20);
            this.menuItemFile.Text = "ファイル";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.menuItemOpen.Text = "開く";
            this.menuItemOpen.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(180, 22);
            this.menuItemClose.Text = "終了";
            this.menuItemClose.Click += new System.EventHandler(this.OnExitMenuClick);
            // 
            // menuItemOption
            // 
            this.menuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImageBackground});
            this.menuItemOption.Name = "menuItemOption";
            this.menuItemOption.Size = new System.Drawing.Size(63, 20);
            this.menuItemOption.Text = "オプション";
            // 
            // menuItemImageBackground
            // 
            this.menuItemImageBackground.Name = "menuItemImageBackground";
            this.menuItemImageBackground.Size = new System.Drawing.Size(134, 22);
            this.menuItemImageBackground.Text = "表示背景色";
            this.menuItemImageBackground.Click += new System.EventHandler(this.OnMenuItemImageBackgroundClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "IconSet.png";
            this.openFileDialog.Filter = "アイコンセット|*.png";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.buttonIconSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonIconChange);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(434, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 401);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iconViewControl);
            this.panel2.Controls.Add(this.flowLayoutPanel3);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 81);
            this.panel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.comboBoxNumber);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(80, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(66, 81);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "番号";
            // 
            // comboBoxNumber
            // 
            this.comboBoxNumber.Enabled = false;
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Location = new System.Drawing.Point(3, 15);
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.Size = new System.Drawing.Size(60, 20);
            this.comboBoxNumber.TabIndex = 0;
            this.comboBoxNumber.SelectionChangeCommitted += new System.EventHandler(this.OnComboBoxNumberSelectionChangeCommitted);
            this.comboBoxNumber.TextUpdate += new System.EventHandler(this.OnComboBoxNumberTextUpdate);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelScroll);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(434, 401);
            this.panel1.TabIndex = 2;
            // 
            // panelScroll
            // 
            this.panelScroll.AutoScroll = true;
            this.panelScroll.BackColor = System.Drawing.Color.Black;
            this.panelScroll.Controls.Add(this.iconSetViewControl);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Location = new System.Drawing.Point(8, 8);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Padding = new System.Windows.Forms.Padding(8);
            this.panelScroll.Size = new System.Drawing.Size(410, 385);
            this.panelScroll.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(418, 8);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(8, 385);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // buttonIconSave
            // 
            this.buttonIconSave.Enabled = false;
            this.buttonIconSave.Location = new System.Drawing.Point(3, 90);
            this.buttonIconSave.Name = "buttonIconSave";
            this.buttonIconSave.Size = new System.Drawing.Size(137, 23);
            this.buttonIconSave.TabIndex = 3;
            this.buttonIconSave.Text = "アイコンを保存";
            this.buttonIconSave.UseVisualStyleBackColor = true;
            this.buttonIconSave.Click += new System.EventHandler(this.OnButtonIconSaveClick);
            // 
            // buttonIconChange
            // 
            this.buttonIconChange.Enabled = false;
            this.buttonIconChange.Location = new System.Drawing.Point(3, 119);
            this.buttonIconChange.Name = "buttonIconChange";
            this.buttonIconChange.Size = new System.Drawing.Size(137, 23);
            this.buttonIconChange.TabIndex = 4;
            this.buttonIconChange.Text = "アイコンを入れ替え";
            this.buttonIconChange.UseVisualStyleBackColor = true;
            this.buttonIconChange.Click += new System.EventHandler(this.OnButtonIconChangeClick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*";
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Enabled = false;
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAs.Text = "名前をつけて保存";
            this.menuItemSaveAs.Click += new System.EventHandler(this.OnMenuItemSaveAsClick);
            // 
            // iconSetViewControl
            // 
            this.iconSetViewControl.AutoSize = true;
            this.iconSetViewControl.BackColor = System.Drawing.Color.Transparent;
            this.iconSetViewControl.CorsorColor = System.Drawing.Color.Red;
            iconSet2.IconSize = new System.Drawing.Size(32, 32);
            iconSet2.Image = null;
            this.iconSetViewControl.IconSet = iconSet2;
            this.iconSetViewControl.Location = new System.Drawing.Point(1, 1);
            this.iconSetViewControl.Name = "iconSetViewControl";
            this.iconSetViewControl.SelectedIndex = -1;
            this.iconSetViewControl.Size = new System.Drawing.Size(393, 343);
            this.iconSetViewControl.TabIndex = 0;
            // 
            // iconViewControl
            // 
            this.iconViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            iconSet1.IconSize = new System.Drawing.Size(32, 32);
            iconSet1.Image = null;
            this.iconViewControl.IconSet = iconSet1;
            this.iconViewControl.Location = new System.Drawing.Point(3, 3);
            this.iconViewControl.Name = "iconViewControl";
            this.iconViewControl.SelectedIndex = -1;
            this.iconViewControl.Size = new System.Drawing.Size(72, 72);
            this.iconViewControl.TabIndex = 0;
            // 
            // menuItemSave
            // 
            this.menuItemSave.Enabled = false;
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(180, 22);
            this.menuItemSave.Text = "保存";
            this.menuItemSave.Click += new System.EventHandler(this.OnButtonSaveClick);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "アイコンセットビュー";
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

