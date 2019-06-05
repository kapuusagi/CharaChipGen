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
    class SimpleImageOperationSetting : IOperationSetting
    {
        // 設定UI
        private ControlSelectDirectory controlSelectDirectory = null;
        // 出力ディレクトリ
        private string outputDirectory = "";


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public Control GetControl()
        {
            if (controlSelectDirectory == null)
            {
                controlSelectDirectory = new ControlSelectDirectory();
                controlSelectDirectory.SelectName = "出力フォルダ";
                controlSelectDirectory.Directory = outputDirectory;
                controlSelectDirectory.PropertyChanged += OnControlPropertyChanged;
            }
            return controlSelectDirectory;
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
                    OutputDirectory = controlSelectDirectory.Directory;
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
                if (controlSelectDirectory != null)
                {
                    controlSelectDirectory.Directory = outputDirectory;
                }
            }
            get {
                return outputDirectory;
            }
        }
    }
}
