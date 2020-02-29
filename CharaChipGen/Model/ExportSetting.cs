using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CharaChipGen.Model
{
    /// <summary>
    /// エクスポート設定
    /// </summary>
    public class ExportSetting
    {
        private Size charaChipSize; // キャラチップサイズ
        private Size faceSize; // 顔サイズ
        private bool isRenderTwice; // 2倍で描画するかどうか

        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting()
        {
            charaChipSize = new Size(32, 48);
            faceSize = new Size(96, 96);
            isRenderTwice = false;
        }

        /// <summary>
        /// 設定を読み出す。
        /// </summary>
        public void Load()
        {
            // アプリケーションが格納している設定をロード
            ParseSizeString(Properties.Settings.Default.CharacterSize, charaChipSize);
            ParseSizeString(Properties.Settings.Default.FaceSize, faceSize);
            isRenderTwice = Properties.Settings.Default.IsRenderTwice;
        }

        /// <summary>
        /// 設定を保存する。
        /// </summary>
        public void Save()
        {
            Properties.Settings.Default.CharacterSize = $"{charaChipSize.Width},{charaChipSize.Width}";
            Properties.Settings.Default.FaceSize = $"{faceSize.Width},{faceSize.Height}";
            Properties.Settings.Default.IsRenderTwice = isRenderTwice;
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }


        private static void ParseSizeString(string s, Size size)
        {
            try
            {
                string[] tokens = s.Split(',');
                if (tokens.Length >= 2)
                {
                    int width = Convert.ToInt32(tokens[0]);
                    int height = Convert.ToInt32(tokens[1]);
                    size.Width = width;
                    size.Height = height;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// キャラクターサイズ
        /// </summary>
        public Size CharaChipSize
        {
            get { return charaChipSize; }
            set { charaChipSize = value; }
        }

        /// <summary>
        /// 顔サイズ
        /// </summary>
        public Size FaceSize
        {
            get { return faceSize; }
            set { faceSize = value; }
        }

        /// <summary>
        /// 2倍のサイズで描画するかどうか
        /// </summary>
        public bool IsRenderTwice 
        {
            get { return isRenderTwice; }
            set { isRenderTwice = value; }
        }

        /// <summary>
        /// settingに設定をコピーする。
        /// </summary>
        /// <param name="setting">ExportSettingオブジェクト</param>
        public void CopyTo(ExportSetting setting)
        {
            setting.CharaChipSize = CharaChipSize;
        }
    }
}
