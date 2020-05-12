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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCharaSize = new System.Windows.Forms.Label();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLayerType = new System.Windows.Forms.ComboBox();
            this.comboBoxColorRefs = new System.Windows.Forms.ComboBox();
            this.checkBoxColorImmutable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.materialView4x3 = new CharaChipGen.MaterialEditorForm.LayerView3x4();
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
            this.groupBoxLayerName.Size = new System.Drawing.Size(323, 470);
            this.groupBoxLayerName.TabIndex = 0;
            this.groupBoxLayerName.TabStop = false;
            this.groupBoxLayerName.Text = "レイヤー";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 184);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCharaSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPictureSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLayerType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxColorRefs, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxColorImmutable, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFileName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(317, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOpen);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(221, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 50);
            this.flowLayoutPanel1.TabIndex = 2;
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "画像サイズ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "キャラクターサイズ";
            // 
            // labelCharaSize
            // 
            this.labelCharaSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCharaSize.AutoSize = true;
            this.labelCharaSize.Location = new System.Drawing.Point(95, 69);
            this.labelCharaSize.Name = "labelCharaSize";
            this.labelCharaSize.Size = new System.Drawing.Size(65, 12);
            this.labelCharaSize.TabIndex = 4;
            this.labelCharaSize.Text = "0 x 0 pixels";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(95, 39);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(65, 12);
            this.labelPictureSize.TabIndex = 1;
            this.labelPictureSize.Text = "0 x 0 pixels";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "描画レイヤー";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "色パラメータ参照";
            // 
            // comboBoxLayerType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxLayerType, 2);
            this.comboBoxLayerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerType.FormattingEnabled = true;
            this.comboBoxLayerType.Location = new System.Drawing.Point(95, 93);
            this.comboBoxLayerType.Name = "comboBoxLayerType";
            this.comboBoxLayerType.Size = new System.Drawing.Size(219, 20);
            this.comboBoxLayerType.TabIndex = 6;
            this.comboBoxLayerType.SelectedValueChanged += new System.EventHandler(this.OnComboBoxLayerTypeSelectedValueChanged);
            // 
            // comboBoxColorRefs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxColorRefs, 2);
            this.comboBoxColorRefs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxColorRefs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorRefs.FormattingEnabled = true;
            this.comboBoxColorRefs.Location = new System.Drawing.Point(95, 123);
            this.comboBoxColorRefs.Name = "comboBoxColorRefs";
            this.comboBoxColorRefs.Size = new System.Drawing.Size(219, 20);
            this.comboBoxColorRefs.TabIndex = 8;
            this.comboBoxColorRefs.SelectedValueChanged += new System.EventHandler(this.OnComboBoxColorRefsSelectedValueChanged);
            // 
            // checkBoxColorImmutable
            // 
            this.checkBoxColorImmutable.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxColorImmutable, 2);
            this.checkBoxColorImmutable.Location = new System.Drawing.Point(95, 153);
            this.checkBoxColorImmutable.Name = "checkBoxColorImmutable";
            this.checkBoxColorImmutable.Size = new System.Drawing.Size(155, 16);
            this.checkBoxColorImmutable.TabIndex = 9;
            this.checkBoxColorImmutable.Text = "このレイヤーは色変換しない";
            this.checkBoxColorImmutable.UseVisualStyleBackColor = true;
            this.checkBoxColorImmutable.CheckedChanged += new System.EventHandler(this.OnCheckBoxColorImmutableCheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "ファイル";
            // 
            // labelFileName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelFileName, 2);
            this.labelFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFileName.Location = new System.Drawing.Point(95, 0);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(219, 30);
            this.labelFileName.TabIndex = 11;
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル|*.png";
            this.openFileDialog.Title = "開く";
            // 
            // materialView4x3
            // 
            this.materialView4x3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialView4x3.Image = null;
            this.materialView4x3.ImageBackground = System.Drawing.SystemColors.Control;
            this.materialView4x3.Location = new System.Drawing.Point(3, 199);
            this.materialView4x3.Name = "materialView4x3";
            this.materialView4x3.Size = new System.Drawing.Size(317, 268);
            this.materialView4x3.TabIndex = 1;
            // 
            // MaterialEditorLayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLayerName);
            this.Name = "MaterialEditorLayerView";
            this.Size = new System.Drawing.Size(323, 470);
            this.groupBoxLayerName.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLayerName;
        private LayerView3x4 materialView4x3;
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
        private System.Windows.Forms.CheckBox checkBoxColorImmutable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFileName;
    }
}
