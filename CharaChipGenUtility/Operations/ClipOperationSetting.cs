using System;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// クリッピング処理設定
    /// </summary>
    public sealed class ClipOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        // 出力ディレクトリ
        private string outputDirectory;
        // クリップ領域
        private System.Drawing.Rectangle clipBounds;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ClipOperationSetting()
        {
            outputDirectory = "";
            clipBounds = new System.Drawing.Rectangle(0, 0, 192, 384);
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
        /// 出力ディレクトリ
        /// </summary>
        public string OutputDirectory {
            get { return outputDirectory; }
            set {
                if ((value == null) || (value.Equals(outputDirectory)))
                {
                    return;
                }
                outputDirectory = value;
                NotifyPropertyChanged(nameof(OutputDirectory));
            }
        }

        /// <summary>
        /// クリップ領域
        /// </summary>
        public System.Drawing.Rectangle ClipBounds {
            get { return clipBounds; }
            set {
                if (clipBounds.Equals(value))
                {
                    return;
                }
                clipBounds = value;
                NotifyPropertyChanged(nameof(ClipBounds));
            }
        }

        /// <summary>
        /// 設定を操作するためのUIを得る。
        /// </summary>
        /// <returns>UIが返る。</returns>
        public System.Windows.Forms.Control GetControl()
        {
            return new ClipOperationSettingControl() { Model = this };
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
                case nameof(ClipBounds):
                    return $"{clipBounds.X},{clipBounds.Y},{clipBounds.Width},{clipBounds.Height}";
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
                case nameof(ClipBounds):
                    {
                        string[] args = value.Split(',');
                        try
                        {
                            int x = Convert.ToInt32(args[0]);
                            int y = Convert.ToInt32(args[1]);
                            int width = Convert.ToInt32(args[2]);
                            int height = Convert.ToInt32(args[3]);
                            if ((x >= 0) && (y >= 0) && (width > 0) && (height > 0))
                            {
                                ClipBounds = new System.Drawing.Rectangle(x, y, width, height);
                            }

                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);
                        }

                    }
                    break;
            }

        }
    }
}
