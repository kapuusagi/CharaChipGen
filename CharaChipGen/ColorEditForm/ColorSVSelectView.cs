using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CGenImaging;

namespace CharaChipGen.ColorEditForm
{
    public partial class ColorSVSelectView : UserControl
    {
        // 色差
        private float saturation;
        // 明度
        private float value;
        // 色相
        private float hue;
        // 表示イメージレンダリング用バッファ。
        // nullにするとOnPaint時にコントロールのサイズから再構築してレンダリングする。
        private ImageBuffer imageBuffer;
        // 表示イメージ。nullにするとOnPaint時に表示用イメージを再構築する。
        private Image displayImage;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorSVSelectView()
        {
            hue = 0.0f;
            imageBuffer = null;
            displayImage = null;
            InitializeComponent();
        }

        /// <summary>
        /// 色差選択が変更された。
        /// </summary>
        public event EventHandler SaturationChanged;
        /// <summary>
        /// 明度が変更された。
        /// </summary>
        public event EventHandler ValueChanged;


        /// <summary>
        /// このコントロールの描画を行う。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // 色相ビューを描画する。
            if ((imageBuffer == null) && (Width > 2) && (Height > 2))
            {
                imageBuffer = ImageBuffer.Create(Width - 2, Height - 2);
                displayImage = null;
            }

            if ((displayImage == null) && (imageBuffer != null))
            {
                // ImageBufferを再レンダリング
                RenderImageBuffer();

                displayImage = imageBuffer.GetImage();
            }
            if (displayImage != null)
            {
                g.DrawImage(displayImage, 1, 1, Width - 1, Height - 1);
            }

            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            using (Pen pen = new Pen((value > 0.5f) ? Color.White : Color.Black))
            {
                // 選択されているsaturation, valueの位置に十字カーソルを書く
                int x = Convert.ToInt32(saturation * (Width - 2));
                int y = Convert.ToInt32(value * (Height - 2));
                g.DrawLine(pen, x, 1, x, Height - 1);
                g.DrawLine(pen, 1, y, Width - 1, y);
            }
        }

        /// <summary>
        /// 色選択用バッファをレンダリングする。
        /// </summary>
        private void RenderImageBuffer()
        {
            float hue = Hue;
            for (int y = 0; y < imageBuffer.Height; y++)
            {
                float value = 1.0f - (y / (float)(imageBuffer.Height - 1));
                for (int x = 0; x < imageBuffer.Width; x++)
                {
                    float saturation = 1.0f - (x / (float)(imageBuffer.Width - 1));
                    Color c = CGenImaging.ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(hue, saturation, value));
                    imageBuffer.SetPixel(x, y, c);
                }
            }
        }

        /// <summary>
        /// 色相
        /// </summary>
        public float Hue {
            get => hue;
            set {
                float h = ColorUtility.GetHueWithLimitedRange(value);
                if (hue == h)
                {
                    return;
                }
                hue = value;
                displayImage = null;
                Invalidate();
            }
        }

        /// <summary>
        /// 色差(0.0～1.0)
        /// </summary>
        public float Saturation {
            get => saturation;
            set {
                float s = ColorUtility.Clamp(value, 0.0f, 1.0f);
                if (saturation == s)
                {
                    return;
                }
                saturation = s;
                Invalidate();
                SaturationChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// 明度(0.0～1.0)
        /// </summary>
        public float Value {
            get => value;
            set {
                float v = ColorUtility.Clamp(value, 0.0f, 1.0f);
                if (this.value == v)
                {
                    return;
                }
                this.value = v;
                Invalidate();
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// コントロールのサイズが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnResize(object sender, EventArgs e)
        {
            imageBuffer = null;
            displayImage = null; // 再構築必要
            Invalidate();
        }

        /// <summary>
        /// コントロールがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnClick(object sender, EventArgs e)
        {
            SetSVViaPoint(PointToClient(Control.MousePosition));
        }

        /// <summary>
        /// Saturation/Valueをpointで指定した位置に設定する。
        /// </summary>
        /// <param name="point"></param>
        private void SetSVViaPoint(Point point)
        { 
            float saturation = ColorUtility.Clamp((float)(point.X) / (float)(Width - 2), 0.0f, 1.0f);
            float value = ColorUtility.Clamp((float)(point.Y) / (float)(Height - 2), 0.0f, 1.0f);

            if ((saturation != Saturation) || (value != Value))
            {
                Saturation = saturation;
                Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// マウスが移動したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                SetSVViaPoint(PointToClient(Control.MousePosition));
            }
        }
    }
}
