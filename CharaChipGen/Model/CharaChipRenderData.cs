﻿using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.Material;
using System;
using System.Collections.Generic;
using System.Data;
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
        private PartsChangeEventHandler partsChangedHandler;
        // ハンドラ
        public delegate void ImageChangedEventHandler(Object sender, EventArgs e);
        // イメージが変更されたときのイベント
        public event ImageChangedEventHandler ImageChanged;

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

            partsChangedHandler = new PartsChangeEventHandler((sender, e) =>
            {
                OnPartsChanged((Character)(sender), e.PartsType, e.PropertyName);
            });

            character.PartsChanged += partsChangedHandler;
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
                character.PartsChanged -= partsChangedHandler;
                character = value;
                character.PartsChanged += partsChangedHandler;

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
        /// キャラチップの1パターンを描画するのに最適なサイズを取得する。
        /// 1キャラクターの1パターンを描画するサイズ。
        /// </summary>
        public Size PreferredCharaChipSize {
            get {
                int width = 0;
                int height = 0;
                foreach (RenderLayer layer in this)
                {
                    if (layer.PreferredCharaChipWidth > width)
                    {
                        width = layer.PreferredCharaChipWidth;
                    }
                    if (layer.PreferredCharaChipHeight > height)
                    {
                        height = layer.PreferredCharaChipHeight;
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
                OnPartsAttributeChanged(model, partsType, propertyName);
            }

            ImageChanged?.Invoke(this, new EventArgs());
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
            var material = AppData.Instance.GetMaterialList(partsType).Get(parts.MaterialName);
            if (material == null)
            {
                // 素材読み出しエラー
                HasMaterialError = true;
                return;
            }

            for (int i = 0; i < material.GetLayerCount(); i++)
            {
                var info = material.Layers[i];
                var group = layerGroups.First((entry) => entry.LayerType == info.LayerType);
                var colorPartsRefs = info.ColorPartsRefs ?? partsType;
                var colorPropertyName = info.ColorPropertyName ?? Parts.DefaultColorPropertyName;
                var layer = new RenderLayer(info.LayerType, partsType,
                    colorPartsRefs, colorPropertyName);
                layer.ColorImmutable = info.ColorImmutable;
                layer.Coloring = info.Coloring;
                try
                {
                    layer.Image = material.LoadLayerImage(i);
                    layer.HasError = false;
                }
                catch
                {
                    layer.Image = null;
                    layer.HasError = true;
                }
                // レイヤーに設定値適用
                ApplyLayerOffsets(layer, model);
                ApplyLayerColor(layer, model);
                group.Add(partsType, layer);
            }

            HasMaterialError = false;
        }

        /// <summary>
        /// この部品の設定が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="model">キャラチップモデル</param>
        /// <param name="partsType">部品タイプ</param>
        /// <param name="propertyName">プロパティ名</param>
        private void OnPartsAttributeChanged(Character model, PartsType partsType,
            string propertyName)
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
                    if ((layer.ColorPartsRefs == partsType)
                        && (layer.ColorPropertyName.Equals(propertyName)))
                    {
                        ColorSetting setting = parts.GetColorSetting(propertyName);
                        if (setting != null)
                        {
                            ApplyLayerColor(layer, setting);
                        }
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
            ColorSetting setting = parts.GetColorSetting(layer.ColorPropertyName);
            if (setting != null)
            {
                ApplyLayerColor(layer, setting);
            }
        }

        /// <summary>
        /// レイヤーにpartsで指定される部品の設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="setting">色設定</param>
        private void ApplyLayerColor(RenderLayer layer, ColorSetting setting)
        {
            layer.Hue = setting.Hue;
            layer.Saturation = setting.Saturation;
            layer.Value = setting.Value;
            layer.Opacity = setting.Opacity;
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
        /// エラーがあるかどうかを返す。
        /// </summary>
        public bool HasError {
            get {
                return HasMaterialError || layerGroups.Any((group) => group.HasError);
            }
        }

        /// <summary>
        /// 素材エラー
        /// </summary>
        private bool HasMaterialError { get; set; } = false;

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
