namespace CharaChipGenUtility.Operations
{
    partial class MonoColorOperationSettingControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.selectDirectoryControl = new CharaChipGenUtility.Operations.SelectDirectoryControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.buttonSelectColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectDirectoryControl
            // 
            this.selectDirectoryControl.Directory = "";
            this.selectDirectoryControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectDirectoryControl.Location = new System.Drawing.Point(0, 0);
            this.selectDirectoryControl.Name = "selectDirectoryControl";
            this.selectDirectoryControl.Padding = new System.Windows.Forms.Padding(8);
            this.selectDirectoryControl.SelectName = "出力フォルダ";
            this.selectDirectoryControl.Size = new System.Drawing.Size(358, 36);
            this.selectDirectoryControl.TabIndex = 0;
            this.selectDirectoryControl.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.OnControlPropertyChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxColor);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectColor);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(358, 45);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // textBoxColor
            // 
            this.textBoxColor.BackColor = System.Drawing.Color.Black;
            this.textBoxColor.ForeColor = System.Drawing.Color.White;
            this.textBoxColor.Location = new System.Drawing.Point(34, 11);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.ReadOnly = true;
            this.textBoxColor.Size = new System.Drawing.Size(100, 19);
            this.textBoxColor.TabIndex = 0;
            // 
            // buttonSelectColor
            // 
            this.buttonSelectColor.Location = new System.Drawing.Point(140, 11);
            this.buttonSelectColor.Name = "buttonSelectColor";
            this.buttonSelectColor.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectColor.TabIndex = 1;
            this.buttonSelectColor.Text = "選択";
            this.buttonSelectColor.UseVisualStyleBackColor = true;
            this.buttonSelectColor.Click += new System.EventHandler(this.OnSelectColorButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "色";
            // 
            // MonoColorOperationSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.selectDirectoryControl);
            this.Name = "MonoColorOperationSettingControl";
            this.Size = new System.Drawing.Size(358, 228);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectDirectoryControl selectDirectoryControl;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.Button buttonSelectColor;
        private System.Windows.Forms.Label label1;
    }
}
