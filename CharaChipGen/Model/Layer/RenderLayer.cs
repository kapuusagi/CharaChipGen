using CGenImaging;
using CharaChipGen.Model.CharaChip;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CharaChipGen.Model.Layer
{
    /// <summary>
    /// キャラクタチップをレンダリングする際の１つのレイヤーを表すモデル。
    /// 1つのレイヤーに対して、オフセット/HSV変更を適用したデータを取得する。
    /// </summary>
    /// <remarks>
    /// 使用想定
    /// PropertyChangedにハンドラを登録する。
    /// PropertyChangedイベントを受けたときにGetProcessedImage()メソッドを使用し、
    /// HSV/Offsetフィルタ適用済み画像データを取得する。
    /// </remarks>
    public class RenderLayer : INotifyPropertyChanged
    {
        // レイヤーのオリジナルイメージデータ
        private Image image;
        // オフセットX
        private int offsetX;
        // オフセットY
        private int offsetY;
        // 色相
        private int hue;
        // 彩度
        private int saturation;
        // 輝度
        private int value;
        // 不透明度
        private int opacity;
        // 着色レイヤーかどうか
        private bool coloring;
        // 画像状態ロック
        private readonly object renderRequestLock;
        // 再描画する必要があるか
        private bool renderRequested;
        // 処理済みデータ
        private ImageBuffer processedImage;

        /// <summary>
        /// キャラクターチップ生成のレイヤーを表すモデル
        /// </summary>
        /// <param name="layerType">レイヤータイプ</param>
        /// <param name="partsType">パラメータを取得する部品タイプ</param>
        /// <param name="colorPartsRefs">色パラメータを取得する部品タイプ</param>
        /// <param name="colorPropertyName">色参照プロパティ名</param>
        public RenderLayer(LayerType layerType, PartsType partsType, PartsType colorPartsRefs,
            string colorPropertyName)
        {
            renderRequestLock = new object();
            renderRequested = true;
            LayerType = layerType;
            PartsType = partsType;
            ColorPartsRefs = colorPartsRefs;
            ColorPropertyName = colorPropertyName;
            this.image = null;
            this.offsetX = 0;
            this.offsetY = 0;
            this.hue = 0;
            this.saturation = 0;
            this.value = 0;
            this.opacity = 100;
            this.coloring = false;
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
        public PartsType ColorPartsRefs { get; private set; }
        /// <summary>
        /// Hue, Saturation, Value, Opacity を取得する色プロパティ名(Color1だとかColor2だとか)
        /// </summary>
        public string ColorPropertyName { get; private set; }

        /// <summary>
        /// 色が不変かどうか
        /// </summary>
        /// <remarks>
        /// trueにすると、HSVによる色変更が適用できなくなる。
        /// </remarks>
        public bool ColorImmutable { get; set; } = false;

        /// <summary>
        /// 着色レイヤーかどうか
        /// </summary>
        /// <remarks>
        /// trueにすると、HSVで指定された色で着色する。ColorImmutableが優先される。
        /// </remarks>
        public bool Coloring {
            get => coloring;
            set {
                if (ColorImmutable)
                {
                    return;
                }
                if (coloring == value)
                {
                    return;
                }
                coloring = value;
                InvalidateProcessedImage();
                NotifyPropertyChange(nameof(Saturation));
            }
        }

        /// <summary>
        /// レイヤーイメージ
        /// 未設定の場合にはnull
        /// </summary>
        public Image Image {
            get { return image; }
            set {
                if (((image == null) && (value == null))
                        || ((image != null) && (image.Equals(value))))
                {
                    return; // 変更なし。
                }

                image = value;
                InvalidateProcessedImage();
                NotifyPropertyChange(nameof(Image));
            }
        }

        /// <summary>
        /// オフセットX
        /// </summary>
        public int OffsetX {
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
        public int OffsetY {
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
        public int Hue {
            get { return hue; }
            set {
                if (ColorImmutable)
                {
                    return;
                }
                if (hue == value)
                {
                    return; // 変更なし
                }
                hue = value;
                InvalidateProcessedImage();
                NotifyPropertyChange(nameof(Opacity));
            }
        }

        /// <summary>
        /// 彩度調整値
        /// </summary>
        public int Saturation {
            get { return saturation; }
            set {
                if (ColorImmutable)
                {
                    return;
                }
                if (saturation == value)
                {
                    return; // 変更なし。
                }
                this.saturation = value;
                InvalidateProcessedImage();
                NotifyPropertyChange(nameof(Saturation));
            }
        }

        /// <summary>
        /// 輝度調整値
        /// </summary>
        public int Value {
            get { return value; }
            set {
                if (ColorImmutable)
                {
                    return;
                }
                if (this.value == value)
                {
                    return; // 変更なし。
                }
                this.value = value;
                InvalidateProcessedImage();
                NotifyPropertyChange(nameof(Value));
            }
        }

        /// <summary>
        /// 処理済みイメージを無効にし、演算済みデータ取得時の再レンダリングを要求する。
        /// </summary>
        private void InvalidateProcessedImage()
        {
            lock (renderRequestLock)
            {
                renderRequested = true;
                processedImage = null;
            }
        }

        /// <summary>
        /// HSV加算演算済みのデータを取得する。
        /// </summary>
        /// <returns>ImageBufferオブジェクトが返る。</returns>
        public ImageBuffer GetProcessedImage()
        {
            lock (renderRequestLock)
            {
                if (renderRequested)
                {
                    if (image != null)
                    {
                        if (coloring)
                        {
                            var h = hue;
                            var s = Math.Min(255, Math.Max(0, saturation));
                            var v = Math.Min(255, Math.Max(0, value));
                            var c = CGenImaging.ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(h, s,v));
                            processedImage = ImageProcessor.ProcessColoring(
                                ImageBuffer.CreateFrom(image), c);
                        }
                        else
                        {
                            processedImage = ImageProcessor.ProcessHSLFilter(
                                ImageBuffer.CreateFrom(image), hue, saturation, value);
                        }
                    }
                    renderRequested = false;
                }

                return processedImage;
            }
        }

        /// <summary>
        /// 推奨する画像の幅
        /// </summary>
        public int PreferredWidth {
            get => PreferredCharaChipWidth * 3;
        }

        /// <summary>
        /// 推奨するキャラチップ画像の1パターンの幅
        /// </summary>
        public int PreferredCharaChipWidth {
            get {
                return ((this.image != null)
                    ? image.Width + Math.Abs(offsetX) : Math.Abs(offsetX)) / 3;
            }
        }

        /// <summary>
        /// 推奨する画像の高さ
        /// </summary>
        public int PreferredHeight {
            get => PreferredCharaChipHeight * 4;
        }

        /// <summary>
        /// 推奨するキャラチップ画像の1パターンの高さ
        /// </summary>
        public int PreferredCharaChipHeight {
            get {
                return ((this.image != null)
                    ? image.Height + Math.Abs(offsetY) : Math.Abs(offsetY)) / 4;
            }
        }

        /// <summary>
        /// エラーの有無
        /// </summary>
        public bool HasError { get; set; }

    }
}
