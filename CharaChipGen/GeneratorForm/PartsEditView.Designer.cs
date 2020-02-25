namespace CharaChipGen.GeneratorForm
{
    partial class PartsEditView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownYPos = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSaturation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.trackBarYPos = new System.Windows.Forms.TrackBar();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.trackBarValue = new System.Windows.Forms.TrackBar();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownYPos, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownHue, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownSaturation, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownOpacity, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBarYPos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBarHue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBarSaturation, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBarValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarOpacity, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 215);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "垂直位置調整";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "色相";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "彩度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(9, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 41);
            this.label4.TabIndex = 3;
            this.label4.Text = "輝度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(9, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 43);
            this.label5.TabIndex = 4;
            this.label5.Text = "不当明度";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownYPos
            // 
            this.numericUpDownYPos.Location = new System.Drawing.Point(211, 7);
            this.numericUpDownYPos.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownYPos.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericUpDownYPos.Name = "numericUpDownYPos";
            this.numericUpDownYPos.Size = new System.Drawing.Size(54, 19);
            this.numericUpDownYPos.TabIndex = 2;
            // 
            // numericUpDownHue
            // 
            this.numericUpDownHue.Location = new System.Drawing.Point(211, 48);
            this.numericUpDownHue.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownHue.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDownHue.Name = "numericUpDownHue";
            this.numericUpDownHue.Size = new System.Drawing.Size(54, 19);
            this.numericUpDownHue.TabIndex = 4;
            // 
            // numericUpDownSaturation
            // 
            this.numericUpDownSaturation.Location = new System.Drawing.Point(211, 89);
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
            this.numericUpDownSaturation.Size = new System.Drawing.Size(54, 19);
            this.numericUpDownSaturation.TabIndex = 6;
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(211, 130);
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
            this.numericUpDownValue.Size = new System.Drawing.Size(54, 19);
            this.numericUpDownValue.TabIndex = 8;
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Location = new System.Drawing.Point(211, 171);
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(54, 19);
            this.numericUpDownOpacity.TabIndex = 10;
            this.numericUpDownOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // trackBarYPos
            // 
            this.trackBarYPos.LargeChange = 1;
            this.trackBarYPos.Location = new System.Drawing.Point(110, 7);
            this.trackBarYPos.Maximum = 50;
            this.trackBarYPos.Minimum = -50;
            this.trackBarYPos.Name = "trackBarYPos";
            this.trackBarYPos.Size = new System.Drawing.Size(95, 35);
            this.trackBarYPos.TabIndex = 1;
            this.trackBarYPos.TickFrequency = 20;
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(110, 48);
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Minimum = -180;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(95, 35);
            this.trackBarHue.TabIndex = 3;
            this.trackBarHue.TickFrequency = 60;
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Location = new System.Drawing.Point(110, 89);
            this.trackBarSaturation.Maximum = 255;
            this.trackBarSaturation.Minimum = -255;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(95, 35);
            this.trackBarSaturation.TabIndex = 5;
            this.trackBarSaturation.TickFrequency = 50;
            // 
            // trackBarValue
            // 
            this.trackBarValue.Location = new System.Drawing.Point(110, 130);
            this.trackBarValue.Maximum = 255;
            this.trackBarValue.Minimum = -255;
            this.trackBarValue.Name = "trackBarValue";
            this.trackBarValue.Size = new System.Drawing.Size(95, 35);
            this.trackBarValue.TabIndex = 7;
            this.trackBarValue.TickFrequency = 50;
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(110, 171);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(95, 37);
            this.trackBarOpacity.TabIndex = 9;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 233);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.panel1.Size = new System.Drawing.Size(280, 51);
            this.panel1.TabIndex = 1;
            // 
            // buttonReset
            // 
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Location = new System.Drawing.Point(6, 4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(268, 43);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.OnButtonResetClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "調整";
            // 
            // ParamEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(280, 280);
            this.Name = "ParamEditView";
            this.Size = new System.Drawing.Size(280, 284);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownYPos;
        private System.Windows.Forms.NumericUpDown numericUpDownHue;
        private System.Windows.Forms.NumericUpDown numericUpDownSaturation;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.TrackBar trackBarYPos;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.TrackBar trackBarValue;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
