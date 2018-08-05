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
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.オプションToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.規格選択ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.オプションToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(717, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.SaveToolStripMenuItem,
            this.SaveAsNewToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ExportToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ExitToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.NewToolStripMenuItem.Text = "新規作成";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.OnNewFile_click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.OpenToolStripMenuItem.Text = "開く";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OnOpen_click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.SaveToolStripMenuItem.Text = "上書き保存";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.OnSave_click);
            // 
            // SaveAsNewToolStripMenuItem
            // 
            this.SaveAsNewToolStripMenuItem.Name = "SaveAsNewToolStripMenuItem";
            this.SaveAsNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsNewToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.SaveAsNewToolStripMenuItem.Text = "名前を付けて保存";
            this.SaveAsNewToolStripMenuItem.Click += new System.EventHandler(this.OnSaveAs_click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ExportToolStripMenuItem.Text = "エクスポート";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.OnExportButton_click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(229, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ExitToolStripMenuItem.Text = "閉じる";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // オプションToolStripMenuItem
            // 
            this.オプションToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.規格選択ToolStripMenuItem,
            this.materialManageToolStripMenuItem});
            this.オプションToolStripMenuItem.Name = "オプションToolStripMenuItem";
            this.オプションToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.オプションToolStripMenuItem.Text = "オプション";
            // 
            // 規格選択ToolStripMenuItem
            // 
            this.規格選択ToolStripMenuItem.Name = "規格選択ToolStripMenuItem";
            this.規格選択ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.規格選択ToolStripMenuItem.Text = "設定";
            this.規格選択ToolStripMenuItem.Click += new System.EventHandler(this.OnConfigButton_click);
            // 
            // materialManageToolStripMenuItem
            // 
            this.materialManageToolStripMenuItem.Name = "materialManageToolStripMenuItem";
            this.materialManageToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.materialManageToolStripMenuItem.Text = "素材管理";
            this.materialManageToolStripMenuItem.Click += new System.EventHandler(this.OnMaterialManage_clicked);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョン情報ToolStripMenuItem});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonExport.Location = new System.Drawing.Point(545, 437);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(158, 38);
            this.buttonExport.TabIndex = 10;
            this.buttonExport.Text = "エクスポート";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.OnExportButton_click);
            // 
            // buttonMaterialManage
            // 
            this.buttonMaterialManage.Location = new System.Drawing.Point(13, 446);
            this.buttonMaterialManage.Name = "buttonMaterialManage";
            this.buttonMaterialManage.Size = new System.Drawing.Size(75, 23);
            this.buttonMaterialManage.TabIndex = 11;
            this.buttonMaterialManage.Text = "素材管理";
            this.buttonMaterialManage.UseVisualStyleBackColor = true;
            this.buttonMaterialManage.Click += new System.EventHandler(this.OnMaterialManage_clicked);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(464, 446);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 12;
            this.buttonConfig.Text = "設定";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.OnConfigButton_click);
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
            this.characterEntryControl8.Location = new System.Drawing.Point(535, 232);
            this.characterEntryControl8.Name = "characterEntryControl8";
            this.characterEntryControl8.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl8.TabIndex = 9;
            this.characterEntryControl8.ButtonClick += new System.EventHandler(this.OnCharacterBtn8_clicked);
            // 
            // characterEntryControl7
            // 
            this.characterEntryControl7.ButtonName = "キャラクター7";
            this.characterEntryControl7.FaceImage = null;
            this.characterEntryControl7.Image = null;
            this.characterEntryControl7.Location = new System.Drawing.Point(361, 232);
            this.characterEntryControl7.Name = "characterEntryControl7";
            this.characterEntryControl7.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl7.TabIndex = 8;
            this.characterEntryControl7.ButtonClick += new System.EventHandler(this.OnCharacterBtn7_clicked);
            // 
            // characterEntryControl6
            // 
            this.characterEntryControl6.ButtonName = "キャラクター6";
            this.characterEntryControl6.FaceImage = null;
            this.characterEntryControl6.Image = null;
            this.characterEntryControl6.Location = new System.Drawing.Point(187, 232);
            this.characterEntryControl6.Name = "characterEntryControl6";
            this.characterEntryControl6.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl6.TabIndex = 7;
            this.characterEntryControl6.ButtonClick += new System.EventHandler(this.OnCharacterBtn6_clicked);
            // 
            // characterEntryControl5
            // 
            this.characterEntryControl5.ButtonName = "キャラクター5";
            this.characterEntryControl5.FaceImage = null;
            this.characterEntryControl5.Image = null;
            this.characterEntryControl5.Location = new System.Drawing.Point(13, 232);
            this.characterEntryControl5.Name = "characterEntryControl5";
            this.characterEntryControl5.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl5.TabIndex = 6;
            this.characterEntryControl5.ButtonClick += new System.EventHandler(this.OnCharacterBtn5_clicked);
            // 
            // characterEntryControl4
            // 
            this.characterEntryControl4.ButtonName = "キャラクター4";
            this.characterEntryControl4.FaceImage = null;
            this.characterEntryControl4.Image = null;
            this.characterEntryControl4.Location = new System.Drawing.Point(535, 28);
            this.characterEntryControl4.Name = "characterEntryControl4";
            this.characterEntryControl4.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl4.TabIndex = 5;
            this.characterEntryControl4.ButtonClick += new System.EventHandler(this.OnCharacterBtn4_clicked);
            // 
            // characterEntryControl3
            // 
            this.characterEntryControl3.ButtonName = "キャラクター3";
            this.characterEntryControl3.FaceImage = null;
            this.characterEntryControl3.Image = null;
            this.characterEntryControl3.Location = new System.Drawing.Point(361, 28);
            this.characterEntryControl3.Name = "characterEntryControl3";
            this.characterEntryControl3.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl3.TabIndex = 4;
            this.characterEntryControl3.ButtonClick += new System.EventHandler(this.OnCharacterBtn3_clicked);
            // 
            // characterEntryControl2
            // 
            this.characterEntryControl2.ButtonName = "キャラクター2";
            this.characterEntryControl2.FaceImage = null;
            this.characterEntryControl2.Image = null;
            this.characterEntryControl2.Location = new System.Drawing.Point(187, 27);
            this.characterEntryControl2.Name = "characterEntryControl2";
            this.characterEntryControl2.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl2.TabIndex = 3;
            this.characterEntryControl2.ButtonClick += new System.EventHandler(this.OnCharacterBtn2_clicked);
            // 
            // characterEntryControl1
            // 
            this.characterEntryControl1.ButtonName = "キャラクター1";
            this.characterEntryControl1.FaceImage = null;
            this.characterEntryControl1.Image = null;
            this.characterEntryControl1.Location = new System.Drawing.Point(13, 28);
            this.characterEntryControl1.Name = "characterEntryControl1";
            this.characterEntryControl1.Size = new System.Drawing.Size(168, 188);
            this.characterEntryControl1.TabIndex = 2;
            this.characterEntryControl1.ButtonClick += new System.EventHandler(this.OnCharacterBtn1_clicked);
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "PNGファイル|*.png";
            this.saveFileDialogExport.Title = "キャラチップ保存設定";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 481);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.buttonMaterialManage);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.characterEntryControl8);
            this.Controls.Add(this.characterEntryControl7);
            this.Controls.Add(this.characterEntryControl6);
            this.Controls.Add(this.characterEntryControl5);
            this.Controls.Add(this.characterEntryControl4);
            this.Controls.Add(this.characterEntryControl3);
            this.Controls.Add(this.characterEntryControl2);
            this.Controls.Add(this.characterEntryControl1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "キャラクターチップジェネレータ";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem オプションToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 規格選択ToolStripMenuItem;
        private CharacterEntryView characterEntryControl1;
        private CharacterEntryView characterEntryControl2;
        private CharacterEntryView characterEntryControl3;
        private CharacterEntryView characterEntryControl4;
        private CharacterEntryView characterEntryControl5;
        private CharacterEntryView characterEntryControl6;
        private CharacterEntryView characterEntryControl7;
        private CharacterEntryView characterEntryControl8;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolStripMenuItem materialManageToolStripMenuItem;
        private System.Windows.Forms.Button buttonMaterialManage;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
    }
}

