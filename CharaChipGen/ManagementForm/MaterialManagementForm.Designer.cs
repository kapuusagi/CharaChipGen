namespace CharaChipGen.ManagementForm
{
    partial class MaterialManagementForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("髪型");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("頭");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("目");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("体");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("アクセサリ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("頭部アクセサリ");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("キャラチップ素材", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.buttonClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewMaterials = new System.Windows.Forms.TreeView();
            this.listViewMaterials = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBoxMaterial.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(523, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.OnMenuItemCloseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(53, 20);
            this.menuItemFile.Text = "ファイル";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemClose.Size = new System.Drawing.Size(146, 22);
            this.menuItemClose.Text = "閉じる";
            this.menuItemClose.Click += new System.EventHandler(this.OnMenuItemCloseClick);
            // 
            // treeViewMaterials
            // 
            this.treeViewMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMaterials.Location = new System.Drawing.Point(8, 8);
            this.treeViewMaterials.Name = "treeViewMaterials";
            treeNode1.Name = "HairStyles";
            treeNode1.Text = "髪型";
            treeNode2.Name = "Heads";
            treeNode2.Text = "頭";
            treeNode3.Name = "Eyes";
            treeNode3.Text = "目";
            treeNode4.Name = "Bodies";
            treeNode4.Text = "体";
            treeNode5.Name = "Accessories";
            treeNode5.Text = "アクセサリ";
            treeNode6.Name = "HeadAccessories";
            treeNode6.Text = "頭部アクセサリ";
            treeNode7.Name = "CharaChipDirectory";
            treeNode7.Text = "キャラチップ素材";
            this.treeViewMaterials.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeViewMaterials.Size = new System.Drawing.Size(147, 290);
            this.treeViewMaterials.TabIndex = 0;
            this.treeViewMaterials.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewItemSelected);
            // 
            // listViewMaterials
            // 
            this.listViewMaterials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderDisplayName,
            this.columnHeaderPath});
            this.listViewMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMaterials.Enabled = false;
            this.listViewMaterials.HideSelection = false;
            this.listViewMaterials.Location = new System.Drawing.Point(8, 8);
            this.listViewMaterials.Name = "listViewMaterials";
            this.listViewMaterials.Size = new System.Drawing.Size(428, 243);
            this.listViewMaterials.TabIndex = 0;
            this.listViewMaterials.UseCompatibleStateImageBehavior = false;
            this.listViewMaterials.View = System.Windows.Forms.View.Details;
            this.listViewMaterials.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnMaterialListSelectionChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "素材名";
            this.columnHeaderName.Width = 120;
            // 
            // columnHeaderDisplayName
            // 
            this.columnHeaderDisplayName.Text = "表示名";
            this.columnHeaderDisplayName.Width = 120;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "パス";
            this.columnHeaderPath.Width = 240;
            // 
            // groupBoxMaterial
            // 
            this.groupBoxMaterial.Controls.Add(this.panel4);
            this.groupBoxMaterial.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMaterial.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMaterial.Name = "groupBoxMaterial";
            this.groupBoxMaterial.Size = new System.Drawing.Size(450, 306);
            this.groupBoxMaterial.TabIndex = 0;
            this.groupBoxMaterial.TabStop = false;
            this.groupBoxMaterial.Text = "素材一覧";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listViewMaterials);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 44);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8);
            this.panel4.Size = new System.Drawing.Size(444, 259);
            this.panel4.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonDelete);
            this.flowLayoutPanel2.Controls.Add(this.buttonEdit);
            this.flowLayoutPanel2.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel2.Controls.Add(this.buttonRename);
            this.flowLayoutPanel2.Controls.Add(this.buttonNew);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(444, 29);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(366, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.OnMaterialDeleteClicked);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(285, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "編集";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.OnMaterialEditClicked);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(204, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.OnMaterialAddClicked);
            // 
            // buttonRename
            // 
            this.buttonRename.Enabled = false;
            this.buttonRename.Location = new System.Drawing.Point(123, 3);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 1;
            this.buttonRename.Text = "名前変更";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.OnButtonRenameClick);
            // 
            // buttonNew
            // 
            this.buttonNew.Enabled = false;
            this.buttonNew.Location = new System.Drawing.Point(42, 3);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "新規";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.OnButtonNewClick);
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(12, 9);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(54, 12);
            this.labelDirectory.TabIndex = 0;
            this.labelDirectory.Text = "ディレクトリ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "素材ファイル|*.ccgmaterial";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "追加";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 359);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(613, 41);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelDirectory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 29);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeViewMaterials);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(163, 306);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBoxMaterial);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(163, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 306);
            this.panel3.TabIndex = 11;
            // 
            // MaterialManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 400);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MaterialManagementForm";
            this.Text = "素材管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxMaterial.ResumeLayout(false);
            this.groupBoxMaterial.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.TreeView treeViewMaterials;
        private System.Windows.Forms.ListView listViewMaterials;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.GroupBox groupBoxMaterial;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.ColumnHeader columnHeaderDisplayName;
    }
}