namespace CharaChipGen.MainForm
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisplayImage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemMaterialManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonMaterialManage = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelOutputPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.characterEntryControl1 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl2 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl8 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl3 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl7 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl4 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl6 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl5 = new CharaChipGen.MainForm.CharacterEntryView();
            this.menuStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemOption,
            this.menuItemHelp});
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.toolStripMenuItem1,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.toolStripMenuItem2,
            this.menuItemExport,
            this.toolStripMenuItem3,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            resources.ApplyResources(this.menuItemNew, "menuItemNew");
            this.menuItemNew.Click += new System.EventHandler(this.OnMenuItemNewClick);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            resources.ApplyResources(this.menuItemOpen, "menuItemOpen");
            this.menuItemOpen.Click += new System.EventHandler(this.OnMenuItemOpenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            resources.ApplyResources(this.menuItemSave, "menuItemSave");
            this.menuItemSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            resources.ApplyResources(this.menuItemSaveAs, "menuItemSaveAs");
            this.menuItemSaveAs.Click += new System.EventHandler(this.OnSaveAsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuItemExport
            // 
            this.menuItemExport.Name = "menuItemExport";
            resources.ApplyResources(this.menuItemExport, "menuItemExport");
            this.menuItemExport.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.OnMenuItemExitClick);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCopy,
            this.menuItemPaste});
            this.menuItemEdit.Name = "menuItemEdit";
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Name = "menuItemCopy";
            resources.ApplyResources(this.menuItemCopy, "menuItemCopy");
            this.menuItemCopy.Click += new System.EventHandler(this.OnMenuItemCopyClick);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Name = "menuItemPaste";
            resources.ApplyResources(this.menuItemPaste, "menuItemPaste");
            this.menuItemPaste.Click += new System.EventHandler(this.OnMenuItemPasteClick);
            // 
            // menuItemOption
            // 
            this.menuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDisplayImage,
            this.menuItemPreference,
            this.toolStripSeparator1,
            this.menuItemMaterialManagement});
            this.menuItemOption.Name = "menuItemOption";
            resources.ApplyResources(this.menuItemOption, "menuItemOption");
            // 
            // menuItemDisplayImage
            // 
            this.menuItemDisplayImage.Name = "menuItemDisplayImage";
            resources.ApplyResources(this.menuItemDisplayImage, "menuItemDisplayImage");
            this.menuItemDisplayImage.Click += new System.EventHandler(this.OnMenuItemDisplayBackgroundClick);
            // 
            // menuItemPreference
            // 
            this.menuItemPreference.Name = "menuItemPreference";
            resources.ApplyResources(this.menuItemPreference, "menuItemPreference");
            this.menuItemPreference.Click += new System.EventHandler(this.OnPreferenceClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuItemMaterialManagement
            // 
            this.menuItemMaterialManagement.Name = "menuItemMaterialManagement";
            resources.ApplyResources(this.menuItemMaterialManagement, "menuItemMaterialManagement");
            this.menuItemMaterialManagement.Click += new System.EventHandler(this.OnMaterialManageClicked);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVersion});
            this.menuItemHelp.Name = "menuItemHelp";
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            // 
            // menuItemVersion
            // 
            this.menuItemVersion.Name = "menuItemVersion";
            resources.ApplyResources(this.menuItemVersion, "menuItemVersion");
            this.menuItemVersion.Click += new System.EventHandler(this.OnMenuItemVersionClick);
            // 
            // buttonExport
            // 
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // buttonMaterialManage
            // 
            resources.ApplyResources(this.buttonMaterialManage, "buttonMaterialManage");
            this.buttonMaterialManage.Name = "buttonMaterialManage";
            this.buttonMaterialManage.UseVisualStyleBackColor = true;
            this.buttonMaterialManage.Click += new System.EventHandler(this.OnMaterialManageClicked);
            // 
            // buttonConfig
            // 
            resources.ApplyResources(this.buttonConfig, "buttonConfig");
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.OnPreferenceClick);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // saveFileDialogExport
            // 
            resources.ApplyResources(this.saveFileDialogExport, "saveFileDialogExport");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelOutputPath);
            this.panel4.Controls.Add(this.label1);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // labelOutputPath
            // 
            resources.ApplyResources(this.labelOutputPath, "labelOutputPath");
            this.labelOutputPath.Name = "labelOutputPath";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonExport);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonConfig);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonMaterialManage);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl5, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // characterEntryControl1
            // 
            this.characterEntryControl1.ButtonName = "キャラクター1";
            this.characterEntryControl1.Image = null;
            this.characterEntryControl1.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl1, "characterEntryControl1");
            this.characterEntryControl1.Name = "characterEntryControl1";
            this.characterEntryControl1.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl1.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl2
            // 
            this.characterEntryControl2.ButtonName = "キャラクター2";
            this.characterEntryControl2.Image = null;
            this.characterEntryControl2.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl2, "characterEntryControl2");
            this.characterEntryControl2.Name = "characterEntryControl2";
            this.characterEntryControl2.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl2.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl8
            // 
            this.characterEntryControl8.ButtonName = "キャラクター8";
            this.characterEntryControl8.Image = null;
            this.characterEntryControl8.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl8, "characterEntryControl8");
            this.characterEntryControl8.Name = "characterEntryControl8";
            this.characterEntryControl8.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl8.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl3
            // 
            this.characterEntryControl3.ButtonName = "キャラクター3";
            this.characterEntryControl3.Image = null;
            this.characterEntryControl3.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl3, "characterEntryControl3");
            this.characterEntryControl3.Name = "characterEntryControl3";
            this.characterEntryControl3.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl3.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl7
            // 
            this.characterEntryControl7.ButtonName = "キャラクター7";
            this.characterEntryControl7.Image = null;
            this.characterEntryControl7.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl7, "characterEntryControl7");
            this.characterEntryControl7.Name = "characterEntryControl7";
            this.characterEntryControl7.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl7.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl4
            // 
            this.characterEntryControl4.ButtonName = "キャラクター4";
            this.characterEntryControl4.Image = null;
            this.characterEntryControl4.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl4, "characterEntryControl4");
            this.characterEntryControl4.Name = "characterEntryControl4";
            this.characterEntryControl4.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl4.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl6
            // 
            this.characterEntryControl6.ButtonName = "キャラクター6";
            this.characterEntryControl6.Image = null;
            this.characterEntryControl6.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl6, "characterEntryControl6");
            this.characterEntryControl6.Name = "characterEntryControl6";
            this.characterEntryControl6.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl6.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // characterEntryControl5
            // 
            this.characterEntryControl5.ButtonName = "キャラクター5";
            this.characterEntryControl5.Image = null;
            this.characterEntryControl5.ImageBackground = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.characterEntryControl5, "characterEntryControl5");
            this.characterEntryControl5.Name = "characterEntryControl5";
            this.characterEntryControl5.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            this.characterEntryControl5.DoubleClick += new System.EventHandler(this.OnCharacterEntryControlDoubleClick);
            this.characterEntryControl5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnCharacterEntryControlKeyDown);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemOption;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemVersion;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreference;
        private CharacterEntryView characterEntryControl1;
        private CharacterEntryView characterEntryControl2;
        private CharacterEntryView characterEntryControl3;
        private CharacterEntryView characterEntryControl4;
        private CharacterEntryView characterEntryControl5;
        private CharacterEntryView characterEntryControl6;
        private CharacterEntryView characterEntryControl7;
        private CharacterEntryView characterEntryControl8;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemMaterialManagement;
        private System.Windows.Forms.Button buttonMaterialManage;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelOutputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisplayImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

