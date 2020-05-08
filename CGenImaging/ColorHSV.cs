namespace CGenImaging
{
    /// <summary>
    /// HSV(色相、彩度、明度)の色を表すモデル。
    /// </summary>
    public struct ColorHSV
    {
        /// <summary>
        /// 新しいHSV色を取得する
        /// </summary>
        /// <param name="hue">色相(0≦hue＜360)</param>
        /// <param name="saturation">彩度(0≦saturation≦255)</param>
        /// <param name="value">明度(0≦value≦255)</param>
        /// <returns>色</returns>
        public static ColorHSV FromHSV(int hue, int saturation, int value)
            => FromAHSV(255, hue, saturation, value);


        /// <summary>
        /// 新しいHSV色を取得する
        /// </summary>
        /// <param name="hue">色相(0≦hue＜360)</param>
        /// <param name="saturation">彩度(0≦saturation≦1.0)</param>
        /// <param name="value">明度(0≦value≦1.0)</param>
        /// <returns>色</returns>
        public static ColorHSV FromHSV(float hue, float saturation, float value)
            => FromAHSV(1.0f, hue, saturation, value);

        /// <summary>
        /// 新しいHSV色を取得する
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦255)</param>
        /// <param name="hue">色相(0≦hue＜360)</param>
        /// <param name="saturation">彩度(0≦saturation≦255)</param>
        /// <param name="value">明度(0≦value≦255)</param>
        /// <returns>色</returns>
        public static ColorHSV FromAHSV(int alpha, int hue, int saturation, int value)
        {
            float a = alpha / 1.0f;
            float h = (float)(hue);
            float s = saturation / 255.0f;
            float v = value / 255.0f;
            return FromAHSV(a, h, s, v);
        }

        /// <summary>
        ///  新しいHSV色を取得する
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦1.0)</param>
        /// <param name="hue">色相(0≦hue＜360)</param>
        /// <param name="saturation">彩度(0≦saturation≦1.0)</param>
        /// <param name="value">明度(0≦value≦1.0)</param>
        /// <returns>色</returns>
        public static ColorHSV FromAHSV(float alpha, float hue, float saturation, float value)
        {
            // 値の範囲を補正する。
            float a = ColorUtility.Restrict(alpha, 0.0f, 1.0f);
            float h = ColorUtility.GetHueWithLimitedRange(hue);
            float s = ColorUtility.Restrict(saturation, 0.0f, 1.0f);
            float v = ColorUtility.Restrict(value, 0.0f, 1.0f);

            return new ColorHSV(a, h, s, v);
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="alpha">不透明度(0.0≦alpha≦1.0)</param>
        /// <param name="hue">色相(0≦hue＜360)</param>
        /// <param name="saturation">彩度(0≦saturation≦1.0)</param>
        /// <param name="value">明度(0≦value≦1.0)</param>
        private ColorHSV(float alpha, float hue, float saturation, float value)
        {
            Alpha = alpha;
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }

        /// <summary>
        /// 不透明度(0≦Alpha≦1.0))
        /// </summary>
        public float Alpha { get; private set; }

        /// <summary>
        /// 色差。（0≦Hue＜360） 
        /// </summary>
        public float Hue { get; private set; }
        /// <summary>
        /// 彩度
        /// </summary>
        public float Saturation { get; private set; }
        /// <summary>
        /// 明度(Brightness)
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return $"Color [A={Alpha}, H={Hue}, S={Saturation}, V={Value}]";
        }


    }
}
