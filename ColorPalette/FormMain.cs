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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void OnButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnColorChanged(object sender, EventArgs e)
        {
            var c1 = panelColorSelect1.Color;
            var c2 = panelColorSelect2.Color;

            var rgb = Color.FromArgb((c1.R + c2.R) / 2, (c1.G + c2.G) / 2, (c1.B + c2.B) / 2);
            var hsv = CGenImaging.ColorConverter.ConvertRGBtoHSV(rgb);

            labelR.Text = rgb.R.ToString();
            labelG.Text = rgb.G.ToString();
            labelB.Text = rgb.B.ToString();

            labelH.Text = ((int)(hsv.Hue)).ToString();
            labelS.Text = ((int)(hsv.Saturation * 255)).ToString();
            labelV.Text = ((int)(hsv.Value * 255)).ToString();

            labelPreview.BackColor = rgb;
            if (hsv.Saturation < 0.1)
            {
                labelPreview.ForeColor = (hsv.Value > 0.5) ? Color.Black : Color.White;

            }
            else
            {
                labelPreview.ForeColor = CGenImaging.ColorConverter.GetComplementaryColor(rgb);
            }
            labelPreview.Text = "#" + rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
        }
    }
}
