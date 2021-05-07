using CGenImaging;
using System.Drawing;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// スマート拡大？
    /// </summary>
    public class SmartExtendX2Operation : ImageOperationBase
    {
        private ImageOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SmartExtendX2Operation()
        {
            setting = new ImageOperationSetting();
        }

        /// <summary>
        /// 画像に処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public override ImageBuffer Process(ImageBuffer buffer)
        {
            ImageBuffer dstImage = ImageBuffer.Create(buffer.Width * 2, buffer.Height * 2);

            // まずオリジナルと同じにできるところを生成する。
            for (int y = 0; y < dstImage.Height; y += 2)
            {
                for (int x = 0; x < dstImage.Width; x += 2)
                {
                    dstImage.SetPixel(x, y, buffer.GetPixel((x >> 1), (y >> 1)));
                }
            }

            // ここからエンプティなところを埋めてくんだけど。
            // 実は結構面倒だし、タイルになってたらうまくいかんのだよね。ごふっ

            // オリジナルのところの右トナリ
            for (int y = 0; y < dstImage.Height; y += 2)
            {
                for (int x = 1; x < dstImage.Width; x += 2)
                {
                    int srcX = (x - 1) >> 1;
                    int srcY = y >> 1;
                    Color src1 = buffer.GetPixel(srcX, srcY);
                    Color src2 = buffer.GetPixel(srcX + 1, srcY);
                    if ((src1.A == 0) || (src2.A == 0))
                    {
                        // どっちか透明なら無色にする。
                    }
                    else
                    {
                        // 両方色ついてるなら混合色を作る
                        Color c = ImageProcessor.Blend(src1, src2);
                        dstImage.SetPixel(x, y, c);
                    }
                }
            }

            // オリジナルのところの1つ下
            for (int y = 1; y < dstImage.Height; y += 2)
            {
                for (int x = 0; x < dstImage.Width; x += 2)
                {
                    int srcX = x >> 1;
                    int srcY = (y - 1) >> 1;
                    Color src1 = buffer.GetPixel(srcX, srcY);
                    Color src2 = buffer.GetPixel(srcX, srcY + 1);
                    if ((src1.A == 0) || (src2.A == 0))
                    {
                        // どっちか透明なら無色にする。
                    }
                    else
                    {
                        // 両方色ついてるなら混合色を作る
                        Color c = ImageProcessor.Blend(src1, src2);
                        dstImage.SetPixel(x, y, c);
                    }
                }
            }

            // オリジナルのところの右下
            for (int y = 1; y < dstImage.Height; y += 2)
            {
                for (int x = 1; x < dstImage.Width; x += 2)
                {
                    Color c1 = dstImage.GetPixel(x - 1, y);
                    Color c2 = dstImage.GetPixel(x + 1, y);
                    Color c3 = dstImage.GetPixel(x, y - 1);
                    Color c4 = dstImage.GetPixel(x, y + 1);

                    if (((c1.A != 0) && (c2.A != 0)) || ((c3.A != 0) && (c4.A != 0)))
                    {
                        // 対角のどちらかが色つき
                        // Note: 
                        // 斜め対角は右トナリ、左トナリの判定結果が
                        // c1, c2, c3, c4に効き、この判定で処理できる
                        Color c12 = ImageProcessor.Blend(c1, c2);
                        Color c34 = ImageProcessor.Blend(c3, c4);
                        Color c1234 = ImageProcessor.Blend(c12, c34);

                        dstImage.SetPixel(x, y, c1234);
                    }
                }
            }

            return dstImage;
        }

        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string Name { get => "SmartExtend(x2)"; }

        /// <summary>
        /// 操作の説明
        /// </summary>
        public override string Description {
            get => "ちょっと改良を試みた2倍化処理";
        }

        /// <summary>
        /// 出力ディレクトリを得る。
        /// </summary>
        /// <returns>出力ディレクトリ</returns>
        protected override string GetOutputDirectory()
        {
            return setting.OutputDirectory;
        }

        /// <summary>
        /// 設定
        /// </summary>
        public override IOperationSetting Setting {
            get { return setting; }
        }
    }
}
