using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 単色化処理設定
    /// </summary>
    public class MonoColorOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        // 出力ディレクトリ
        private string outputDirectory;
        // 色
        private Color color;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MonoColorOperationSetting()
        {
            outputDirectory = "";
            color = Color.Black;
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
                if ((value == null) || (outputDirectory.Equals(value)))
                {
                    return;
                }

                outputDirectory = value;
                NotifyPropertyChanged(nameof(OutputDirectory));
            }
        }

        /// <summary>
        /// 色
        /// </summary>
        public Color Color {
            get { return color; }
            set {
                if ((value == null) || color.Equals(value))
                {
                    return;
                }
                color = value;
                NotifyPropertyChanged(nameof(Color));
            }
        }

        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public System.Windows.Forms.Control GetControl()
        {
            return new MonoColorOperationSettingControl() { Model = this };
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
                case nameof(Color):
                    return $"{Color.R},{Color.G},{Color.B}";
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
                case nameof(Color):
                    string[] values = value.Split(',');
                    Color = Color.FromArgb(Convert.ToByte(values[0]),
                        Convert.ToByte(values[1]), Convert.ToByte(values[2]));
                    break;
            }
        }

    }
}
