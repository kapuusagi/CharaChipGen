using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 部品が変更されたことを表すイベント。
    /// </summary>
    public class PartsChangeEventArgs : EventArgs
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="type">部品種別</param>
        public PartsChangeEventArgs(PartsType type)
        {
            PartsType = type;
        }

        /// <summary>
        /// 部品種別
        /// </summary>
        public PartsType PartsType { get; private set; }
    }
}
