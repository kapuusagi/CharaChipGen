using CGenImaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 1枚の絵に対する画像処理を行う抽象クラス。
    /// </summary>
    public abstract class ImageOperationBase : IOperation, IImageOperation
    {

        /// <summary>
        /// 新しいインスタンスを生成する。
        /// </summary>
        protected ImageOperationBase()
        {
        }

        /// <summary>
        /// 処理する。
        /// </summary>
        /// <param name="filePaths">ファイルパス</param>
        public void Process(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                ImageBuffer srcBuffer;
                ImageFormat imageFormat;

                // データを読み出す。
                // usingブロックをすぐに閉じるのは、
                // こうしないとファイルをオープンしっぱなしになるため。
                using (Image srcImage = Image.FromFile(filePath))
                {
                    srcBuffer = ImageBuffer.CreateFrom(srcImage);
                    imageFormat = srcImage.RawFormat;
                }


                ImageBuffer dstBuffer = Process(srcBuffer);
                using (Image dstImage = dstBuffer.GetImage())
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    string dir = GetOutputDirectory();
                    if (string.IsNullOrEmpty(dir))
                    {
                        dir = System.IO.Directory.GetCurrentDirectory();
                    }
                    string dstPath = System.IO.Path.Combine(dir, fileName);

                    dstImage.Save(dstPath, imageFormat);
                }
            }
        }

        /// <summary>
        /// 出力ディレクトリを得る。
        /// </summary>
        /// <remarks>
        /// (空文字ornull可)
        /// </remarks>
        /// <returns>出力ディレクトリ</returns>
        protected abstract string GetOutputDirectory();



        /// <summary>
        /// 画像に処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public abstract ImageBuffer Process(ImageBuffer buffer);

        /// <summary>
        /// 操作名
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 操作の説明
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// 設定
        /// </summary>
        public abstract IOperationSetting Setting { get; }

    }
}
