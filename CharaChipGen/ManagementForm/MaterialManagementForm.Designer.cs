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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("前髪");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("髪型");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("頭");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("目");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("体");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("衣装");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("アクセサリ");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("頭部アクセサリ");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("キャラチップ素材", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("顔");
            this.buttonClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewMaterials = new System.Windows.Forms.TreeView();
            this.listViewMaterials = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBoxMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(376, 389);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.OnCloseMenuStrip_clicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.closeToolStripMenuItem.Text = "閉じる";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.OnCloseMenuStrip_clicked);
            // 
            // treeViewMaterials
            // 
            this.treeViewMaterials.Location = new System.Drawing.Point(12, 47);
            this.treeViewMaterials.Name = "treeViewMaterials";
            treeNode1.Name = "FrontHairStyles";
            treeNode1.Text = "前髪";
            treeNode2.Name = "HairStyles";
            treeNode2.Text = "髪型";
            treeNode3.Name = "Heads";
            treeNode3.Text = "頭";
            treeNode4.Name = "Eyes";
            treeNode4.Text = "目";
            treeNode5.Name = "Bodies";
            treeNode5.Text = "体";
            treeNode6.Name = "Costumes";
            treeNode6.Text = "衣装";
            treeNode7.Name = "Accessories";
            treeNode7.Text = "アクセサリ";
            treeNode8.Name = "HeadAccessories";
            treeNode8.Text = "頭部アクセサリ";
            treeNode9.Name = "CharaChipDirectory";
            treeNode9.Text = "キャラチップ素材";
            treeNode10.Name = "Faces";
            treeNode10.Text = "顔";
            this.treeViewMaterials.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            this.treeViewMaterials.Size = new System.Drawing.Size(102, 283);
            this.treeViewMaterials.TabIndex = 3;
            this.treeViewMaterials.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeViewItemSelected);
            // 
            // listViewMaterials
            // 
            this.listViewMaterials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderPath});
            this.listViewMaterials.Enabled = false;
            this.listViewMaterials.Location = new System.Drawing.Point(6, 48);
            this.listViewMaterials.Name = "listViewMaterials";
            this.listViewMaterials.Size = new System.Drawing.Size(325, 235);
            this.listViewMaterials.TabIndex = 5;
            this.listViewMaterials.UseCompatibleStateImageBehavior = false;
            this.listViewMaterials.View = System.Windows.Forms.View.Details;
            this.listViewMaterials.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnMaterialList_selectionChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "素材名";
            this.columnHeaderName.Width = 240;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "パス";
            this.columnHeaderPath.Width = 240;
            // 
            // groupBoxMaterial
            // 
            this.groupBoxMaterial.Controls.Add(this.buttonDelete);
            this.groupBoxMaterial.Controls.Add(this.buttonEdit);
            this.groupBoxMaterial.Controls.Add(this.buttonAdd);
            this.groupBoxMaterial.Controls.Add(this.listViewMaterials);
            this.groupBoxMaterial.Location = new System.Drawing.Point(120, 47);
            this.groupBoxMaterial.Name = "groupBoxMaterial";
            this.groupBoxMaterial.Size = new System.Drawing.Size(337, 283);
            this.groupBoxMaterial.TabIndex = 6;
            this.groupBoxMaterial.TabStop = false;
            this.groupBoxMaterial.Text = "素材一覧";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(256, 19);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.OnMaterialDelete_clicked);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(175, 18);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "編集";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.OnMaterialEdit_clicked);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(94, 19);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.OnMaterialAdd_clicked);
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(12, 28);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(54, 12);
            this.labelDirectory.TabIndex = 7;
            this.labelDirectory.Text = "ディレクトリ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル|*.png";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "追加";
            // 
            // MaterialManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 424);
            this.Controls.Add(this.groupBoxMaterial);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.treeViewMaterials);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MaterialManagementForm";
            this.Text = "素材管理";
            this.Resize += new System.EventHandler(this.OnFormResized);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxMaterial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
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
    }
}