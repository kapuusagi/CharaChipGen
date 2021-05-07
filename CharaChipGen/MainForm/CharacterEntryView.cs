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
        // キャラチップ画像
        private Image charaChipImage;
        // 背景色
        private Color imageBackground;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharacterEntryView()
        {
            imageBackground = Color.Transparent;
            InitializeComponent();
        }

        /// <summary>
        /// コンポーネントがリサイズされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnResized(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// UIの描画を行う。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int inset = 4;
            int margin = 4;
            int width = ClientSize.Width - inset * 2;
            int height = ClientSize.Height - (button.Height + margin + inset);

            Graphics g = e.Graphics;
            int x = margin;
            int y = margin;


            using (Brush brush = new SolidBrush(ImageBackground))
            {

                g.FillRectangle(brush, x, y, width - 1, height - 1);
            }

            if (charaChipImage != null)
            {
                int xOffset = (Bounds.Width - charaChipImage.Width) / 2;
                int yOffset = (Bounds.Height - charaChipImage.Height) / 2;

                g.DrawImageUnscaled(charaChipImage, xOffset, yOffset);
            }

            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, x, y, width - 1, height - 1);
            }
        }

        /// <summary>
        /// 画像背景色
        /// </summary>
        public Color ImageBackground {
            get => imageBackground;
            set {
                imageBackground = value;
                Invalidate();
            }

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
            get { return charaChipImage; }
            set {
                charaChipImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// イメージエリアサイズ
        /// </summary>
        public Size ImageAreaSize {
            get {
                int inset = 4;
                int margin = 4;
                int width = ClientSize.Width - inset * 2;
                int height = ClientSize.Height - (button.Height + margin + inset);
                return new Size(width, height);
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
