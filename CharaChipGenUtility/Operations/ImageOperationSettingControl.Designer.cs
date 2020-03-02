namespace CharaChipGenUtility.Operations
{
    partial class ImageOperationSettingControl
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
            this.SuspendLayout();
            // 
            // selectDirectoryControl
            // 
            this.selectDirectoryControl.Directory = "";
            this.selectDirectoryControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectDirectoryControl.Location = new System.Drawing.Point(0, 0);
            this.selectDirectoryControl.Name = "selectDirectoryControl";
            this.selectDirectoryControl.Padding = new System.Windows.Forms.Padding(8);
            this.selectDirectoryControl.SelectName = "フォルダ";
            this.selectDirectoryControl.Size = new System.Drawing.Size(247, 36);
            this.selectDirectoryControl.TabIndex = 0;
            this.selectDirectoryControl.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.OnSelectDirectoryControlPropertyChanged);
            // 
            // ImageOperationSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectDirectoryControl);
            this.Name = "ImageOperationSettingControl";
            this.Size = new System.Drawing.Size(247, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private Operations.SelectDirectoryControl selectDirectoryControl;
    }
}
