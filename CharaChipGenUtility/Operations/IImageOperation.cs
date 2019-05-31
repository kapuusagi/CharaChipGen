using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGenUtility.Imaging;

namespace CharaChipGenUtility.Operations
{
    interface IImageOperation
    {
        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        ImageBuffer Process(ImageBuffer buffer);
    }
}
