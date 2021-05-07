using CGenImaging;
using System;
using System.Drawing;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 結合操作
    /// </summary>
    public class CombineOperation : IOperation
    {
        /// <summary>
        /// 設定
        /// </summary>
        private CombineOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CombineOperation()
        {
            setting = new CombineOperationSetting();
        }

        /// <summary>
        /// このオペレーションの名前
        /// </summary>
        public string Name {
            get { return "Combine"; }
        }

        /// <summary>
        /// このオペレーションの説明
        /// </summary>
        public string Description {
            get { return "設定された水平数/垂直数で、入力画像を結合します。"; }
        }

        /// <summary>
        /// 処理設定
        /// </summary>
        public IOperationSetting Setting {
            get { return setting; }
        }

        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="fileNames">ファイルパス</param>
        public void Process(string[] fileNames)
        {
            // 名前でソートする。
            // 残念なことに、エクスプローラ上でクリック選択した順番とか
            // 全く関係なしにわたってくるのだ。
            Array.Sort(fileNames, (s1, s2) => s1.CompareTo(s2));

            int imageCount = setting.HorizontalCount * setting.VerticalCount;

            int fileIndex = 0;
            while (fileIndex < fileNames.Length)
            {
                ImageBuffer imageBuffer = null;

                for (int y = 0; y < setting.VerticalCount; y++)
                {
                    for (int x = 0; x < setting.HorizontalCount; x++)
                    {
                        if (fileIndex >= fileNames.Length)
                        {
                            break;
                        }
                        imageBuffer = CombineImage(fileNames[fileIndex], imageBuffer, x, y);
                        fileIndex++;
                    }
                }
                if (imageBuffer != null)
                {
                    // 書き出す。
                    WriteOutputImage(imageBuffer);
                }

            }
        }

        /// <summary>
        /// fileNameで指定されるファイルを読み出し、bufferの指定位置に嵌め込む。
        /// bufferがnullの場合にはアロケートして返す。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="buffer">バッファ(null指定時はアロケートして返す)</param>
        /// <param name="x">X位置</param>
        /// <param name="y">Y位置</param>
        /// <returns>バッファが返る。</returns>
        private ImageBuffer CombineImage(string fileName, ImageBuffer buffer, int x, int y)
        {
            using (Image image = ReadImage(fileName))
            {
                ImageBuffer srcImage = ImageBuffer.CreateFrom(image);
                if (buffer == null)
                {
                    int width = srcImage.Width * setting.HorizontalCount;
                    int height = srcImage.Height * setting.VerticalCount;
                    buffer = ImageBuffer.Create(width, height);
                }

                int regionWidth = buffer.Width / setting.HorizontalCount;
                int regionHeight = buffer.Height / setting.VerticalCount;

                int dstXOffs = regionWidth * x;
                int dstYOffs = regionHeight * y;

                int srcXOffs = (srcImage.Width - regionWidth) / 2;
                int srcYOffs = (srcImage.Height - regionHeight) / 2;

                buffer.WriteImage(srcImage, srcXOffs, srcYOffs, dstXOffs, dstYOffs, regionWidth, regionHeight);
            }

            return buffer;
        }

        /// <summary>
        /// pathの画像を読み込む。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns></returns>
        private Image ReadImage(string path)
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(path))
            {
                return Image.FromStream(stream, false, false);
            }
        }

        /// <summary>
        /// 画像を書き出す。
        /// </summary>
        /// <param name="imageBuffer">イメージバッファ</param>
        private void WriteOutputImage(ImageBuffer imageBuffer)
        {
            string dir = setting.OutputDirectory;
            if (string.IsNullOrEmpty(dir))
            {
                dir = System.IO.Directory.GetCurrentDirectory();
            }
            OutputUtilities.WriteImageWithNewName(dir, "image", imageBuffer);
        }
    }
}
