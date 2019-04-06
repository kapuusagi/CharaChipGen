using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.MainForm
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        private string editFilePath; // 編集中のデータのファイルパス

        public MainForm()
        {
            editFilePath = "";
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMaterialManage_clicked(object sender, EventArgs e)
        {
            CharaChipGen.ManagementForm.MaterialManagementForm form
                = new CharaChipGen.ManagementForm.MaterialManagementForm();
            // モーダルダイアログとして表示する。
            form.ShowDialog(this);
        }

        private void OnCharacterBtn1_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl1, 0);
        }

        private void OnCharacterBtn2_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl2, 1);
        }

        private void OnCharacterBtn3_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl3, 2);
        }

        private void OnCharacterBtn4_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl4, 3);
        }

        private void OnCharacterBtn5_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl5, 4);
        }

        private void OnCharacterBtn6_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl6, 5);
        }

        private void OnCharacterBtn7_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl7, 6);
        }

        private void OnCharacterBtn8_clicked(object sender, EventArgs e)
        {
            OnCharacterBtn_clicked(characterEntryControl8, 7);
        }

        private void OnCharacterBtn_clicked(CharacterEntryView view, int index)
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

        private void OnExportButton_click(object sender, EventArgs evt)
        {
            // エクスポートボタンが押されたらエクスポート処理する。
            DialogResult res = saveFileDialogExport.ShowDialog(this);
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
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }

        }

        private void OnConfigButton_click(object sender, EventArgs e)
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
        }

        private void OnNewFile_click(object sender, EventArgs e)
        {
            // 新規作成が押された
            // データをリセットする。
            editFilePath = "";
            AppData appData = AppData.GetInstance();
            for (int i = 0; i < appData.CharaChipDataCount; i++)
            {
                appData.GetCharaChipData(i).Reset();
            }
        }

        private void OnOpen_click(object sender, EventArgs evt)
        {
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }
            try
            {
                SettingFileController.Load(openFileDialog.FileName);
                editFilePath = openFileDialog.FileName;

                // Note: 本当はCharaChipDataModelをViewに設定して
                //       ここに余計なコードを書かない方が美しい。
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
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        private void OnSave_click(object sender, EventArgs evt)
        {
            if (editFilePath == "")
            {
                OnSaveAs_click(sender, evt);
                return;
            }
            else
            {
                try
                {
                    SettingFileController.Save(editFilePath);
                }
                catch(Exception e)
                {
                    MessageBox.Show(this, e.Message, "エラー");
                }

            }
        }

        private void OnSaveAs_click(object sender, EventArgs evt)
        {
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
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }
    }
}
