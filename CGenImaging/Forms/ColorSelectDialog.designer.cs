namespace CGenImaging.Forms
{
    partial class ColorSelectDialog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorSelectBarR = new CGenImaging.Forms.ColorSelectBar();
            this.colorSelectBarG = new CGenImaging.Forms.ColorSelectBar();
            this.colorSelectBarB = new CGenImaging.Forms.ColorSelectBar();
            this.colorSelectBarA = new CGenImaging.Forms.ColorSelectBar();
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorHSVSelecter = new CGenImaging.Forms.ColorHSVSelecter();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSelectedColor = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 231);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(438, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(360, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnButtonCancelClick);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(279, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnButtonOKClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarR, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarG, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarA, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownR, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownG, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownB, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownA, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 191);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "A";
            // 
            // colorSelectBarR
            // 
            this.colorSelectBarR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorSelectBarR.BackColor = System.Drawing.Color.Red;
            this.colorSelectBarR.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarR.Location = new System.Drawing.Point(26, 14);
            this.colorSelectBarR.Maximum = 255;
            this.colorSelectBarR.Minimum = 0;
            this.colorSelectBarR.Name = "colorSelectBarR";
            this.colorSelectBarR.Size = new System.Drawing.Size(122, 24);
            this.colorSelectBarR.TabIndex = 6;
            this.colorSelectBarR.Value = 0;
            this.colorSelectBarR.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarG
            // 
            this.colorSelectBarG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorSelectBarG.BackColor = System.Drawing.Color.Lime;
            this.colorSelectBarG.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarG.Location = new System.Drawing.Point(26, 59);
            this.colorSelectBarG.Maximum = 255;
            this.colorSelectBarG.Minimum = 0;
            this.colorSelectBarG.Name = "colorSelectBarG";
            this.colorSelectBarG.Size = new System.Drawing.Size(122, 24);
            this.colorSelectBarG.TabIndex = 7;
            this.colorSelectBarG.Value = 0;
            this.colorSelectBarG.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarB
            // 
            this.colorSelectBarB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorSelectBarB.BackColor = System.Drawing.Color.Blue;
            this.colorSelectBarB.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarB.Location = new System.Drawing.Point(26, 104);
            this.colorSelectBarB.Maximum = 255;
            this.colorSelectBarB.Minimum = 0;
            this.colorSelectBarB.Name = "colorSelectBarB";
            this.colorSelectBarB.Size = new System.Drawing.Size(122, 24);
            this.colorSelectBarB.TabIndex = 8;
            this.colorSelectBarB.Value = 0;
            this.colorSelectBarB.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarA
            // 
            this.colorSelectBarA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorSelectBarA.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarA.Location = new System.Drawing.Point(26, 151);
            this.colorSelectBarA.Maximum = 255;
            this.colorSelectBarA.Minimum = 0;
            this.colorSelectBarA.Name = "colorSelectBarA";
            this.colorSelectBarA.Size = new System.Drawing.Size(122, 24);
            this.colorSelectBarA.TabIndex = 9;
            this.colorSelectBarA.Value = 255;
            this.colorSelectBarA.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownR.Location = new System.Drawing.Point(154, 17);
            this.numericUpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(70, 19);
            this.numericUpDownR.TabIndex = 10;
            this.numericUpDownR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownR.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownG
            // 
            this.numericUpDownG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownG.Location = new System.Drawing.Point(154, 62);
            this.numericUpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG.Name = "numericUpDownG";
            this.numericUpDownG.Size = new System.Drawing.Size(70, 19);
            this.numericUpDownG.TabIndex = 11;
            this.numericUpDownG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownG.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownB.Location = new System.Drawing.Point(154, 107);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(70, 19);
            this.numericUpDownB.TabIndex = 12;
            this.numericUpDownB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownB.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownA.Location = new System.Drawing.Point(154, 153);
            this.numericUpDownA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(70, 19);
            this.numericUpDownA.TabIndex = 13;
            this.numericUpDownA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownA.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownA.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(207, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 231);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.colorHSVSelecter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12);
            this.panel2.Size = new System.Drawing.Size(207, 191);
            this.panel2.TabIndex = 4;
            // 
            // colorHSVSelectView
            // 
            this.colorHSVSelecter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorHSVSelecter.Location = new System.Drawing.Point(12, 12);
            this.colorHSVSelecter.Name = "colorHSVSelectView";
            this.colorHSVSelecter.Size = new System.Drawing.Size(183, 167);
            this.colorHSVSelecter.TabIndex = 1;
            this.colorHSVSelecter.ValueChanged += new System.EventHandler(this.OnColorSLSelectViewValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSelectedColor, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 191);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 40);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "選択色";
            // 
            // labelSelectedColor
            // 
            this.labelSelectedColor.BackColor = System.Drawing.Color.Black;
            this.labelSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSelectedColor.Location = new System.Drawing.Point(56, 6);
            this.labelSelectedColor.Name = "labelSelectedColor";
            this.labelSelectedColor.Size = new System.Drawing.Size(142, 28);
            this.labelSelectedColor.TabIndex = 1;
            // 
            // ColorEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 260);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorEditForm";
            this.ShowIcon = false;
            this.Text = "色設定";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private ColorHSVSelecter colorHSVSelecter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ColorSelectBar colorSelectBarR;
        private ColorSelectBar colorSelectBarG;
        private ColorSelectBar colorSelectBarB;
        private ColorSelectBar colorSelectBarA;
        private System.Windows.Forms.NumericUpDown numericUpDownR;
        private System.Windows.Forms.NumericUpDown numericUpDownG;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSelectedColor;
    }
}