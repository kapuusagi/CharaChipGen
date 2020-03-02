using System;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 配置オペレーション設定
    /// </summary>
    public class LineupOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        public const int DIRECTION_HORIZONTAL = 0;
        public const int DIRECTION_VERTICAL = 1;

        private string outputDirectory;
        private int direction;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public LineupOperationSetting()
        {
            outputDirectory = "";
            direction = 0;
        }

        /// <summary>
        /// プロパティが変更された。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更された時に通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 設定を行うためのUIを返す。
        /// </summary>
        /// <returns>UI</returns>
        public System.Windows.Forms.Control GetControl()
        {
            return new LineupOperationSettingControl() { Model = this };
        }

        /// <summary>
        /// 出力ディレクトリ設定
        /// </summary>
        public string OutputDirectory {
            set {
                if ((value == null) || outputDirectory.Equals(value))
                {
                    return;
                }
                outputDirectory = value;
                NotifyPropertyChanged(nameof(OutputDirectory));
            }
            get {
                return outputDirectory;
            }
        }

        /// <summary>
        /// 方向を設定する。
        /// </summary>
        public int Direction {
            get {
                return direction;
            }
            set {
                if (direction == value)
                {
                    return;
                }
                if ((direction != DIRECTION_HORIZONTAL)
                    && (direction != DIRECTION_VERTICAL))
                {
                    throw new ArgumentException($"Invalid direction. {value}");
                }
                direction = value;
                NotifyPropertyChanged(nameof(Direction));
            }
        }

        /// <summary>
        /// プロパティの値を文字列表現にしたものを得る。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>値</returns>
        public string GetPropertyValue(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(OutputDirectory):
                    return OutputDirectory;
                case nameof(Direction):
                    return (Direction == 0) ? "Horizontal" : "Vertical";
                default:
                    return "";
            }
        }

        /// <summary>
        /// プロパティの値を設定する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="value">プロパティの値</param>
        public void SetPropertyValue(string propertyName, string value)
        {
            switch (propertyName)
            {
                case nameof(OutputDirectory):
                    OutputDirectory = value;
                    break;
                case nameof(Direction):
                    Direction = (value.ToLower().Equals("horizontal"))
                        ? DIRECTION_HORIZONTAL : DIRECTION_VERTICAL;
                    break;
            }
        }
    }
}
