using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace ImageStacker
{
    /// <summary>
    /// レイヤーエントリ
    /// 
    /// 1つのレイヤーを表すモデル。
    /// </summary>
    public class LayerEntry : INotifyPropertyChanged
    {
        /// <summary>
        /// オフセット最小値
        /// </summary>
        public const int OFFSET_MIN = -10000;
        /// <summary>
        /// オフセット最大値
        /// </summary>
        public const int OFFSET_MAX = 10000;

        // ファイル名
        private string fileName;
        // Xオフセット
        private int offsetX;
        // Yオフセット
        private int offsetY;
        // 色相調整値
        private int hue;
        //  彩度調整値
        private int saturation;
        // 輝度調整値
        private int value;
        // 不透明度（高いほど不透明） = アルファチャンネル
        private int opacity;
        // 単色
        private bool monoricConversionEnabled;
        // カラー
        private Color monoricConvertColor;

        // 選択されているかどうか
        private bool selected;
        /// <summary>
        /// 新しい空のレイヤーエントリを作成する。
        /// </summary>
        public LayerEntry()
        {
            fileName = string.Empty;
            offsetX = 0;
            offsetY = 0;
            hue = 0;
            saturation = 0;
            value = 0;
            opacity = 255;
            monoricConversionEnabled = false;
            monoricConvertColor = Color.Black;
            selected = false;
        }

        /// <summary>
        /// プロパティが変更された
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティの変更を通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName {
            get => fileName;
            set {
                if (!string.IsNullOrEmpty(value) && !fileName.Equals(value))
                {
                    fileName = value;
                    NotifyPropertyChanged(nameof(FileName));
                }
            }

        }

        /// <summary>
        /// Xオフセット
        /// </summary>
        public int OffsetX {
            get => offsetX;
            set {
                var d = Math.Min(OFFSET_MAX, Math.Max(OFFSET_MIN, value));
                if (offsetX != d)
                {
                    offsetX = d;
                    NotifyPropertyChanged(nameof(OffsetX));
                }
            }
        }
        /// <summary>
        /// Yオフセット
        /// </summary>
        public int OffsetY {
            get => offsetY;
            set {
                var d = Math.Min(OFFSET_MAX, Math.Max(OFFSET_MIN, value));
                if (offsetY != d)
                {
                    offsetY = d;
                    NotifyPropertyChanged(nameof(OffsetY));
                }
            }

        }
        /// <summary>
        /// 色相調整値(-180 ～ 180)
        /// </summary>
        public int Hue {
            get { return hue; }
            set {
                var setHue = Math.Max(-180, Math.Min(180, value));
                if (hue == setHue)
                {
                    return; // 同値なので設定変更不要。
                }
                hue = setHue;
                NotifyPropertyChanged(nameof(Hue));
            }
        }

        /// <summary>
        /// 彩度の調整値(-255～255)
        /// </summary>
        public int Saturation {
            get { return saturation; }
            set {
                var setSaturation = Math.Max(-255, Math.Min(255, value));
                if (saturation == setSaturation)
                {
                    return; // 同値なので設定変更不要。
                }
                saturation = setSaturation;
                NotifyPropertyChanged(nameof(Saturation));
            }
        }
        /// <summary>
        /// 輝度の調整値(-255～255)
        /// </summary>
        public int Value {
            get { return value; }
            set {
                var setValue = Math.Max(-255, Math.Min(255, value));
                if (this.value == setValue)
                {
                    return;
                }
                this.value = setValue;
                NotifyPropertyChanged(nameof(Value));
            }
        }

        /// <summary>
        /// 不透明度(0-255)
        /// </summary>
        public int Opacity {
            get { return opacity; }
            set {
                var setOpacity = Math.Min(255, Math.Max(0, value));
                if (this.opacity == setOpacity)
                {
                    return;
                }
                opacity = setOpacity;
                NotifyPropertyChanged(nameof(Opacity));
            }
        }
        /// <summary>
        /// 単色変換を行うかどうか
        /// </summary>
        public bool MonoricConversionEnabled {
            get => monoricConversionEnabled;
            set {
                if (monoricConversionEnabled != value)
                {
                    monoricConversionEnabled = value;
                    NotifyPropertyChanged(nameof(MonoricConversionEnabled));
                }
            }
        }

        /// <summary>
        /// 単色変換指定色
        /// </summary>
        public Color MonoricConvertColor {
            get => monoricConvertColor;
            set {
                if (!monoricConvertColor.Equals(value))
                {
                    monoricConvertColor = value;
                    NotifyPropertyChanged(nameof(MonoricConvertColor));
                }
            }
        }

        /// <summary>
        /// 選択状態
        /// </summary>
        public bool Selected {
            get => selected;
            set {
                if (selected != value)
                {
                    selected = value;
                    NotifyPropertyChanged(nameof(Selected));
                }
            }
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('\"').Append(nameof(FileName)).Append("\"=\"").Append(FileName).Append("\",");
            sb.Append('\"').Append(nameof(OffsetX)).Append("\"=\"").Append(OffsetX).Append("\",");
            sb.Append('\"').Append(nameof(OffsetY)).Append("\"=\"").Append(OffsetY).Append("\",");
            sb.Append('\"').Append(nameof(Hue)).Append("\"=\"").Append(Hue).Append("\",");
            sb.Append('\"').Append(nameof(Saturation)).Append("\"=\"").Append(Saturation).Append("\",");
            sb.Append('\"').Append(nameof(Value)).Append("\"=\"").Append(Value).Append("\",");
            sb.Append('\"').Append(nameof(Opacity)).Append("\"=\"").Append(Opacity).Append("\",");
            sb.Append('\"').Append(nameof(MonoricConversionEnabled)).Append("\"=\"").Append(MonoricConversionEnabled).Append("\",");
            sb.Append('\"').Append(nameof(MonoricConvertColor)).Append("\"=\"").Append(MonoricConvertColor.ToArgb()).Append("\",");
            return sb.ToString();
        }

        /// <summary>
        /// strをパースしてLayerEntryオブジェクトを構築する。
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>LayerEntryオブジェクト。解析エラーが発生した場合には例外が飛ぶ</returns>
        public static LayerEntry Parse(string str)
        {
            var layer = new LayerEntry();
            var tokens = Common.TextUtility.Split(str, new char[] { ',' });
            foreach (var token in tokens)
            {
                // '='もファイル名に使えるが、キーワードに=が含まれないから、最初に出現した=で分割して良い。
                var index = token.IndexOf('=');
                if (index >= 0)
                {
                    var key = token.Substring(0, index).Trim(new char[] { '\"' });
                    var value = token.Substring(index + 1).Trim(new char[] { '\"' });
                    switch (key)
                    {
                        case nameof(FileName):
                            layer.FileName = value;
                            break;
                        case nameof(OffsetX):
                            layer.OffsetX = int.Parse(value);
                            break;
                        case nameof(OffsetY):
                            layer.OffsetY = int.Parse(value);
                            break;
                        case nameof(Hue):
                            layer.Hue = int.Parse(value);
                            break;
                        case nameof(Saturation):
                            layer.Saturation = int.Parse(value);
                            break;
                        case nameof(Value):
                            layer.Value = int.Parse(value);
                            break;
                        case nameof(Opacity):
                            layer.Opacity = int.Parse(value);
                            break;
                        case nameof(MonoricConversionEnabled):
                            layer.MonoricConversionEnabled = bool.Parse(value);
                            break;
                        case nameof(MonoricConvertColor):
                            layer.MonoricConvertColor = Color.FromArgb(int.Parse(value));
                            break;
                    }
                }
            }

            return layer;
        }

    }
}
