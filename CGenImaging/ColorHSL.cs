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
    public struct ColorHSL
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
            Alpha = alpha;
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

        /// <summary>
        /// colorHSVで指定される色と一致しているかどうかを判定する。
        /// </summary>
        /// <param name="colorHSL">色</param>
        /// <returns>同値なものである場合にはtrue, それ以外はfalse</returns>
        public bool Equals(ColorHSL colorHSL)
        {
            return (colorHSL.Hue == Hue) && (colorHSL.Saturation == Saturation) && (colorHSL.Lightness == Lightness);
        }

        /// <summary>
        /// objで指定されたオブジェクトが同じものかどうかおｗ判定して返す。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>同値なものである場合にはtrue, それ以外はfalse</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorHSL colorHSL)
            {
                return Equals(colorHSL);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// このオブジェクトのハッシュ値を得る。
        /// </summary>
        /// <returns>ハッシュ値</returns>
        public override int GetHashCode()
        {
            int hashCode = -1617763555;
            hashCode = hashCode * -1521134295 + Alpha.GetHashCode();
            hashCode = hashCode * -1521134295 + Hue.GetHashCode();
            hashCode = hashCode * -1521134295 + Saturation.GetHashCode();
            hashCode = hashCode * -1521134295 + Lightness.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 等号演算子オーバーライド
        /// </summary>
        /// <param name="left">左辺オブジェクト</param>
        /// <param name="right">右辺オブジェクト</param>
        /// <returns>一致しているかどうか</returns>
        public static bool operator ==(ColorHSL left, ColorHSL right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 不等号演算子オーバーライド
        /// </summary>
        /// <param name="left">左辺オブジェクト</param>
        /// <param name="right">右辺オブジェクト</param>
        /// <returns>一致しているかどうか</returns>
        public static bool operator !=(ColorHSL left, ColorHSL right)
        {
            return !(left == right);
        }
    }
}
