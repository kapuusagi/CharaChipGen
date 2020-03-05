using CharaChipGen.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        /// 設定値をUIに反映させる。
        /// </summary>
        /// <param name="setting">エクスポート設定</param>
        public void LoadFromSetting(ExportSetting setting)
        {
            numericUpDownCharaChipWidth.Value = GetLimited(setting.CharaChipSize.Width,
                (int)(numericUpDownCharaChipWidth.Minimum), (int)(numericUpDownCharaChipWidth.Maximum));
            numericUpDownCharaChipHeight.Value = GetLimited(setting.CharaChipSize.Height,
                (int)(numericUpDownCharaChipHeight.Minimum), (int)(numericUpDownCharaChipHeight.Maximum));

            textBoxExportFilePath.Text = setting.ExportFilePath;
        }

        /// <summary>
        /// valueをmin～maxの間に制限した値を取得する。
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="min">下限値</param>
        /// <param name="max">上限値</param>
        /// <returns>制限された値</returns>
        private int GetLimited(int value, int min, int max)
        {
            return (value < min) ? min : ((value > max) ? max : value);
        }

        /// <summary>
        /// UIの値を設定値に格納する
        /// </summary>
        /// <param name="setting">エクスポート設定</param>
        public void StoreToSetting(ExportSetting setting)
        {
            setting.CharaChipSize = new Size()
            {
                Width = (int)(numericUpDownCharaChipWidth.Value),
                Height = (int)(numericUpDownCharaChipHeight.Value)
            };
            setting.ExportFilePath = textBoxExportFilePath.Text;
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
