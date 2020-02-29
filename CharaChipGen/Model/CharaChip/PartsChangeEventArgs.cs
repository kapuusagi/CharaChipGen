using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// 部品が変更されたことを表すイベント。
    /// </summary>
    public class PartsChangeEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="type">部品種別</param>
        /// <param name="propertyName">プロパティ名</param>
        public PartsChangeEventArgs(PartsType type, string propertyName) : base(propertyName)
        {
            PartsType = type;
        }

        /// <summary>
        /// 部品種別
        /// </summary>
        public PartsType PartsType { get; private set; }
    }
}
