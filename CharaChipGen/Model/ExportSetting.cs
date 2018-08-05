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

        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting()
        {
            charaChipSize = new Size(32, 48);
            faceSize = new Size(96, 96);
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
    }
}
