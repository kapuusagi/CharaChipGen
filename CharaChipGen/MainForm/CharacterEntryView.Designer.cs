﻿namespace CharaChipGen.MainForm
{
    partial class CharacterEntryView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterEntryView));
            this.button = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewControl = new CharaChipGen.CommonControl.ImageViewControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button.Location = new System.Drawing.Point(7, 158);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(154, 23);
            this.button.TabIndex = 1;
            this.button.Text = "ButtonName";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.OnButtonClick);
            this.button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnButtonKeyDown);
            this.button.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnButtonKeyPress);
            this.button.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnButtonKeyUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集ToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(99, 48);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.削除ToolStripMenuItem.Text = "削除";
            // 
            // imageViewControl1
            // 
            this.imageViewControl.BackColor = System.Drawing.Color.Transparent;
            this.imageViewControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageViewControl1.BackgroundImage")));
            this.imageViewControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewControl.Image = null;
            this.imageViewControl.ImageRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.imageViewControl.Location = new System.Drawing.Point(7, 7);
            this.imageViewControl.Name = "imageViewControl1";
            this.imageViewControl.Padding = new System.Windows.Forms.Padding(24, 4, 4, 4);
            this.imageViewControl.Size = new System.Drawing.Size(154, 145);
            this.imageViewControl.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.imageViewControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(168, 188);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CharacterEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CharacterEntryView";
            this.Size = new System.Drawing.Size(168, 188);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private CommonControl.ImageViewControl imageViewControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
