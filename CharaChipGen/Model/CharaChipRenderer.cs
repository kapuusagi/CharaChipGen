using CGenImaging;
using CharaChipGen.Model.Layer;
using System.Drawing;
using System.Threading.Tasks;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクタチップを生成するための処理をAPIを提供するクラス。
    /// </summary>
    public static class CharaChipRenderer
    {
        /// <summary>
        /// modelのパターン(x,y)をbufferに描画する
        /// </summary>
        /// <param name="model">レイヤーモデル</param>
        /// <param name="buffer">描画対象バッファ</param>
        /// <param name="xPos">水平位置</param>
        /// <param name="yPos">垂直位置</param>
        public static void Draw(CharaChipRenderData model, ImageBuffer buffer, int xPos, int yPos)
        {
            if ((xPos < 0) || (xPos > 2) || (yPos < 0) || (yPos > 3))
            {
                return;
            }

            buffer.Clear();

            if ((model == null) || (model.LayerCount == 0))
            {
                return;
            }

            for (int i = model.LayerCount - 1; i >= 0; i--)
            {
                RenderLayer layer = model.GetLayer(i);
                if (layer.Image == null)
                {
                    continue;
                }

                // レイヤーを描画する。
                DrawLayer(buffer, xPos, yPos, layer);
            }
        }


        /// <summary>
        /// レイヤーを描画する
        /// </summary>
        /// <param name="buffer">描画対象のBMP</param>
        /// <param name="xPos">描画対象の水平位置(0≦xPos＜3) </param>
        /// <param name="yPos">描画対象の垂直位置(0≦yPos＜4)</param>
        /// <param name="layer">レイヤーモデル</param>
        private static void DrawLayer(ImageBuffer buffer, int xPos, int yPos, RenderLayer layer)
        {
            ImageBuffer srcImage = layer.GetProcessedImage();
            if (srcImage == null)
            {
                return; // このレイヤーは描画対象が存在しない。
            }
            int srcWidth = srcImage.Width / 3;
            int srcHeight = srcImage.Height / 4;
            int srcOriginX = srcWidth * xPos;
            int srcOriginY = srcHeight * yPos;
            int xOffset = (buffer.Width - srcWidth) / 2 - layer.OffsetX;
            int yOffset = (buffer.Height - srcHeight) / 2 - layer.OffsetY;
            int opacity = layer.Opacity;

            Parallel.For(0, srcHeight, y =>
            {
                for (int x = 0; x < srcWidth; x++)
                {
                    int dstX = x + xOffset;
                    int dstY = y + yOffset;

                    Color srcColor = srcImage.GetPixel(srcOriginX + x, srcOriginY + y);
                    if ((dstX < 0) || (dstX >= buffer.Width)
                        || (dstY < 0) || (dstY >= buffer.Height)
                        || (srcColor.A == 0x0))
                    {
                        // コピー先の座標が範囲外であるか、
                        // ソースが完全透明なので処理不要。
                        continue;
                    }
                    srcColor = ImageProcessor.ProcessHSLFilter(srcColor, layer.Hue, layer.Saturation, layer.Value);
                    if (opacity < 100)
                    {
                        int newAlpha = (int)(srcColor.A * opacity / 100.0f);
                        srcColor = Color.FromArgb(newAlpha, srcColor.R, srcColor.G, srcColor.B);
                    }

                    var dstColor = ImageProcessor.Blend(srcColor, buffer.GetPixel(dstX, dstY));
                    buffer.SetPixel(dstX, dstY, dstColor);
                }
            });
        }
    }
}
