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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEditorLayerView));
            this.groupBoxLayerName = new System.Windows.Forms.GroupBox();
            this.materialView4x3 = new CharaChipGen.MaterialEditorForm.LayerView3x4();
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
            this.label5 = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.comboBoxColorProperty = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxColorImmutable = new System.Windows.Forms.CheckBox();
            this.checkBoxColoring = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxLayerName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLayerName
            // 
            this.groupBoxLayerName.Controls.Add(this.materialView4x3);
            this.groupBoxLayerName.Controls.Add(this.panel1);
            resources.ApplyResources(this.groupBoxLayerName, "groupBoxLayerName");
            this.groupBoxLayerName.Name = "groupBoxLayerName";
            this.groupBoxLayerName.TabStop = false;
            // 
            // materialView4x3
            // 
            resources.ApplyResources(this.materialView4x3, "materialView4x3");
            this.materialView4x3.Image = null;
            this.materialView4x3.ImageBackground = System.Drawing.SystemColors.Control;
            this.materialView4x3.Name = "materialView4x3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCharaSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPictureSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLayerType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxColorRefs, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxColorProperty, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonOpen);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.OnOpenButtonClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labelCharaSize
            // 
            resources.ApplyResources(this.labelCharaSize, "labelCharaSize");
            this.labelCharaSize.Name = "labelCharaSize";
            // 
            // labelPictureSize
            // 
            resources.ApplyResources(this.labelPictureSize, "labelPictureSize");
            this.labelPictureSize.Name = "labelPictureSize";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxLayerType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxLayerType, 2);
            resources.ApplyResources(this.comboBoxLayerType, "comboBoxLayerType");
            this.comboBoxLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayerType.FormattingEnabled = true;
            this.comboBoxLayerType.Name = "comboBoxLayerType";
            this.comboBoxLayerType.SelectedValueChanged += new System.EventHandler(this.OnComboBoxLayerTypeSelectedValueChanged);
            // 
            // comboBoxColorRefs
            // 
            resources.ApplyResources(this.comboBoxColorRefs, "comboBoxColorRefs");
            this.comboBoxColorRefs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorRefs.FormattingEnabled = true;
            this.comboBoxColorRefs.Name = "comboBoxColorRefs";
            this.comboBoxColorRefs.SelectedValueChanged += new System.EventHandler(this.OnComboBoxColorRefsSelectedValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // labelFileName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelFileName, 2);
            resources.ApplyResources(this.labelFileName, "labelFileName");
            this.labelFileName.Name = "labelFileName";
            // 
            // comboBoxColorProperty
            // 
            this.comboBoxColorProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorProperty.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxColorProperty, "comboBoxColorProperty");
            this.comboBoxColorProperty.Name = "comboBoxColorProperty";
            this.comboBoxColorProperty.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxColorPropertySelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxColorImmutable);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxColoring);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // checkBoxColorImmutable
            // 
            resources.ApplyResources(this.checkBoxColorImmutable, "checkBoxColorImmutable");
            this.checkBoxColorImmutable.Name = "checkBoxColorImmutable";
            this.checkBoxColorImmutable.UseVisualStyleBackColor = true;
            this.checkBoxColorImmutable.CheckedChanged += new System.EventHandler(this.OnCheckBoxColorImmutableCheckedChanged);
            // 
            // checkBoxColoring
            // 
            resources.ApplyResources(this.checkBoxColoring, "checkBoxColoring");
            this.checkBoxColoring.Name = "checkBoxColoring";
            this.checkBoxColoring.UseVisualStyleBackColor = true;
            this.checkBoxColoring.CheckedChanged += new System.EventHandler(this.OnCheckBoxColoringCheckedChanged);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // MaterialEditorLayerView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLayerName);
            this.Name = "MaterialEditorLayerView";
            this.groupBoxLayerName.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxColorProperty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxColoring;
    }
}
