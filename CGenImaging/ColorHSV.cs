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
            float a = alpha / 255.0f;
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
            float a = ColorUtility.Clamp(alpha, 0.0f, 1.0f);
            float h = ColorUtility.GetHueWithLimitedRange(hue);
            float s = ColorUtility.Clamp(saturation, 0.0f, 1.0f);
            float v = ColorUtility.Clamp(value, 0.0f, 1.0f);

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

        /// <summary>
        /// colorHSVで指定される色と一致しているかどうかを判定する。
        /// </summary>
        /// <param name="colorHSV">色</param>
        /// <returns>同値なものである場合にはtrue, それ以外はfalse</returns>
        public bool Equals(ColorHSV colorHSV)
        {
            return (colorHSV.Hue == Hue) && (colorHSV.Saturation == Saturation) && (colorHSV.Value == Value);
        }

        /// <summary>
        /// objで指定されたオブジェクトが同じものかどうかおｗ判定して返す。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>同値なものである場合にはtrue, それ以外はfalse</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorHSV colorHSV)
            {
                return Equals(colorHSV);
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
            int hashCode = -1269385161;
            hashCode = hashCode * -1521134295 + Alpha.GetHashCode();
            hashCode = hashCode * -1521134295 + Hue.GetHashCode();
            hashCode = hashCode * -1521134295 + Saturation.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 等号演算子オーバーライド
        /// </summary>
        /// <param name="left">左辺オブジェクト</param>
        /// <param name="right">右辺オブジェクト</param>
        /// <returns>一致しているかどうか</returns>
        public static bool operator ==(ColorHSV left, ColorHSV right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 不等号演算子オーバーライド
        /// </summary>
        /// <param name="left">左辺オブジェクト</param>
        /// <param name="right">右辺オブジェクト</param>
        /// <returns>一致しているかどうか</returns>
        public static bool operator !=(ColorHSV left, ColorHSV right)
        {
            return !(left == right);
        }
    }
}
