using System;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// 画像処理のインタフェースを提供する
    /// </summary>
    public class ImageProcessor
    {


        /// <summary>
        /// HSVの色調整を行ってピクセルデータを返す。
        /// </summary>
        /// <param name="c">カラー</param>
        /// <param name="hue">色差加算値(-360≦hue≦360)</param>
        /// <param name="saturation">彩度加割合(-255≦saturation≦255)</param>
        /// <param name="value">明度加算割合(-255≦value≦255)</param>
        /// <returns></returns>
        public static Color ProcessHSVFilter(Color c, int hue, int saturation, int value)
        {
            if (((hue == 0) && (saturation == 0) && (value == 0)))
            {
                return c; // 色変換しない。
            }

            ColorHSV srcHSV = ColorConverter.ConvertRGBtoHSV(c);
            float h = ColorUtility.GetHueWithLimitedRange((srcHSV.Hue + hue) % 360.0f);

            float s = ColorUtility.ModifyValueByPercent(srcHSV.Saturation, 0f, 1.0f, saturation / 255.0f);
            float v = ColorUtility.ModifyValueByPercent(srcHSV.Value, 0f, 1.0f, value / 255.0f);

            return ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(h, s, v), c.A);
        }

        /// <summary>
        /// HSVの色調整を行ったデータを返す。
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="hue">色相加算値(-360≦hue≦360)</param>
        /// <param name="saturation">彩度加算割合(-255≦saturation≦255)</param>
        /// <param name="value">明度加算割合(-255≦value≦255)</param>
        /// <returns>イメージを返す</returns>
        public static ImageBuffer ProcessHSVFilter(ImageBuffer image, int hue, int saturation, int value)
        {
            if ((hue == 0) || (saturation == 0) || (value == 0))
            {
                return image;
            }

            ImageBuffer dst = ImageBuffer.Create(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);

                    dst.SetPixel(x, y, ProcessHSVFilter(srcColor, hue, saturation, value));
                }
            }
            return dst;
        }

        /// <summary>
        /// HSVの色調整を行ってピクセルデータを返す。
        /// </summary>
        /// <param name="c">カラー</param>
        /// <param name="hue">色差加算値(-360≦hue≦360)</param>
        /// <param name="saturation">彩度加割合(-255≦saturation≦255)</param>
        /// <param name="lightness">輝度加算割合(-255≦lightness≦255)</param>
        /// <returns></returns>
        public static Color ProcessHSLFilter(Color c, int hue, int saturation, int lightness)
        {
            if (((hue == 0) && (saturation == 0) && (lightness == 0)))
            {
                return c; // 色変換しない。
            }

            ColorHSL srcHSL = ColorConverter.ConvertRGBtoHSL(c);
            float h = ColorUtility.GetHueWithLimitedRange((srcHSL.Hue + hue) % 360.0f);

            float s = ColorUtility.ModifyValueByPercent(srcHSL.Saturation, 0f, 1.0f, saturation / 255.0f);
            float l = ColorUtility.ModifyValueByPercent(srcHSL.Lightness, 0f, 1.0f, lightness / 255.0f);

            return ColorConverter.ConvertHSLtoRGB(ColorHSL.FromHSL(h, s, l), c.A);
        }
        /// <summary>
        /// HSVの色調整を行ったデータを返す。
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="hue">色相加算値(-360≦hue≦360)</param>
        /// <param name="saturation">彩度加算割合(-255≦saturation≦255)</param>
        /// <param name="lightness">輝度加算割合(-255≦lightness≦255)</param>
        /// <returns>イメージを返す</returns>
        public static ImageBuffer ProcessHSLFilter(ImageBuffer image, int hue, int saturation, int lightness)
        {
            if ((hue == 0) || (saturation == 0) || (lightness == 0))
            {
                return image;
            }

            ImageBuffer dst = ImageBuffer.Create(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);

                    dst.SetPixel(x, y, ProcessHSLFilter(srcColor, hue, saturation, lightness));
                }
            }
            return dst;
        }
        /// <summary>
        /// colorで指定した色相の画像を得る。
        /// </summary>
        /// <remarks>
        /// これでいけんのかな
        /// </remarks>
        /// <param name="image">イメージ</param>
        /// <param name="color">変更する色</param>
        /// <returns>単色化した画像が返る</returns>
        public static ImageBuffer ProcessMonoricColorFilter(ImageBuffer image, Color color)
        {
            ImageBuffer dst = ImageBuffer.Create(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);
                    dst.SetPixel(x, y, MonoricColor(srcColor, color));
                }
            }
            return dst;
        }

        /// <summary>
        /// セピアカラーフィルタを適用する。
        /// </summary>
        /// <param name="image">イメージ</param>
        /// <returns>セピア調の画像が返る</returns>
        public static ImageBuffer ProcessSepiaColorFilter(ImageBuffer image)
        {
            ImageBuffer dst = ImageBuffer.Create(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);
                    dst.SetPixel(x, y, SepiaColor(srcColor));
                }
            }
            return dst;
        }

        /// <summary>
        /// 輝度・彩度はそのままで、hueで指定された色相の色を得る。
        /// </summary>
        /// <param name="color">色</param>
        /// <param name="hue">変更先の色相(0≦hue≦360)</param>
        /// <returns>変化させた色</returns>
        public static Color MonoricColor(Color color, int hue)
        {
            ColorHSV hsv = ColorConverter.ConvertRGBtoHSV(color);
            ColorHSV newHsv = ColorHSV.FromHSV(hue, hsv.Saturation, hsv.Value);
            return ColorConverter.ConvertHSVtoRGB(newHsv, color.A);
        }

        /// <summary>
        /// colorで指定される色をmodifyToの色相に変更させる。
        /// </summary>
        /// <param name="color">色</param>
        /// <param name="modifyTo">変更先の色</param>
        /// <returns>変化させた色</returns>
        public static Color MonoricColor(Color color, Color modifyTo)
        {
            // Note: BT.709
            float v = 0.2126f * color.R / 255.0f
                + 0.7152f * color.G / 255.0f
                + 0.0722f * color.B / 255.0f;
            int r = ColorUtility.Clamp(Convert.ToInt32(modifyTo.R * v), 0, 255);
            int g = ColorUtility.Clamp(Convert.ToInt32(modifyTo.G * v), 0, 255);
            int b = ColorUtility.Clamp(Convert.ToInt32(modifyTo.B * v), 0, 255);
            return Color.FromArgb(color.A, r, g, b);
        }

        /// <summary>
        /// セピア色に変換する
        /// </summary>
        /// <param name="color">色</param>
        /// <returns>セピア調の色</returns>
        /// <remarks>
        /// 下記サイトを参考にした。
        /// http://k-ichikawa.blog.enjoy.jp/etc/HP/htm/imageSepia.html
        /// </remarks>
        public static Color SepiaColor(Color color)
        {
            float v = 0.2126f * color.R / 255.0f
                + 0.7152f * color.G / 255.0f
                + 0.0722f * color.B / 255.0f;
            int r = ColorUtility.Clamp(Convert.ToInt32(v * 255.0f), 0, 255);
            int g = ColorUtility.Clamp(Convert.ToInt32(v * 74.0f / 107.0f * 255.0f), 0, 255);
            int b = ColorUtility.Clamp(Convert.ToInt32(v * 43.0f / 107.0f * 255.0f), 0, 255);
            return Color.FromArgb(color.A, r, g, b);
        }

        /// <summary>
        /// 色のブレンディング処理を行う。
        /// 
        /// ブレンディング処理については以下のURLを参考にした。
        /// http://d.hatena.ne.jp/yus_iri/20110921/1316610121
        /// </summary>
        /// <param name="c1">色1</param>
        /// <param name="c2">色2</param>
        /// <returns>ブレンディングされた色</returns>
        public static Color Blend(Color c1, Color c2)
        {
            float a1 = (c1.A * c2.A) / (float)(255 * 255);
            float a2 = (c1.A * (255 - c2.A)) / (float)(255 * 255);
            float a3 = ((255 - c1.A) * c2.A) / (float)(255 * 255);
            float alpha = a1 + a2 + a3;
            if (alpha == 0)
            {
                return Color.FromArgb(0, 0, 0, 0);
            }
            int r = (int)(ColorUtility.Clamp((a1 * (c1.R + c2.R) / 2 + a2 * c1.R + a3 * c2.R) / alpha, 0, 255));
            int g = (int)(ColorUtility.Clamp((a1 * (c1.G + c2.G) / 2 + a2 * c1.G + a3 * c2.G) / alpha, 0, 255));
            int b = (int)(ColorUtility.Clamp((a1 * (c1.B + c2.B) / 2 + a2 * c1.B + a3 * c2.B) / alpha, 0, 255));
            int a = (int)(ColorUtility.Clamp(alpha * 255, 0, 255));
            return Color.FromArgb(a, r, g, b);
        }



        /// <summary>
        /// 画像をブレンド処理する。
        /// ブレンド処理した結果の新しいImageBufferを構築して返す。
        /// </summary>
        /// <param name="image1">画像1</param>
        /// <param name="image2">画像2</param>
        /// <returns>ブレンドした新しい結果の画像データ</returns>
        public static ImageBuffer Blend(ImageBuffer image1, ImageBuffer image2)
        {
            int width = (image1.Width > image2.Width) ? image1.Width : image2.Width;
            int height = (image1.Height > image2.Height) ? image1.Height : image2.Height;

            ImageBuffer output = ImageBuffer.Create(width, height);
            return Blend(image1, image2, output);
        }

        /// <summary>
        /// 画像をブレンド処理する
        /// </summary>
        /// <param name="image1">画像1</param>
        /// <param name="image2">画像2</param>
        /// <param name="output">出力</param>
        /// <returns>outputに指定したバッファが返る</returns>
        public static ImageBuffer Blend(ImageBuffer image1, ImageBuffer image2, ImageBuffer output)
        {
            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    Color c1 = image1.GetPixel(x, y);
                    Color c2 = image2.GetPixel(x, y);

                    output.SetPixel(x, y, Blend(c1, c2));
                }
            }
            return output;
        }

        /// <summary>
        /// 2倍に単純拡大する。
        /// </summary>
        /// <param name="image">画像</param>
        /// <returns>拡大した画像</returns>
        public static ImageBuffer ExpansionX2(ImageBuffer image)
        {
            ImageBuffer output = ImageBuffer.Create(image.Width * 2, image.Height * 2);
            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x += 2)
                {
                    Color c = image.GetPixel(x / 2, y / 2);
                    output.SetPixel(x + 0, y, c);
                    output.SetPixel(x + 1, y, c);
                }
            }
            return output;
        }

        /// <summary>
        /// 画像に不透明度を適用し、新しい画像として取得する。
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="opacity">不透明度(0.0≦opacity≦1.0)</param>
        /// <returns>画像が返る</returns>
        public static ImageBuffer ApplyOpacity(ImageBuffer image, float opacity)
        {
            ImageBuffer output = ImageBuffer.Create(image.Width, image.Height);
            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    Color c = image.GetPixel(x, y);

                    int newAlpha = (int)(c.A * opacity);
                    if (newAlpha < 0)
                    {
                        newAlpha = 0;
                    }
                    else if (newAlpha > 255)
                    {
                        newAlpha = 255;
                    }
                    output.SetPixel(x, y, Color.FromArgb(newAlpha, c.R, c.G, c.B));
                }
            }
            return output;

        }
    }
}
