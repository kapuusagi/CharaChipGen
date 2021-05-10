using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
            var tokens = TextUtility.Split(str, new char[] { ',' });
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
                    }
                }
            }

            return layer;
        }

    }
}
