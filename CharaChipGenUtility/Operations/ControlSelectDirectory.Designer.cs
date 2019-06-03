namespace CharaChipGenUtility.Operations
{
    partial class ControlSelectDirectory
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
            this.labelSelectName = new System.Windows.Forms.Label();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSelectName
            // 
            this.labelSelectName.AutoSize = true;
            this.labelSelectName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSelectName.Location = new System.Drawing.Point(8, 8);
            this.labelSelectName.Name = "labelSelectName";
            this.labelSelectName.Size = new System.Drawing.Size(40, 12);
            this.labelSelectName.TabIndex = 0;
            this.labelSelectName.Text = "フォルダ";
            // 
            // textBoxDirectory
            // 
            this.textBoxDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDirectory.Location = new System.Drawing.Point(48, 8);
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.Size = new System.Drawing.Size(193, 19);
            this.textBoxDirectory.TabIndex = 1;
            this.textBoxDirectory.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectDirectory.Location = new System.Drawing.Point(241, 8);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(53, 20);
            this.buttonSelectDirectory.TabIndex = 2;
            this.buttonSelectDirectory.Text = "選択";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.OnButtonSelectFolderClick);
            // 
            // ControlSelectDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxDirectory);
            this.Controls.Add(this.labelSelectName);
            this.Controls.Add(this.buttonSelectDirectory);
            this.Name = "ControlSelectDirectory";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(302, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSelectName;
        private System.Windows.Forms.TextBox textBoxDirectory;
        private System.Windows.Forms.Button buttonSelectDirectory;
    }
}
