using CharaChipGen.Model.CharaChip;
using System;
using System.Xml;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクタチップジェネレータ設定ファイルを書き出す。
    /// </summary>
    public class GeneratorSettingWriter
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public GeneratorSettingWriter()
        {
        }

        /// <summary>
        /// 設定を書き出す。
        /// </summary>
        /// <param name="path">書き出すファイルパス</param>
        /// <param name="setting">設定</param>
        public void Write(string path, GeneratorSetting setting)
        {
            XmlDocument doc = GenerateXmlDocument(setting);
            doc.Save(path);
        }

        /// <summary>
        /// 設定をwriterに書き出す。
        /// </summary>
        /// <param name="writer">テキストライター</param>
        /// <param name="setting">設定</param>
        public void Write(System.IO.TextWriter writer, GeneratorSetting setting)
        {
            XmlDocument doc = GenerateXmlDocument(setting);
            doc.Save(writer);
        }

        /// <summary>
        /// 設定を書き出す。
        /// </summary>
        /// <param name="stream">出力ストリーム</param>
        /// <param name="setting">設定</param>
        public void Write(System.IO.Stream stream, GeneratorSetting setting)
        {
            XmlDocument doc = GenerateXmlDocument(setting);
            doc.Save(stream);
        }

        /// <summary>
        /// GeneratorSettingをXMLドキュメントに変換する。
        /// </summary>
        /// <param name="setting">設定</param>
        /// <returns>XmlDocumentオブジェクト</returns>
        /// <remarks>
        /// シリアライズ使った方が良かったかもしれない。
        /// </remarks>
        private XmlDocument GenerateXmlDocument(GeneratorSetting setting)
        {
            // データをXMLモデルで構築する。
            XmlDocument doc = new XmlDocument();

            XmlElement rootNode = doc.CreateElement(GeneratorSettingFileDefs.NodeCharaChipGen);
            doc.AppendChild(rootNode);

            // キャラクター設定ノード
            XmlElement charactersElem = doc.CreateElement(GeneratorSettingFileDefs.NodeCharacters);
            rootNode.AppendChild(charactersElem);
            for (int i = 0; i < setting.GetCharacterCount(); i++)
            {
                Character data = setting.GetCharacter(i);
                AddCharacter(doc, charactersElem, i + 1, data);
            }

            // エクスポート設定ノード
            XmlElement exportConfigElem = doc.CreateElement(GeneratorSettingFileDefs.NodeExportSetting);
            AddConfigNode(doc, exportConfigElem, setting.ExportSetting);
            rootNode.AppendChild(exportConfigElem);

            return doc;
        }

        /// <summary>
        /// キャラクター設定ノードを追加する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <param name="parent">親要素</param>
        /// <param name="index">キャラクタ番号</param>
        /// <param name="character">キャラクターモデル</param>
        private static void AddCharacter(XmlDocument doc, XmlElement parent, int index, Character character)
        {
            XmlElement charaElem = doc.CreateElement("character");
            charaElem.SetAttribute(GeneratorSettingFileDefs.CharacterAttrNumber, index.ToString());

            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                AddCharacterPartsNode(doc, charaElem, partsType, character.GetParts(partsType));
            }

            parent.AppendChild(charaElem);
        }

        /// <summary>
        /// キャラクター部品ノードを追加する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <param name="parent">親要素</param>
        /// <param name="partsType">部品種類</param>
        /// <param name="parts">部品</param>
        private static void AddCharacterPartsNode(XmlDocument doc, XmlElement parent, PartsType partsType, Parts parts)
        {
            // nodeNameでなく、parts.MaterialNameでも良さそうだが、使うモデルによってはMaterialNameで""が返る事があるのでやらない。
            XmlElement partsElem = doc.CreateElement(GeneratorSettingFileDefs.NodeParts);
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrName, partsType.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrMaterialName, parts.MaterialName);
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrOffsetX, parts.OffsetX.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrOffsetY, parts.OffsetY.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrHue, parts.Hue.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrSaturation, parts.Saturation.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrBrightness, parts.Value.ToString());
            partsElem.SetAttribute(GeneratorSettingFileDefs.PartsAttrOpacity, parts.Opacity.ToString());

            parent.AppendChild(partsElem);
        }

        /// <summary>
        /// 出力設定ノードを追加する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <param name="parent">親要素</param>
        /// <param name="setting">出力設定</param>
        private static void AddConfigNode(XmlDocument doc, XmlElement parent, ExportSetting setting)
        {
            XmlElement chipSizeElem = doc.CreateElement(GeneratorSettingFileDefs.NodeCharaChipSize);
            chipSizeElem.SetAttribute("width", setting.CharaChipSize.Width.ToString());
            chipSizeElem.SetAttribute("height", setting.CharaChipSize.Height.ToString());
            parent.AppendChild(chipSizeElem);

            XmlElement exportPathElem = doc.CreateElement(GeneratorSettingFileDefs.NodeExportPath);
            exportPathElem.SetAttribute("path", setting.ExportFilePath);
            parent.AppendChild(exportPathElem);
        }
    }
}
