namespace CharaChipGenUtility
{
    partial class FormMain
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.panelAccept = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelAccept.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonConfig);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxOperation);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(72, 9);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(190, 20);
            this.comboBoxOperation.TabIndex = 1;
            // 
            // panelAccept
            // 
            this.panelAccept.AllowDrop = true;
            this.panelAccept.Controls.Add(this.label2);
            this.panelAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccept.Location = new System.Drawing.Point(0, 41);
            this.panelAccept.Name = "panelAccept";
            this.panelAccept.Padding = new System.Windows.Forms.Padding(8);
            this.panelAccept.Size = new System.Drawing.Size(271, 280);
            this.panelAccept.TabIndex = 1;
            this.panelAccept.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnPanelAcceptDragDrop);
            this.panelAccept.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnPanelAcceptDragEnter);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 264);
            this.label2.TabIndex = 0;
            this.label2.Text = "ここにファイルをドラッグ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(9, 9);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(22, 23);
            this.buttonConfig.TabIndex = 2;
            this.buttonConfig.Text = "...";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.OnButtonMenuClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 321);
            this.Controls.Add(this.panelAccept);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Utility";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelAccept.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Panel panelAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfig;
    }
}

