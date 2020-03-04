using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.MainForm
{
    /// <summary>
    ///  MainFormにて、キャラクタのエントリUIを提供するコントロール。
    /// </summary>
    public partial class CharacterEntryView : UserControl
    {
        public event EventHandler ButtonClick;

        private Image charaChipImage;
        private Image faceImage;

        public CharacterEntryView()
        {
            InitializeComponent();
        }

        private void OnResized(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// UIの描画を行う。
        /// </summary>
        /// <param name="e"></param>
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
            if (faceImage != null)
            {
                g.DrawImage(faceImage, new Rectangle(x, y, width, height));
            }
            if (charaChipImage != null)
            {
                int charaChipX = x + width - charaChipImage.Width;
                int charaChipY = y + width - charaChipImage.Height;
                g.DrawImageUnscaled(charaChipImage, charaChipX, charaChipY);
            }

            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, x, y, width - 1, height - 1);
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
        public Image Image {
            get { return charaChipImage; }
            set {
                charaChipImage = value;
                Invalidate();
            }
        }

        public Image FaceImage {
            get { return faceImage; }
            set {
                faceImage = value;
                Invalidate();
            }
        }

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
    }
}
