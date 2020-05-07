﻿namespace CGenImaging
{
    public struct ColorHSV
    {
        /// <summary>
        ///  新しいHIV色を取得する
        /// </summary>
        /// <param name="hue">色差</param>
        /// <param name="saturation">彩度</param>
        /// <param name="value">輝度</param>
        /// <returns>色</returns>
        public static ColorHSV FromHSV(int hue, int saturation, int value)
        {
            ColorHSV c = new ColorHSV();

            // 値の範囲を補正する。
            hue %= 360;
            if (hue < 0)
            {
                hue += 360;
            }
            c.hue = hue;

            c.saturation = (byte)((saturation > 255) ? 255 : ((saturation < 0) ? 0 : saturation));
            c.value = (byte)((value > 255) ? 255 : ((value < 0) ? 0 : value));

            return c;
        }


        private int hue; // 色差 0-360
        private byte saturation; // 彩度 0-255
        private byte value; // 輝度 0-255

        /// <summary>
        /// 色差。（0≦Hue＜360） 
        /// </summary>
        public int Hue {
            get { return this.hue; }
        }
        /// <summary>
        /// 彩度
        /// </summary>
        public byte Saturation {
            get { return saturation; }
        }
        /// <summary>
        /// 輝度
        /// </summary>
        public byte Value {
            get { return value; }
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return $"H:{hue} S:{saturation} V:{Value}";
        }
    }
}
