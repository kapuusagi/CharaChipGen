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
    /// 単純な画像操作の設定
    /// </summary>
    public class ImageOperationSetting : IOperationSetting
    {
        // 設定UI
        private SelectDirectoryControl settingControl = null;
        // 出力ディレクトリ
        private string outputDirectory = "";
        // 設定パネル
        private Panel control = null;


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public Control GetControl()
        {
            if (control == null)
            {
                settingControl =  new SelectDirectoryControl();
                settingControl.SelectName = "出力フォルダ";
                settingControl.Directory = outputDirectory;
                settingControl.PropertyChanged += OnControlPropertyChanged;
                settingControl.Dock = DockStyle.Top;
                control = new Panel();
                control.Controls.Add(settingControl);
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
                case nameof(settingControl.Directory):
                    OutputDirectory = settingControl.Directory;
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
                    settingControl.Directory = outputDirectory;
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
