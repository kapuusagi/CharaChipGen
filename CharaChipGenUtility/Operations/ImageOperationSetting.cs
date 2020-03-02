using System.ComponentModel;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 単純な画像操作の設定
    /// </summary>
    public class ImageOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        // 出力ディレクトリ
        private string outputDirectory = "";

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ImageOperationSetting()
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
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public Control GetControl()
        {
            return new ImageOperationSettingControl() { Model = this };
        }

        /// <summary>
        /// 出力ディレクトリ設定
        /// </summary>
        public string OutputDirectory {
            set {
                if ((value == null) || (outputDirectory.Equals(value)))
                {
                    // nullまたは同じ
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
            }
        }
    }
}
