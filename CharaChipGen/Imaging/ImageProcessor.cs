﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CharaChipGen.Imaging
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
        /// <param name="hue">色差加算値</param>
        /// <param name="saturation">彩度加算値</param>
        /// <param name="value">輝度加算値</param>
        /// <returns></returns>
        public static Color ProcessHSVFilter(Color c, int hue, int saturation, int value)
        {
            if ((c.A == 0) || ((hue == 0) && (saturation == 0) && (value == 0)))
            {
                return c; // アルファ値が0または色変換しない。
            }

            ColorHSV srcHSV = ColorConverter.ConvertRGBtoHSV(c);
            int h = (srcHSV.Hue + hue) % 360;
            int s = srcHSV.Saturation + saturation;
            int v = srcHSV.Value + value;

            return ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(h, s, v), c.A);
        }

        /// <summary>
        /// HSVの色調整を行ったデータを返す。
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="hue">色相加算値</param>
        /// <param name="saturation">彩度加算値</param>
        /// <param name="value">輝度加算値</param>
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
        /// 色のブレンディング処理を行う。
        /// 
        /// ブレンディング処理については以下のURLを参考にした。
        /// http://d.hatena.ne.jp/yus_iri/20110921/1316610121
        /// </summary>
        /// <param name="c1">色1</param>
        /// <param name="c2">色2</param>
        /// <returns></returns>
        public static Color Blend(Color c1, Color c2)
        {
            float a1 = (c1.A * c2.A) / (float)(255 * 255);
            float a2 = (c1.A * (255 - c2.A)) / (float)(255 * 255);
            float a3 = ((255 - c1.A) * c2.A) / (float)(255 * 255);
            int a = (int)((a1 + a2 + a3) * 255);
            int r = (int)(a1 * (c1.R + c2.R) / 2 + a2 * c1.R + a3 * c2.R) / a;
            int g = (int)(a1 * (c1.G + c2.G) / 2 + a2 * c1.G + a3 * c2.G) / a;
            int b = (int)(a1 * (c1.B + c2.B) / 2 + a2 * c1.B + a3 * c2.B) / a;
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
    }
}
