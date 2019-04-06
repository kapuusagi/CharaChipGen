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

    }
}
