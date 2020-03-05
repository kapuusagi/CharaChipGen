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
        private const string PreviousSavedFileName = "CharaChipGen.tmp.ccgset";
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

            // 素材が変更されたかもしれないので、UIの表示を変更する。
            UpdateAllEntryViews();
        }

        /// <summary>
        /// キャラクターエントリービューのボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCharacterEntryViewButtonClick(object sender, EventArgs e)
        {
            int index = GetCharacterIndexByView(sender);
            if (index >= 0)
            {
                CharacterChipEditProc((CharacterEntryView)(sender), index);
            }
        }

        /// <summary>
        /// キャラクターエントリビュー
        /// </summary>
        private CharacterEntryView[] CharacterEntryViews {
            get => new CharacterEntryView[]
            {
                characterEntryControl1,
                characterEntryControl2,
                characterEntryControl3,
                characterEntryControl4,
                characterEntryControl5,
                characterEntryControl6,
                characterEntryControl7,
                characterEntryControl8,
            };
        }

        /// <summary>
        /// 送信元オブジェクトからキャラクターモデルのインデックス番号を取得する。
        /// 
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <returns>インデックス番号。該当するものがない場合には-1</returns>
        private int GetCharacterIndexByView(object sender)
        {
            CharacterEntryView[] characterEntryViews = CharacterEntryViews;

            for (int i = 0; i < characterEntryViews.Length; i++)
            {
                if (characterEntryViews[i] == sender)
                {
                    return i;
                }
            }

            return -1;
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
            appData.GeneratorSetting.GetCharacter(index).CopyTo(form.Character);

            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            // 反映処理する。
            form.Character.CopyTo(appData.GeneratorSetting.GetCharacter(index));

            UpdateEntryView(view, appData.GeneratorSetting.GetCharacter(index));
        }

        /// <summary>
        /// UIのエントリ表示部分を全て更新する。
        /// </summary>
        private void UpdateAllEntryViews()
        {
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;
            CharacterEntryView[] views = CharacterEntryViews;
            for (int i = 0; i < views.Length; i++)
            {
                UpdateEntryView(views[i], setting.GetCharacter(i));
            }
        }

        /// <summary>
        /// UIのエントリ表示部分を更新する。
        /// </summary>
        /// <param name="view">ビュー</param>
        /// <param name="character">対応するデータモデル</param>
        private void UpdateEntryView(CharacterEntryView view, Character character)
        {
            // キャラクタチップデータ
            CharaChipRenderData renderData = new CharaChipRenderData();
            character.CopyTo(renderData.Character);
            Size cchipPrefSize = renderData.PreferredSize;
            if ((cchipPrefSize.Width > 0) && (cchipPrefSize.Height > 0))
            {
                ImageBuffer charaChipBuffer = ImageBuffer.Create(cchipPrefSize.Width, cchipPrefSize.Height);
                CharaChipRenderer.Draw(renderData, charaChipBuffer, 1, 0);
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

            form.StoreToSetting(setting.ExportSetting);

            labelOutputPath.Text = setting.ExportSetting.ExportFilePath;
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
            UpdateAllEntryViews();
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

            // Note: 本当はComponentModelをViewに設定して
            //       変更があったらViewが自動的に更新されるようにして、
            //       ここに余計なコードを書かない方が美しい。
            UpdateAllEntryViews();

            labelOutputPath.Text = setting.ExportSetting.ExportFilePath;
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

        /// <summary>
        /// クリップボードにコピーする
        /// </summary>
        /// <param name="view">ビュー</param>
        /// <param name="character">クリップボードにコピーするキャラクター</param>
        private void CopyCharacter(CharacterEntryView view, Character character)
        {
            CharacterWriter cw = new CharacterWriter();
            using (System.IO.StringWriter writer = new System.IO.StringWriter())
            {
                cw.Write(writer, character);
                writer.Flush();
                string text = writer.ToString();
                Clipboard.SetText(text);
            }
        }

        /// <summary>
        /// クリップボードからコピーする。
        /// </summary>
        /// <param name="view">ビュー</param>
        /// <param name="character">クリップボードからコピーするキャラクター</param>
        private void PasteCharacter(CharacterEntryView view, Character character)
        {

            string text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            CharacterReader cr = new CharacterReader();
            System.IO.StringReader reader = new System.IO.StringReader(text);
            Character readCharacter = cr.Read(reader);
            readCharacter.CopyTo(character);

            UpdateEntryView(view, character);
        }

        /// <summary>
        /// キーが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCharacterEntryControlKeyDown(object sender, KeyEventArgs e)
        {
            CharacterEntryView view = sender as CharacterEntryView;
            int index = GetCharacterIndexByView(sender);
            if (index < 0)
            {
                return;
            }

            try
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CopyCharacter(view, AppData.Instance.GeneratorSetting.GetCharacter(index));
                            e.Handled = true;
                            break;
                        case Keys.V:
                            PasteCharacter(view, AppData.Instance.GeneratorSetting.GetCharacter(index));
                            e.Handled = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// コピーメニューが選択された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemCopyClick(object sender, EventArgs e)
        {
            CharacterEntryView view = GetSelectedEntryView();
            if (view == null)
            {
                return;
            }
            try
            {
                int index = GetCharacterIndexByView(view);
                Character character = AppData.Instance.GeneratorSetting.GetCharacter(index);
                CopyCharacter(view, character);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }

        }

        /// <summary>
        /// ペーストメニューが選択された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemPasteClick(object sender, EventArgs e)
        {
            CharacterEntryView view = GetSelectedEntryView();
            if (view == null)
            {
                return;
            }
            try
            {
                int index = GetCharacterIndexByView(view);
                Character character = AppData.Instance.GeneratorSetting.GetCharacter(index);
                PasteCharacter(view, character);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 選択されているエントリビューを得る。
        /// </summary>
        /// <returns>選択されているエントリビュー。該当ビューが無い場合にはnull</returns>
        private CharacterEntryView GetSelectedEntryView()
        {
            CharacterEntryView[] characterEntryViews = CharacterEntryViews;
            foreach (CharacterEntryView view in characterEntryViews)
            {
                if (view.ActiveControl != null)
                {
                    return view;
                }
            }
            return null;
        }
    }
}
