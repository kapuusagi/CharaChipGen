using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 空のオペレーション。
    /// </summary>
    class OperationEmpty : AbstractImageOperation
    {
        /// <summary>
        /// オペレーション名
        /// </summary>
        public override string Name {
            get { return "Empty"; }
        }

        /// <summary>
        /// このオペレーション設定を得る
        /// </summary>
        public override IOperationSetting Setting {
            get { return null; }
        }


        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        protected override ImageBuffer DoImageProcess(ImageBuffer buffer)
        {
            return buffer;
        }


    }
}
