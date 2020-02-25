using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;
using CGenImaging;

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

        private void OnExitToolStripMenuItemClick(object sender, EventArgs evt)
        {
            Close();
        }

        private void OnMaterialManageClicked(object sender, EventArgs e)
        {
            CharaChipGen.ManagementForm.MaterialManagementForm form
                = new CharaChipGen.ManagementForm.MaterialManagementForm();
            // モーダルダイアログとして表示する。
            form.ShowDialog(this);
        }

        private void OnCharacterBtn1Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl1, 0);
        }

        private void OnCharacterBtn2Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl2, 1);
        }

        private void OnCharacterBtn3Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl3, 2);
        }

        private void OnCharacterBtn4Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl4, 3);
        }

        private void OnCharacterBtn5Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl5, 4);
        }

        private void OnCharacterBtn6Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl6, 5);
        }

        private void OnCharacterBtn7Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl7, 6);
        }

        private void OnCharacterBtn8Clicked(object sender, EventArgs e)
        {
            OnCharacterBtnClicked(characterEntryControl8, 7);
        }

        private void OnCharacterBtnClicked(CharacterEntryView view, int index)
        {
            CharaChipGen.GeneratorForm.CharaChipGeneratorForm form
                = new CharaChipGen.GeneratorForm.CharaChipGeneratorForm();
            form.Text = String.Format("キャラクター {0} - キャラチップ設定", index);

            // モデルを設定する。
            AppData appData = AppData.GetInstance();
            appData.GetCharaChipData(index).CopyTo(form.CharaChipDataModel);

            DialogResult result = form.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            // 反映処理する。
            form.CharaChipDataModel.CopyTo(appData.GetCharaChipData(index));

            UpdateEntryView(view, appData.GetCharaChipData(index));
        }

        /// <summary>
        /// UIのエントリ表示部分を全て更新する。
        /// </summary>
        private void UpdateAllEntryView()
        {
            AppData appData = AppData.GetInstance();
            UpdateEntryView(characterEntryControl1, appData.GetCharaChipData(0));
            UpdateEntryView(characterEntryControl2, appData.GetCharaChipData(1));
            UpdateEntryView(characterEntryControl3, appData.GetCharaChipData(2));
            UpdateEntryView(characterEntryControl4, appData.GetCharaChipData(3));
            UpdateEntryView(characterEntryControl5, appData.GetCharaChipData(4));
            UpdateEntryView(characterEntryControl6, appData.GetCharaChipData(5));
            UpdateEntryView(characterEntryControl7, appData.GetCharaChipData(6));
            UpdateEntryView(characterEntryControl8, appData.GetCharaChipData(7));
        }

        /// <summary>
        /// UIのエントリ表示部分を更新する。
        /// </summary>
        /// <param name="view">ビュー</param>
        /// <param name="dataModel">対応するデータモデル</param>
        private void UpdateEntryView(CharacterEntryView view, CharaChipDataModel dataModel)
        {
            // キャラクタチップデータ
            CharaChipRenderModel renderModel = new CharaChipRenderModel();
            dataModel.CopyTo(renderModel.CharaChipDataModel);
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

            // フェイスデータ
            CharaFaceRenderModel faceRenderModel = new CharaFaceRenderModel();
            dataModel.CopyTo(faceRenderModel.CharaChipDataModel);
            Size facePrefSize = view.ImageAreaSize;
            if ((facePrefSize.Width > 0) && (facePrefSize.Height > 0))
            {
                ImageBuffer faceBuffer = ImageBuffer.Create(facePrefSize.Width, facePrefSize.Height);
                CharaFaceGenerator.Draw(faceRenderModel, faceBuffer);

                view.FaceImage = faceBuffer.GetImage();
            } else
            {
                view.FaceImage = null;
            }
        }

        /// <summary>
        /// エクスポートボタンが押された時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnExportButtonClick(object sender, EventArgs evt)
        {
            // エクスポートボタンが押されたらエクスポート処理する。

            RestoreDialog(saveFileDialogExport, Properties.Settings.Default.LastSavePath);
            DialogResult res = saveFileDialogExport.ShowDialog();
            if (res != DialogResult.OK)
            {
                return; // OK押されていない。
            }

            try
            {
                string charaChipPath = saveFileDialogExport.FileName;
                string dir = System.IO.Path.GetDirectoryName(charaChipPath);
                string baseName = System.IO.Path.GetFileNameWithoutExtension(charaChipPath);
                string facePath = System.IO.Path.Combine(dir, baseName + "_face.png");

                CharaChipExporter.ExportCharaChip(charaChipPath);
                CharaChipExporter.ExportFace(facePath);

                // 最後にエクスポートしたパスを保存
                Properties.Settings.Default.LastExportPath = charaChipPath;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }

        }

        private void OnConfigButtonClick(object sender, EventArgs e)
        {
            // 設定ボタンが押されたとき
            CharaChipGen.ExportSettingForm.ExportSettingForm form
                = new CharaChipGen.ExportSettingForm.ExportSettingForm();

            AppData appData = AppData.GetInstance();

            form.CharaChipSize = appData.ExportSetting.CharaChipSize;
            form.FaceSize = appData.ExportSetting.FaceSize;
            form.IsExpandTwice = appData.ExportSetting.IsRenderTwice;

            DialogResult res = form.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            appData.ExportSetting.CharaChipSize = form.CharaChipSize;
            appData.ExportSetting.FaceSize = form.FaceSize;
            appData.ExportSetting.IsRenderTwice = form.IsExpandTwice;
            appData.ExportSetting.Save();
        }

        private void OnNewFileClick(object sender, EventArgs e)
        {
            // 新規作成が押された
            // データをリセットする。
            editFilePath = "";
            AppData appData = AppData.GetInstance();
            for (int i = 0; i < appData.CharaChipDataCount; i++)
            {
                appData.GetCharaChipData(i).Reset();
            }

            // モデルに合わせてUIの表示更新
            UpdateAllEntryView();
        }

        private void OnOpenClick(object sender, EventArgs evt)
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
            SettingFileController.Load(path);
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
            SettingFileController.Save(path);
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
                catch(Exception e)
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
                SettingFileController.Save(filePath);
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
            AppData.GetInstance().ExportSetting.Load();

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

        private void OnToolStripMenuItemVersionClick(object sender, EventArgs e)
        {
            VersionForm form = new VersionForm();
            form.ShowDialog(this);
        }
    }
}
