﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CharaChipGen.Imaging;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクタチップをレンダリングする際の１つのレイヤーを表すモデル。
    /// </summary>
    class CharaChipRenderLayerModel
    {
        private string layerName; // レイヤー名
        private Image image; // レイヤーのオリジナルイメージデータ
        private int offsetX; // オフセットX
        private int offsetY; // オフセットY
        private int hue; // 色相
        private int saturation; // 彩度
        private int value; // 輝度
        private ImageBuffer processedImage; // 処理済みデータ

        /// <summary>
        /// キャラクターチップ生成のレイヤーを表すモデル
        /// </summary>
        /// <param name="layerName"></param>
        public CharaChipRenderLayerModel(string layerName)
        {
            this.layerName = layerName;
            this.image = null;
            this.offsetX = 0;
            this.offsetY = 0;
            this.hue = 0;
            this.saturation = 0;
            this.value = 0;
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
            set {
                if (((image == null) && (value == null))
                        || ((image != null) && (image.Equals(value)))) {
                    return; // 変更なし。
                }

                image = value;
                processedImage = null;
            }
        }
 
        /// <summary>
        /// オフセットX
        /// </summary>
        public int OffsetX
        {
            get { return offsetX; }
            set { offsetX = value; }
        }

        /// <summary>
        /// オフセットY
        /// </summary>
        public int OffsetY
        {
            get { return offsetY; }
            set { offsetY = value; }
        }

        /// <summary>
        /// 色相調整値
        /// </summary>
        public int Hue
        {
            get { return hue; }
            set {
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
                }
            }

            return processedImage;
        }

        /// <summary>
        /// 推奨する画像の幅
        /// </summary>
        public int PreferredWidth
        {
            get {
                return (this.image != null) 
                    ? image.Width + Math.Abs(offsetX) : Math.Abs(offsetX);
            }
        }

        /// <summary>
        /// 推奨する画像の高さ
        /// </summary>
        public int PreferredHeight
        {
            get {
                return (this.image != null) 
                    ? image.Height + Math.Abs(offsetY) : Math.Abs(offsetY);
            }
        }

    }
}
