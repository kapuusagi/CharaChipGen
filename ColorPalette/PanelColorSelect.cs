using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPalette
{
    public partial class PanelColorSelect : UserControl
    {
        // R値
        private int red;
        // G値
        private int green;
        // B値
        private int blue;

        public PanelColorSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 色が変更された
        /// </summary>
        public event EventHandler ColorChanged;

        /// <summary>
        /// 色変更を通知する。
        /// </summary>
        private void NotifyColorChanged()
        {
            ColorChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 色
        /// </summary>
        public Color Color
        {
            get
            {
                return Color.FromArgb(red, green, blue);
            }
            set
            {
                if ((red != value.R) || (green != value.G) || (blue != value.B))
                {
                    red = value.R;
                    green = value.G;
                    blue = value.B;
                    OnColorChanged();
                }
            }
        }

        /// <summary>
        /// 色が変更されたときの処理を行う。
        /// </summary>
        private void OnColorChanged()
        {
            var color = Color;
            labelColorPreview.BackColor = color;
            var hsv = CGenImaging.ColorConverter.ConvertRGBtoHSV(color);
            if (hsv.Saturation < 0.1)
            {
                labelColorPreview.ForeColor = (hsv.Value > 0.5) ? Color.Black : Color.White;
            }
            else
            {
                labelColorPreview.ForeColor = CGenImaging.ColorConverter.GetComplementaryColor(color);
            }
            labelColorPreview.Text = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

            NotifyColorChanged();
        }

        /// <summary>
        /// カラーセレクトバーで値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColorSelectBarValueChanged(object sender, EventArgs e)
        {
            if ((sender == colorSelectBarR) && (red != colorSelectBarR.Value))
            {
                red = colorSelectBarR.Value;
                OnColorChanged();
            }
            else if ((sender == colorSelectBarG) && (green != colorSelectBarG.Value))
            {
                green = colorSelectBarG.Value;
                OnColorChanged();
            }
            else if ((sender == colorSelectBarB) && (blue != colorSelectBarB.Value))
            {
                blue = colorSelectBarB.Value;
                OnColorChanged();
            }
        }

        /// <summary>
        /// 数値入力欄で値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if ((sender == numericUpDownR) && (red != numericUpDownR.Value))
            {
                red = (int)(numericUpDownR.Value);
                OnColorChanged();
            }
            else if ((sender == numericUpDownG) && (green != numericUpDownG.Value))
            {
                green = (int)(numericUpDownG.Value);
                OnColorChanged();
            }
            else if ((sender == numericUpDownB) && (blue != numericUpDownB.Value))
            {
                blue = (int)(numericUpDownB.Value);
                OnColorChanged();
            }
        }
    }
}
