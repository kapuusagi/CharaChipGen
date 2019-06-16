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
    /// クリップ領域処理設定UI
    /// </summary>
    public partial class ClipOperationSettingControl : UserControl
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ClipOperationSettingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// プロパティが変更されたときに通知を受け取る。
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
            get { return selectDirectoryControl.Directory; }
            set { selectDirectoryControl.Directory = value; }
        }

        /// <summary>
        /// コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "Directory":
                    NotifyPropertyChanged("OutputDirectory");
                    break;
            }
        }

        /// <summary>
        /// 数値入力欄の値が変更されたときに通知を受けとる。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs evt)
        {
            NotifyPropertyChanged("ClipBounds");
        }

        /// <summary>
        /// クリップ領域設定
        /// </summary>
        public Rectangle ClipBounds {
            set {
                numericUpDownX.Value = value.X;
                numericUpDownY.Value = value.Y;
                numericUpDownWidth.Value = value.Width;
                numericUpDownHeight.Value = value.Height;
            }
            get {
                return new Rectangle(
                    (int)(numericUpDownX.Value),
                    (int)(numericUpDownY.Value),
                    (int)(numericUpDownWidth.Value),
                    (int)(numericUpDownHeight.Value));
            }
        }


    }
}
