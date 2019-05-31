namespace CharaChipGen.UI
{
    partial class FormValueInput
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMaximum = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.labelMinimum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar.Location = new System.Drawing.Point(0, 0);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(254, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.ValueChanged += new System.EventHandler(this.OnTrackBarValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.labelCurrent);
            this.panel1.Controls.Add(this.labelMaximum);
            this.panel1.Controls.Add(this.labelMinimum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(254, 27);
            this.panel1.TabIndex = 1;
            // 
            // labelMaximum
            // 
            this.labelMaximum.AutoSize = true;
            this.labelMaximum.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMaximum.Location = new System.Drawing.Point(227, 4);
            this.labelMaximum.Name = "labelMaximum";
            this.labelMaximum.Size = new System.Drawing.Size(23, 12);
            this.labelMaximum.TabIndex = 1;
            this.labelMaximum.Text = "100";
            // 
            // labelCurrent
            // 
            this.labelCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrent.Location = new System.Drawing.Point(15, 4);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(212, 19);
            this.labelCurrent.TabIndex = 2;
            this.labelCurrent.Text = "0";
            this.labelCurrent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMinimum
            // 
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMinimum.Location = new System.Drawing.Point(4, 4);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(11, 12);
            this.labelMinimum.TabIndex = 0;
            this.labelMinimum.Text = "0";
            // 
            // FormValueInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(254, 72);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormValueInput";
            this.Text = "FormValueInput";
            this.Deactivate += new System.EventHandler(this.OnFormDeactivate);
            this.Shown += new System.EventHandler(this.OnFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelMaximum;
        private System.Windows.Forms.Label labelMinimum;
    }
}