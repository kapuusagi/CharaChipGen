using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGenImaging
{
    /// <summary>
    /// HSL(色相、彩度、輝度)色空間の色を表すモデル。
    /// </summary>
    public class ColorHSL
    {
        /// <summary>
        /// 新しいHSL色を得る。
        /// </summary>
        /// <param name="hue">色相(0.0≦hue＜360)</param>
        /// <param name="saturation">彩度(0.0≦saturation≦255)</param>
        /// <param name="lightness">輝度(0.0≦lightness≦255)</param>
        /// <returns>色</returns>
        public static ColorHSL FromHSL(int hue, int saturation, int lightness)
        {
            float s = saturation / 255.0f;
            float l = lightness / 255.0f;
            return FromHSL((float)(hue), s, l);
        }

        /// <summary>
        /// 新しいHSL色を得る。
        /// </summary>
        /// <param name="hue">色相(0.0≦hue＜360)</param>
        /// <param name="saturation">彩度(0.0≦saturation≦1.0)</param>
        /// <param name="lightness">輝度(0.0≦lightness≦1.0)</param>
        /// <returns>色</returns>
        public static ColorHSL FromHSL(float hue, float saturation, float lightness)
        {
            float h = ColorUtility.GetHueWithLimitedRange(hue);
            float s = ColorUtility.Restrict(saturation, 0.0f, 1.0f);
            float l = ColorUtility.Restrict(lightness, 0.0f, 1.0f);
            return new ColorHSL(h, s, l);
        }

        /// <summary>
        /// 新しいColorHSVLオブジェクトを構築する。
        /// </summary>
        /// <param name="hue">色相</param>
        /// <param name="saturation">彩度</param>
        /// <param name="lightness">輝度</param>
        private ColorHSL(float hue, float saturation, float lightness)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        /// <summary>
        /// 色相(0.0≦hue＜360)
        /// </summary>
        public float Hue { get; private set; }
        /// <summary>
        /// 彩度(0.0≦saturation≦1.0)
        /// </summary>
        public float Saturation { get; private set; }
        /// <summary>
        /// 明度(0.0≦lightness≦1.0)
        /// </summary>
        public float Lightness { get; private set; }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        public override string ToString()
        {
            return $"Color [H={Hue}, S={Saturation}, L={Lightness}]";
        }
    }
}
