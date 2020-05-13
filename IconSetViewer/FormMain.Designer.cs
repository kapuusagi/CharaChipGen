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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImageBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSetViewControl = new IconSetViewer.IconSetViewControl();
            this.iconViewControl = new IconSetViewer.IconViewControl();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelScroll.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.menuItemOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.OnExitMenuClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "IconSet.png";
            this.openFileDialog.Filter = "アイコンセット|*.png";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxNumber);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(618, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(66, 401);
            this.flowLayoutPanel1.TabIndex = 1;
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
            this.panel1.Size = new System.Drawing.Size(618, 401);
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
            this.panelScroll.Size = new System.Drawing.Size(516, 385);
            this.panelScroll.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.iconViewControl);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(524, 8);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(86, 385);
            this.flowLayoutPanel2.TabIndex = 2;
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
            // iconSetViewControl
            // 
            this.iconSetViewControl.BackColor = System.Drawing.Color.Transparent;
            this.iconSetViewControl.CorsorColor = System.Drawing.Color.Red;
            this.iconSetViewControl.Location = new System.Drawing.Point(1, 1);
            this.iconSetViewControl.Name = "iconSetViewControl";
            this.iconSetViewControl.SelectedIndex = 0;
            this.iconSetViewControl.Size = new System.Drawing.Size(393, 343);
            this.iconSetViewControl.TabIndex = 0;
            // 
            // iconViewControl
            // 
            this.iconViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconViewControl.Location = new System.Drawing.Point(7, 7);
            this.iconViewControl.Name = "iconViewControl";
            this.iconViewControl.SelectedIndex = 0;
            this.iconViewControl.Size = new System.Drawing.Size(72, 72);
            this.iconViewControl.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 425);
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
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelScroll.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
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
    }
}

