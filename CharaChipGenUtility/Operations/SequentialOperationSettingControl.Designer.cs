namespace CharaChipGenUtility.Operations
{
    partial class SequentialOperationSettingControl
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
            this.selectDirectoryControl = new CharaChipGenUtility.Operations.SelectDirectoryControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxOperations = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxTool = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectDirectoryControl
            // 
            this.selectDirectoryControl.Directory = "";
            this.selectDirectoryControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectDirectoryControl.Location = new System.Drawing.Point(0, 0);
            this.selectDirectoryControl.Name = "selectDirectoryControl";
            this.selectDirectoryControl.Padding = new System.Windows.Forms.Padding(8);
            this.selectDirectoryControl.SelectName = "フォルダ";
            this.selectDirectoryControl.Size = new System.Drawing.Size(480, 36);
            this.selectDirectoryControl.TabIndex = 0;
            this.selectDirectoryControl.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.OnPropertyChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 224);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBoxOperations);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(212, 218);
            this.panel2.TabIndex = 2;
            // 
            // listBoxOperations
            // 
            this.listBoxOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOperations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxOperations.FormattingEnabled = true;
            this.listBoxOperations.Location = new System.Drawing.Point(8, 37);
            this.listBoxOperations.Name = "listBoxOperations";
            this.listBoxOperations.Size = new System.Drawing.Size(196, 173);
            this.listBoxOperations.TabIndex = 2;
            this.listBoxOperations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnListBoxToolDrawItem);
            this.listBoxOperations.SelectedValueChanged += new System.EventHandler(this.OnListBoxOperationsSelectedValueChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonUp);
            this.flowLayoutPanel2.Controls.Add(this.buttonDown);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(196, 29);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // buttonUp
            // 
            this.buttonUp.Enabled = false;
            this.buttonUp.Location = new System.Drawing.Point(3, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(32, 23);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.OnButtonUpClick);
            // 
            // buttonDown
            // 
            this.buttonDown.Enabled = false;
            this.buttonDown.Location = new System.Drawing.Point(41, 3);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(32, 23);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.OnButtonDownClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxTool);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(265, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(212, 218);
            this.panel1.TabIndex = 2;
            // 
            // listBoxTool
            // 
            this.listBoxTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTool.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTool.FormattingEnabled = true;
            this.listBoxTool.Location = new System.Drawing.Point(8, 8);
            this.listBoxTool.Name = "listBoxTool";
            this.listBoxTool.Size = new System.Drawing.Size(196, 202);
            this.listBoxTool.TabIndex = 1;
            this.listBoxTool.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnListBoxToolDrawItem);
            this.listBoxTool.SelectedValueChanged += new System.EventHandler(this.OnListBoxToolSelectedValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemove);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(221, 83);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(38, 58);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(32, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "<<";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.OnButtonAddClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(3, 32);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(32, 23);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = ">>";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.OnButtonRemoveClick);
            // 
            // SequentialOperationSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.selectDirectoryControl);
            this.Name = "SequentialOperationSettingControl";
            this.Size = new System.Drawing.Size(480, 260);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectDirectoryControl selectDirectoryControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxOperations;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxTool;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
    }
}
