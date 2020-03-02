using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.Material;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクターのパーツ設定と、描画するための各レイヤーを保持するクラス。
    /// レイヤーの重ね合わせ処理はこのモデルのデータを使用して描画する。
    /// </summary>
    /// <remarks>
    /// Character での設定変更を、関連するRenderLayerに設定する役割を持つ。
    /// </remarks>
    public class CharaChipRenderData : IEnumerable<RenderLayer>
    {
        // レイヤー
        private RenderLayerGroup[] layerGroups;
        // レンダリング対象のキャラクターチップデータモデル
        private Character character;
        // ハンドラ
        private PartsChangeEventHandler partsChangeHandler;
        // ハンドラ
        public delegate void ImageChanged(Object sender, EventArgs e);
        // イメージが変更されたときのイベント
        public event ImageChanged OnImageChanged;

        /// <summary>
        /// レンダリング用データモデル
        /// </summary>
        public CharaChipRenderData()
        {
            LayerType[] layerTypes = (LayerType[])(Enum.GetValues(typeof(LayerType)));
            layerGroups = new RenderLayerGroup[layerTypes.Length];
            for (int i = 0; i < layerTypes.Length; i++)
            {
                layerGroups[i] = new RenderLayerGroup(layerTypes[i]);
            }

            character = new Character();

            partsChangeHandler = new PartsChangeEventHandler((sender, e) =>
            {
                OnPartsChanged((Character)(sender), e.PartsType, e.PropertyName);
            });

            character.OnCharaChipParamChanged += partsChangeHandler;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public Character Character {
            get { return character; }
            set {
                if ((value == null) || (character == value))
                {
                    return;
                }
                character.OnCharaChipParamChanged -= partsChangeHandler;
                character = value;
                character.OnCharaChipParamChanged += partsChangeHandler;

                OnCharacterChanged();
            }
        }

        /// <summary>
        /// キャラチップモデル自体が変更されたとき、
        /// モデルから設定を読み出してレイヤーを構築する処理を行う。
        /// </summary>
        private void OnCharacterChanged()
        {
            // 全部品の変更適用をする。
            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                OnMaterialChanged(character, partsType);
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
        /// バッファをレンダリングするのに最適サイズを取得する。
        /// 1キャラクタをレンダリングするために必要なサイズが返る。
        /// 1キャラクターの1パターンを描画するサイズではないことに注意。
        /// </summary>
        public Size PreferredSize {
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
                return new Size(width, height);
            }
        }

        /// <summary>
        /// 推奨される幅
        /// 
        /// 1キャラクタを表示するために必要な幅が返る。
        /// </summary>
        public int PreferredWidth {
            get {
                return PreferredSize.Width;
            }
        }

        /// <summary>
        /// 推奨される高さ。
        /// 
        /// 1キャラクタを表示するために必要な高さが返る。
        /// </summary>
        public int PreferredHeight {
            get {
                return PreferredSize.Height;
            }
        }

        /// <summary>
        /// 設定を適用する。
        /// </summary>
        /// <param name="model">データモデル</param>
        /// <param name="name">パーツ種別</param>
        /// <param name="partsType">プロパティ名</param>
        private void OnPartsChanged(Character model, PartsType partsType, string propertyName)
        {
            if (propertyName.Equals(nameof(Parts.MaterialName)))
            {
                // 素材自体が変更された。
                // この部品に関係する画像レイヤーを全部削除して追加。
                OnMaterialChanged(model, partsType);
            }
            else
            {
                // この部品に関係する画像レイヤーに設定を適用する。
                OnPartsAttributeChanged(model, partsType);
            }

            OnImageChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// 部品に割り当てられた素材が変更されたときの処理を行う。
        /// </summary>
        /// <param name="model">キャラチップモデル</param>
        /// <param name="partsType">部品タイプ</param>
        private void OnMaterialChanged(Character model, PartsType partsType)
        {
            // 該当レイヤーを削除
            foreach (RenderLayerGroup group in layerGroups)
            {
                group.Remove(partsType);
            }

            Parts parts = model.GetParts(partsType);
            if (string.IsNullOrEmpty(parts.MaterialName))
            {
                // 設定なし。
                return;
            }

            // この部品のレイヤーを得て追加する。
            var m = AppData.Instance.GetMaterialList(partsType).Get(parts.MaterialName);
            for (int i = 0; i < m.GetLayerCount(); i++)
            {
                MaterialLayerInfo info = m.Layers[i];
                RenderLayerGroup group = layerGroups.First((entry) => entry.LayerType == info.LayerType);
                PartsType colorPartsRefs = info.ColorPartsRefs ?? partsType;
                RenderLayer layer = new RenderLayer(info.LayerType, partsType, colorPartsRefs);
                layer.Image = m.LoadLayerImage(i);
                // レイヤーに設定値適用
                ApplyLayerOffsets(layer, model);
                ApplyLayerColor(layer, model);
                group.Add(partsType, layer);
            }
        }

        /// <summary>
        /// この部品の設定が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="model">キャラチップモデル</param>
        /// <param name="partsType">部品タイプ</param>
        private void OnPartsAttributeChanged(Character model, PartsType partsType)
        {
            // 変更対象の部品に関係するレイヤーに設定を適用する。
            Parts parts = model.GetParts(partsType);
            foreach (RenderLayerGroup layerGroup in layerGroups)
            {
                foreach (RenderLayer layer in layerGroup)
                {
                    if (layer.PartsType == partsType)
                    {
                        ApplyLayerOffsets(layer, parts);
                    }
                    if (layer.ColorPartsRefs == partsType)
                    {
                        ApplyLayerColor(layer, parts);
                    }
                }
            }
        }

        /// <summary>
        /// レイヤーにmodelの持つpartsに相当する部品の設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="model">キャラチップモデル</param>
        private void ApplyLayerColor(RenderLayer layer, Character model)
        {
            Parts parts = model.GetParts(layer.ColorPartsRefs);
            ApplyLayerColor(layer, parts);
        }

        /// <summary>
        /// レイヤーにpartsで指定される部品の設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="parts">部品</param>
        private void ApplyLayerColor(RenderLayer layer, Parts parts)
        {
            layer.Hue = parts.Hue;
            layer.Saturation = parts.Saturation;
            layer.Value = parts.Value;
            layer.Opacity = parts.Opacity;
        }

        /// <summary>
        /// レイヤーにmodelの持つpartsに相当する部品の設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="model">キャラチップモデル</param>
        private void ApplyLayerOffsets(RenderLayer layer, Character model)
        {
            Parts parts = model.GetParts(layer.PartsType);
            ApplyLayerOffsets(layer, parts);
        }

        /// <summary>
        /// レイヤーにpartsで指定される部品の設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="parts">部品</param>
        private void ApplyLayerOffsets(RenderLayer layer, Parts parts)
        {
            layer.OffsetX = parts.OffsetX;
            layer.OffsetY = parts.OffsetY;
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
