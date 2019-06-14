using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 画像操作の設定インタフェース
    /// </summary>
    class ImageOperationSetting : IOperationSetting
    {
        // 設定UI
        private SelectDirectoryControl control = null;
        // 出力ディレクトリ
        private string outputDirectory = "";


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public Control GetControl()
        {
            if (control == null)
            {
                control = new SelectDirectoryControl();
                control.SelectName = "出力フォルダ";
                control.Directory = outputDirectory;
                control.PropertyChanged += OnControlPropertyChanged;
            }
            return control;
        }


        /// <summary>
        /// コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "Directory":
                    OutputDirectory = control.Directory;
                    break;
            }

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
                if (control != null)
                {
                    control.Directory = outputDirectory;
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
            }
        }
    }
}
