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
            this.materialView4x3 = new CharaChipGen.MaterialEditorForm.MaterialView3x4();
            this.labelCharaSize = new System.Windows.Forms.Label();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLayerName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLayerName
            // 
            this.groupBoxLayerName.Controls.Add(this.materialView4x3);
            this.groupBoxLayerName.Controls.Add(this.panel1);
            this.groupBoxLayerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLayerName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLayerName.Name = "groupBoxLayerName";
            this.groupBoxLayerName.Size = new System.Drawing.Size(435, 608);
            this.groupBoxLayerName.TabIndex = 0;
            this.groupBoxLayerName.TabStop = false;
            this.groupBoxLayerName.Text = "レイヤー";
            this.groupBoxLayerName.Resize += new System.EventHandler(this.OnControlResized);
            // 
            // materialView4x3
            // 
            this.materialView4x3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialView4x3.Image = null;
            this.materialView4x3.Location = new System.Drawing.Point(3, 87);
            this.materialView4x3.Name = "materialView4x3";
            this.materialView4x3.Size = new System.Drawing.Size(429, 518);
            this.materialView4x3.TabIndex = 5;
            // 
            // labelCharaSize
            // 
            this.labelCharaSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCharaSize.AutoSize = true;
            this.labelCharaSize.Location = new System.Drawing.Point(95, 44);
            this.labelCharaSize.Name = "labelCharaSize";
            this.labelCharaSize.Size = new System.Drawing.Size(65, 12);
            this.labelCharaSize.TabIndex = 4;
            this.labelCharaSize.Text = "0 x 0 pixels";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(95, 10);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(65, 12);
            this.labelPictureSize.TabIndex = 4;
            this.labelPictureSize.Text = "0 x 0 pixels";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "キャラクターサイズ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "画像サイズ";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(9, 9);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "開く";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.OnOpenButtonClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル|*.png";
            this.openFileDialog.Title = "開く";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 72);
            this.panel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOpen);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 72);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCharaSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelPictureSize, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 67);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // MaterialEditorLayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLayerName);
            this.Name = "MaterialEditorLayerView";
            this.Size = new System.Drawing.Size(435, 608);
            this.groupBoxLayerName.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
