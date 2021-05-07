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
            FileName = string.Empty;
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
                if (!string.IsNullOrEmpty(value) && (fileName != value)
                    && (fileName?.Equals(value) ?? true))
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
    }
}
