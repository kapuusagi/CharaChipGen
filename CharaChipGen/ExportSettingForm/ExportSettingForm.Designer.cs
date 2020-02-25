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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceHeight)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(96, 9);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(177, 9);
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
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "キャラチップサイズ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "フェイスサイズ";
            // 
            // numericUpDownCharaChipWidth
            // 
            this.numericUpDownCharaChipWidth.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDownCharaChipWidth.Location = new System.Drawing.Point(138, 4);
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
            this.numericUpDownCharaChipHeight.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDownCharaChipHeight.Location = new System.Drawing.Point(197, 4);
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
            this.numericUpDownFaceWidth.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDownFaceWidth.Location = new System.Drawing.Point(142, 0);
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
            this.numericUpDownFaceHeight.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDownFaceHeight.Location = new System.Drawing.Point(201, 0);
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
            this.checkBoxRenderTwice.Location = new System.Drawing.Point(3, 3);
            this.checkBoxRenderTwice.Name = "checkBoxRenderTwice";
            this.checkBoxRenderTwice.Size = new System.Drawing.Size(108, 16);
            this.checkBoxRenderTwice.TabIndex = 5;
            this.checkBoxRenderTwice.Text = "サイズを2倍にする";
            this.checkBoxRenderTwice.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 137);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 41);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownCharaChipWidth);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownCharaChipHeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(249, 25);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDownFaceWidth);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericUpDownFaceHeight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(9, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 25);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 137);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(186, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(190, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "x";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.checkBoxRenderTwice);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(9, 71);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(249, 25);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // ExportSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 178);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExportSettingForm";
            this.Text = "エクスポート設定";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharaChipHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFaceHeight)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}