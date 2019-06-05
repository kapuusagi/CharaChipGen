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
    public partial class ControlCombineSetting : UserControl
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ControlCombineSetting()
        {
            InitializeComponent();
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
        /// 水平カウント
        /// </summary>
        public int HorizontalCount {
            get {
                return (int)(numericUpDownH.Value);
            }
            set {
                if ((int)(numericUpDownH.Value) == value)
                {
                    // 変更なし。
                    return;
                }
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => { HorizontalCount = value; }));
                }
                else
                {
                    numericUpDownH.Value = value;
                    NotifyPropertyChanged("HorizontalCount");
                }
            }
        }

        /// <summary>
        /// 垂直カウント
        /// </summary>
        public int VerticalCount {
            get {
                return (int)(numericUpDownV.Value);
            }
            set {
                if ((int)(numericUpDownV.Value) == value)
                {
                    // 変更なし。
                    return;
                }
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => { VerticalCount = value; }));
                }
                else
                {
                    numericUpDownV.Value = value;
                    NotifyPropertyChanged("VerticalCount");
                }
            }
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
        /// 水平カウント欄の値が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnNumericUpDownHValueChanged(object sender, EventArgs evt)
        {
            NotifyPropertyChanged("HorizontalCount");
        }

        /// <summary>
        /// 垂直カウント欄の値が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnNumericUpDownVValueChanged(object sender, EventArgs evt)
        {
            NotifyPropertyChanged("VerticalCount");
        }

        /// <summary>
        /// フォルダ選択コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <remarks>
        /// 関数名長い。
        /// </remarks>
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
    }
}
