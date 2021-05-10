
namespace FImageEditor
{
    partial class FaceViewControl
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
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelPictureParent = new System.Windows.Forms.Panel();
            this.facePictureControl = new FImageEditor.FacePictureControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelPictureParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownY, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 64);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y";
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownX.Location = new System.Drawing.Point(21, 38);
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(75, 19);
            this.numericUpDownX.TabIndex = 3;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownY.Location = new System.Drawing.Point(140, 38);
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(75, 19);
            this.numericUpDownY.TabIndex = 4;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.OnNumericUpDownValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 5);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelFileName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelect, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 26);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // labelFileName
            // 
            this.labelFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFileName.Location = new System.Drawing.Point(3, 0);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(125, 26);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(134, 3);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 20);
            this.buttonSelect.TabIndex = 0;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.OnButtonSelectClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "パラメータ";
            // 
            // panelPictureParent
            // 
            this.panelPictureParent.BackColor = System.Drawing.Color.Black;
            this.panelPictureParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPictureParent.Controls.Add(this.facePictureControl);
            this.panelPictureParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPictureParent.Location = new System.Drawing.Point(0, 0);
            this.panelPictureParent.Name = "panelPictureParent";
            this.panelPictureParent.Padding = new System.Windows.Forms.Padding(6);
            this.panelPictureParent.Size = new System.Drawing.Size(224, 169);
            this.panelPictureParent.TabIndex = 2;
            this.panelPictureParent.Resize += new System.EventHandler(this.OnPanelResized);
            // 
            // facePictureControl
            // 
            this.facePictureControl.BackgroundImage = global::FImageEditor.Properties.Resources.Background;
            this.facePictureControl.Image = null;
            this.facePictureControl.ImageRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.facePictureControl.Location = new System.Drawing.Point(11, 16);
            this.facePictureControl.Name = "facePictureControl";
            this.facePictureControl.Size = new System.Drawing.Size(113, 118);
            this.facePictureControl.TabIndex = 0;
            this.facePictureControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseDown);
            this.facePictureControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseMove);
            this.facePictureControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPictureBoxMouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル(*.png)|*.png|全てのファイル(*.*)|*.*";
            // 
            // FaceViewControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPictureParent);
            this.Controls.Add(this.groupBox1);
            this.Name = "FaceViewControl";
            this.Size = new System.Drawing.Size(224, 251);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelPictureParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Panel panelPictureParent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSelect;
        private FacePictureControl facePictureControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
