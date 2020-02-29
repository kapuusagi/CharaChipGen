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
    /// キャラクタチップジェネレータ設定ファイルを読み込む。
    /// </summary>
    public class GeneratorSettingReader
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public GeneratorSettingReader()
        {
        }

        /// <summary>
        /// pathで指定されるファイルを開き、GeneratorSettingを読み込む。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>GeneratorSettingオブジェクト</returns>
        public GeneratorSetting Read(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return ParseXmlDocument(doc);
        }

        /// <summary>
        /// streamで指定されるストリームからGeneratorSettingを読み込む。
        /// </summary>
        /// <param name="stream">読み込むストリーム</param>
        /// <returns>GeneratorSettingオブジェクト</returns>
        public GeneratorSetting Read(System.IO.Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            return ParseXmlDocument(doc);
        }

        /// <summary>
        /// XMLドキュメントを解析して、GeneratorSettingを取得する。
        /// </summary>
        /// <param name="doc">XmlDocumentオブジェクト</param>
        /// <returns>GeneratorSettingオブジェクト</returns>
        private GeneratorSetting ParseXmlDocument(XmlDocument doc)
        {
            GeneratorSetting setting = new GeneratorSetting();
            // ツリーからXMLで取得する。
            foreach (XmlNode rootNode in doc.ChildNodes)
            {
                if (rootNode.Name != GeneratorSettingFileDefs.NodeNameRoot)
                {
                    throw new NotSupportedException("Unsupported root node. [" + rootNode.Name + "]");
                }
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case GeneratorSettingFileDefs.NodeNameCharacters:
                            LoadCharactersNode(node, setting);
                            break;
                        case GeneratorSettingFileDefs.NodeNameExportSetting:
                            LoadConfigNode(node, setting.ExportSetting);
                            break;
                    }
                }
            }
            return setting;
        }

        /// <summary>
        /// Charactersノードを解析し、設定値を得る。
        /// </summary>
        /// <param name="node">Charactersノード</param>
        /// <param name="setting">GeneratorSettingオブジェクト</param>
        private static void LoadCharactersNode(XmlNode node, GeneratorSetting setting)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                try
                {
                    if (node.ChildNodes[i].Name != GeneratorSettingFileDefs.NodeNameCharacter)
                    {
                        continue;
                    }
                    XmlAttribute attr = node.ChildNodes[i].Attributes[GeneratorSettingFileDefs.AttrNameNumber];
                    if (attr == null)
                    {
                        continue; // number 属性がない。
                    }
                    int index = Int32.Parse(attr.Value) - 1;
                    if ((index < 0) || (index >= setting.GetCharacterCount()))
                    {
                        continue;
                    }
                    LoadCharacterNode(node.ChildNodes[i], setting.GetCharacter(index));
                }
                catch (Exception)
                { // 解析の例外は無視する。
                }
            }
        }

        /// <summary>
        /// キャラクターノードを解析し、設定値を得る。
        /// </summary>
        /// <param name="node">キャラクターノード</param>
        /// <param name="character">Characterオブジェクト</param>
        private static void LoadCharacterNode(XmlNode node, Character character)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode subNode = node.ChildNodes[i];
                if (subNode.Name != GeneratorSettingFileDefs.NodeNameCharacterParts)
                {
                    continue;
                }
                XmlAttribute attr = subNode.Attributes[GeneratorSettingFileDefs.AttrNamePartsName];
                if (attr == null)
                {
                    continue;
                }

                if (Enum.TryParse(attr.Value, out PartsType partsType))
                {
                    LoadCharacterPartsNode(subNode, character.GetParts(partsType));
                }
            }

        }

        /// <summary>
        /// キャラクタチップ部品のノードを解析し、設定値を得る。
        /// </summary>
        /// <param name="node">キャラクタチップ部品ノード</param>
        /// <param name="parts">Partsオブジェクト</param>
        private static void LoadCharacterPartsNode(XmlNode node, Parts parts)
        {
            foreach (XmlAttribute attr in node.Attributes)
            { // 全ての子要素に対して読み出す。
                try
                {
                    switch (attr.Name)
                    {
                        case GeneratorSettingFileDefs.AttrNameMaterialName:
                            parts.MaterialName = attr.Value;
                            break;
                        case GeneratorSettingFileDefs.AttrNameXOffset:
                            parts.OffsetX = Int32.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.AttrNameYOffset:
                            parts.OffsetY = Int32.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.AttrNameHue:
                            parts.Hue = Int32.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.AttrNameSaturation:
                            parts.Saturation = Int32.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.AttrNameBrightness:
                            parts.Value = Int32.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.AttrNameOpacity:
                            parts.Opacity = Int32.Parse(attr.Value);
                            break;
                    }
                }
                catch (Exception)
                { // ここの解析例外は無視する。
                }
            }
        }

        /// <summary>
        /// 出力設定ノードを解析して設定値を取得する。
        /// </summary>
        /// <param name="node">出力設定ノード</param>
        /// <param name="setting">ExportSettingオブジェクト</param>
        private static void LoadConfigNode(XmlNode node, ExportSetting setting)
        {
            foreach (XmlNode subNode in node.ChildNodes)
            {
                try
                {
                    switch (subNode.Name)
                    {
                        case GeneratorSettingFileDefs.NodeNameCharaChipSize:
                            {
                                XmlAttribute wAttr = subNode.Attributes["width"];
                                XmlAttribute hAttr = subNode.Attributes["height"];
                                if ((wAttr != null) && (hAttr != null))
                                {
                                    setting.CharaChipSize
                                        = new System.Drawing.Size(Int32.Parse(wAttr.Value), Int32.Parse(hAttr.Value));
                                }
                            }
                            break;
                    }
                }
                catch (Exception)
                { // 各項目の例外は無視する。
                }
            }

        }
    }
}
