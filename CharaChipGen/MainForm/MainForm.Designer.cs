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
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreference = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMaterialManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonMaterialManage = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.characterEntryControl8 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl7 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl6 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl5 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl4 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl3 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl2 = new CharaChipGen.MainForm.CharacterEntryView();
            this.characterEntryControl1 = new CharaChipGen.MainForm.CharacterEntryView();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemOption,
            this.menuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(727, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
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
            this.menuItemFile.Size = new System.Drawing.Size(53, 20);
            this.menuItemFile.Text = "ファイル";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemNew.Size = new System.Drawing.Size(232, 22);
            this.menuItemNew.Text = "新規作成";
            this.menuItemNew.Click += new System.EventHandler(this.OnMenuItemNewClick);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpen.Size = new System.Drawing.Size(232, 22);
            this.menuItemOpen.Text = "開く";
            this.menuItemOpen.Click += new System.EventHandler(this.OnMenuItemOpenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(232, 22);
            this.menuItemSave.Text = "上書き保存";
            this.menuItemSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.menuItemSaveAs.Size = new System.Drawing.Size(232, 22);
            this.menuItemSaveAs.Text = "名前を付けて保存";
            this.menuItemSaveAs.Click += new System.EventHandler(this.OnSaveAsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemExport
            // 
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(232, 22);
            this.menuItemExport.Text = "エクスポート";
            this.menuItemExport.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(232, 22);
            this.menuItemExit.Text = "閉じる";
            this.menuItemExit.Click += new System.EventHandler(this.OnMenuItemExitClick);
            // 
            // menuItemOption
            // 
            this.menuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPreference,
            this.menuItemMaterialManagement});
            this.menuItemOption.Name = "menuItemOption";
            this.menuItemOption.Size = new System.Drawing.Size(63, 20);
            this.menuItemOption.Text = "オプション";
            // 
            // menuItemPreference
            // 
            this.menuItemPreference.Name = "menuItemPreference";
            this.menuItemPreference.Size = new System.Drawing.Size(180, 22);
            this.menuItemPreference.Text = "設定";
            this.menuItemPreference.Click += new System.EventHandler(this.OnPreferenceClick);
            // 
            // menuItemMaterialManagement
            // 
            this.menuItemMaterialManagement.Name = "menuItemMaterialManagement";
            this.menuItemMaterialManagement.Size = new System.Drawing.Size(180, 22);
            this.menuItemMaterialManagement.Text = "素材管理";
            this.menuItemMaterialManagement.Click += new System.EventHandler(this.OnMaterialManageClicked);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVersion});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(48, 20);
            this.menuItemHelp.Text = "ヘルプ";
            // 
            // menuItemVersion
            // 
            this.menuItemVersion.Name = "menuItemVersion";
            this.menuItemVersion.Size = new System.Drawing.Size(142, 22);
            this.menuItemVersion.Text = "バージョン情報";
            this.menuItemVersion.Click += new System.EventHandler(this.OnMenuItemVersionClick);
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonExport.Location = new System.Drawing.Point(90, 9);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(158, 38);
            this.buttonExport.TabIndex = 10;
            this.buttonExport.Text = "エクスポート";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // buttonMaterialManage
            // 
            this.buttonMaterialManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMaterialManage.Location = new System.Drawing.Point(9, 17);
            this.buttonMaterialManage.Name = "buttonMaterialManage";
            this.buttonMaterialManage.Size = new System.Drawing.Size(75, 23);
            this.buttonMaterialManage.TabIndex = 11;
            this.buttonMaterialManage.Text = "素材管理";
            this.buttonMaterialManage.UseVisualStyleBackColor = true;
            this.buttonMaterialManage.Click += new System.EventHandler(this.OnMaterialManageClicked);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConfig.Location = new System.Drawing.Point(9, 24);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 12;
            this.buttonConfig.Text = "設定";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.OnPreferenceClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "設定保存ファイル|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "設定保存ファイル|*.xml";
            // 
            // characterEntryControl8
            // 
            this.characterEntryControl8.ButtonName = "キャラクター8";
            this.characterEntryControl8.FaceImage = null;
            this.characterEntryControl8.Image = null;
            this.characterEntryControl8.Location = new System.Drawing.Point(543, 204);
            this.characterEntryControl8.Name = "characterEntryControl8";
            this.characterEntryControl8.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl8.TabIndex = 9;
            this.characterEntryControl8.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl7
            // 
            this.characterEntryControl7.ButtonName = "キャラクター7";
            this.characterEntryControl7.FaceImage = null;
            this.characterEntryControl7.Image = null;
            this.characterEntryControl7.Location = new System.Drawing.Point(365, 204);
            this.characterEntryControl7.Name = "characterEntryControl7";
            this.characterEntryControl7.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl7.TabIndex = 8;
            this.characterEntryControl7.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl6
            // 
            this.characterEntryControl6.ButtonName = "キャラクター6";
            this.characterEntryControl6.FaceImage = null;
            this.characterEntryControl6.Image = null;
            this.characterEntryControl6.Location = new System.Drawing.Point(187, 204);
            this.characterEntryControl6.Name = "characterEntryControl6";
            this.characterEntryControl6.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl6.TabIndex = 7;
            this.characterEntryControl6.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl5
            // 
            this.characterEntryControl5.ButtonName = "キャラクター5";
            this.characterEntryControl5.FaceImage = null;
            this.characterEntryControl5.Image = null;
            this.characterEntryControl5.Location = new System.Drawing.Point(9, 204);
            this.characterEntryControl5.Name = "characterEntryControl5";
            this.characterEntryControl5.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl5.TabIndex = 6;
            this.characterEntryControl5.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl4
            // 
            this.characterEntryControl4.ButtonName = "キャラクター4";
            this.characterEntryControl4.FaceImage = null;
            this.characterEntryControl4.Image = null;
            this.characterEntryControl4.Location = new System.Drawing.Point(543, 9);
            this.characterEntryControl4.Name = "characterEntryControl4";
            this.characterEntryControl4.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl4.TabIndex = 5;
            this.characterEntryControl4.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl3
            // 
            this.characterEntryControl3.ButtonName = "キャラクター3";
            this.characterEntryControl3.FaceImage = null;
            this.characterEntryControl3.Image = null;
            this.characterEntryControl3.Location = new System.Drawing.Point(365, 9);
            this.characterEntryControl3.Name = "characterEntryControl3";
            this.characterEntryControl3.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl3.TabIndex = 4;
            this.characterEntryControl3.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl2
            // 
            this.characterEntryControl2.ButtonName = "キャラクター2";
            this.characterEntryControl2.FaceImage = null;
            this.characterEntryControl2.Image = null;
            this.characterEntryControl2.Location = new System.Drawing.Point(187, 9);
            this.characterEntryControl2.Name = "characterEntryControl2";
            this.characterEntryControl2.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl2.TabIndex = 3;
            this.characterEntryControl2.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // characterEntryControl1
            // 
            this.characterEntryControl1.ButtonName = "キャラクター1";
            this.characterEntryControl1.FaceImage = null;
            this.characterEntryControl1.Image = null;
            this.characterEntryControl1.Location = new System.Drawing.Point(9, 9);
            this.characterEntryControl1.Name = "characterEntryControl1";
            this.characterEntryControl1.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl1.TabIndex = 2;
            this.characterEntryControl1.ButtonClick += new System.EventHandler(this.OnCharacterEntryViewButtonClick);
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "PNGファイル|*.png";
            this.saveFileDialogExport.Title = "キャラチップ保存設定";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 55);
            this.panel1.TabIndex = 13;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.buttonMaterialManage);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(109, 55);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonConfig);
            this.flowLayoutPanel1.Controls.Add(this.buttonExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(452, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(275, 55);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.characterEntryControl5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 402);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "キャラクターチップジェネレータ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
    }
}

