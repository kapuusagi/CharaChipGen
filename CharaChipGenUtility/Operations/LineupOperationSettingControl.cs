using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 並べる操作の設定UI
    /// </summary>
    public partial class LineupOperationSettingControl : UserControl
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public LineupOperationSettingControl()
        {
            InitializeComponent();
            comboBoxDirection.SelectedIndex = 0;
        }

        /// <summary>
        /// ユーザーによってプロパティが変更された。
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
        /// 出力ディレクトリ選択
        /// </summary>
        public string OutputDirectory {
            get {
                return controlSelectDirectory.Directory;
            }
            set {
                controlSelectDirectory.Directory = value;
            }
        }

        /// <summary>
        /// 方向
        /// </summary>
        public int Direction {
            get {
                return comboBoxDirection.SelectedIndex;
            }
            set {
                if (comboBoxDirection.SelectedIndex == value)
                {
                    // 変更なし。
                    return;
                }
                if ((value < 0) || (value >= comboBoxDirection.Items.Count))
                {
                    // 範囲外
                    // ここに来るのはバグなので基本的にないはず。
                    throw new ArgumentException($"Direction is incorrect. [{value}]");
                }

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => Direction = value));
                }
                else
                {
                    comboBoxDirection.SelectedIndex = value;
                }
            }
        }

        /// <summary>
        /// ディレクトリ選択コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlSelectDirectoryPropertyChanged(object sender, 
            PropertyChangedEventArgs evt)
        {
            if (evt.PropertyName.Equals("Directory"))
            {
                NotifyPropertyChanged("OutputDirectory");
            }
            
        }

        /// <summary>
        /// 方向コンボボックスで選択が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnComboBoxDirectionSelectedIndexChanged(object sender, EventArgs evt)
        {
            NotifyPropertyChanged("Direction");
        }
    }
}
