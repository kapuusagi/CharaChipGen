using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Material;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model;
using CGenImaging;

namespace CharaChipGen.MaterialViewForm
{
    /// <summary>
    /// 3x4のうち、1つの領域の表示を行うビュー
    /// </summary>
    public partial class MaterialViewNN : UserControl
    {
        // X位置
        private int positionX;
        // Y位置
        private int positionY;
        // レンダリング完了済みデータ
        private Image renderedImage;
        // レンダリングモデル
        private MaterialRenderData renderData;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialViewNN()
        {
            positionX = 0;
            positionY = 0;
            renderedImage = null;
            renderData = new MaterialRenderData();
            InitializeComponent();
        }

        /// <summary>
        /// 描画対象のデータ
        /// </summary>
        [Browsable(false)]
        public MaterialRenderData MaterialRenderData {
            get => renderData;
            set {
                if ((renderData == value) || ((renderData != null) && renderData.Equals(value)))
                {
                    return;
                }
                renderData = value;
                renderedImage = null;
                Invalidate();
            }
        }
        /// <summary>
        /// 水平位置
        /// </summary>
        public int CharaChipPositionX {
            get { return positionX; }
            set {
                if ((value >= 0) && (value < 3) && (positionX != value))
                {
                    positionX = value;
                    renderedImage = null;
                }
            }
        }

        /// <summary>
        /// 垂直位置
        /// </summary>
        public int CharaChipPositionY {
            get { return positionY; }
            set {
                if ((value >= 0) && (value < 4) && (positionY != value))
                {
                    positionY = value;
                    renderedImage = null;
                }
            }
        }
        /// <summary>
        /// レンダリング済みデータを取得する
        /// </summary>
        /// <returns>レンダリング済みデータ</returns>
        public Image GetRenderedImage()
        {
            return renderedImage;
        }

        /// <summary>
        /// 描画処理を行う。
        /// </summary>
        /// <param name="args"></param>
        protected override void OnPaint(PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            // 表示領域と同じグラフィックバッファを作成し、
            // それに対してレンダリングを行う実装になっている。
            // すると等倍にできるでしょ？

            // 背景色でクリア
            Brush brush = new SolidBrush(BackColor);
            g.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            // イメージをレンダリング
            if ((renderData != null) && (renderedImage == null))
            {
                Size prefSize = renderData.PreferredSize;
                if ((prefSize.Width > 0) && (prefSize.Height > 0))
                {

                    Size imageSize = new Size(prefSize.Width / 3, prefSize.Height / 4);

                    ImageBuffer renderBuffer = ImageBuffer.Create(imageSize.Width, imageSize.Height);

                    // レンダリングする。
                    MaterialRenderer.Draw(renderData, renderBuffer, positionX, positionY);
                    renderedImage = renderBuffer.GetImage();
                }
            }

            if (renderedImage != null)
            {
                // グラフィクスに描画する。
                if ((ClientSize.Width >= (renderedImage.Width * 2))
                    && (ClientSize.Height >= (renderedImage.Height * 2)))
                {
                    // 2倍以上でいけるんじゃない？
                    Rectangle drawRect = new Rectangle();
                    drawRect.Width = renderedImage.Width * 2;
                    drawRect.Height = renderedImage.Height * 2;
                    drawRect.X = (ClientSize.Width - drawRect.Width) / 2;
                    drawRect.Y = (ClientSize.Height - drawRect.Height) / 2;
                    g.DrawImage(renderedImage, drawRect);
                }
                else
                {
                    // 描画対象範囲が等倍以上でしか表示できないサイズ
                    int xoffs = (ClientSize.Width - renderedImage.Width) / 2;
                    int yoffs = (ClientSize.Height - renderedImage.Height) / 2;

                    g.DrawImageUnscaled(renderedImage, xoffs, yoffs);
                }
            }
            // 枠を描画
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }



        /// <summary>
        /// コントロールがリサイズされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnControlResized(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
