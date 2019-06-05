namespace CharaChipGenUtility.Operations
{
    partial class ControlCombineSetting
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownV = new System.Windows.Forms.NumericUpDown();
            this.controlSelectDirectory = new CharaChipGenUtility.Operations.ControlSelectDirectory();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownV)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownH);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownV);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(426, 45);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "水平";
            // 
            // numericUpDownH
            // 
            this.numericUpDownH.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.numericUpDownH.Location = new System.Drawing.Point(46, 11);
            this.numericUpDownH.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownH.Name = "numericUpDownH";
            this.numericUpDownH.Size = new System.Drawing.Size(40, 23);
            this.numericUpDownH.TabIndex = 1;
            this.numericUpDownH.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownH.ValueChanged += new System.EventHandler(this.OnNumericUpDownHValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "垂直";
            // 
            // numericUpDownV
            // 
            this.numericUpDownV.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.numericUpDownV.Location = new System.Drawing.Point(127, 11);
            this.numericUpDownV.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownV.Name = "numericUpDownV";
            this.numericUpDownV.Size = new System.Drawing.Size(40, 23);
            this.numericUpDownV.TabIndex = 3;
            this.numericUpDownV.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownV.ValueChanged += new System.EventHandler(this.OnNumericUpDownVValueChanged);
            // 
            // controlSelectDirectory
            // 
            this.controlSelectDirectory.Directory = "";
            this.controlSelectDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlSelectDirectory.Location = new System.Drawing.Point(0, 0);
            this.controlSelectDirectory.Name = "controlSelectDirectory";
            this.controlSelectDirectory.Padding = new System.Windows.Forms.Padding(8);
            this.controlSelectDirectory.SelectName = "出力フォルダ";
            this.controlSelectDirectory.Size = new System.Drawing.Size(426, 36);
            this.controlSelectDirectory.TabIndex = 0;
            this.controlSelectDirectory.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.OnControlSelectDirectoryPropertyChanged);
            // 
            // ControlCombineSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.controlSelectDirectory);
            this.Name = "ControlCombineSetting";
            this.Size = new System.Drawing.Size(426, 170);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlSelectDirectory controlSelectDirectory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownV;
    }
}
