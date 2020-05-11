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
        /// <returns></returns>
        public static ColorHSL FromHSL(int hue, int saturation, int lightness)
            => FromAHSL(255, hue, saturation, lightness);


        /// <summary>
        /// 新しいHSL色を得る。
        /// </summary>
        /// <param name="hue">色相(0.0≦hue＜360)</param>
        /// <param name="saturation">彩度(0.0≦saturation≦1.0)</param>
        /// <param name="lightness">輝度(0.0≦lightness≦1.0)</param>
        /// <returns>色</returns>
        public static ColorHSL FromHSL(float hue, float saturation, float lightness)
            => FromAHSL(1.0f, hue, saturation, lightness);


        /// <summary>
        /// 新しいHSL色を得る。
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦255)</param>
        /// <param name="hue">色相(0.0≦hue＜360)</param>
        /// <param name="saturation">彩度(0.0≦saturation≦255)</param>
        /// <param name="lightness">輝度(0.0≦lightness≦255)</param>
        /// <returns>色</returns>
        public static ColorHSL FromAHSL(int alpha, int hue, int saturation, int lightness)
        {
            float a = alpha / 255.0f;
            float s = saturation / 255.0f;
            float l = lightness / 255.0f;
            return FromAHSL(a, (float)(hue), s, l);
        }

        /// <summary>
        /// 新しいHSL色を得る。
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦1.0)</param>
        /// <param name="hue">色相(0.0≦hue＜360)</param>
        /// <param name="saturation">彩度(0.0≦saturation≦1.0)</param>
        /// <param name="lightness">輝度(0.0≦lightness≦1.0)</param>
        /// <returns>色</returns>
        public static ColorHSL FromAHSL(float alpha, float hue, float saturation, float lightness)
        {
            float a = ColorUtility.Clamp(alpha, 0.0f, 1.0f);
            float h = ColorUtility.GetHueWithLimitedRange(hue);
            float s = ColorUtility.Clamp(saturation, 0.0f, 1.0f);
            float l = ColorUtility.Clamp(lightness, 0.0f, 1.0f);
            return new ColorHSL(a, h, s, l);
        }

        /// <summary>
        /// 新しいColorHSVLオブジェクトを構築する。
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦1.0)</param>
        /// <param name="hue">色相</param>
        /// <param name="saturation">彩度</param>
        /// <param name="lightness">輝度</param>
        private ColorHSL(float alpha, float hue, float saturation, float lightness)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

        /// <summary>
        /// 不透明度(0.0≦Alpha≦1.0)
        /// </summary>
        public float Alpha { get; private set; }

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
            return $"Color [A={Alpha}, H={Hue}, S={Saturation}, L={Lightness}]";
        }
    }
}
