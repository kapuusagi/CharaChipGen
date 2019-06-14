using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;
using System.Drawing;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// シーケンシャルオペレーション
    /// </summary>
    public class SequentialOperation : IOperation
    {
        // 設定
        private SequentialOperationSetting setting;
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SequentialOperation()
        {
            setting = new SequentialOperationSetting();
        }

        /// <summary>
        /// 処理名
        /// </summary>
        public string Name { get { return "Sequential"; } }

        /// <summary>
        /// 処理の設定
        /// </summary>
        public IOperationSetting Setting {
            get { return setting; }
        }

        /// <summary>
        /// 処理する。
        /// </summary>
        /// <param name="paths">ファイルパス</param>
        public void Process(string[] paths)
        {
            foreach (string filePath in paths)
            {
                using (Image srcImage = Image.FromFile(filePath))
                {
                    ImageBuffer srcBuffer = ImageBuffer.CreateFrom(srcImage);
                    ImageBuffer dstBuffer = SequentialProcess(srcBuffer);
                    using (Image dstImage = dstBuffer.GetImage())
                    {
                        string fileName = System.IO.Path.GetFileName(filePath);
                        string dir = setting.OutputDirectory;
                        if (string.IsNullOrEmpty(dir))
                        {
                            dir = System.IO.Directory.GetCurrentDirectory();
                        }
                        string dstPath = System.IO.Path.Combine(dir, fileName);

                        dstImage.Save(dstPath, srcImage.RawFormat);
                    }
                }

            }

        }

        /// <summary>
        /// 処理する
        /// </summary>
        /// <param name="src">イメージソース</param>
        /// <returns>処理結果画像</returns>
        private ImageBuffer SequentialProcess(ImageBuffer src)
        {
            ImageBuffer tmp = src;
            foreach (IImageOperation operation in setting.Operations)
            {
                tmp = operation.Process(tmp);
            }

            return tmp;
        }


    }
}
