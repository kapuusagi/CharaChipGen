namespace CharaChipGen.GeneratorForm
{
    partial class CharaChipGeneratorPartsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharaChipGeneratorPartsView));
            this.labelItemName = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdjust = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelItemName
            // 
            resources.ApplyResources(this.labelItemName, "labelItemName");
            this.labelItemName.Name = "labelItemName";
            // 
            // comboBoxItem
            // 
            resources.ApplyResources(this.comboBoxItem, "comboBoxItem");
            this.comboBoxItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnComboBoxDrawItem);
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.OnMaterialNameChanged);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.labelItemName);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxItem);
            this.flowLayoutPanel1.Controls.Add(this.buttonAdjust);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonAdjust
            // 
            resources.ApplyResources(this.buttonAdjust, "buttonAdjust");
            this.buttonAdjust.Name = "buttonAdjust";
            this.buttonAdjust.UseVisualStyleBackColor = true;
            this.buttonAdjust.Click += new System.EventHandler(this.OnButtonAdjustClick);
            // 
            // CharaChipGeneratorPartsView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CharaChipGeneratorPartsView";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAdjust;
    }
}
