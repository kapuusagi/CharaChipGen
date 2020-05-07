using System.Drawing;
using System.Drawing.Imaging;

namespace CGenImaging
{
    public class ImageBuffer
    {
        /// <summary>
        /// imageを元にイメージバッファを作成する
        /// </summary>
        /// <param name="image">基にするImageオブジェクト</param>
        /// <returns>ImageBufferオブジェクト</returns>
        public static ImageBuffer CreateFrom(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            int width = bmp.Width;
            int height = bmp.Height;
            BitmapData bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte[] buffer = new byte[bmpData.Stride * height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, buffer, 0, buffer.Length);


            ImageBuffer ret = new ImageBuffer(buffer, width, height, bmpData.Stride);
            bmp.UnlockBits(bmpData);
            bmp.Dispose();


            return ret;
        }

        /// <summary>
        /// 空のイメージバッファを作成する
        /// </summary>
        /// <param name="width">水平方向ピクセル数</param>
        /// <param name="height">垂直方向ピクセル数</param>
        /// <returns>ImageBufferオブジェクト</returns>
        public static ImageBuffer Create(int width, int height)
        {
            int stride = width * 4; /* BGRA, PixelFormat.Format32bppArgb */
            byte[] buffer = new byte[stride * height];
            ImageBuffer ret = new ImageBuffer(buffer, width, height, stride);
            return ret;
        }


        private byte[] buffer; // バッファ
        private readonly int lineBytes; // 1行あたりのバイト数

        /// <summary>
        /// bufferをデータバッファとしたイメージバッファを作成する。
        /// </summary>
        /// <param name="buffer">データバッファ</param>
        /// <param name="width">水平方向ピクセル数</param>
        /// <param name="height">垂直方向ピクセル数</param>
        /// <param name="lineBytes">1ラインあたりのバイト数</param>
        private ImageBuffer(byte[] buffer, int width, int height, int lineBytes)
        {
            this.buffer = buffer;
            this.Width = width;
            this.Height = height;
            this.lineBytes = lineBytes;
        }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// 高さ
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// 指定位置のピクセルを取得する。
        /// X,Yが範囲外の時は透明色が返る。
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <returns>ピクセル値</returns>
        public Color GetPixel(int x, int y)
        {
            if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height))
            {
                return Color.FromArgb(0, 0, 0, 0);
            }

            int pos = x * 4 + lineBytes * y;
            int b = buffer[pos + 0];
            int g = buffer[pos + 1];
            int r = buffer[pos + 2];
            int a = buffer[pos + 3];


            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// 指定位置のピクセルを設定する。
        /// X,Yが範囲外の時は何もしない。
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="c">カラー</param>
        public void SetPixel(int x, int y, Color c)
        {
            if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height))
            {
                return;
            }

            int pos = x * 4 + lineBytes * y;
            buffer[pos + 0] = c.B;
            buffer[pos + 1] = c.G;
            buffer[pos + 2] = c.R;
            buffer[pos + 3] = c.A;
        }

        /// <summary>
        /// 指定色で塗りつぶす。
        /// </summary>
        /// <param name="c">色</param>
        public void Fill(Color c)
        {
            for (int y = 0; y < Height; y++)
            {
                int pos = y * lineBytes;
                for (int x = 0; x < Width; x++)
                {
                    buffer[pos + 0] = c.B;
                    buffer[pos + 1] = c.G;
                    buffer[pos + 2] = c.R;
                    buffer[pos + 3] = c.A;
                    pos += 4;
                }
            }
        }

        /// <summary>
        /// データをクリアする。
        /// </summary>
        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                int pos = y * lineBytes;
                for (int x = 0; x < Width; x++)
                {
                    buffer[pos + 0] = 0;
                    buffer[pos + 1] = 0;
                    buffer[pos + 2] = 0;
                    buffer[pos + 3] = 0;
                    pos += 4;
                }
            }
        }

        /// <summary>
        /// このイメージにsrcImageで指定されるイメージを書き込む。
        /// srcImageをこのイメージに嵌め込む用途のインタフェースになる。
        /// 嵌め込む位置だけ指定し、srcImageは左上起点である。
        /// 特定の範囲を特定の範囲に書き込みたい場合には
        /// パラメータを詳細に指定可能なオーバーライドメソッドを使う事。
        /// </summary>
        /// <param name="srcImage">コピーするイメージ</param>
        /// <param name="dstXOffs">コピー先のX位置</param>
        /// <param name="dstYOffs">コピー先のY位置</param>
        public void WriteImage(ImageBuffer srcImage, int dstXOffs, int dstYOffs)
        {
            WriteImage(srcImage, 0, 0, dstXOffs, dstYOffs, srcImage.Width, srcImage.Height);
        }

        /// <summary>
        /// このイメージにsrcImageで指定されるイメージを書き込む。
        /// 座標が画像データの範囲外を指す部分はコピーされない。
        /// </summary>
        /// <param name="srcImage">コピーするイメージ</param>
        /// <param name="srcXOffs">コピー元のX位置</param>
        /// <param name="srcYOffs">コピー元のY位置</param>
        /// <param name="dstXOffs">コピー先のX位置</param>
        /// <param name="dstYOffs">コピー先のY位置</param>
        /// <param name="copyWidth">幅</param>
        /// <param name="copyHeight">高さ</param>
        public void WriteImage(ImageBuffer srcImage, int srcXOffs, int srcYOffs, int dstXOffs, int dstYOffs, int copyWidth, int copyHeight)
        {
            for (int y = 0; y < copyHeight; y++)
            {
                for (int x = 0; x < copyWidth; x++)
                {
                    int srcX = srcXOffs + x;
                    int srcY = srcYOffs + y;
                    int dstX = dstXOffs + x;
                    int dstY = dstYOffs + y;
                    if ((srcX < 0) || (srcX >= srcImage.Width)
                        || (srcY < 0) || (srcY >= srcImage.Height)
                        || (dstX < 0) || (dstX >= Width)
                        || (dstY < 0) || (dstY >= Height))
                    {
                        continue; // コピーする部分のピクセルが範囲外
                    }
                    Color c = srcImage.GetPixel(srcX, srcY);
                    SetPixel(dstX, dstY, c);
                }
            }
        }

        /// <summary>
        /// イメージを取得する。
        /// </summary>
        /// <returns>Imageオブジェクト</returns>
        public Image GetImage()
        {
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            BitmapData bmpData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, Width, Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

    }
}
