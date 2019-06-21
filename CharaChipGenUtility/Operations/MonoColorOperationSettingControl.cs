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
    /// 単色化処理設定用コントロール
    /// </summary>
    public partial class MonoColorOperationSettingControl : UserControl
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MonoColorOperationSettingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// プロパティが変更されたことを通知する。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたことを通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                case nameof(selectDirectoryControl.Directory):
                    NotifyPropertyChanged(nameof(OutputDirectory));
                    break;
            }
        }

        /// <summary>
        /// 色選択ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnSelectColorButtonClick(object sender, EventArgs evt)
        {
            colorDialog.Color = textBoxColor.BackColor;
            if (colorDialog.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            textBoxColor.BackColor = colorDialog.Color;
            NotifyPropertyChanged(nameof(Color));
        }

        /// <summary>
        /// 出力ディレクトリ
        /// </summary>
        public string OutputDirectory {
            get { return selectDirectoryControl.Directory; }
            set { selectDirectoryControl.Directory = value; }
        }

        /// <summary>
        /// カラー
        /// </summary>
        public Color Color {
            get { return textBoxColor.BackColor; }
            set {
                if ((value == null) || (textBoxColor.BackColor.Equals(value)))
                {
                    return;
                }
                textBoxColor.BackColor = value;
                NotifyPropertyChanged(nameof(Color));
            }
        }

    }
}
