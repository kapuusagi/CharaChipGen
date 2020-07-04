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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSelectDialog));
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
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnButtonCancelClick);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnButtonOKClick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            // colorSelectBarR
            // 
            resources.ApplyResources(this.colorSelectBarR, "colorSelectBarR");
            this.colorSelectBarR.BackColor = System.Drawing.Color.Red;
            this.colorSelectBarR.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarR.Maximum = 255;
            this.colorSelectBarR.Minimum = 0;
            this.colorSelectBarR.Name = "colorSelectBarR";
            this.colorSelectBarR.Value = 0;
            this.colorSelectBarR.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarG
            // 
            resources.ApplyResources(this.colorSelectBarG, "colorSelectBarG");
            this.colorSelectBarG.BackColor = System.Drawing.Color.Lime;
            this.colorSelectBarG.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarG.Maximum = 255;
            this.colorSelectBarG.Minimum = 0;
            this.colorSelectBarG.Name = "colorSelectBarG";
            this.colorSelectBarG.Value = 0;
            this.colorSelectBarG.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarB
            // 
            resources.ApplyResources(this.colorSelectBarB, "colorSelectBarB");
            this.colorSelectBarB.BackColor = System.Drawing.Color.Blue;
            this.colorSelectBarB.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarB.Maximum = 255;
            this.colorSelectBarB.Minimum = 0;
            this.colorSelectBarB.Name = "colorSelectBarB";
            this.colorSelectBarB.Value = 0;
            this.colorSelectBarB.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarA
            // 
            resources.ApplyResources(this.colorSelectBarA, "colorSelectBarA");
            this.colorSelectBarA.ForeColor = System.Drawing.Color.White;
            this.colorSelectBarA.Maximum = 255;
            this.colorSelectBarA.Minimum = 0;
            this.colorSelectBarA.Name = "colorSelectBarA";
            this.colorSelectBarA.Value = 255;
            this.colorSelectBarA.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // numericUpDownR
            // 
            resources.ApplyResources(this.numericUpDownR, "numericUpDownR");
            this.numericUpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownG
            // 
            resources.ApplyResources(this.numericUpDownG, "numericUpDownG");
            this.numericUpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG.Name = "numericUpDownG";
            this.numericUpDownG.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownB
            // 
            resources.ApplyResources(this.numericUpDownB, "numericUpDownB");
            this.numericUpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownA
            // 
            resources.ApplyResources(this.numericUpDownA, "numericUpDownA");
            this.numericUpDownA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownA.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.colorHSVSelecter);
            this.panel2.Name = "panel2";
            // 
            // colorHSVSelecter
            // 
            resources.ApplyResources(this.colorHSVSelecter, "colorHSVSelecter");
            this.colorHSVSelecter.Name = "colorHSVSelecter";
            this.colorHSVSelecter.ValueChanged += new System.EventHandler(this.OnColorSLSelectViewValueChanged);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSelectedColor, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // labelSelectedColor
            // 
            resources.ApplyResources(this.labelSelectedColor, "labelSelectedColor");
            this.labelSelectedColor.BackColor = System.Drawing.Color.Black;
            this.labelSelectedColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedColor.Name = "labelSelectedColor";
            // 
            // ColorSelectDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorSelectDialog";
            this.ShowIcon = false;
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