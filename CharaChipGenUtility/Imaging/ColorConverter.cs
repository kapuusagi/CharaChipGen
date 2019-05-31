using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CharaChipGenUtility.Imaging
{
    /// <summary>
    /// 色変換を行う機能を提供する。
    /// 
    /// HSV<->RGBの処理は次のURLを参考にした。
    /// https://pokosho.com/t/image/8/
    /// </summary>
    public class ColorConverter
    {
        /// <summary>
        /// RGBからHSVへ変換を行う
        /// </summary>
        /// <param name="rgb">RGBカラー</param>
        /// <returns>HSVカラー</returns>
        public static ColorHSV ConvertRGBtoHSV(Color rgb)
        {
            byte min = rgb.R;
            if (min > rgb.G)
            {
                min = rgb.G;
            }
            if (min > rgb.B)
            {
                min = rgb.B;
            }
            byte max = rgb.R;
            if (max < rgb.G)
            {
                max = rgb.G;
            }
            if (max < rgb.B)
            {
                max = rgb.B;
            }

            int h;
            if (max != min)
            {
                if (rgb.R == max)
                {
                    h = 60 * (rgb.G - rgb.B) / (max - min);
                }
                else if (rgb.G == max)
                {
                    h = 60 * (rgb.B - rgb.R) / (max - min) + 120;
                }
                else
                {
                    h = 60 * (rgb.R - rgb.G) / (max - min) + 240;
                }
            }
            else
            {
                h = 0;
            }

            int s;
            if (max > 0)
            {
                s = ((max - min) * 255) / max;
            }
            else
            {
                s = 0;
            }
            byte v = max;

            return ColorHSV.FromHSV(h, s, v);
        }

        /// <summary>
        /// HSVからRGBへ変換を行う
        /// </summary>
        /// <param name="hsv">HSVカラー</param>
        /// <param name="arpha">アルファ値</param>
        /// <returns>RGBカラーが返る</returns>
        public static Color ConvertHSVtoRGB(ColorHSV hsv, byte arpha)
        {
            int h = hsv.Hue / 60;
            int P = (hsv.Value * (255 - hsv.Saturation)) / 255;
            //int Q = (int)(c.Value * (255 - c.Saturation * (c.Hue / 60.0f - h))) / 255;
            int Q = (hsv.Value * (255 - hsv.Saturation * (hsv.Hue - h * 60) / 60)) / 255;
            //int T = (int)(c.Value * (255 - c.Saturation * (1.0f - c.Hue / 60.0f + h))) / 255;
            int T = (hsv.Value * (255 - hsv.Saturation * ((h + 1) * 60 - hsv.Hue) / 60)) / 255;
            switch (h)
            {
                case 0:
                    return Color.FromArgb(arpha, hsv.Value, T, P);
                case 1:
                    return Color.FromArgb(arpha, Q, hsv.Value, P);
                case 2:
                    return Color.FromArgb(arpha, P, hsv.Value, T);
                case 3:
                    return Color.FromArgb(arpha, P, Q, hsv.Value);
                case 4:
                    return Color.FromArgb(arpha, T, P, hsv.Value);
                case 5:
                    return Color.FromArgb(arpha, hsv.Value, P, Q);
                default:
                    return Color.FromArgb(arpha, 0, 0, 0);
            }
        }

    }
}
