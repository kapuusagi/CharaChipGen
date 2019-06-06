﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 単純拡大処理
    /// </summary>
    class OperationExtendX2 : AbstractImageOperation
    {
        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        protected override ImageBuffer DoImageProcess(ImageBuffer buffer)
        {
            ImageBuffer dstImage = ImageBuffer.Create(buffer.Width * 2, buffer.Height * 2);

            // バイキュービックもなにもあったもんじゃない。
            for (int y = 0; y < dstImage.Height; y++)
            {
                for (int x = 0; x < dstImage.Width; x++)
                {
                    dstImage.SetPixel(x, y, buffer.GetPixel((x >> 1), (y >> 1)));
                }
            }

            return dstImage;
        }

        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string Name
        {
            get { return "SimpleExtend(x2)"; }
        }
    }
}
