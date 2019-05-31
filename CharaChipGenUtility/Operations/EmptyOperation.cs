using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGenUtility.Imaging;

namespace CharaChipGenUtility.Operations
{
    class EmptyOperation : IImageOperation
    {
        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public ImageBuffer Process(ImageBuffer buffer)
        {
            return buffer;
        }

        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return "Empty";
        }
    }
}
