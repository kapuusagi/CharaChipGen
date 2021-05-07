using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStacker
{
    /// <summary>
    /// レイヤーイベント
    /// </summary>
    public class LayerEventArgs : EventArgs
    {
        /// <summary>
        /// レイヤーイベント
        /// </summary>
        /// <param name="index">レイヤーインデックス</param>
        /// <param name="layer">レイヤー</param>
        public LayerEventArgs(int index, LayerEntry layer)
        {
            Index = index;
            Layer = layer;
        }

        /// <summary>
        /// レイヤーインデックス
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// レイヤー
        /// </summary>
        public LayerEntry Layer { get; private set; }
    }
}
