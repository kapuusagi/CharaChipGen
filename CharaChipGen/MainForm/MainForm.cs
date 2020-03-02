using CGenImaging;
using CharaChipGen.Model;
using CharaChipGen.Model.CharaChip;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.MainForm
{

    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 前回作業保存ファイル名。
        /// </summary>
        /// <remarks>
        /// アプリケーション終了時に保存され、起動時に読み込むために使用される。
        /// 前回作業の続きからやりたいよね。
        /// </remarks>
        private const string PreviousSavedFileName = "CharaChipGen.tmp.xml";
        /// <summary>
        /// 編集中のデータのファイルパス
        /// </summary>
        /// <remarks>
        /// 「保存」操作が行われたとき、保存ファイルパスとして使用される。
        /// </remarks>
        private string editFilePath;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MainForm()
        {
            editFilePath = "";
            InitializeComponent();
        }

        /// <summary>
        /// 閉じるボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMenuItemExitClick(object sender, EventArgs evt)
        {
            Close();
        }

        /// <summary>
        /// 素材管理メニュー/素材管理ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMaterialManageClicked(object sender, EventArgs e)
        {
            ManagementForm.MaterialManagementForm form
                = new ManagementForm.MaterialManagementForm();
            // モーダルダイアログとして表示する。
            form.ShowDialog(this);
        }

        /// <summary>
        /// キャラクターエントリービューのボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCharacterEntryViewButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(characterEntryControl1))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 0);
            }
            else if (sender.Equals(characterEntryControl2))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 1);
            }
            else if (sender.Equals(characterEntryControl3))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 2);
            }
            else if (sender.Equals(characterEntryControl4))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 3);
            }
            else if (sender.Equals(characterEntryControl5))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 4);
            }
            else if (sender.Equals(characterEntryControl6))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 5);
            }
            else if (sender.Equals(characterEntryControl7))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 6);
            }
            else if (sender.Equals(characterEntryControl8))
            {
                CharacterChipEditProc((CharacterEntryView)(sender), 7);
            }
        }

        /// <summary>
        /// キャラクターチップ編集処理を行う。
        /// </summary>
        /// <param name="view">キャラクターチップ表示コントロール</param>
        /// <param name="index">キャラクター編集対象のインデックス番号</param>
        private void CharacterChipEditProc(CharacterEntryView view, int index)
        {
            GeneratorForm.CharaChipGeneratorForm form
                = new GeneratorForm.CharaChipGeneratorForm();
            form.Text = String.Format("キャラクター {0} - キャラチップ設定", index);

            // モデルを設定する。
            AppData appData = AppData.Instance;
            appData.GeneratorSetting.GetCharacter(index).CopyTo(form.CharaChipDataModel);

            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            // 反映処理する。
            form.CharaChipDataModel.CopyTo(appData.GeneratorSetting.GetCharacter(index));

            UpdateEntryView(view, appData.GeneratorSetting.GetCharacter(index));
        }

        /// <summary>
        /// UIのエントリ表示部分を全て更新する。
        /// </summary>
        private void UpdateAllEntryView()
        {
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;

            UpdateEntryView(characterEntryControl1, setting.GetCharacter(0));
            UpdateEntryView(characterEntryControl2, setting.GetCharacter(1));
            UpdateEntryView(characterEntryControl3, setting.GetCharacter(2));
            UpdateEntryView(characterEntryControl4, setting.GetCharacter(3));
            UpdateEntryView(characterEntryControl5, setting.GetCharacter(4));
            UpdateEntryView(characterEntryControl6, setting.GetCharacter(5));
            UpdateEntryView(characterEntryControl7, setting.GetCharacter(6));
            UpdateEntryView(characterEntryControl8, setting.GetCharacter(7));
        }

        /// <summary>
        /// UIのエントリ表示部分を更新する。
        /// </summary>
        /// <param name="view">ビュー</param>
        /// <param name="dataModel">対応するデータモデル</param>
        private void UpdateEntryView(CharacterEntryView view, Character dataModel)
        {
            // キャラクタチップデータ
            CharaChipRenderData renderModel = new CharaChipRenderData();
            dataModel.CopyTo(renderModel.Character);
            Size cchipPrefSize = renderModel.PreferredSize;
            if ((cchipPrefSize.Width > 0) && (cchipPrefSize.Height > 0))
            {
                ImageBuffer charaChipBuffer = ImageBuffer.Create(cchipPrefSize.Width, cchipPrefSize.Height);
                CharaChipGenerator.Draw(renderModel, charaChipBuffer, 1, 0);
                view.Image = charaChipBuffer.GetImage();
            }
            else
            {
                view.Image = null;
            }
        }

        /// <summary>
        /// エクスポートメニュー/ボタンが押された時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnExportButtonClick(object sender, EventArgs evt)
        {
            // エクスポートボタンが押されたらエクスポート処理する。
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;
            if (string.IsNullOrEmpty(setting.ExportSetting.ExportFilePath))
            {
                RestoreDialog(saveFileDialogExport, Properties.Settings.Default.LastSavePath);
                DialogResult res = saveFileDialogExport.ShowDialog();
                if (res != DialogResult.OK)
                {
                    return; // OK押されていない。
                }
                setting.ExportSetting.ExportFilePath = saveFileDialogExport.FileName;
            }

            try
            {
                CharaChipExporter.ExportCharaChip(setting);
                MessageBox.Show(this, $" {setting.ExportSetting.ExportFilePath}", "Export succeed.");
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }

        }

        /// <summary>
        /// 設定メニュー/ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPreferenceClick(object sender, EventArgs e)
        {
            // 設定ボタンが押されたとき
            ExportSettingForm.ExportSettingForm form
                = new ExportSettingForm.ExportSettingForm();

            GeneratorSetting setting = AppData.Instance.GeneratorSetting;

            form.LoadFromSetting(setting.ExportSetting);

            DialogResult res = form.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            form.StorToSetting(setting.ExportSetting);

        }

        /// <summary>
        /// 新規作成メニューがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemNewClick(object sender, EventArgs e)
        {
            // 新規作成が押された
            // データをリセットする。
            editFilePath = "";
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;
            for (int i = 0; i < setting.GetCharacterCount(); i++)
            {
                setting.GetCharacter(i).Reset();
            }

            // モデルに合わせてUIの表示更新
            UpdateAllEntryView();
        }

        /// <summary>
        /// 開くメニュー項目がクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMenuItemOpenClick(object sender, EventArgs evt)
        {
            RestoreDialog(openFileDialog, Properties.Settings.Default.LastSavePath);
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }
            try
            {
                string fileName = openFileDialog.FileName;
                LoadDataProc(fileName);
                Properties.Settings.Default.LastSavePath = fileName;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        /// <summary>
        /// データを指定されたファイルからロードする。
        /// </summary>
        /// <param name="path">パス</param>
        private void LoadDataProc(string path)
        {
            GeneratorSettingReader reader = new GeneratorSettingReader();
            GeneratorSetting readSetting = reader.Read(path);

            GeneratorSetting setting = AppData.Instance.GeneratorSetting;
            readSetting.CopyTo(setting);


            editFilePath = openFileDialog.FileName;

            // Note: 本当はCharaChipDataModelをViewに設定して
            //       ここに余計なコードを書かない方が美しい。
            UpdateAllEntryView();
        }

        /// <summary>
        /// ファイルに保存する。
        /// </summary>
        /// <param name="path">パス</param>
        private void SaveDataProc(string path)
        {
            GeneratorSettingWriter writer = new GeneratorSettingWriter();
            writer.Write(path, AppData.Instance.GeneratorSetting);
        }

        /// <summary>
        /// 保存が選択されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベント</param>
        private void OnSaveClick(object sender, EventArgs evt)
        {
            if (editFilePath == "")
            {
                OnSaveAsClick(sender, evt);
                return;
            }
            else
            {
                try
                {
                    SaveDataProc(editFilePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message, "エラー");
                }

            }
        }

        /// <summary>
        /// 名前を付けて保存が選択されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnSaveAsClick(object sender, EventArgs evt)
        {
            RestoreDialog(saveFileDialog, Properties.Settings.Default.LastSavePath);
            DialogResult result = saveFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            string filePath = saveFileDialog.FileName;
            try
            {
                GeneratorSettingWriter writer = new GeneratorSettingWriter();
                writer.Write(filePath, AppData.Instance.GeneratorSetting);
                editFilePath = filePath;
                Properties.Settings.Default.LastSavePath = filePath;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        /// <summary>
        /// pathで指定される内容をダイアログに反映させる。
        /// </summary>
        /// <param name="dialog">ダイアログ</param>
        /// <param name="path">パス</param>
        private static void RestoreDialog(FileDialog dialog, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                dialog.FileName = "";
                dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            }
            else
            {
                string fileName = System.IO.Path.GetFileName(path);
                string dir = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(dir))
                {
                    dialog.FileName = "";
                    dialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                }
                else
                {
                    dialog.FileName = fileName;
                    dialog.InitialDirectory = dir;
                }
            }
        }

        /// <summary>
        /// 画面が表示されたときに通知を受け取る
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs evt)
        {
            string appDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string workTempPath = System.IO.Path.Combine(appDir, PreviousSavedFileName);
            if (System.IO.File.Exists(workTempPath))
            {
                try
                {
                    LoadDataProc(workTempPath);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }

        /// <summary>
        /// フォームがクローズされようとしている時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベント。</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs evt)
        {

            // 次回起動時、作業を継続できるように現在の設定を保存しておく。
            string appDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string workTempPath = System.IO.Path.Combine(appDir, PreviousSavedFileName);
            try
            {
                SaveDataProc(workTempPath);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// バージョンメニューがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemVersionClick(object sender, EventArgs e)
        {
            VersionForm form = new VersionForm();
            form.ShowDialog(this);
        }
    }
}
