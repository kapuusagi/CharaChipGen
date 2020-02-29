using System.Drawing;

namespace CharaChipGen.Model
{
    /// <summary>
    /// エクスポート設定
    /// </summary>
    public class ExportSetting
    {
        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting()
        {
        }

        /// <summary>
        /// キャラクターサイズ
        /// </summary>
        public Size CharaChipSize { get; set; }

        /// <summary>
        /// 出力ファイルパス
        /// </summary>
        public string ExportFilePath { get; set; }

        /// <summary>
        /// settingに設定をコピーする。
        /// </summary>
        /// <param name="setting">ExportSettingオブジェクト</param>
        public void CopyTo(ExportSetting setting)
        {
            setting.CharaChipSize = CharaChipSize;
            setting.ExportFilePath = ExportFilePath;
        }
    }
}
