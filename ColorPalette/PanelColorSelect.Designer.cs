
namespace ColorPalette
{
    partial class PanelColorSelect
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelColorPreview = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorSelectBarR = new CGenImaging.Forms.ColorSelectBar();
            this.colorSelectBarG = new CGenImaging.Forms.ColorSelectBar();
            this.colorSelectBarB = new CGenImaging.Forms.ColorSelectBar();
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownB, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownG, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarG, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorSelectBarB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownR, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 135);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownB.Location = new System.Drawing.Point(115, 110);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(87, 19);
            this.numericUpDownB.TabIndex = 9;
            this.numericUpDownB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownB.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownG
            // 
            this.numericUpDownG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownG.Location = new System.Drawing.Point(115, 80);
            this.numericUpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG.Name = "numericUpDownG";
            this.numericUpDownG.Size = new System.Drawing.Size(87, 19);
            this.numericUpDownG.TabIndex = 8;
            this.numericUpDownG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownG.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.labelColorPreview);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(199, 39);
            this.panel1.TabIndex = 0;
            // 
            // labelColorPreview
            // 
            this.labelColorPreview.AutoEllipsis = true;
            this.labelColorPreview.BackColor = System.Drawing.Color.Black;
            this.labelColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelColorPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColorPreview.ForeColor = System.Drawing.Color.White;
            this.labelColorPreview.Location = new System.Drawing.Point(8, 8);
            this.labelColorPreview.Name = "labelColorPreview";
            this.labelColorPreview.Size = new System.Drawing.Size(183, 23);
            this.labelColorPreview.TabIndex = 0;
            this.labelColorPreview.Text = "#000000";
            this.labelColorPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "B";
            // 
            // colorSelectBarR
            // 
            this.colorSelectBarR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSelectBarR.BackColor = System.Drawing.Color.Red;
            this.colorSelectBarR.Location = new System.Drawing.Point(22, 48);
            this.colorSelectBarR.Maximum = 255;
            this.colorSelectBarR.Minimum = 0;
            this.colorSelectBarR.Name = "colorSelectBarR";
            this.colorSelectBarR.Size = new System.Drawing.Size(87, 24);
            this.colorSelectBarR.TabIndex = 4;
            this.colorSelectBarR.Value = 255;
            this.colorSelectBarR.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarG
            // 
            this.colorSelectBarG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSelectBarG.BackColor = System.Drawing.Color.GreenYellow;
            this.colorSelectBarG.Location = new System.Drawing.Point(22, 78);
            this.colorSelectBarG.Maximum = 255;
            this.colorSelectBarG.Minimum = 0;
            this.colorSelectBarG.Name = "colorSelectBarG";
            this.colorSelectBarG.Size = new System.Drawing.Size(87, 24);
            this.colorSelectBarG.TabIndex = 5;
            this.colorSelectBarG.Value = 255;
            this.colorSelectBarG.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // colorSelectBarB
            // 
            this.colorSelectBarB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSelectBarB.BackColor = System.Drawing.Color.Blue;
            this.colorSelectBarB.Location = new System.Drawing.Point(22, 108);
            this.colorSelectBarB.Maximum = 255;
            this.colorSelectBarB.Minimum = 0;
            this.colorSelectBarB.Name = "colorSelectBarB";
            this.colorSelectBarB.Size = new System.Drawing.Size(87, 24);
            this.colorSelectBarB.TabIndex = 6;
            this.colorSelectBarB.Value = 255;
            this.colorSelectBarB.ValueChanged += new System.EventHandler(this.OnColorSelectBarValueChanged);
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownR.Location = new System.Drawing.Point(115, 50);
            this.numericUpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(87, 19);
            this.numericUpDownR.TabIndex = 7;
            this.numericUpDownR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownR.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // PanelColorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PanelColorSelect";
            this.Size = new System.Drawing.Size(205, 135);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelColorPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownG;
        private CGenImaging.Forms.ColorSelectBar colorSelectBarR;
        private CGenImaging.Forms.ColorSelectBar colorSelectBarG;
        private CGenImaging.Forms.ColorSelectBar colorSelectBarB;
        private System.Windows.Forms.NumericUpDown numericUpDownR;
    }
}
