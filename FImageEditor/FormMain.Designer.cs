
namespace FImageEditor
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.faceViewControl8 = new FImageEditor.FaceViewControl();
            this.faceViewControl7 = new FImageEditor.FaceViewControl();
            this.faceViewControl6 = new FImageEditor.FaceViewControl();
            this.faceViewControl5 = new FImageEditor.FaceViewControl();
            this.faceViewControl1 = new FImageEditor.FaceViewControl();
            this.faceViewControl2 = new FImageEditor.FaceViewControl();
            this.faceViewControl3 = new FImageEditor.FaceViewControl();
            this.faceViewControl4 = new FImageEditor.FaceViewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonGenerate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(3, 3);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.OnButtonGenerateClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Generate";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnMenuItemGenerateClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnButtonExitClick);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Enabled = false;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.faceViewControl4, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 397);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // faceViewControl8
            // 
            this.faceViewControl8.AllowDrop = true;
            this.faceViewControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl8.FaceImageEntry = null;
            this.faceViewControl8.Location = new System.Drawing.Point(3, 201);
            this.faceViewControl8.Name = "faceViewControl8";
            this.faceViewControl8.Size = new System.Drawing.Size(194, 193);
            this.faceViewControl8.TabIndex = 7;
            // 
            // faceViewControl7
            // 
            this.faceViewControl7.AllowDrop = true;
            this.faceViewControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl7.FaceImageEntry = null;
            this.faceViewControl7.Location = new System.Drawing.Point(203, 201);
            this.faceViewControl7.Name = "faceViewControl7";
            this.faceViewControl7.Size = new System.Drawing.Size(194, 193);
            this.faceViewControl7.TabIndex = 6;
            // 
            // faceViewControl6
            // 
            this.faceViewControl6.AllowDrop = true;
            this.faceViewControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl6.FaceImageEntry = null;
            this.faceViewControl6.Location = new System.Drawing.Point(403, 201);
            this.faceViewControl6.Name = "faceViewControl6";
            this.faceViewControl6.Size = new System.Drawing.Size(194, 193);
            this.faceViewControl6.TabIndex = 5;
            // 
            // faceViewControl5
            // 
            this.faceViewControl5.AllowDrop = true;
            this.faceViewControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl5.FaceImageEntry = null;
            this.faceViewControl5.Location = new System.Drawing.Point(603, 201);
            this.faceViewControl5.Name = "faceViewControl5";
            this.faceViewControl5.Size = new System.Drawing.Size(194, 193);
            this.faceViewControl5.TabIndex = 4;
            // 
            // faceViewControl1
            // 
            this.faceViewControl1.AllowDrop = true;
            this.faceViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl1.FaceImageEntry = null;
            this.faceViewControl1.Location = new System.Drawing.Point(3, 3);
            this.faceViewControl1.Name = "faceViewControl1";
            this.faceViewControl1.Size = new System.Drawing.Size(194, 192);
            this.faceViewControl1.TabIndex = 0;
            // 
            // faceViewControl2
            // 
            this.faceViewControl2.AllowDrop = true;
            this.faceViewControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl2.FaceImageEntry = null;
            this.faceViewControl2.Location = new System.Drawing.Point(203, 3);
            this.faceViewControl2.Name = "faceViewControl2";
            this.faceViewControl2.Size = new System.Drawing.Size(194, 192);
            this.faceViewControl2.TabIndex = 1;
            // 
            // faceViewControl3
            // 
            this.faceViewControl3.AllowDrop = true;
            this.faceViewControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl3.FaceImageEntry = null;
            this.faceViewControl3.Location = new System.Drawing.Point(403, 3);
            this.faceViewControl3.Name = "faceViewControl3";
            this.faceViewControl3.Size = new System.Drawing.Size(194, 192);
            this.faceViewControl3.TabIndex = 2;
            // 
            // faceViewControl4
            // 
            this.faceViewControl4.AllowDrop = true;
            this.faceViewControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceViewControl4.FaceImageEntry = null;
            this.faceViewControl4.Location = new System.Drawing.Point(603, 3);
            this.faceViewControl4.Name = "faceViewControl4";
            this.faceViewControl4.Size = new System.Drawing.Size(194, 192);
            this.faceViewControl4.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 397);
            this.panel1.TabIndex = 3;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private FaceViewControl faceViewControl1;
        private FaceViewControl faceViewControl2;
        private FaceViewControl faceViewControl8;
        private FaceViewControl faceViewControl7;
        private FaceViewControl faceViewControl6;
        private FaceViewControl faceViewControl5;
        private FaceViewControl faceViewControl3;
        private FaceViewControl faceViewControl4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

