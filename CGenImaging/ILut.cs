using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// ルックアップテーブルを表すインタフェース
    /// </summary>
    public interface ILut
    {
        /// <summary>
        /// indexに対応する色を得る。
        /// </summary>
        /// <param name="index">インデックス(0≦index＜Resolution-1)</param>
        /// <returns>色</returns>
        Color Get(int index);

        /// <summary>
        /// LUTの解像度を得る。
        /// </summary>
        int Resolution { get; }
    }
}
