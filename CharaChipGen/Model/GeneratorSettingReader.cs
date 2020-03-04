using CharaChipGen.Model.CharaChip;
using System;
using System.Xml;

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
        /// readerで指定されるリーダーを使用してGeneratorSettingを読み込む。
        /// </summary>
        /// <param name="reader">リーダー</param>
        /// <returns>GeneratorSettingオブジェクト</returns>
        public GeneratorSetting Read(System.IO.TextReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
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
                if (rootNode.Name != GeneratorSettingFileDefs.NodeCharaChipGen)
                {
                    throw new NotSupportedException("Unsupported root node. [" + rootNode.Name + "]");
                }
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case GeneratorSettingFileDefs.NodeCharacters:
                            LoadCharactersNode(node, setting);
                            break;
                        case GeneratorSettingFileDefs.NodeExportSetting:
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
                    if (node.ChildNodes[i].Name != GeneratorSettingFileDefs.NodeCharacter)
                    {
                        continue;
                    }
                    XmlAttribute attr = node.ChildNodes[i].Attributes[GeneratorSettingFileDefs.CharacterAttrNumber];
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
        /// <param name="characterNode">キャラクターノード</param>
        /// <param name="character">Characterオブジェクト</param>
        private static void LoadCharacterNode(XmlNode characterNode, Character character)
        {
            foreach (XmlNode node in characterNode.ChildNodes)
            {
                if (!node.Name.Equals(GeneratorSettingFileDefs.NodeParts))
                {
                    continue;
                }
                XmlAttribute attr = node.Attributes[GeneratorSettingFileDefs.PartsAttrName];
                if (attr == null)
                {
                    continue;
                }

                if (Enum.TryParse(attr.Value, out PartsType partsType))
                {
                    LoadCharacterPartsNode(node, character.GetParts(partsType));
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
                        case GeneratorSettingFileDefs.PartsAttrMaterialName:
                            parts.MaterialName = attr.Value;
                            break;
                        case GeneratorSettingFileDefs.PartsAttrOffsetX:
                            parts.OffsetX = int.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.PartsAttrOffsetY:
                            parts.OffsetY = int.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.PartsAttrHue:
                            parts.Hue = int.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.PartsAttrSaturation:
                            parts.Saturation = int.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.PartsAttrBrightness:
                            parts.Value = int.Parse(attr.Value);
                            break;
                        case GeneratorSettingFileDefs.PartsAttrOpacity:
                            parts.Opacity = int.Parse(attr.Value);
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
                        case GeneratorSettingFileDefs.NodeCharaChipSize:
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
                        case GeneratorSettingFileDefs.NodeExportPath:
                            XmlAttribute pathAttr = subNode.Attributes["path"];
                            setting.ExportFilePath = pathAttr.Value;
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
