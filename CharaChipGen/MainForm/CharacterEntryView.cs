using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CharaChipGen.MainForm
{
    /// <summary>
    ///  MainFormにて、キャラクタのエントリUIを提供するコントロール。
    /// </summary>
    public partial class CharacterEntryView : UserControl
    {
        /// <summary>
        /// ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        public event EventHandler ButtonClick;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharacterEntryView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画像背景色
        /// </summary>
        public Color ImageBackground {
            get => imageViewControl.BackColor;
            set => imageViewControl.BackColor = value;
        }

        /// <summary>
        /// ボタン名
        /// </summary>
        public string ButtonName {
            get { return button.Text; }
            set { button.Text = value; }
        }

        /// <summary>
        /// イメージ
        /// </summary>
        [Browsable(false)]
        public Image Image {
            get => imageViewControl.Image;
            set {
                imageViewControl.Image = value;
                imageViewControl.ImageRect = (value != null)
                    ? new Rectangle(0, 0, value.Width, value.Height) : new Rectangle();
            }
        }


        /// <summary>
        /// ボタンがクリックされたときのハンドラ
        /// </summary>
        /// <param name="sender">送信オブジェクト</param>
        /// <param name="e">イベント</param>
        private void OnButtonClick(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e); // 通知する
        }

        /// <summary>
        /// ボタンでキーが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonKeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        /// <summary>
        /// ボタンでキーが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        /// <summary>
        /// ボタンでキーが離された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonKeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }
    }
}
