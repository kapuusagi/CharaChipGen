using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// 素材ユーティリティクラス
    /// </summary>
    public static class MaterialUtils
    {
        /// <summary>
        /// 空の素材エントリファイルを作成する。
        /// </summary>
        /// <param name="entryFilePath">エントリファイルパス</param>
        /// <param name="materialType">素材種類</param>
        /// <returns>素材エントリファイル</returns>
        public static MaterialEntryFile CreateDefaultEntryFile(string entryFilePath, MaterialType materialType)
        {
            MaterialEntryFile entryFile = new MaterialEntryFile(entryFilePath);

            switch (materialType)
            {
                case MaterialType.Accessories:
                    AddLayer(entryFile, "front", LayerType.AccessoryFront);
                    AddLayer(entryFile, "back", LayerType.AccessoryBack);
                    break;
                case MaterialType.Bodies:
                    AddLayer(entryFile, "costume", LayerType.Costume);
                    AddLayer(entryFile, "body", LayerType.Body, PartsType.Head);
                    break;
                case MaterialType.Eyes:
                    AddLayer(entryFile, "eyebrow", LayerType.HairStyleFront, PartsType.HairStyle);
                    AddLayer(entryFile, "eye", LayerType.Eye);
                    break;
                case MaterialType.HairStyles:
                    AddLayer(entryFile, "front", LayerType.HairStyleFront);
                    AddLayer(entryFile, "haed", LayerType.Body, PartsType.Head);
                    AddLayer(entryFile, "back", LayerType.HairStyleBack);
                    break;
                case MaterialType.HeadAccessories:
                    AddLayer(entryFile, "front", LayerType.HeadAccessoryFront);
                    AddLayer(entryFile, "back", LayerType.HeadAccessoryBack);
                    break;
                case MaterialType.Heads:
                    AddLayer(entryFile, "ear", LayerType.HeadEar);
                    AddLayer(entryFile, "head", LayerType.Body);
                    break;
            }
            return entryFile;
        }

        /// <summary>
        /// レイヤーを追加する。
        /// </summary>
        /// <param name="entryFile">エントリファイル</param>
        /// <param name="layerName">レイヤー名</param>
        /// <param name="drawLayer">描画レイヤー</param>
        private static void AddLayer(MaterialEntryFile entryFile, string layerName,
            LayerType drawLayer)
            => AddLayer(entryFile, layerName, drawLayer, null);

        /// <summary>
        /// レイヤーを追加する。
        /// </summary>
        /// <param name="entryFile">エントリファイル</param>
        /// <param name="layerName">レイヤー名</param>
        /// <param name="drawLayer">描画レイヤー</param>
        /// <param name="colorRefs">色参照名</param>
        private static void AddLayer(MaterialEntryFile entryFile, string layerName,
            LayerType drawLayer, PartsType? colorRefs)
            => AddLayer(entryFile, layerName, drawLayer, colorRefs, Parts.DefaultColorPropertyName);

        /// <summary>
        /// レイヤーを追加する。
        /// </summary>
        /// <param name="entryFile">エントリファイル</param>
        /// <param name="layerName">レイヤー名</param>
        /// <param name="drawLayer">描画レイヤー</param>
        /// <param name="colorRefs">色参照（nullで既定）</param>
        /// <param name="colorPropertyName">色参照名</param>
        private static void AddLayer(MaterialEntryFile entryFile, string layerName,
            LayerType drawLayer, PartsType? colorRefs, string colorPropertyName)
        {
            entryFile.Layers.Add(layerName, new MaterialLayerInfo(layerName)
            {
                LayerType = drawLayer, ColorImmutable = false,
                ColorPartsRefs = colorRefs,
                ColorPropertyName = colorPropertyName
            });
        }
    }
}
