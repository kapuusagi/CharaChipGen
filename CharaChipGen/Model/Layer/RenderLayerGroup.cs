using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model.Layer
{
    /// <summary>
    /// レンダリング対象レイヤーグループ
    /// </summary>
    public class RenderLayerGroup : IEnumerable<RenderLayerModel>
    {
        // レイヤー
        private List<RenderLayerEntry> layerEntries;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public RenderLayerGroup(LayerType layerType)
        {
            LayerType = layerType;
            layerEntries = new List<RenderLayerEntry>();
        }

        /// <summary>
        /// レイヤーグループ
        /// </summary>
        public LayerType LayerType { get; private set; }

        /// <summary>
        /// partsTypeの情報を持つレンダリングレイヤーを追加する。
        /// </summary>
        /// <param name="partsType">パーツ種別</param>
        /// <param name="layer">レイヤー</param>
        public void Add(PartsType partsType, RenderLayerModel layer)
        {
            for (int i = 0; i < layerEntries.Count; i++)
            {
                if (partsType <= layerEntries[i].PartsType)
                {
                    layerEntries.Insert(i, new RenderLayerEntry(partsType, layer));
                    return;
                }
            }

            layerEntries.Add(new RenderLayerEntry(partsType, layer));
        }

        /// <summary>
        /// partsTypeに該当するレンダリングレイヤーを削除する。
        /// </summary>
        /// <param name="partsType"></param>
        public void Remove(PartsType partsType)
        {
            // 削除しても飛ばされたりしないように、後ろから調べる。
            for (int i = layerEntries.Count - 1; i >= 0; i--)
            {
                if (layerEntries[i].PartsType == partsType)
                {
                    layerEntries.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// レイヤーを得る。
        /// </summary>
        /// <param name="index">インデックス番号(0≦index＜Count)</param>
        /// <returns>レイヤーオブジェクト。インデックスが不正な場合にはnull.</returns>
        public RenderLayerModel this[int index] {
            get {
                if ((index >= 0) && (index < layerEntries.Count))
                {
                    return layerEntries[index].Layer;
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// レイヤーエントリ数。
        /// </summary>
        public int Count { get => layerEntries.Count; }

        /// <summary>
        /// 要素にアクセスするための列挙子を得る
        /// </summary>
        /// <returns>列挙子</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// 要素にアクセスするための列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<RenderLayerModel> GetEnumerator()
        {
            foreach (var entry in layerEntries)
            {
                yield return entry.Layer;
            }
        }

        /// <summary>
        /// レンダリングレイヤーエントリ
        /// </summary>
        private class RenderLayerEntry
        {
            /// <summary>
            /// 新しいインスタンスを構築する。
            /// </summary>
            /// <param name="partsType">パーツ種別</param>
            /// <param name="layer">レイヤー</param>
            public RenderLayerEntry(PartsType partsType, RenderLayerModel layer)
            {
                PartsType = partsType;
                Layer = layer;
            }

            /// <summary>
            /// パーツ種別
            /// </summary>
            public PartsType PartsType { get; private set; }

            /// <summary>
            /// レイヤーデータ
            /// </summary>
            public RenderLayerModel Layer { get; private set; }
        }
    }
}
