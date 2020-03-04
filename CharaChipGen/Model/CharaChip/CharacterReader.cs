using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// Characterを読み込むためのリーダークラス
    /// </summary>
    public class CharacterReader
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharacterReader()
        {
        }

        /// <summary>
        /// pathで指定されるファイルからCharacterを読み込む。
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>Characterオブジェクト</returns>
        public Character Read(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return ParseXmlDocument(doc);
        }

        /// <summary>
        /// readerで指定されるファイルからCharacterを読み込む。
        /// </summary>
        /// <param name="reader">リーダー</param>
        /// <returns>Characterオブジェクト</returns>
        public Character Read(System.IO.TextReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            return ParseXmlDocument(doc);
        }

        /// <summary>
        /// streamで指定されるstramからCharacterを読み込む。
        /// </summary>
        /// <param name="stream">ストリーム</param>
        /// <returns>Characterオブジェクト</returns>
        public Character Read(System.IO.Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            return ParseXmlDocument(doc);
        }

        /// <summary>
        /// XMLドキュメントを解析して、Characterを取得する。
        /// </summary>
        /// <param name="doc">XMLドキュメント</param>
        /// <returns>Characterオブジェクト</returns>
        private Character ParseXmlDocument(XmlDocument doc)
        {
            Character character = new Character();

            var nodes = doc.GetElementsByTagName(CharacterFileDefs.NodeCharacter);
            if (nodes.Count != 1)
            {
                throw new Exception("Unsupported data.");
            }

            LoadCharacterNode(nodes[0], character);

            return character;
        }

        /// <summary>
        /// キャラクターノードを解析し、設定値を得る。
        /// </summary>
        /// <param name="characterNode">キャラクターノード</param>
        /// <param name="character">Characterオブジェクト</param>
        private void LoadCharacterNode(XmlNode characterNode, Character character)
        {
            foreach (XmlNode node in characterNode.ChildNodes)
            {
                if (!node.Name.Equals(CharacterFileDefs.NodeParts))
                {
                    continue;
                }

                XmlAttribute attr = node.Attributes[CharacterFileDefs.PartsAttrName];
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
                        case CharacterFileDefs.PartsAttrMaterialName:
                            parts.MaterialName = attr.Value;
                            break;
                        case CharacterFileDefs.PartsAttrOffsetX:
                            parts.OffsetX = int.Parse(attr.Value);
                            break;
                        case CharacterFileDefs.PartsAttrOffsetY:
                            parts.OffsetY = int.Parse(attr.Value);
                            break;
                        case CharacterFileDefs.PartsAttrHue:
                            parts.Hue = int.Parse(attr.Value);
                            break;
                        case CharacterFileDefs.PartsAttrSaturation:
                            parts.Saturation = int.Parse(attr.Value);
                            break;
                        case CharacterFileDefs.PartsAttrBrightness:
                            parts.Value = int.Parse(attr.Value);
                            break;
                        case CharacterFileDefs.PartsAttrOpacity:
                            parts.Opacity = int.Parse(attr.Value);
                            break;
                    }
                }
                catch (Exception)
                { // ここの解析例外は無視する。
                }
            }
        }
    }
}
