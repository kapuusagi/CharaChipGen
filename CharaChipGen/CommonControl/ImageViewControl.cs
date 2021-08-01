using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.CommonControl
{
    public partial class ImageViewControl : UserControl, INotifyPropertyChanged
    {
        // 表示する画像
        private Image image;
        // 表示画像の矩形領域
        private Rectangle imageRect;
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ImageViewControl()
        {
            image = null;
            imageRect = new Rectangle();
            InitializeComponent();
        }

        /// <summary>
        /// プロパティが変更された時に通知を受け取る。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// プロパティ変更イベントを通知する。
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        /// 表示画像を変更する。
        /// </summary>
        public Image Image {
            get => image;
            set {
                if (image != value)
                {
                    image = value;
                    NotifyPropertyChanged(nameof(Image));
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 表示画像の矩形領域
        /// </summary>
        public Rectangle ImageRect {
            get => imageRect;
            set {
                if (!imageRect.Equals(value))
                {
                    imageRect = value;
                    NotifyPropertyChanged(nameof(ImageRect));
                    Invalidate();
                }


            }
        }

        /// <summary>
        /// リサイズされたときの処理を行う。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        /// <summary>
        /// パディングが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            Invalidate();
        }

        /// <summary>
        /// 描画矩形領域を得る。
        /// </summary>
        /// <returns>矩形領域</returns>
        private Rectangle GetPaintRect()
        {
            return ClientRectangle;
        }

        /// <summary>
        /// コンポーネントの描画を行う。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                var g = e.Graphics;
                if ((image == null) || (imageRect.Width <= 0) || (imageRect.Height <= 0))
                {
                    return;
                }
                var paintRect = GetPaintRect();
                if ((paintRect.Width <= 0) || (paintRect.Height <= 0))
                {
                    return;
                }

                var drawableWidth = Math.Min(image.Width - imageRect.X, imageRect.Width);
                var drawableHeight = Math.Min(image.Height - imageRect.Y, imageRect.Height);
                if ((drawableWidth <= 0) || (drawableHeight <= 0))
                {
                    return;
                }
                var drawWidth = Math.Min(drawableWidth, paintRect.Width);
                var drawHeight = Math.Min(drawableHeight, paintRect.Height);
                var dstXOffset = paintRect.X + (paintRect.Width - drawWidth) / 2;
                var dstYOffset = paintRect.Y + (paintRect.Height - drawHeight) / 2;
                var srcRect = new Rectangle(imageRect.X, imageRect.Y, drawWidth, drawHeight);

                g.DrawImage(image, dstXOffset, dstYOffset, srcRect, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                // パラメータが不正になることがある。
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// 背景を描画する。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        /// <remarks>OnPaintBackgroundのデフォルト実装でも良かったかも。たぶん実現したい機能は満たしている。</remarks>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;

            var paintRect = GetPaintRect();
            if ((BackgroundImage != null) && (BackColor.A < 255))
            {
                using (var brush = new TextureBrush(BackgroundImage))
                {
                    brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    g.FillRectangle(brush, paintRect);
                }
            }


            if (BackColor.A > 0)
            {
                using (var brush = new SolidBrush(BackColor))
                {
                    g.FillRectangle(brush, paintRect);
                }
            }
        }

    }
}
