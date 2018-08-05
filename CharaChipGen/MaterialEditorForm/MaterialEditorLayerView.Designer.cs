namespace CharaChipGen.MaterialEditorForm
{
    partial class MaterialEditorLayerView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.groupBoxLayerName = new System.Windows.Forms.GroupBox();
            this.labelCharaSize = new System.Windows.Forms.Label();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.materialView4x3 = new CharaChipGen.MaterialEditorForm.MaterialView3x4();
            this.groupBoxLayerName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLayerName
            // 
            this.groupBoxLayerName.Controls.Add(this.materialView4x3);
            this.groupBoxLayerName.Controls.Add(this.labelCharaSize);
            this.groupBoxLayerName.Controls.Add(this.labelPictureSize);
            this.groupBoxLayerName.Controls.Add(this.label4);
            this.groupBoxLayerName.Controls.Add(this.label3);
            this.groupBoxLayerName.Controls.Add(this.buttonOpen);
            this.groupBoxLayerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLayerName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLayerName.Name = "groupBoxLayerName";
            this.groupBoxLayerName.Size = new System.Drawing.Size(559, 608);
            this.groupBoxLayerName.TabIndex = 0;
            this.groupBoxLayerName.TabStop = false;
            this.groupBoxLayerName.Text = "レイヤー";
            this.groupBoxLayerName.Resize += new System.EventHandler(this.OnControl_resized);
            // 
            // labelCharaSize
            // 
            this.labelCharaSize.AutoSize = true;
            this.labelCharaSize.Location = new System.Drawing.Point(125, 43);
            this.labelCharaSize.Name = "labelCharaSize";
            this.labelCharaSize.Size = new System.Drawing.Size(65, 12);
            this.labelCharaSize.TabIndex = 4;
            this.labelCharaSize.Text = "0 x 0 pixels";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(125, 18);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(65, 12);
            this.labelPictureSize.TabIndex = 4;
            this.labelPictureSize.Text = "0 x 0 pixels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "キャラクターサイズ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "画像サイズ";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(469, 18);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "開く";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.OnOpenButton_clicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル|*.png";
            this.openFileDialog.Title = "開く";
            // 
            // materialView4x3
            // 
            this.materialView4x3.Image = null;
            this.materialView4x3.Location = new System.Drawing.Point(11, 68);
            this.materialView4x3.Name = "materialView4x3";
            this.materialView4x3.Size = new System.Drawing.Size(533, 494);
            this.materialView4x3.TabIndex = 5;
            // 
            // MaterialEditorLayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLayerName);
            this.Name = "MaterialEditorLayerView";
            this.Size = new System.Drawing.Size(559, 608);
            this.groupBoxLayerName.ResumeLayout(false);
            this.groupBoxLayerName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLayerName;
        private MaterialView3x4 materialView4x3;
        private System.Windows.Forms.Label labelCharaSize;
        private System.Windows.Forms.Label labelPictureSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
