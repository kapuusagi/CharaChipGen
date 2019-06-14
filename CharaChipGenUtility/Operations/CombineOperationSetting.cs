using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 結合オペレーション設定
    /// </summary>
    public class CombineOperationSetting : IOperationSetting
    {
        private CombineOperationSettingControl control;

        private int horizontalCount = 1;

        private int verticalCount = 1;

        /// <summary>
        /// 水平数
        /// </summary>
        public int HorizontalCount {
            get { return horizontalCount; }
            set {
                horizontalCount = value;
                if (control != null)
                {
                    control.HorizontalCount = value;
                }
            }
        }
        /// <summary>
        /// 垂直数
        /// </summary>
        public int VerticalCount {
            get { return verticalCount; }
            set {
                verticalCount = value;
                if (control != null)
                {
                    control.VerticalCount = value;
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
                if (control != null)
                {
                    control.OutputDirectory = outputDirectory;
                }
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
                case "OutputDirectory":
                    return OutputDirectory;
                case "HorizontalCount":
                    return HorizontalCount.ToString();
                case "VerticalCount":
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
                case "OutputDirectory":
                    OutputDirectory = value;
                    break;
                case "HorizontalCount":
                    HorizontalCount = Convert.ToInt32(value);
                    break;
                case "VerticalCount":
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
            if (control == null)
            {
                control = new CombineOperationSettingControl();
                control.HorizontalCount = HorizontalCount;
                control.VerticalCount = VerticalCount;
                control.OutputDirectory = OutputDirectory;
                control.PropertyChanged += OnControlCombineSettingPropertyChanged;
            }

            return control;
        }

        /// <summary>
        /// コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlCombineSettingPropertyChanged(object sender,
            PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "OutputDirectory":
                    OutputDirectory = control.OutputDirectory;
                    break;
                case "HorizontalCount":
                    HorizontalCount = control.HorizontalCount;
                    break;
                case "VerticalCount":
                    VerticalCount = control.VerticalCount;
                    break;
            }
        }
    }
}
