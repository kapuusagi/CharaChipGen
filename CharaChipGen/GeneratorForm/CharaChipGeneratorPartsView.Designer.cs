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
            this.labelItemName = new System.Windows.Forms.Label();
            this.comboBoxItem = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdjust = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelItemName
            // 
            this.labelItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelItemName.Location = new System.Drawing.Point(7, 4);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(100, 29);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "項目名";
            this.labelItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(113, 7);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(121, 20);
            this.comboBoxItem.TabIndex = 1;
            this.comboBoxItem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnComboBoxDrawItem);
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.OnMaterialNameChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelItemName);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxItem);
            this.flowLayoutPanel1.Controls.Add(this.buttonAdjust);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonAdjust
            // 
            this.buttonAdjust.Location = new System.Drawing.Point(240, 7);
            this.buttonAdjust.Name = "buttonAdjust";
            this.buttonAdjust.Size = new System.Drawing.Size(75, 23);
            this.buttonAdjust.TabIndex = 2;
            this.buttonAdjust.Text = "調整";
            this.buttonAdjust.UseVisualStyleBackColor = true;
            this.buttonAdjust.Click += new System.EventHandler(this.OnButtonAdjustClick);
            // 
            // CharaChipGeneratorPartsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CharaChipGeneratorPartsView";
            this.Size = new System.Drawing.Size(356, 36);
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
