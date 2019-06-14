﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 1枚の絵に対する画像処理を行う抽象クラス。
    /// </summary>
    public abstract class ImageOperationBase : IOperation, IImageOperation
    {
        // 設定
        private ImageOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを生成する。
        /// </summary>
        protected ImageOperationBase()
        {
            setting = new ImageOperationSetting();
        }

        /// <summary>
        /// 処理する。
        /// </summary>
        /// <param name="filePaths">ファイルパス</param>
        public void Process(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                using (Image srcImage = Image.FromFile(filePath))
                {
                    ImageBuffer srcBuffer = ImageBuffer.CreateFrom(srcImage);
                    ImageBuffer dstBuffer = Process(srcBuffer);
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
        /// 設定
        /// </summary>
        public virtual IOperationSetting Setting {
            get {
                return setting;
            }
        }

    }
}
