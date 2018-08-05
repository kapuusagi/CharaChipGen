namespace CharaChipGen.GeneratorForm
{
    partial class CharaChipGeneratorParamView
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
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.numericUpDownSaturation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            this.SuspendLayout();
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.Location = new System.Drawing.Point(3, 12);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(41, 12);
            this.labelItemName.TabIndex = 0;
            this.labelItemName.Text = "項目名";
            // 
            // comboBoxItem
            // 
            this.comboBoxItem.FormattingEnabled = true;
            this.comboBoxItem.Location = new System.Drawing.Point(101, 9);
            this.comboBoxItem.Name = "comboBoxItem";
            this.comboBoxItem.Size = new System.Drawing.Size(121, 20);
            this.comboBoxItem.TabIndex = 1;
            this.comboBoxItem.SelectedIndexChanged += new System.EventHandler(this.OnMaterialName_changed);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(228, 9);
            this.numericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(44, 19);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.OnOffset_changed);
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(279, 0);
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Minimum = -180;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(106, 45);
            this.trackBarHue.TabIndex = 3;
            this.trackBarHue.ValueChanged += new System.EventHandler(this.OnHue_changed);
            // 
            // numericUpDownSaturation
            // 
            this.numericUpDownSaturation.Location = new System.Drawing.Point(391, 10);
            this.numericUpDownSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSaturation.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numericUpDownSaturation.Name = "numericUpDownSaturation";
            this.numericUpDownSaturation.Size = new System.Drawing.Size(42, 19);
            this.numericUpDownSaturation.TabIndex = 4;
            this.numericUpDownSaturation.ValueChanged += new System.EventHandler(this.OnSaturation_changed);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(439, 10);
            this.numericUpDownValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownValue.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(42, 19);
            this.numericUpDownValue.TabIndex = 5;
            this.numericUpDownValue.ValueChanged += new System.EventHandler(this.OnValue_changed);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(487, 9);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(19, 20);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "R";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.OnResetButton_clicked);
            // 
            // CharaChipGeneratorParamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.numericUpDownSaturation);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.comboBoxItem);
            this.Controls.Add(this.labelItemName);
            this.Name = "CharaChipGeneratorParamView";
            this.Size = new System.Drawing.Size(531, 44);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ComboBox comboBoxItem;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.NumericUpDown numericUpDownSaturation;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.Button buttonReset;
    }
}
