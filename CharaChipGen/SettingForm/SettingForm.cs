using CharaChipGen.Model;
using CharaChipGen.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using CharaChipGen.CommonControl;

namespace CharaChipGen.ExportSettingForm
{
    /// <summary>
    /// 設定を行うUI
    /// </summary>
    public partial class SettingForm : Form
    {
        // フォルダ選択ダイアログ
        private FolderSelectDialog folderSelectDialog;
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定値をUIに反映させる。
        /// </summary>
        public void LoadFromSetting()
        {
            AppData data = AppData.Instance;
            ExportSetting exportSetting = data.GeneratorSetting.ExportSetting;
            sizeInputCharaChipSize.Value = exportSetting.CharaChipSize;
            labelMaterialDirectory.Text = data.MaterialDirectory;
            labelImageBackground.BackColor = Settings.Default.ImageBackground;

            textBoxExportFilePath.Text = exportSetting.ExportFilePath;
        }



        /// <summary>
        /// UIの値を設定値に格納する
        /// </summary>
        public void StoreToSetting()
        {
            AppData data = AppData.Instance;
            ExportSetting exportSetting = data.GeneratorSetting.ExportSetting;
            exportSetting.CharaChipSize = sizeInputCharaChipSize.Value;
            exportSetting.ExportFilePath = textBoxExportFilePath.Text;

            Settings.Default.MaterialDirectory = labelMaterialDirectory.Text;
            Settings.Default.CharaChipSize = sizeInputDefaultCharaChipSize.Value;
            Settings.Default.ImageBackground = labelImageBackground.BackColor;
        }

        /// <summary>
        /// OKボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnOKButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 出力ファイルパス選択ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSelectExportFilePathClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxExportFilePath.Text))
            {
                string dir = System.IO.Path.GetDirectoryName(textBoxExportFilePath.Text);
                saveFileDialog.InitialDirectory = dir;
                saveFileDialog.FileName = textBoxExportFilePath.Text;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxExportFilePath.Text = saveFileDialog.FileName;
            }

        }

        /// <summary>
        /// 素材フォルダ選択ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSelectMaterialFolderClick(object sender, EventArgs e)
        {
            if (folderSelectDialog == null)
            {
                folderSelectDialog = new FolderSelectDialog();
            }
            folderSelectDialog.Path = labelMaterialDirectory.Text;
            if (folderSelectDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            labelMaterialDirectory.Text = folderSelectDialog.Path;
        }

        /// <summary>
        /// 画像背景色欄がクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLabelImageBackgroundClick(object sender, EventArgs e)
        {
            Color defaultColor = labelImageBackground.BackColor;
            Color selectColor = CGenImaging.Forms.ColorSelectDialog.ShowDialog(this, defaultColor);
            labelImageBackground.BackColor = selectColor;
        }
    }
}
