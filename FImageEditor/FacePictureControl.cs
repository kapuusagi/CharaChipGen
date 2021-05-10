using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FImageEditor
{
    public partial class FacePictureControl : UserControl
    {
        private Rectangle imageRect;
        private Image image;

        /// <summary>
        /// 新しい FacePictureControl を構築する。
        /// </summary>
        public FacePictureControl()
        {
            imageRect = new Rectangle();
            image = null;
            InitializeComponent();
        }
        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (image != null))
            {
                image.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// 表示画像
        /// </summary>
        public Image Image {
            get => image;
            set {
                if (image != value)
                {
                    image = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 描画矩形領域
        /// </summary>
        public Rectangle ImageRect {
            get => new Rectangle(imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height);
            set {
                if (!imageRect.Equals(value))
                {
                    imageRect = value;
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// 描画する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            PaintBackground(graphics);
            PaintForeground(graphics);
        }

        /// <summary>
        /// 画像を描画する。
        /// </summary>
        /// <param name="g"></param>
        private void PaintForeground(Graphics g)
        {
            if (Image != null)
            {
                var srcX = (imageRect.X <= Image.Width) ? imageRect.X : Image.Width;
                var srcY = (imageRect.Y <= Image.Height) ? imageRect.Y : Image.Height;
                var srcWidth = ((srcX + imageRect.Width) <= Image.Width) ? imageRect.Width : Image.Width - srcX;
                var srcHeight = ((srcY + imageRect.Height) <= Image.Height) ? imageRect.Height : Image.Height - srcY;
                if ((srcWidth > 0) && (srcHeight > 0))
                {
                    var dstRect = new Rectangle(0, 0, Width, Height);
                    g.DrawImage(Image, dstRect, srcX, srcY, srcWidth, srcHeight, GraphicsUnit.Pixel);
                }
            }
        }

        /// <summary>
        /// 背景を描画する
        /// </summary>
        private void PaintBackground(Graphics g)
        {
            if (BackgroundImage != null)
            {
                using (var brush = new TextureBrush(BackgroundImage))
                {
                    brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    g.FillRectangle(brush, g.ClipBounds);
                }
            }
            else
            {
                using (var brush = new SolidBrush(Color.Black))
                {
                    g.FillRectangle(brush, g.ClipBounds);
                }
            }
        }
    }


}
