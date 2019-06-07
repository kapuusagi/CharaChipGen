using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 並べる操作
    /// </summary>
    public class LineupOperation : IOperation
    {
        private LineupOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public LineupOperation()
        {
            setting = new LineupOperationSetting();
        }

        /// <summary>
        /// このオペレーションの名前
        /// </summary>
        public string Name { get { return "Lineup"; } }

        /// <summary>
        /// 処理設定
        /// </summary>
        public IOperationSetting Setting { get { return setting; } }

        /// <summary>
        /// 処理を行う。
        /// </summary>
        public void Process(string[] fileNames)
        {
            ImageBuffer[] images = LoadImages(fileNames);

            switch (setting.Direction)
            {
                case LineupOperationSetting.DIRECTION_HORIZONTAL:
                    ProcessLineupHorizontal(images);
                    break;
                case LineupOperationSetting.DIRECTION_VERTICAL:
                    ProcessLineupVertical(images);
                    break;
            }

        }

        /// <summary>
        /// 水平方向に並べて書き出す。
        /// </summary>
        /// <param name="images"></param>
        private void ProcessLineupHorizontal(ImageBuffer[] images)
        {
            int width = images.Sum((x) => x.Width); // 水平ピクセル数の合計
            int height = images.Max((x) => x.Height); // 垂直ピクセル数の最大値

            ImageBuffer imageBuffer = ImageBuffer.Create(width, height);
            int xoffs = 0;
            foreach (ImageBuffer image in images)
            {
                int yoffs = (height - image.Height) / 2;
                imageBuffer.WriteImage(image, xoffs, yoffs);
                xoffs += image.Width;
            }

            WriteOutputImage(imageBuffer);
        }

        /// <summary>
        /// 垂直方向に並べて書き出す。
        /// </summary>
        /// <param name="images">画像</param>
        private void ProcessLineupVertical(ImageBuffer[] images)
        {
            int width = images.Max((x) => x.Width); // 水平ピクセル数の最大値
            int height = images.Sum((x) => x.Height); // 垂直ピクセル数の最大値

            ImageBuffer imageBuffer = ImageBuffer.Create(width, height);
            int yoffs = 0;
            foreach (ImageBuffer image in images)
            {
                int xoffs = (width - image.Width) / 2;
                imageBuffer.WriteImage(image, xoffs, yoffs);
                yoffs += image.Height;
            }

            WriteOutputImage(imageBuffer);
        }

        /// <summary>
        /// 出力画像を書き出す。
        /// </summary>
        /// <param name="imageBuffer">書き出すデータ</param>
        private void WriteOutputImage(ImageBuffer imageBuffer)
        {
            string dir = setting.OutputDirectory;
            if (string.IsNullOrEmpty(dir))
            {
                dir = System.IO.Directory.GetCurrentDirectory();
            }
            OutputUtilities.WriteImageWithNewName(dir, "image", imageBuffer);
        }

        /// <summary>
        /// 画像を読み込む。
        /// </summary>
        /// <param name="paths">パス</param>
        /// <returns>読み込んだ画像の配列</returns>
        private static ImageBuffer[] LoadImages(string[] paths)
        {
            List<ImageBuffer> images = new List<ImageBuffer>();
            foreach (string path in paths)
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
                {
                    images.Add(ImageBuffer.CreateFrom(image));
                }
            }

            return images.ToArray();
        }
    }
}
