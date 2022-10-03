using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// レイヤーのコレクションクラス
    /// </summary>
    public class MaterialLayerList : IEnumerable<MaterialLayerInfo>
    {
        // レイヤーリストのインスタンス
        private List<MaterialLayerInfo> layers = new List<MaterialLayerInfo>();

        /// <summary>
        /// レイヤーリスト
        /// </summary>
        public MaterialLayerList()
        {
        }

        /// <summary>
        /// レイヤーを追加する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        public void Add(MaterialLayerInfo layer)
        {
            if (layer  == null)
            {
                throw new NullReferenceException($"layer is null reference.");
            }
            if (Contains(layer))
            {
                throw new ArgumentException($"Layer {layer.Name} is already registered.");
            }
            layers.Add(layer);
        }

        /// <summary>
        /// indexで指定される位置のレイヤーをlayerに置き換える。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <param name="layer">レイヤー</param>
        public void Replace(int index, MaterialLayerInfo layer)
        {
            if (layer == null)
            {
                throw new NullReferenceException($"layer is null reference.");
            }
            if ((index <= 0) || (index >= layers.Count))
            {
                throw new IndexOutOfRangeException($"Specified index is out of range {index}/{layers.Count}");
            }
            if (!layers[index].Name.Equals(layer.Name) // 置換対象のレイヤーは同名レイヤーでない？
                || Contains(layer.Name)) // 同名レイヤーが含まれている？
            {
                throw new ArgumentException($"Layer {layer.Name} is already registered.");
            }

            layers[index] = layer;
        }

        /// <summary>
        /// indexで指定される位置にレイヤーを挿入する。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <param name="layer">レイヤー</param>
        public void Insert(int index, MaterialLayerInfo layer)
        {
            if (layer == null)
            {
                throw new NullReferenceException($"layer is null reference.");
            }
            if (Contains(layer))
            {
                throw new ArgumentException($"Layer {layer.Name} is already registered.");
            }
            if ((index < 0) || (index > layers.Count))
            {
                throw new IndexOutOfRangeException($"Specified index is out of range {index}/{layers.Count}");
            }

            layers.Insert(index, layer);
        }

        /// <summary>
        /// indexで指定されるレイヤーを削除する。
        /// </summary>
        /// <param name="index">インデックス</param>
        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < layers.Count))
            {
                layers.RemoveAt(index);
            }
        }

        /// <summary>
        /// layerNameで指定されるレイヤーを削除する。
        /// </summary>
        /// <param name="layerName">レイヤー名</param>
        public void Remove(string layerName)
        {
            int index = IndexOf(layerName);
            RemoveAt(index);
        }

        /// <summary>
        /// layerで指定されるレイヤーを削除する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        public void Remove(MaterialLayerInfo layer)
            => Remove(layer.Name);

        /// <summary>
        /// レイヤーをすべてクリアする。
        /// </summary>
        public void Clear()
            => layers.Clear();

        /// <summary>
        /// layerNameで指定されるレイヤーのインデックス番号を得る。
        /// </summary>
        /// <param name="layerName">レイヤー名</param>
        /// <returns>インデックス番号。見つからない場合には-1</returns>
        public int IndexOf(string layerName)
            => layers.FindIndex((l) => l.Name.Equals(layerName));

        /// <summary>
        /// layerで指定されるレイヤーのインデックス番号を得る。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <returns>インデックス番号。見つからない場合には-1</returns>
        public int IndexOf(MaterialLayerInfo layer)
            => IndexOf(layer.Name);

        /// <summary>
        /// レイヤー数
        /// </summary>
        public int Count { get => layers.Count; }

        /// <summary>
        /// layerNameで指定されるレイヤーを得る。
        /// </summary>
        /// <param name="layerName">レイヤー名</param>
        /// <returns>レイヤー。見つからない場合にはnull。</returns>
        public MaterialLayerInfo Get(string layerName)
            => layers.FirstOrDefault((l) => l.Name.Equals(layerName));

        /// <summary>
        /// indexで指定されるレイヤーを得る。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>レイヤー。見つからない場合にはnull</returns>
        public MaterialLayerInfo Get(int index)
            => ((index >= 0) && (index < layers.Count)) ? layers[index] : default;

        /// <summary>
        /// レイヤーが含まれているかどうかを判定する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <returns>含まれている場合にはtrue, それ以外はfalse.</returns>
        public bool Contains(MaterialLayerInfo layer)
            => Contains(layer.Name);

        /// <summary>
        /// レイヤー名が含まれているかどうかを判定する。
        /// </summary>
        /// <param name="layerName">レイヤー名</param>
        /// <returns>含まれている場合にはtrue, それ以外はfalse.</returns>
        public bool Contains(string layerName)
            => layers.Any((l) => l.Name.Equals(layerName));

        /// <summary>
        /// layerNameで指定される要素にアクセスする。
        /// </summary>
        /// <param name="layerName">レイヤー名</param>
        /// <returns>レイヤー</returns>
        public MaterialLayerInfo this[string layerName] {
            get => Get(layerName);
            set {
                int index = IndexOf(layerName);
                if (index >= 0)
                {
                    Replace(index, value);
                }
                else
                {
                    Add(value);
                }
            }
        }

        /// <summary>
        /// indexで指定される要素にアクセスする。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>レイヤー</returns>
        public MaterialLayerInfo this[int index] {
            get => Get(index);
            set {
                if ((index >= 0) && (index < layers.Count))
                {
                    Replace(index, value);
                }
                else if (index == layers.Count)
                {
                    Add(value);
                }
                else
                {
                    throw new IndexOutOfRangeException($"Specified index is out of range {index}/{layers.Count}");
                }
            }
        }

        /// <summary>
        /// このコレクションの要素にアクセスするための列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// このコレクションの要素にアクセスするための列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<MaterialLayerInfo> GetEnumerator()
            => layers.GetEnumerator();
    }
}
