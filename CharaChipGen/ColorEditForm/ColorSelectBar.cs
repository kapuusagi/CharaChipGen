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
using System.Xml.Schema;
using CGenImaging;

namespace CharaChipGen.ColorEditForm
{
    public partial class ColorSelectBar : UserControl
    {
        // 設定値
        private int selectedValue;
        // 最小値
        private int minimum;
        // 最大値
        private int maximum;
        // ドラッグ中かどうか
        private bool isDragging;

        public ColorSelectBar()
        {
            minimum = 0;
            maximum = 255;
            selectedValue = 255;
            isDragging = false;
            InitializeComponent();
        }

        /// <summary>
        /// 値が変更された
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// 設定値
        /// </summary>
        public int Value {
            get => selectedValue;
            set {
                int newValue = ColorUtility.Clamp(value, minimum, maximum);
                if (selectedValue == newValue)
                {
                    return;
                }
                selectedValue = newValue;
                Invalidate();
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }
        /// <summary>
        /// 最小値
        /// </summary>
        public int Minimum {
            get => minimum;
            set {
                if (value == minimum)
                {
                    return;
                }
                minimum = value;
                if (maximum < minimum)
                {
                    maximum = minimum;
                }
                if (Value < minimum)
                {
                    Value = ColorUtility.Clamp(Value, minimum, maximum);
                }
                else
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// 最大値
        /// </summary>
        public int Maximum {
            get => maximum;
            set {
                if (value == maximum)
                {
                    return;
                }
                maximum = value;
                if (minimum > maximum)
                {
                    minimum = maximum;
                }
                if (Value > maximum)
                {
                    Value = ColorUtility.Clamp(Value, minimum, maximum);
                }
                else
                {
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 内側はグラディエーションブラシで書く
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(1, Height / 2), new Point(Width - 1, Height / 2),
                Color.Black, BackColor))
            {
                g.FillRectangle(brush, 1, 1, Width - 2, Height - 2);
            }

            // 選択値を描画
            if (Maximum > Minimum)
            {
                using (Pen pen = new Pen(ForeColor))
                {
                    float percent = (float)(Value) / (float)(Maximum - Minimum);
                    int x = Convert.ToInt32(percent * Width - 2) + 1;
                    g.DrawLine(pen, x, 1, x, Height - 1);
                }
            }

            // コントロール外枠を描画
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>
        /// コントロールのサイズが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnResize(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// マウスがコントロール上で動いた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                SetValueViaPoint(e.Location);
            }
        }

        /// <summary>
        /// pointで指定される位置に相当する値を設定する。
        /// </summary>
        /// <param name="point">位置</param>
        private void SetValueViaPoint(Point point)
        { 
            if ((maximum > minimum) && ((Width - 2) > 0))
            {
                float percent = (float)(point.X) / (float)(Width - 2);
                int newValue = Convert.ToInt32(minimum + (maximum - minimum) * percent);
                Value = newValue;
            }
        }

        /// <summary>
        /// マウスボタンが放されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        /// <summary>
        /// マウスボタンが押されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                isDragging = true;
                SetValueViaPoint(e.Location);
            }
        }

        /// <summary>
        /// マウスがコントロールの領域から離れたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            isDragging = false;
        }
    }
}
