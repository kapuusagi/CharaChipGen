using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CGenImaging;

namespace CharaChipGen.Model
{
    /// <summary>
    /// フェイスデータを生成するためのAPIを提供するクラス。
    /// </summary>
    class CharaFaceGenerator
    {
        private CharaFaceGenerator()
        {
        }

        /// <summary>
        /// 描画する。
        /// </summary>
        /// <param name="model">レイヤーモデル</param>
        /// <param name="buffer">描画対象バッファ</param>
        public static void Draw(CharaFaceRenderModel model, ImageBuffer buffer)
        {
            buffer.Clear();

            if ((model == null) || (model.LayerCount == 0))
            {
                return;
            }

            for (int i = model.LayerCount - 1; i >= 0; i--)
            {
                CharaFaceRenderLayerModel layer = model.GetLayer(i);
                if (layer.Image == null)
                {
                    continue;
                }

                // レイヤーを描画する。
                DrawLayer(buffer, layer);
            }
        }

        /// <summary>
        /// レイヤーを描画する
        /// </summary>
        /// <param name="buffer">描画対象のバッファ</param>
        /// <param name="layer">レイヤー</param>
        private static void DrawLayer(ImageBuffer buffer, CharaFaceRenderLayerModel layer)
        {
            ImageBuffer srcImage = layer.GetProcessedImage();
            if (srcImage == null)
            {
                return; // このレイヤーは描画対象が存在しない。
            }

            // まず、元データのうち、どの部分を取り出すのかを計算する。
            float aspectRatio = (float)(buffer.Height) / (float)(buffer.Width);

            int srcWidth = srcImage.Width;
            int srcHeight = (int)(srcImage.Width * aspectRatio);
            if (srcImage.Height < srcHeight)
            {
                srcWidth = (int)(srcImage.Height * buffer.Width / buffer.Height);
                srcHeight = srcImage.Height;
            }
            float ratioX = (float)(srcImage.Width) / (float)(buffer.Width);
            float ratioY = (float)(srcImage.Height) / (float)(buffer.Height);

            int xOffset = (srcImage.Width - srcWidth) / 2;
            int yOffset = (srcImage.Height - srcHeight) / 2;

            for (int y = 0; y < buffer.Height; y++)
            {
                for (int x = 0; x < buffer.Height; x++)
                {
                    int srcX = (int)((x * ratioX) + xOffset);
                    int srcY = (int)((y * ratioY) + yOffset);

                    Color srcColor = srcImage.GetPixel(srcX, srcY);
                    if (srcColor.A == 0x0)
                    {
                        // ソースが完全透明
                        continue;
                    }
                    srcColor = ImageProcessor.ProcessHSVFilter(srcColor, layer.Hue, layer.Saturation, layer.Value);

                    Color dstColor;
                    if (srcColor.A == 0xff)
                    {
                        dstColor = srcColor;　// 上のレイヤーのアルファ値が0xffなのでブレンディング処理不要。
                    }
                    else
                    {
                        dstColor = ImageProcessor.Blend(srcColor, buffer.GetPixel(x, y));
                    }
                    buffer.SetPixel(x, y, dstColor);
                }
            }
        }
    }
}
