namespace CharaChipGen.ExportSettingForm
{
    partial class ExportSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCharaChipWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCharaChipHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFaceWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFaceHeight = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRenderTwice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(65, 130);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(148, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "キャラチップサイズ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "フェイスサイズ";
            // 
            // numericUpDownCharaChipWidth
            // 
            this.numericUpDownCharaChipWidth.Location = new System.Drawing.Point(121, 12);
            this.numericUpDownCharaChipWidth.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownCharaChipWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCharaChipWidth.Name = "numericUpDownCharaChipWidth";
            this.numericUpDownCharaChipWidth.Size = new System.Drawing.Size(48, 19);
            this.numericUpDownCharaChipWidth.TabIndex = 4;
            this.numericUpDownCharaChipWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCharaChipHeight
            // 
            this.numericUpDownCharaChipHeight.Location = new System.Drawing.Point(175, 12);
            this.numericUpDownCharaChipHeight.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownCharaChipHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCharaChipHeight.Name = "numericUpDownCharaChipHeight";
            this.numericUpDownCharaChipHeight.Size = new System.Drawing.Size(48, 19);
            this.numericUpDownCharaChipHeight.TabIndex = 4;
            this.numericUpDownCharaChipHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownFaceWidth
            // 
            this.numericUpDownFaceWidth.Location = new System.Drawing.Point(121, 44);
            this.numericUpDownFaceWidth.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownFaceWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFaceWidth.Name = "numericUpDownFaceWidth";
            this.numericUpDownFaceWidth.Size = new System.Drawing.Size(48, 19);
            this.numericUpDownFaceWidth.TabIndex = 4;
            this.numericUpDownFaceWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownFaceHeight
            // 
            this.numericUpDownFaceHeight.Location = new System.Drawing.Point(175, 44);
            this.numericUpDownFaceHeight.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownFaceHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFaceHeight.Name = "numericUpDownFaceHeight";
            this.numericUpDownFaceHeight.Size = new System.Drawing.Size(48, 19);
            this.numericUpDownFaceHeight.TabIndex = 4;
            this.numericUpDownFaceHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxRenderTwice
            // 
            this.checkBoxRenderTwice.AutoSize = true;
            this.checkBoxRenderTwice.Location = new System.Drawing.Point(17, 82);
            this.checkBoxRenderTwice.Name = "checkBoxRenderTwice";
            this.checkBoxRenderTwice.Size = new System.Drawing.Size(108, 16);
            this.checkBoxRenderTwice.TabIndex = 5;
            this.checkBoxRenderTwice.Text = "サイズを2倍にする";
            this.checkBoxRenderTwice.UseVisualStyleBackColor = true;
            // 
            // ExportSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 165);
            this.Controls.Add(this.checkBoxRenderTwice);
            this.Controls.Add(this.numericUpDownFaceHeight);
            this.Controls.Add(this.numericUpDownCharaChipHeight);
            this.Controls.Add(this.numericUpDownFaceWidth);
            this.Controls.Add(this.numericUpDownCharaChipWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExportSettingForm";
            this.Text = "エクスポート設定";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCharaChipWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownCharaChipHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownFaceWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownFaceHeight;
        private System.Windows.Forms.CheckBox checkBoxRenderTwice;
    }
}