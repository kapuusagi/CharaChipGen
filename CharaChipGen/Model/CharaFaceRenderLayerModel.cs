using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CGenImaging;

namespace CharaChipGen.Model
{
    class CharaFaceRenderLayerModel
    {
        /// <summary>
        /// フェイスデータをレンダリングする際の１つのレイヤーを表すモデル
        /// </summary>
        private string layerName; // レイヤー名
        private Image image; // レイヤーのオリジナルイメージ
        private int hue; // 色相
        private int saturation; // 彩度
        private int value; // 輝度
        private int opacity; // 不透明度
        private ImageBuffer processedImage; // 処理済みデータ

        /// <summary>
        /// キャラクタフェイス生成のレイヤーを表すモデル
        /// </summary>
        /// <param name="layerName"></param>
        public CharaFaceRenderLayerModel(string layerName)
        {
            this.layerName = layerName;
            this.image = null;
            this.hue = 0;
            this.saturation = 0;
            this.hue = 0;
            this.opacity = 100;
        }
        /// <summary>
        /// レイヤー名
        /// </summary>
        public String LayerName
        {
            get { return layerName; }
        }

        /// <summary>
        /// レイヤーイメージ
        /// 未設定の場合にはnull
        /// </summary>
        public Image Image
        {
            get { return image; }
            set
            {
                if (image == value)
                {
                    return; // 変更なし。
                }
                image = value;
            }
        }

        /// <summary>
        /// 色相調整値
        /// </summary>
        public int Hue
        {
            get { return hue; }
            set
            {
                if (hue == value)
                {
                    return; // 変更なし
                }
                hue = value;
                processedImage = null;
            }
        }

        /// <summary>
        /// 彩度調整値
        /// </summary>
        public int Saturation
        {
            get { return saturation; }
            set
            {
                if (saturation == value)
                {
                    return; // 変更なし。
                }
                this.saturation = value;
                processedImage = null;
            }
        }

        /// <summary>
        /// 輝度調整値
        /// </summary>
        public int Value
        {
            get { return value; }
            set
            {
                if (this.value == value)
                {
                    return; // 変更なし。
                }
                this.value = value;
                processedImage = null;
            }
        }

        /// <summary>
        /// 不透明度調整値 (0-100)
        /// </summary>
        public int Opacity {
            get { return opacity; }
            set {
                if (this.opacity == value)
                {
                    return; // 変更なし。
                }
                this.opacity = value;
                processedImage = null;
            }
        }

        /// <summary>
        /// HSV加算演算済みのデータを取得する。
        /// </summary>
        /// <returns></returns>
        public ImageBuffer GetProcessedImage()
        {
            if (processedImage == null)
            {
                if (image != null)
                {
                    processedImage = ImageProcessor.ProcessHSVFilter(
                        ImageBuffer.CreateFrom(image), hue, saturation, value);
                    if (opacity < 100)
                    {
                        processedImage = ImageProcessor.ApplyOpacity(processedImage, opacity / 100.0f);
                    }
                }
            }

            return processedImage;
        }

        /// <summary>
        /// 推奨する画像の幅
        /// </summary>
        public int PreferredWidth
        {
            get { return (image != null) ? image.Width : 0; }
        }

        /// <summary>
        /// 推奨する画像の高さ
        /// </summary>
        public int PreferredHeight
        {
            get { return (image != null) ? image.Height : 0; }
        }
    }
}
