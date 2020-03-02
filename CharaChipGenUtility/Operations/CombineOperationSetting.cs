using System;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 結合オペレーション設定
    /// </summary>
    public sealed class CombineOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        // 水平カウント
        private int horizontalCount = 1;
        // 垂直カウント
        private int verticalCount = 1;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CombineOperationSetting()
        {
        }

        /// <summary>
        /// プロパティが変更された。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたときに通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// 水平数
        /// </summary>
        public int HorizontalCount {
            get => horizontalCount;
            set {
                if (horizontalCount != value)
                {
                    horizontalCount = value;
                    NotifyPropertyChanged(nameof(HorizontalCount));
                }
            }
        }
        /// <summary>
        /// 垂直数
        /// </summary>
        public int VerticalCount {
            get => verticalCount;
            set {
                if (verticalCount != value)
                {
                    verticalCount = value;
                    NotifyPropertyChanged(nameof(VerticalCount));
                }
            }
        }

        /// <summary>
        /// 出力ディレクトリ
        /// </summary>
        private string outputDirectory = "";

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
            get => outputDirectory;
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
                case nameof(outputDirectory):
                    return OutputDirectory;
                case nameof(HorizontalCount):
                    return HorizontalCount.ToString();
                case nameof(VerticalCount):
                    return VerticalCount.ToString();
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
                case nameof(HorizontalCount):
                    HorizontalCount = Convert.ToInt32(value);
                    break;
                case nameof(VerticalCount):
                    VerticalCount = Convert.ToInt32(value);
                    break;
            }
        }

        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public System.Windows.Forms.Control GetControl()
        {
            return new CombineOperationSettingControl() { Model = this };
        }
    }
}
