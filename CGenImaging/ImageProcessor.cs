﻿using System;
using System.Drawing;
using System.Threading.Tasks;

namespace CGenImaging
{
    /// <summary>
    /// 画像処理のインタフェースを提供する
    /// </summary>
    public class ImageProcessor
    {
        /// <summary>
        /// cで指定された色で着色して返す。
        /// </summary>
        /// <remarks>このアルゴリズムでいいんだろうか</remarks>
        /// <param name="srcColor"></param>
        /// <param name="c"></param>
        /// <returns>着色した色</returns>
        public static Color ProcessColoring(Color srcColor, Color c)
        {
            // Note: BT.709でグレースケール変換する。
            float v = ColorConverter.ConvertRGBToGrayscale(srcColor.R / 255.0f, srcColor.G / 255.0f, srcColor.B / 255.0f);
            if (v < 0.5)
            {
                // 暗い方は割合として使用する。
                float rate = v * 2;
                int r = ColorUtility.Clamp(Convert.ToInt32(c.R * rate), 0, 255);
                int g = ColorUtility.Clamp(Convert.ToInt32(c.G * rate), 0, 255);
                int b = ColorUtility.Clamp(Convert.ToInt32(c.B * rate), 0, 255);
                return Color.FromArgb(srcColor.A, r, g, b);
            }
            else
            {
                // 明るい方は、白に寄せる。
                float rate = (v - 0.5f) * 2;
                int r = ColorUtility.Clamp(Convert.ToInt32(c.R + (255 - c.R) * rate), 0, 255);
                int g = ColorUtility.Clamp(Convert.ToInt32(c.G + (255 - c.R) * rate), 0, 255);
                int b = ColorUtility.Clamp(Convert.ToInt32(c.B + (255 - c.R) * rate), 0, 255);
                return Color.FromArgb(srcColor.A, r, g, b);
            }
        }

        /// <summary>
        /// srcColorをグレースケール変換し、指定されたLUTで着色して返す。
        /// </summary>
        /// <param name="srcColor">ベースカラー</param>
        /// <param name="lut">LUT</param>
        /// <returns>色</returns>
        public static Color ProcessColoring(Color srcColor, ILut lut)
        {
            if (lut.Resolution != 256)
            {
                throw new ArgumentException($"Gradiation Lut resolution unsupported.");
            }

            var index = ColorConverter.ConvertRGBToGrayscale(srcColor);
            return lut.Get(index);
        }


        /// <summary>
        /// cで指定された色で着色して返す。
        /// </summary>
        /// <param name="image">元画像</param>
        /// <param name="c">色</param>
        /// <returns>着色した画像</returns>
        public static ImageBuffer ProcessColoring(ImageBuffer image, Color c)
        {
            ImageBuffer dst = ImageBuffer.Create(image.Width, image.Height);

            Parallel.For(0, image.Height, y =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);

                    dst.SetPixel(x, y, ProcessColoring(srcColor, c));
                }
            });
            return dst;
        }

        /// <summary>
        /// HSVの色調整を行ってピクセルデータを返す。
        /// </summary>
        /// <param name="c">カラー</param>
        /// <param name="hue">色差加算値(-360≦hue≦360)</param>
        /// <param name="saturation">彩度加割合(-255≦saturation≦255)</param>
        /// <param name="value">明度加算割合(-255≦value≦255)</param>
        /// <returns>カラー</returns>
        public static Color ProcessHSVFilter(Color c, int hue, int saturation, int value)
        {
            if (((hue == 0) && (saturation == 0) && (value == 0)))
            {
                return c; // 色変換しない。
            }

            var srcHSV = ColorConverter.ConvertRGBtoHSV(c);
            float h = ColorUtility.GetHueWithLimitedRange((srcHSV.Hue + hue) % 360.0f);

            float s = ColorUtility.ModifyValueByPercent(srcHSV.Saturation, 0f, 1.0f, saturation / 255.0f);
            float v = Math.Min(ColorUtility.ModifyValueByPercent(srcHSV.Value, 0f, srcHSV.Value * 2, value / 255.0f), 1.0f);

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

            Parallel.For(0, image.Height, y =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);

                    dst.SetPixel(x, y, ProcessHSVFilter(srcColor, hue, saturation, value));
                }
            });
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
            float l = Math.Min(ColorUtility.ModifyValueByPercent(srcHSL.Lightness, 0f, srcHSL.Lightness * 2, lightness / 255.0f), 1.0f);

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

            Parallel.For(0, image.Height, y =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);

                    dst.SetPixel(x, y, ProcessHSLFilter(srcColor, hue, saturation, lightness));
                }
            });
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

            Parallel.For(0, image.Height, y =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);
                    dst.SetPixel(x, y, MonoricColor(srcColor, color));
                }
            });
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

            Parallel.For(0, image.Height, y =>
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color srcColor = image.GetPixel(x, y);
                    dst.SetPixel(x, y, SepiaColor(srcColor));
                }
            });
            return dst;
        }

        /// <summary>
        /// 輝度・彩度はそのままで、hueで指定された色相の色を得る。
        /// </summary>
        /// <param name="color">色</param>
        /// <param name="hue">変更先の色相(0≦hue≦360)</param>
        /// <returns>変化させた色</returns>
        public static Color MonoricColor(Color color, float hue)
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
            ColorHSV newHsv = ColorConverter.ConvertRGBtoHSV(modifyTo);
            return MonoricColor(color, newHsv.Hue);
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
        /// 通常のブレンドモード(Nrmal, c1)
        /// 
        /// ブレンディング処理については以下のURLを参考にした。
        /// http://d.hatena.ne.jp/yus_iri/20110921/1316610121
        /// </summary>
        /// <param name="c1">色1(前景色)</param>
        /// <param name="c2">色2(背景色)</param>
        /// <returns>ブレンディングされた色</returns>
        public static Color Blend(Color c1, Color c2)
        {
            if ((c1.A >= 255) || (c2.A == 0))
            {
                // c1.Aが255(不透明)または c2.Aが透過(A=0)だと、
                // 計算結果がc1になるのでそのまま返す。
                return c1;
            }

            float a1 = (c1.A * c2.A) / (float)(255 * 255);
            float a2 = (c1.A * (255 - c2.A)) / (float)(255 * 255);
            float a3 = ((255 - c1.A) * c2.A) / (float)(255 * 255);
            float alpha = a1 + a2 + a3;
            if (alpha == 0)
            {
                return Color.FromArgb(0, 0, 0, 0);
            }
            // Note: ブレンドモードがNormalじゃないなら、a1に乗算する対象を変える必要がある。
            int r = (int)(ColorUtility.Clamp((a1 * c1.R + a2 * c1.R + a3 * c2.R) / alpha, 0, 255));
            int g = (int)(ColorUtility.Clamp((a1 * c1.G + a2 * c1.G + a3 * c2.G) / alpha, 0, 255));
            int b = (int)(ColorUtility.Clamp((a1 * c1.B + a2 * c1.B + a3 * c2.B) / alpha, 0, 255));
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
            Parallel.For(0, output.Height, y =>
            {
                for (int x = 0; x < output.Width; x++)
                {
                    Color c1 = image1.GetPixel(x, y);
                    Color c2 = image2.GetPixel(x, y);

                    output.SetPixel(x, y, Blend(c1, c2));
                }
            });
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
            Parallel.For(0, output.Height, y =>
            {
                for (int x = 0; x < output.Width; x += 2)
                {
                    Color c = image.GetPixel(x / 2, y / 2);
                    output.SetPixel(x + 0, y, c);
                    output.SetPixel(x + 1, y, c);
                }
            });
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
            Parallel.For(0, output.Height, y =>
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
            });
            return output;

        }
    }
}
