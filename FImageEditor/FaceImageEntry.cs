using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace FImageEditor
{
    /// <summary>
    /// 1つの顔グラフィックエントリを表すクラス。
    /// </summary>
    public class FaceImageEntry : INotifyPropertyChanged
    {

        // ファイル名
        private string fileName;
        // 切り出すX位置
        private int x;
        // 切り出すY位置
        private int y;
        // 切り出す幅
        private int width;
        // 切り出す高さ
        private int height;
        /// <summary>
        /// 新しいFaceImageEntryオブジェクトを構築する。
        /// </summary>
        public FaceImageEntry()
        {
            fileName = string.Empty;
            x = 0;
            y = 0;
            width = 144;
            height = 144;
        }

        /// <summary>
        /// プロパティが変更された
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティ変更を通知する。
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// データをリセットする。
        /// </summary>
        public void Reset()
        {
            FileName = string.Empty;
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName {
            get => fileName;
            set {
                if ((value != null) && !fileName.Equals(value))
                {
                    fileName = value;
                    NotifyPropertyChange(nameof(FileName));
                }
            }
        }

        /// <summary>
        /// 切り出しX位置
        /// </summary>
        public int X {
            get => x;
            set {
                if ((value >= 0) && (x != value))
                {
                    x = value;
                    NotifyPropertyChange(nameof(X));
                }
            }
        }

        /// <summary>
        /// 切り出しY位置
        /// </summary>
        public int Y {
            get => y;
            set {
                if ((value >= 0) && (y != value))
                {
                    y = value;
                    NotifyPropertyChange(nameof(Y));
                }
            }
        }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width {
            get => width;
            set {
                if ((value > 0) && (width != value))
                {
                    width = value;
                    NotifyPropertyChange(nameof(Width));
                }
            }
        }

        /// <summary>
        /// 高さ
        /// </summary>
        public int Height {
            get => height;
            set {
                if ((value > 0) && (height != value))
                {
                    height = value;
                    NotifyPropertyChange(nameof(Height));
                }
            }
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('\"').Append(nameof(FileName)).Append("\"=\"").Append(FileName).Append("\",");
            sb.Append('\"').Append(nameof(X)).Append("\"=\"").Append(X).Append("\",");
            sb.Append('\"').Append(nameof(Y)).Append("\"=\"").Append(Y).Append("\",");

            return sb.ToString();
        }

        /// <summary>
        /// strをパースしてFaceImageEntryオブジェクトを構築する。
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>LayerEntryオブジェクト。解析エラーが発生した場合には例外が飛ぶ</returns>
        public static FaceImageEntry Parse(string str)
        {
            var entry = new FaceImageEntry();

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
                            entry.FileName = value;
                            break;
                        case nameof(X):
                            entry.X = int.Parse(value);
                            break;
                        case nameof(Y):
                            entry.Y = int.Parse(value);
                            break;
                    }
                }

            }
            return entry;
        }

    }
}
