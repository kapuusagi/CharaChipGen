using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ImageStacker
{
    /// <summary>
    /// 一枚の画像データを構成するレイヤーの集まりモデル
    /// </summary>
    public class LayerSet : IEnumerable<LayerEntry>
    {
        // レイヤー
        private List<LayerEntry> layers;

        /// <summary>
        /// 新しいLayerSetを構築する。
        /// </summary>
        public LayerSet()
        {
            layers = new List<LayerEntry>();
        }

        /// <summary>
        /// レイヤーが追加された
        /// </summary>
        public event LayerEventHandler Added;
        /// <summary>
        /// レイヤーが削除された
        /// </summary>
        public event LayerEventHandler Removed;
        /// <summary>
        /// レイヤーが変更された
        /// </summary>
        public event LayerEventHandler Modifired;

        /// <summary>
        /// レイヤー数を得る。
        /// </summary>
        public int Count {
            get => layers.Count;
        }

        /// <summary>
        /// レイヤーを得る。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>レイヤー</returns>
        public LayerEntry Get(int index)
        {
            return layers[index];
        }

        /// <summary>
        /// レイヤーのインデックス番号を得る。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <returns></returns>
        public int IndexOf(LayerEntry layer)
            => layers.IndexOf(layer);

        /// <summary>
        /// layerが含まれているかどうかを得る。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <returns>含まれている場合にはtrue, それ以外はfalse</returns>
        public bool Contains(LayerEntry layer)
        {
            return layers.Contains(layer);
        }
        /// <summary>
        /// レイヤーエントリを追加する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        public void Add(LayerEntry layer)
        {
            Insert(Count, layer);
        }

        /// <summary>
        /// レイヤーエントリを追加する。
        /// </summary>
        /// <param name="index">挿入するインデックス番号(0≦index≦Count)</param>
        /// <param name="layer"></param>
        public void Insert(int index, LayerEntry layer)
        {
            if (!Contains(layer) && (index >= 0) && (index <= layers.Count))
            {
                if (index < layers.Count)
                {
                    layers.Insert(index, layer);
                }
                else
                {
                    layers.Add(layer);
                }
                layer.PropertyChanged += OnLayerPropertyChanged;
                Added?.Invoke(this, new LayerEventArgs(layers.Count - 1, layer));
            }
        }

        /// <summary>
        /// 指定レイヤーを削除する。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        public void Remove(int index)
        {
            var removedLayer = layers[index];
            layers.RemoveAt(index);
            removedLayer.PropertyChanged -= OnLayerPropertyChanged;
            Removed?.Invoke(this, new LayerEventArgs(index, removedLayer));
        }

        /// <summary>
        /// 指定レイヤーを削除する。
        /// </summary>
        /// <param name="layer">レイヤー番号</param>
        public void Remove(LayerEntry layer)
        {
            var index = layers.IndexOf(layer);
            if (index >= 0)
            {
                Remove(index);
            }
        }

        /// <summary>
        /// 移動する
        /// </summary>
        /// <param name="layer"></param>
        public void MoveUp(LayerEntry layer)
        {
            var index = layers.IndexOf(layer);
            if (index > 0)
            {
                layers.RemoveAt(index);
                layers.Insert(index - 1, layer);
                Modifired?.Invoke(this, new LayerEventArgs(index - 1, layer));
                Modifired?.Invoke(this, new LayerEventArgs(index, layers[index]));
            }
        }

        /// <summary>
        /// 移動する
        /// </summary>
        /// <param name="layer"></param>
        public void MoveDown(LayerEntry layer)
        {
            var index = layers.IndexOf(layer);
            if ((index >= 0) && (index < (layers.Count - 1)))
            {
                layers.RemoveAt(index);
                layers.Insert(index + 1, layer);
                Modifired?.Invoke(this, new LayerEventArgs(index, layers[index]));
                Modifired?.Invoke(this, new LayerEventArgs(index + 1, layer));
            }

        }


        /// <summary>
        /// レイヤーのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var index = layers.IndexOf((LayerEntry)(sender));
            if (index >= 0)
            {
                Modifired?.Invoke(this, new LayerEventArgs(index, (LayerEntry)(sender)));
            }
        }

        /// <summary>
        /// 列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// 列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<LayerEntry> GetEnumerator()
            => layers.GetEnumerator();
    }
}
