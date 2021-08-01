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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartsEditView));
            CharaChipGen.Model.CharaChip.ColorSetting colorSetting1 = new CharaChipGen.Model.CharaChip.ColorSetting();
            CharaChipGen.Model.CharaChip.ColorSetting colorSetting2 = new CharaChipGen.Model.CharaChip.ColorSetting();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownYPos = new System.Windows.Forms.NumericUpDown();
            this.trackBarYPos = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControlColor2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.colorSettingViewColor1 = new CharaChipGen.GeneratorForm.ColorSettingView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.colorSettingView2 = new CharaChipGen.GeneratorForm.ColorSettingView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYPos)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlColor2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownYPos, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBarYPos, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericUpDownYPos
            // 
            resources.ApplyResources(this.numericUpDownYPos, "numericUpDownYPos");
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
            // 
            // trackBarYPos
            // 
            resources.ApplyResources(this.trackBarYPos, "trackBarYPos");
            this.trackBarYPos.LargeChange = 1;
            this.trackBarYPos.Maximum = 50;
            this.trackBarYPos.Minimum = -50;
            this.trackBarYPos.Name = "trackBarYPos";
            this.trackBarYPos.TickFrequency = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.OnButtonResetClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControlColor2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tabControlColor2
            // 
            this.tabControlColor2.Controls.Add(this.tabPage1);
            this.tabControlColor2.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControlColor2, "tabControlColor2");
            this.tabControlColor2.Name = "tabControlColor2";
            this.tabControlColor2.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.colorSettingViewColor1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // colorSettingViewColor1
            // 
            colorSetting1.Hue = 0;
            colorSetting1.Opacity = 100;
            colorSetting1.Saturation = 0;
            colorSetting1.Value = 0;
            this.colorSettingViewColor1.ColorSetting = colorSetting1;
            resources.ApplyResources(this.colorSettingViewColor1, "colorSettingViewColor1");
            this.colorSettingViewColor1.EditHSV = false;
            this.colorSettingViewColor1.Name = "colorSettingViewColor1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.colorSettingView2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // colorSettingView2
            // 
            colorSetting2.Hue = 0;
            colorSetting2.Opacity = 100;
            colorSetting2.Saturation = 0;
            colorSetting2.Value = 0;
            this.colorSettingView2.ColorSetting = colorSetting2;
            resources.ApplyResources(this.colorSettingView2, "colorSettingView2");
            this.colorSettingView2.EditHSV = false;
            this.colorSettingView2.Name = "colorSettingView2";
            // 
            // PartsEditView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PartsEditView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarYPos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControlColor2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownYPos;
        private System.Windows.Forms.TrackBar trackBarYPos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControlColor2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ColorSettingView colorSettingView2;
        private ColorSettingView colorSettingViewColor1;
    }
}
