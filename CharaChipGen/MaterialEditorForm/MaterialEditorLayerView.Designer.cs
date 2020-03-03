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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCharaSize = new System.Windows.Forms.Label();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLayerType = new System.Windows.Forms.ComboBox();
            this.comboBoxColorRefs = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxLayerName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLayerName
            // 
            this.groupBoxLayerName.Controls.Add(this.materialView4x3);
            this.groupBoxLayerName.Controls.Add(this.panel1);
            this.groupBoxLayerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLayerName.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLayerName.Name = "groupBoxLayerName";
            this.groupBoxLayerName.Size = new System.Drawing.Size(435, 470);
            this.groupBoxLayerName.TabIndex = 0;
            this.groupBoxLayerName.TabStop = false;
            this.groupBoxLayerName.Text = "レイヤー";
            // 
            // materialView4x3
            // 
            this.materialView4x3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialView4x3.Image = null;
            this.materialView4x3.Location = new System.Drawing.Point(3, 159);
            this.materialView4x3.Name = "materialView4x3";
            this.materialView4x3.Size = new System.Drawing.Size(429, 308);
            this.materialView4x3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 144);
            this.panel1.TabIndex = 6;
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLayerType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxColorRefs, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 144);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "画像サイズ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "キャラクターサイズ";
            // 
            // labelCharaSize
            // 
            this.labelCharaSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCharaSize.AutoSize = true;
            this.labelCharaSize.Location = new System.Drawing.Point(95, 48);
            this.labelCharaSize.Name = "labelCharaSize";
            this.labelCharaSize.Size = new System.Drawing.Size(65, 12);
            this.labelCharaSize.TabIndex = 4;
            this.labelCharaSize.Text = "0 x 0 pixels";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(95, 12);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(65, 12);
            this.labelPictureSize.TabIndex = 4;
            this.labelPictureSize.Text = "0 x 0 pixels";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "描画レイヤー";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "色パラメータ参照";
            // 
            // comboBoxLayerType
            // 
            this.comboBoxLayerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerType.FormattingEnabled = true;
            this.comboBoxLayerType.Location = new System.Drawing.Point(95, 75);
            this.comboBoxLayerType.Name = "comboBoxLayerType";
            this.comboBoxLayerType.Size = new System.Drawing.Size(238, 20);
            this.comboBoxLayerType.TabIndex = 7;
            this.comboBoxLayerType.SelectedValueChanged += new System.EventHandler(this.OnComboBoxLayerTypeSelectedValueChanged);
            // 
            // comboBoxColorRefs
            // 
            this.comboBoxColorRefs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxColorRefs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorRefs.FormattingEnabled = true;
            this.comboBoxColorRefs.Location = new System.Drawing.Point(95, 111);
            this.comboBoxColorRefs.Name = "comboBoxColorRefs";
            this.comboBoxColorRefs.Size = new System.Drawing.Size(238, 20);
            this.comboBoxColorRefs.TabIndex = 8;
            this.comboBoxColorRefs.SelectedValueChanged += new System.EventHandler(this.OnComboBoxColorRefsSelectedValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOpen);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(336, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 144);
            this.flowLayoutPanel1.TabIndex = 0;
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
            // MaterialEditorLayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLayerName);
            this.Name = "MaterialEditorLayerView";
            this.Size = new System.Drawing.Size(435, 470);
            this.groupBoxLayerName.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLayerType;
        private System.Windows.Forms.ComboBox comboBoxColorRefs;
    }
}
