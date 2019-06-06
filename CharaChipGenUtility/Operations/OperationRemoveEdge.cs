using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{

    class OperationRemoveEdge : AbstractImageOperation
    {
        /// <summary>
        /// 操作の名前を得る
        /// </summary>
        public override string Name {
            get { return "RemoveEdge"; }
        }

        protected  override ImageBuffer DoImageProcess(ImageBuffer src)
        {
            ImageBuffer dst = ImageBuffer.Create(src.Width, src.Height);

            // 端点を除いてコピー
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    if (!IsEndPoint(src, x, y))
                    {
                        dst.SetPixel(x, y, dst.GetPixel(x, y));
                    }
                }
            }

            return dst;
        }

        /// <summary>
        /// 端点かどうかを判定する。
        /// </summary>
        /// <param name="img">イメージ</param>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <returns>端点の場合にはtrue, 端点でない場合にはfalse。</returns>
        private static bool IsEndPoint(ImageBuffer img, int x, int y)
        {
            // cyx
            // c11 c12 c13
            // c21     c23
            // c31 c32 c33
            Color c11 = img.GetPixel(x - 1, y - 1);
            Color c12 = img.GetPixel(x,     y - 1);
            Color c13 = img.GetPixel(x + 1, y - 1);
            Color c21 = img.GetPixel(x - 1, y    );
            Color c23 = img.GetPixel(x + 1, y    );
            Color c31 = img.GetPixel(x - 1, y + 1);
            Color c32 = img.GetPixel(x,     y + 1);
            Color c33 = img.GetPixel(x + 1, y + 1);


            if ((c11.A == 0) && (c12.A == 0) && (c21.A == 0))
            { 
                return true;
            }
            if ((c12.A == 0) && (c13.A == 0) && (c23.A == 0))
            {
                return true;
            }
            if ((c21.A == 0) && (c31.A == 0) && (c32.A == 0))
            {
                return true;
            }
            if ((c23.A == 0) && (c32.A == 0) && (c33.A == 0))
            {
                return true;
            }

            return false;
        }
    }
}
