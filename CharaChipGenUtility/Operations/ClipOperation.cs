using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 領域をクリップ(切り出す)処理
    /// </summary>
    public class ClipOperation : ImageOperationBase
    {
        // 操作設定
        private ClipOperationSetting setting;
        public ClipOperation()
        {
            setting = new ClipOperationSetting();
        }


        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string Name { get => "Clip"; }

        /// <summary>
        /// 説明文。
        /// </summary>
        public override string Description {
            get => "ソース画像から指定された位置を切り出します。";
        }
        /// <summary>
        /// 設定
        /// </summary>
        public override IOperationSetting Setting {
            get {
                return setting;
            }
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
        /// 画像に処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public override ImageBuffer Process(ImageBuffer buffer)
        {
            System.Drawing.Rectangle clipBounds = setting.ClipBounds;
            ImageBuffer dstImage = ImageBuffer.Create(clipBounds.Width, clipBounds.Height);

            for (int y = 0; y < clipBounds.Height; y++)
            {
                for (int x = 0; x < clipBounds.Width; x++)
                {
                    int srcX = clipBounds.X + x;
                    int srcY = clipBounds.Y + y;

                    dstImage.SetPixel(x, y, buffer.GetPixel(srcX, srcY));
                }
            }

            return dstImage;
        }
    }
}
