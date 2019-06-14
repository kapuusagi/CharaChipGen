using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IconSetViewer
{
    /// <summary>
    /// アイコンセット中の、特定のアイコンを表示するためのコントロール。
    /// </summary>
    public partial class IconViewControl : UserControl
    {

        private Size iconSize = new Size(32, 32);
        private Image image = null;
        private Size imageSize = new Size(0,0); // 画像サイズキャッシュ値
        private int hIconCount; // 水平アイコン数
        private int vIconCount; // 垂直アイコン数
        private int number = 0;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示を更新する。
        /// </summary>
        /// <param name="evt">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs evt)
        {
            Graphics g = evt.Graphics;

            // 背景色でクリア
            Brush brush = new SolidBrush(BackColor);
            g.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            // 表示対象がある場合、もりもり描画。
            if ((image != null) && (number >= 0) && (number < MaxIconCount))
            {
                // 表示元画像部分の座標を計算
                int yPos = number / hIconCount;
                int xPos = number - (hIconCount * yPos);
                int srcXOffs = xPos * iconSize.Width;
                int srcYOffs = yPos * iconSize.Height;
                Rectangle srcRect = new Rectangle(srcXOffs, srcYOffs,
                    iconSize.Width - 1, iconSize.Height - 1);

                System.Diagnostics.Debug.WriteLine($"{srcRect.ToString()}");

                // 表示先範囲の座標を計算
                int drawWidth = ClientSize.Width;
                int drawHeight = (int)(Math.Ceiling(drawWidth
                    * (double)(iconSize.Height) / (double)(iconSize.Width)));
                if (drawHeight > ClientSize.Height)
                {
                    // アスペクト比を維持して描画に必要な高さが足りない
                    drawHeight = ClientSize.Height;
                    drawWidth = (int)(Math.Ceiling(drawHeight
                        * (double)(iconSize.Width) / (double)(iconSize.Height)));
                }
                int dstXOffs = (ClientSize.Width - drawWidth) / 2;
                int dstYOffs = (ClientSize.Height - drawHeight) / 2;
                Rectangle dstRect = new Rectangle(dstXOffs, dstYOffs,
                    drawWidth, drawHeight);

                // 描画
                g.DrawImage(Image, dstRect, srcRect, GraphicsUnit.Pixel);
            }

        }


        /// <summary>
        /// 画像データ
        /// </summary>
        public Image Image {
            get { return image; }
            set {
                image = value;
                imageSize.Width = image?.Width ?? 0;
                imageSize.Height = image?.Height ?? 0;
                UpdateIconData();
            }
        }

        /// <summary>
        /// アイコンインデックス番号(0, 1, 2, ... (MaxIconCount - 1))
        /// </summary>
        public int Number {
            get { return number; }
            set {
                int newNumber = value;
                if (newNumber < 0)
                {
                    newNumber = 0;
                }
                else if (newNumber >= MaxIconCount)
                {
                    newNumber = MaxIconCount - 1;
                }

                if (newNumber != number)
                {
                    number = newNumber;
                    Invalidate();
                }

            }
        }

        /// <summary>
        /// アイコンサイズ
        /// </summary>
        public Size IconSize {
            get { return iconSize; }
            set {
                if ((value.Width <= 0) || (value.Height <= 0))
                {
                    throw new ArgumentException($"Size is incorrect. ({value.Width},{value.Height})");
                }
                iconSize = value;
                UpdateIconData();
            }
        } 

        /// <summary>
        /// アイコン最大数
        /// </summary>
        public int MaxIconCount { get; private set; }

        /// <summary>
        /// アイコンデータを更新する。
        /// </summary>
        private void UpdateIconData()
        {
            hIconCount = imageSize.Width / iconSize.Width;
            vIconCount = imageSize.Height / iconSize.Height;
            MaxIconCount = hIconCount * vIconCount;
            number = 0; // 表示インデックスリセット
            Invalidate();
        }

        /// <summary>
        /// コントロールのサイズが変更された時に通知を受け取る
        /// </summary>
        /// <param name="evt">イベントオブジェクト</param>
        protected override void OnResize(EventArgs evt)
        {
            base.OnResize(evt);
            // 再描画しないとくずれたおかしな画像が表示される。
            Invalidate();
        }
    }
}
