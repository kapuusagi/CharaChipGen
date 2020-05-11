using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// ユーティリティメソッドを提供するクラス
    /// </summary>
    public static class ColorUtility
    {
        /// <summary>
        /// 色相を0-360の範囲に変換する。
        /// </summary>
        /// <param name="hue">色相</param>
        /// <returns>色相値</returns>
        public static float GetHueWithLimitedRange(float hue)
        {
            int hueBase = (int)(hue - ((int)(hue) % 360));
            return (hue >= 0.0f) ? (hue - hueBase) : (hue - hueBase + 360.0f);
        }


        /// <summary>
        /// min-maxの範囲に制限した値を返す。
        /// </summary>
        /// <param name="f">クランプさせる値。</param>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns>クランプした値</returns>
        public static float Clamp(float f, float min, float max)
            => (f < min) ? min : ((f > max) ? max : f);

        /// <summary>
        /// min-maxの範囲に制限した値を返す。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp(int d, int min, int max)
            => (d < min) ? min : ((d > max) ? max : d);

        /// <summary>
        /// 指定された割合分だけ変化させた値を返す。
        /// modifyPercent = 0.0の時、valueが返る。
        /// modifyPercent = 1.0の時、maxが返る。
        /// modifyPercent = -1.0の時、minが返る。
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="min">valueの取り得る最小値</param>
        /// <param name="max">valueの取り得る最大値</param>
        /// <param name="modifyPercent">変更割合(-1.0≦modifyPercent≦1.0)</param>
        /// <returns>変化させた値</returns>
        internal static int ModifyValueByPercent(int value, int min, int max, float modifyPercent)
        {
            float f;
            if (modifyPercent > 0)
            {
                float diff = (max - value) * modifyPercent;
                f = value + diff;
            }
            else if (modifyPercent < 0)
            {
                float diff = (value - min) * (modifyPercent);
                f = value + diff;
            }
            else
            {
                f = value;
            }

            return Clamp((int)(f), min, max);
        }

        /// <summary>
        /// 指定された割合分だけ変化させた値を返す。
        /// modifyPercent = 0.0の時、valueが返る。
        /// modifyPercent = 1.0の時、maxが返る。
        /// modifyPercent = -1.0の時、minが返る。
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="min">valueの取り得る最小値</param>
        /// <param name="max">valueの取り得る最大値</param>
        /// <param name="modifyPercent">変更割合(-1.0≦modifyPercent≦1.0)</param>
        /// <returns>変化させた値</returns>
        internal static float ModifyValueByPercent(float value, float min, float max, float modifyPercent)
        {
            float f;
            if (modifyPercent > 0)
            {
                float diff = (max - value) * modifyPercent;
                f = value + diff;
            }
            else if (modifyPercent < 0)
            {
                float diff = (value - min) * (modifyPercent);
                f = value + diff;
            }
            else
            {
                f = value;
            }

            return Clamp(f, min, max);
        }

        /// <summary>
        /// Colorオブジェクトを構築する。
        /// 0-255の範囲外にあった場合、0-255の範囲に制限して色を構築して返す。
        /// </summary>
        /// <param name="alpha">不透明度</param>
        /// <param name="red">赤</param>
        /// <param name="green">緑</param>
        /// <param name="blue">青</param>
        /// <returns>Colorオブジェクトが返る。</returns>
        internal static Color GetColor(int alpha, int red, int green, int blue)
        {
            int a = Clamp(alpha, 0, 255);
            int r = Clamp(red, 0, 255);
            int g = Clamp(green, 0, 255);
            int b = Clamp(blue, 0, 255);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
