﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using CharaChipGenUtility.Imaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 1枚の絵に対する画像処理を行う抽象クラス。
    /// </summary>
    public abstract class AbstractImageOperation : IOperation
    {
        // 設定
        private SimpleImageOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを生成する。
        /// </summary>
        protected AbstractImageOperation()
        {
            setting = new SimpleImageOperationSetting();
        }

        /// <summary>
        /// 処理する。
        /// </summary>
        /// <param name="filePaths">ファイルパス</param>
        public void Process(string[] filePaths)
        {
            List<Exception> errors = new List<Exception>();
            foreach (string filePath in filePaths)
            {
                using (Image srcImage = Image.FromFile(filePath))
                {
                    ImageBuffer srcBuffer = ImageBuffer.CreateFrom(srcImage);
                    ImageBuffer dstBuffer = DoImageProcess(srcBuffer);
                    using (Image dstImage = dstBuffer.GetImage())
                    {
                        string fileName = System.IO.Path.GetFileName(filePath);
                        string dir = setting.OutputDirectory;

                        dstImage.Save(fileName, srcImage.RawFormat);
                    }
                }
            }
        }


        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        protected abstract ImageBuffer DoImageProcess(ImageBuffer buffer);

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


        /// <summary>
        /// 文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
