using System;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// 色変換を行う機能を提供する。
    /// 
    /// HSV<->RGBの処理は次のURLを参考にした。
    /// https://pokosho.com/t/image/8/
    /// 
    /// HSL<->RGBの処理は次のURLを参考にした。
    /// https://www.peko-step.com/tool/hslrgb.html
    /// 
    /// グレースケール変換は、次のURLを参考にした。
    /// https://qiita.com/yoya/items/96c36b069e74398796f3
    /// SMPTEの規格書でもいいと思うけど。
    /// </summary>
    public static class ColorConverter
    {
        /// <summary>
        /// RGBからHSVへ変換を行う
        /// </summary>
        /// <param name="rgb">RGBカラー</param>
        /// <returns>HSVカラー</returns>
        public static ColorHSV ConvertRGBtoHSV(Color rgb)
        {
            int min = Math.Min(rgb.G, Math.Min(rgb.B, rgb.R));
            int max = Math.Max(rgb.G, Math.Max(rgb.B, rgb.R));

            float hue = GetHue(rgb, min, max);

            float saturation = (max != 0) ? (float)(max - min) / (float)(max) : 0f;
            float value = (float)(max) / 255.0f;

            return ColorHSV.FromHSV(hue, saturation, value);
        }

        /// <summary>
        /// HSVからRGBへ変換を行う
        /// </summary>
        /// <param name="hsv">HSVカラー</param>
        /// <returns>RGBカラーが返る</returns>
        public static Color ConvertHSVtoRGB(ColorHSV hsv)
            => ConvertHSVtoRGB(hsv, hsv.Alpha);

        /// <summary>
        /// HSVからRGBへ変換を行う
        /// </summary>
        /// <param name="hsv">HSVカラー</param>
        /// <param name="alpha">アルファ値(0≦alpha≦1.0)</param>
        /// <returns>RGBカラーが返る</returns>
        public static Color ConvertHSVtoRGB(ColorHSV hsv, float alpha)
        {
            int a = ColorUtility.Clamp(Convert.ToInt32(alpha * 255.0f), 0, 255);
            return ConvertHSVtoRGB(hsv, (byte)(a));
        }

        /// <summary>
        /// HSVからRGBへ変換を行う
        /// </summary>
        /// <param name="hsv">HSVカラー</param>
        /// <param name="alpha">アルファ値(0≦alpha≦255)</param>
        /// <returns>RGBカラーが返る</returns>
        public static Color ConvertHSVtoRGB(ColorHSV hsv, byte alpha)
        {
            int h = (Convert.ToInt32(hsv.Hue) / 60) % 6;
            int v = Convert.ToInt32(hsv.Value * 255.0f);
            int p = Convert.ToInt32((hsv.Value * (1.0f - hsv.Saturation)) * 255.0f);
            int q = Convert.ToInt32(hsv.Value * (1.0f - hsv.Saturation * (hsv.Hue - h * 60.0f) / 60.0f) * 255.0f);
            int t = Convert.ToInt32(hsv.Value * (1.0f - hsv.Saturation * ((h + 1.0f) * 60.0f - hsv.Hue) / 60.0f) * 255.0f);
            if ((hsv.Hue >= 0) && (hsv.Hue < 60))
            {
                return ColorUtility.GetColor(alpha, v, t, p);
            }
            else if ((hsv.Hue >= 60) && (hsv.Hue < 120)) 
            {
                return ColorUtility.GetColor(alpha, q, v, p);
            }
            else if ((hsv.Hue >= 120) && (hsv.Hue < 180))
            {
                return ColorUtility.GetColor(alpha, p, v, t);
            }
            else if ((hsv.Hue >= 180) && (hsv.Hue < 240))
            {
                return ColorUtility.GetColor(alpha, p, q, v);
            }
            else if ((hsv.Hue >= 240) && (hsv.Hue < 300))
            {
                return ColorUtility.GetColor(alpha, t, p, v);
            }
            else if ((hsv.Hue >= 300) && (hsv.Hue < 360))
            {
                return ColorUtility.GetColor(alpha, v, p, q);
            }
            else
            {
                return ColorUtility.GetColor(alpha, 0, 0, 0);
            }
        }

        /// <summary>
        ///  RGBからHSLへ変換を行う。
        /// </summary>
        /// <param name="rgb">RGB色</param>
        /// <returns>HSL色</returns>
        public static ColorHSL ConvertRGBtoHSL(Color rgb)
        {
            int min = Math.Min(rgb.G, Math.Min(rgb.B, rgb.R));
            int max = Math.Max(rgb.G, Math.Max(rgb.B, rgb.R));

            float hue = GetHue(rgb, min, max);

            float lightness = ((min + max) / 2.0f) / 255.0f;
            float saturation;

            if (min == max)
            {
                saturation = 0.0f;
            }
            else
            {
                saturation = (lightness < 0.5)
                    ? (float)(max - min) / (float)(max + min)
                    : (float)(max - min) / (2 * 255.0f - max - min);
            }

            return ColorHSL.FromHSL(hue, saturation, lightness);
        }

        /// <summary>
        /// HSLからRGBへ変換を行う。
        /// </summary>
        /// <param name="hsl">HSL色</param>
        /// <returns>RGB色</returns>
        public static Color ConvertHSLtoRGB(ColorHSL hsl)
            => ConvertHSLtoRGB(hsl, hsl.Alpha);

        /// <summary>
        /// HSLからRGBへ変換を行う。
        /// </summary>
        /// <param name="hsl">HSL色</param>
        /// <param name="alpha">アルファ値(0≦alpha≦1.0)</param>
        /// <returns>RGB色</returns>
        public static Color ConvertHSLtoRGB(ColorHSL hsl, float alpha)
        {
            int a = Convert.ToInt32(ColorUtility.Clamp(alpha * 255.0f, 0.0f, 255.0f));
            return ConvertHSLtoRGB(hsl, (byte)(a));
        }

        /// <summary>
        /// HSLからRGBへ変換を行う。
        /// </summary>
        /// <param name="hsl">HSL色</param>
        /// <param name="alpha">アルファ値(0≦alpha≦255)</param>
        /// <returns>RGB色</returns>
        public static Color ConvertHSLtoRGB(ColorHSL hsl, byte alpha)
        {
            float min = (hsl.Lightness < 0.5f)
                ? (hsl.Lightness - hsl.Lightness * (hsl.Saturation)) * 255.0f
                : (hsl.Lightness - (1.0f - hsl.Lightness) * hsl.Saturation) * 255.0f;
            float max = (hsl.Lightness < 0.5f)
                ? (hsl.Lightness + hsl.Lightness * (hsl.Saturation)) * 255.0f
                : (hsl.Lightness + (1.0f - hsl.Lightness) * hsl.Saturation) * 255.0f;

            int r, g, b;
            if ((hsl.Hue >= 0) && (hsl.Hue < 60))
            {
                r = Convert.ToInt32(max);
                g = Convert.ToInt32((hsl.Hue / 60.0f) * (max - min) + min);
                b = Convert.ToInt32(min);
            }
            else if ((hsl.Hue >= 60) && (hsl.Hue < 120))
            {
                r = Convert.ToInt32(((120.0f - hsl.Hue) / 60.0f) * (max - min) + min);
                g = Convert.ToInt32(max);
                b = Convert.ToInt32(min);
            }
            else if ((hsl.Hue >= 120) && (hsl.Hue < 180))
            {
                r = Convert.ToInt32(min);
                g = Convert.ToInt32(max);
                b = Convert.ToInt32(((hsl.Hue - 120.0f) / 60.0f) * (max - min) + min);
            }
            else if ((hsl.Hue >= 180) && (hsl.Hue < 240))
            {
                r = Convert.ToInt32(min);
                g = Convert.ToInt32(((240 - hsl.Hue) / 60.0f) * (max - min) + min);
                b = Convert.ToInt32(max);
            }
            else if ((hsl.Hue >= 240) && (hsl.Hue < 300))
            {
                r = Convert.ToInt32(((hsl.Hue - 240) / 60.0f) * (max - min) + min);
                g = Convert.ToInt32(min);
                b = Convert.ToInt32(max);
            }
            else if ((hsl.Hue >= 300) && (hsl.Hue < 360))
            {
                r = Convert.ToInt32(max);
                g = Convert.ToInt32(min);
                b = Convert.ToInt32(((360 - hsl.Hue) / 60.0f) * (max - min) + min);
            }
            else
            {
                r = 0;
                g = 0;
                b = 0;
            }
            return ColorUtility.GetColor(alpha, r, g, b);
        }

        /// <summary>
        /// 色相を得る。
        /// </summary>
        /// <param name="rgb">RGBカラー</param>
        /// <param name="min">R,G,Bのうち最小値</param>
        /// <param name="max">R,G,Bのうち最大値</param>
        /// <returns>色相が返る</returns>
        private static float GetHue(Color rgb, int min, int max)
        {
            if (max != min)
            {
                if (rgb.R == max)
                {
                    float h = 60.0f * (rgb.G - rgb.B) / (float)(max - min);
                    return ColorUtility.GetHueWithLimitedRange(h);
                }
                else if (rgb.G == max)
                {
                    float h = 60.0f * (rgb.B - rgb.R) / (float)(max - min) + 120.0f;
                    return ColorUtility.GetHueWithLimitedRange(h);
                }
                else
                {
                    float h = 60.0f * (rgb.R - rgb.G) / (float)(max - min) + 240.0f;
                    return ColorUtility.GetHueWithLimitedRange(h);
                }
            }
            else
            {
                return 0.0f;
            }
        }

        /// <summary>
        /// 補色を計算する。
        /// </summary>
        /// <param name="c">カラー</param>
        /// <returns>補色</returns>
        public static Color GetComplementaryColor(Color c)
        {
            int baseValue = Math.Max(c.R, Math.Max(c.G, c.B)) + Math.Min(c.R, Math.Min(c.G, c.B));

            return Color.FromArgb(c.A, baseValue - c.R, baseValue - c.G, baseValue - c.B);
        }


        /// <summary>
        /// グレースケールに変換する。
        /// 元の色のアルファ値は参照されない。
        /// </summary>
        /// <remarks>
        /// BT.709の返還式を使用して変換する。
        /// </remarks>
        /// <param name="c">色</param>
        /// <returns>グレースケール値</returns>
        public static byte ConvertRGBToGrayscale(Color c) 
        {
            if ((c.R == c.G) && (c.G == c.B))// 全輝度レベルが一致？
            {
                return c.R; // 既にグレースケール
            }
            else
            {
                // BT.709 HDTV
                var matrix = MatrixRGBtoYCbCr.BT709;
                return (byte)(ColorUtility.Clamp((int)(matrix.R2Y * c.R + matrix.G2Y * c.G + matrix.B2Y * c.B), 0, 255));
            }
        }

        /// <summary>
        /// RGBからグレースケールに変換する。
        /// 元の色のアルファ値は参照されない。
        /// </summary>
        /// <remarks>
        /// BT.709の返還式を使用して変換する。
        /// </remarks>
        /// <param name="r">R値(0.0≦r≦1.0)</param>
        /// <param name="g">G値(0.0≦r≦1.0)</param>
        /// <param name="b">B値(0.0≦r≦1.0)</param>
        /// <returns>グレースケール値</returns>
        public static float ConvertRGBToGrayscale(float r, float g, float b)
        {
            var matrix = MatrixRGBtoYCbCr.BT709;
            return ColorUtility.Clamp(matrix.R2Y * r + matrix.G2Y * g + matrix.B2Y * b, 0.0f, 1.0f);
        }
    }
}
