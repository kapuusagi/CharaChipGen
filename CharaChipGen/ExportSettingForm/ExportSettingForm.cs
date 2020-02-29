using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.ExportSettingForm
{
    public partial class ExportSettingForm : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ExportSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// キャラチップサイズ
        /// </summary>
        public Size CharaChipSize {
            get {
                int width = (int)(numericUpDownCharaChipWidth.Value);
                int height = (int)(numericUpDownCharaChipHeight.Value);
                return new Size(width, height);
            }
            set {
                numericUpDownCharaChipWidth.Value = value.Width;
                numericUpDownCharaChipHeight.Value = value.Height;
            }
        }

        /// <summary>
        /// 出力ファイルパス
        /// </summary>
        public string ExportFilePath
        {
            get => textBoxExportFilePath.Text;
            set => textBoxExportFilePath.Text = value;           
        }


        /// <summary>
        /// 設定値をUIに反映させる。
        /// </summary>
        /// <param name="setting">エクスポート設定</param>
        public void LoadFromSetting(ExportSetting setting)
        {
            CharaChipSize = setting.CharaChipSize;
            ExportFilePath = setting.ExportFilePath;
        }

        /// <summary>
        /// UIの値を設定値に格納する
        /// </summary>
        /// <param name="setting">エクスポート設定</param>
        public void StorToSetting(ExportSetting setting)
        {
            setting.CharaChipSize = CharaChipSize;
            setting.ExportFilePath = ExportFilePath;
        }

        /// <summary>
        /// OKボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnOKButtonClick(object sender, EventArgs evt)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnCancelButtonClick(object sender, EventArgs evt)
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
    }
}
