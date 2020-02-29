using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CharaChipGen.Model.CharaChip;

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

            XmlElement rootNode = doc.CreateElement(GeneratorSettingFileDefs.NodeNameRoot);
            doc.AppendChild(rootNode);

            // キャラクター設定ノード
            XmlElement charactersElem = doc.CreateElement(GeneratorSettingFileDefs.NodeNameCharacters);
            rootNode.AppendChild(charactersElem);
            for (int i = 0; i < setting.GetCharacterCount(); i++)
            {
                Character data = setting.GetCharacter(i);
                AddCharacter(doc, charactersElem, i + 1, data);
            }

            // エクスポート設定ノード
            XmlElement exportConfigElem = doc.CreateElement(GeneratorSettingFileDefs.NodeNameExportSetting);
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
            charaElem.SetAttribute(GeneratorSettingFileDefs.AttrNameNumber, index.ToString());

            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                string partsTypeName = AppData.Instance.GetMaterialList(partsType).Name;
                AddCharacterPartsNode(doc, charaElem, partsTypeName, character.GetParts(partsType));
            }

            parent.AppendChild(charaElem);
        }

        /// <summary>
        /// キャラクター部品ノードを追加する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <param name="parent">親要素</param>
        /// <param name="partsName">部品名(素材名ではない)</param>
        /// <param name="parts">部品</param>
        private static void AddCharacterPartsNode(XmlDocument doc, XmlElement parent, string partsName, Parts parts)
        {
            // nodeNameでなく、param.ParameterNameでも良さそうだが、使うモデルによってはParamterNameで""が返る事があるのでやらない。
            XmlElement paramElem = doc.CreateElement(GeneratorSettingFileDefs.NodeNameCharacterParts);
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNamePartsName, partsName);
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameMaterialName, parts.MaterialName);
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameXOffset, parts.OffsetX.ToString());
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameYOffset, parts.OffsetY.ToString());
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameHue, parts.Hue.ToString());
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameSaturation, parts.Saturation.ToString());
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameBrightness, parts.Value.ToString());
            paramElem.SetAttribute(GeneratorSettingFileDefs.AttrNameOpacity, parts.Opacity.ToString());

            parent.AppendChild(paramElem);
        }

        /// <summary>
        /// 出力設定ノードを追加する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <param name="parent">親要素</param>
        /// <param name="setting">出力設定</param>
        private static void AddConfigNode(XmlDocument doc, XmlElement parent, ExportSetting setting)
        {
            XmlElement chipSizeElem = doc.CreateElement(GeneratorSettingFileDefs.NodeNameCharaChipSize);
            chipSizeElem.SetAttribute("width", setting.CharaChipSize.Width.ToString());
            chipSizeElem.SetAttribute("height", setting.CharaChipSize.Height.ToString());
            parent.AppendChild(chipSizeElem);

            XmlElement exportPathElem = doc.CreateElement(GeneratorSettingFileDefs.NodeNameExportPath);
            exportPathElem.SetAttribute("path", setting.ExportFilePath);
            parent.AppendChild(exportPathElem);
        }
    }
}
