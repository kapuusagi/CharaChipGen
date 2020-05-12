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
using System.Diagnostics;

namespace CharaChipGen.ColorEditForm
{
    public partial class ColorHSVSelectView : UserControl
    {
        // 色差
        private float saturation;
        // 明度
        private float value;
        // 色相
        private float hue;
        // 表示イメージレンダリング用バッファ。
        // nullにするとOnPaint時にコントロールのサイズから再構築してレンダリングする。
        private ImageBuffer svRenderBuffer;
        // 表示イメージ。nullにするとOnPaint時に表示用イメージを再構築する。
        private Image svDisplayImage;
        // 表示イメージレンダリング用バッファ
        private ImageBuffer hueRenderBuffer;
        // 表示イメージ
        private Image hueDisplayImage;
        // S,V領域
        private Rectangle svArea;
        // Hue領域
        private Rectangle hueArea;
        // 変更ターゲット
        private Rectangle? modifyTarget;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorHSVSelectView()
        {
            hue = 0.0f;
            svRenderBuffer = null;
            svDisplayImage = null;
            hueRenderBuffer = null;
            hueDisplayImage = null;
            modifyTarget = null;
            InitializeComponent();

            UpdateAreaSize();
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
        /// 色相が変更された。
        /// </summary>
        public event EventHandler HueChanged;

        /// <summary>
        /// このコントロールの描画を行う。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // 彩度/明度ビューを描画する。
            PaintSVArea(g);

            // 色相ビューを描画する。
            PaintHueArea(g);
        }

        /// <summary>
        /// 彩度・明度ビューを描画する。
        /// </summary>
        /// <param name="g">Graphicsオブジェクト</param>
        private void PaintSVArea(Graphics g)
        { 
            if ((svRenderBuffer == null) && (svArea.Width > 2) && (svArea.Height > 2))
            {
                svRenderBuffer = ImageBuffer.Create(svArea.Width - 2, svArea.Height - 2);
                svDisplayImage = null;
            }

            if ((svDisplayImage == null) && (svRenderBuffer != null))
            {
                // ImageBufferを再レンダリング
                RenderSVImageBuffer();
                svDisplayImage = svRenderBuffer.GetImage();
            }
            if (svDisplayImage != null)
            {
                g.DrawImage(svDisplayImage, svArea.X + 1, svArea.X + 1,
                    svArea.Width - 2, svArea.Height - 2);
            }

            using (Pen pen = new Pen((value > 0.5f) ? Color.White : Color.Black))
            {
                // 選択されているsaturation, valueの位置に十字カーソルを書く
                int x = svArea.Left + Convert.ToInt32((1.0f - saturation) * (svArea.Width - 2));
                g.DrawLine(pen, x, svArea.Top, x, svArea.Bottom);
                int y = svArea.Top + Convert.ToInt32((1.0f - value) * (svArea.Height - 2));
                g.DrawLine(pen, svArea.Left, y, svArea.Right, y);
            }

            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, svArea.Left, svArea.Top,
                    svArea.Width - 1, svArea.Height - 1);
            }
        }

        /// <summary>
        /// 色選択用バッファをレンダリングする。
        /// </summary>
        private void RenderSVImageBuffer()
        {
            float hue = Hue;
            for (int y = 0; y < svRenderBuffer.Height; y++)
            {
                float value = 1.0f - (y / (float)(svRenderBuffer.Height - 1));
                for (int x = 0; x < svRenderBuffer.Width; x++)
                {
                    float saturation = 1.0f - (x / (float)(svRenderBuffer.Width - 1));
                    Color c = CGenImaging.ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(hue, saturation, value));
                    svRenderBuffer.SetPixel(x, y, c);
                }
            }
        }

        /// <summary>
        /// 色相領域を描画する。
        /// </summary>
        /// <param name="g"></param>
        private void PaintHueArea(Graphics g)
        {
            if ((hueRenderBuffer == null) && (hueArea.Width > 2) && (hueArea.Height > 2))
            {
                hueRenderBuffer = ImageBuffer.Create(hueArea.Width - 2, hueArea.Height - 2);
                hueDisplayImage = null;
            }

            if ((hueDisplayImage == null) && (hueRenderBuffer != null))
            {
                // ImageBufferを再レンダリング
                RenderHueImageBuffer();
                hueDisplayImage = hueRenderBuffer.GetImage();
            }

            if (hueDisplayImage != null)
            {
                g.DrawImage(hueDisplayImage, hueArea.X + 1, hueArea.Y + 1,
                    hueArea.Width - 2, hueArea.Height - 2);
            }

            using (Pen pen = new Pen(Color.Black))
            {
                // 選択されているHueの位置に十字カーソルを書く
                int x = hueArea.Left + Convert.ToInt32(hue / 360.0f * (hueArea.Width - 2));
                g.DrawLine(pen, x, hueArea.Top, x, hueArea.Bottom);

                Debug.WriteLine($"hue={hue}, x={x}/{hueArea.Width}");
            }

            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, hueArea.Left, hueArea.Top,
                    hueArea.Width - 1, hueArea.Height - 1);
            }
        }

        /// <summary>
        /// 色相イメージバッファをレンダリングする。
        /// </summary>
        private void RenderHueImageBuffer()
        {
            for (int x = 0; x < hueRenderBuffer.Width; x++)
            {
                float hue = ((float)(x) / (float)(hueRenderBuffer.Width - 1)) * 360.0f;
                Color c = CGenImaging.ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(hue, 1.0f, 1.0f));
                for (int y = 0; y < hueRenderBuffer.Height; y++)
                {
                    hueRenderBuffer.SetPixel(x, y, c);
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
                svDisplayImage = null;
                Invalidate();
                HueChanged?.Invoke(this, new EventArgs());
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
            svRenderBuffer = null;
            svDisplayImage = null; 
            hueRenderBuffer = null;
            hueDisplayImage = null;
            UpdateAreaSize();
            Invalidate();
        }

        /// <summary>
        /// 彩度/明度領域、色相領域の寸法を更新する。
        /// </summary>
        private void UpdateAreaSize()
        {
            svArea = new Rectangle(0, 0, Width, Height - 26);
            hueArea = new Rectangle(0, (Height > 20) ? (Height - 20) : 0, Width, (Height > 20) ? 20 : Height);
        }

        /// <summary>
        /// コントロールがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnClick(object sender, EventArgs e)
        {
            SetHSVViaPoint(PointToClient(Control.MousePosition));
        }

        /// <summary>
        /// Saturation/Valueをpointで指定した位置に設定する。
        /// </summary>
        /// <param name="point"></param>
        private void SetHSVViaPoint(Point point)
        { 
            if ((modifyTarget == svArea) && IsHit(svArea, point))
            {
                int x = point.X - svArea.Left - 1;
                int y = point.Y - svArea.Top - 1;
                float saturation = ColorUtility.Clamp(1.0f - (float)(x) / (float)(svArea.Width - 2), 0.0f, 1.0f);
                float value = ColorUtility.Clamp(1.0f - (float)(y) / (float)(svArea.Height - 2), 0.0f, 1.0f);

                Saturation = saturation;
                Value = value;
            }
            else if ((modifyTarget == hueArea) && IsHit(hueArea, point))
            {
                int x = point.X - hueArea.Left - 1;
                float hue = ColorUtility.Clamp((float)(x) / (float)(hueArea.Width - 2) * 360.0f, 0.0f, 360.0f);
                Hue = hue;
            }


        }

        /// <summary>
        /// rで指定される領域内かどうかを判定する。
        /// </summary>
        /// <param name="r">領域</param>
        /// <param name="p">クリック座標(コントロール内座標)</param>
        /// <returns></returns>
        private bool IsHit(Rectangle r, Point p)
        {
            return ((p.X >= r.Left) && (p.X <= r.Right))
                && ((p.Y >= r.Top) && (p.Y <= r.Bottom));
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
                SetHSVViaPoint(e.Location);
            }
        }

        /// <summary>
        /// マウスボタンが押されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == 0)
            {
                return;
            }

            if (IsHit(svArea, e.Location))
            {
                modifyTarget = svArea;
            }
            if (IsHit(hueArea, e.Location))
            {
                modifyTarget = hueArea;
            }
            SetHSVViaPoint(e.Location);
        }

        /// <summary>
        /// マウスがコントロール領域外に移動したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            modifyTarget = null;
        }

        /// <summary>
        /// マウスボタンが放されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == 0)
            {
                modifyTarget = null;
            }
        }
    }
}
