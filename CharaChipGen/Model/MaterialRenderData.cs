using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 素材レンダリング用の素のデータを扱うモデル。
    /// </summary>
    /// <remarks>
    /// 指定されたマテリアルのレイヤーデータを保持し、
    /// レンダラーが描画とするときに提供する役割を持つ。
    /// 本クラスが扱うレイヤーデータは色変更が適用される前の、素のデータである。
    /// 本クラスからレイヤーデータを取得したレンダラーは、
    /// 色変更をピクセル毎に適用しつつ、描画用バッファに書き出す。
    /// 
    /// なんでこんなモデルがいるかって言うと、
    /// 素直に描画処理を実装すると、
    /// (0,0)の画像を構築するとき、(0,1)の画像を構築するとき、....(3,2)の画像を構築するとき、
    /// のそれぞれで画像の読み込みが発生してしまい、パフォーマンスが悪くなる。
    /// そのため、メモリ上にデータを読み込んでおき、必要な時に提供することにした。
    /// </remarks>
    public class MaterialRenderData : IEnumerable<RenderLayer>
    {
        private const CharaChip.PartsType DefaultPartsType = CharaChip.PartsType.Head;

        private const string DefaultColorPropertyName = Parts.DefaultColorPropertyName;

        // レイヤー
        private RenderLayerGroup[] layerGroups;
        // 描画対象の素材
        private Material.Material material;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialRenderData()
        {
            LayerType[] layerTypes = (LayerType[])(Enum.GetValues(typeof(LayerType)));
            layerGroups = new RenderLayerGroup[layerTypes.Length];
            for (int i = 0; i < layerTypes.Length; i++)
            {
                layerGroups[i] = new RenderLayerGroup(layerTypes[i]);
            }
        }

        /// <summary>
        /// 画像が変更された
        /// </summary>
        public event EventHandler ImageChanged;

        /// <summary>
        /// 描画対象の素材データ
        /// </summary>
        public Material.Material Material {
            get => material;
            set {
                if ((material == value) || ((material != null) && material.Equals(value)))
                {
                    return;
                }

                // 保持しているデータをクリア。
                foreach (var layerGroup in layerGroups)
                {
                    layerGroup.Clear();
                }

                material = value;

                if (material != null)
                {
                    // 素材のレイヤーを読み込んでグループに追加。
                    LoadMaterialLayers();
                }

                ImageChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// 素材のレイヤーデータを読み込み、グループに追加する。
        /// </summary>
        private void LoadMaterialLayers()
        {
            // この部品のレイヤーを得て追加する。
            for (int i = 0; i < material.GetLayerCount(); i++)
            {
                Material.MaterialLayerInfo info = material.Layers[i];
                RenderLayerGroup group = layerGroups.First(
                    (entry) => entry.LayerType == info.LayerType);
                RenderLayer layer = new RenderLayer(info.LayerType, DefaultPartsType,
                    DefaultPartsType, DefaultColorPropertyName);
                try
                {
                    layer.Image = material.LoadLayerImage(i);
                    layer.HasError = false;
                }
                catch
                {
                    layer.HasError = true;
                    layer.Image = null;
                }
                // レイヤーに設定値適用
                group.Add(DefaultPartsType, layer);
            }
        }

        /// <summary>
        /// レイヤー総数
        /// </summary>
        public int LayerCount {
            get { return layerGroups.Sum((group) => group.Count); }
        }

        /// <summary>
        /// 指定レイヤーのデータを取得する。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>レイヤーモデル。インデックスが範囲外の場合にはnull</returns>
        public RenderLayer GetLayer(int index)
        {
            int i = 0;
            foreach (RenderLayerGroup group in layerGroups)
            {
                foreach (RenderLayer layer in group)
                {
                    if (i == index)
                    {
                        return layer;
                    }
                    i++;
                }
            }

            return null;
        }

        /// <summary>
        /// 素材をレンダリングするのに最適サイズを取得する。
        /// 1キャラクタをレンダリングするために必要なサイズが返る。
        /// 1キャラクターの1パターンを描画するサイズではないことに注意。
        /// </summary>
        public System.Drawing.Size PreferredSize {
            get {
                int width = 0;
                int height = 0;
                foreach (RenderLayer layer in this)
                {
                    if (layer.PreferredWidth > width)
                    {
                        width = layer.PreferredWidth;
                    }
                    if (layer.PreferredHeight > height)
                    {
                        height = layer.PreferredHeight;
                    }
                }
                return new System.Drawing.Size(width, height);
            }
        }

        /// <summary>
        /// エラーがあるかどうかを判定して返す。
        /// </summary>
        public bool HasError {
            get => layerGroups.Any((group) => group.HasError);
        }
        /// <summary>
        /// レイヤーにアクセスするための列挙子を取得する。
        /// </summary>
        /// <returns>列挙子が返る</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// レイヤーにアクセスするための列挙子を取得する。
        /// </summary>
        /// <returns>列挙子が返る。</returns>
        public IEnumerator<RenderLayer> GetEnumerator()
        {
            foreach (RenderLayerGroup group in layerGroups)
            {
                foreach (RenderLayer layer in group)
                {
                    yield return layer;
                }
            }
        }
    }
}
