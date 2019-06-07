namespace CharaChipGenUtility.Operations
{
    partial class LineupOperationSettingControl
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
            this.controlSelectDirectory = new CharaChipGenUtility.Operations.SelectDirectoryControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlSelectDirectory
            // 
            this.controlSelectDirectory.Directory = "";
            this.controlSelectDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlSelectDirectory.Location = new System.Drawing.Point(0, 0);
            this.controlSelectDirectory.Name = "controlSelectDirectory";
            this.controlSelectDirectory.Padding = new System.Windows.Forms.Padding(8);
            this.controlSelectDirectory.SelectName = "出力フォルダ";
            this.controlSelectDirectory.Size = new System.Drawing.Size(404, 36);
            this.controlSelectDirectory.TabIndex = 0;
            this.controlSelectDirectory.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.OnControlSelectDirectoryPropertyChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxDirection);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "方向";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.comboBoxDirection.Location = new System.Drawing.Point(46, 11);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDirection.TabIndex = 1;
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxDirectionSelectedIndexChanged);
            // 
            // ControlLineupSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.controlSelectDirectory);
            this.Name = "ControlLineupSetting";
            this.Size = new System.Drawing.Size(404, 251);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectDirectoryControl controlSelectDirectory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDirection;
    }
}
