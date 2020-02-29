using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using CGenImaging;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model.Layer
{
    /// <summary>
    /// キャラクタチップをレンダリングする際の１つのレイヤーを表すモデル。
    /// 1つのレイヤーに対して、オフセット/HSV変更を適用したデータを取得する。
    /// </summary>
    /// <remarks>
    /// RenderLayerModelはImageおよびOffsetなどのプロパティを設定する。
    /// 最後にGetProcessedImage()で
    /// 処理済み画像データを取得して使用する。
    /// プロパティを変更したら、GetProcessedImage()で再度処理済みデータを取得すること。
    /// </remarks>
    public class RenderLayerModel : INotifyPropertyChanged
    {
        private Image image; // レイヤーのオリジナルイメージデータ
        private int offsetX; // オフセットX
        private int offsetY; // オフセットY
        private int hue; // 色相
        private int saturation; // 彩度
        private int value; // 輝度
        private int opacity; // 不透明度
        private ImageBuffer processedImage; // 処理済みデータ

        /// <summary>
        /// キャラクターチップ生成のレイヤーを表すモデル
        /// </summary>
        /// <param name="layerType">レイヤータイプ</param>
        /// <param name="partsType">パラメータを取得する部品タイプ</param>
        /// <param name="colorPartsRefs"></param>
        public RenderLayerModel(LayerType layerType, PartsType partsType, PartsType colorPartsRefs)
        {
            LayerType = layerType;
            PartsType = partsType;
            ColorPartsRefs = colorPartsRefs;
            this.image = null;
            this.offsetX = 0;
            this.offsetY = 0;
            this.hue = 0;
            this.saturation = 0;
            this.value = 0;
            this.opacity = 100;
        }

        /// <summary>
        /// プロパティに変更があった場合に通知する。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたときに通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// レイヤー種類
        /// </summary>
        public LayerType LayerType { get; private set; }

        /// <summary>
        /// OffsetX, OffsetYを取得する部品種別
        /// </summary>
        public PartsType PartsType { get; private set; }

        /// <summary>
        /// Hue, Saturation, Value, Opacity を取得する部品種別
        /// </summary>
        public PartsType ColorPartsRefs { get; set; }

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
                NotifyPropertyChange(nameof(Image));
            }
        }
 
        /// <summary>
        /// オフセットX
        /// </summary>
        public int OffsetX
        {
            get { return offsetX; }
            set {
                if (offsetX == value)
                {
                    return;
                }
                offsetX = value;
                NotifyPropertyChange(nameof(OffsetX));
            }
        }

        /// <summary>
        /// オフセットY
        /// </summary>
        public int OffsetY
        {
            get {
                return offsetY;
            }
            set {
                if (offsetY == value)
                {
                    return;
                }
                offsetY = value;
                NotifyPropertyChange(nameof(OffsetY));
            }
        }

        /// <summary>
        /// 不透明度
        /// </summary>
        public int Opacity {
            get { return opacity; }
            set {
                if (opacity == value)
                {
                    return;
                }
                opacity = value;
                NotifyPropertyChange(nameof(Opacity));
            }
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
                NotifyPropertyChange(nameof(Opacity));
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
        /// <returns>ImageBufferオブジェクトが返る。</returns>
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
