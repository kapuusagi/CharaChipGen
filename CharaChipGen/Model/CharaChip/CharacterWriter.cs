using System;
using System.Xml;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// Characterオブジェクトを書き出すクラス
    /// </summary>
    public class CharacterWriter
    {
        /// <summary>
        /// 新しいインスタンスを駆逐する。
        /// </summary>
        public CharacterWriter()
        {
        }

        /// <summary>
        /// Characterオブジェクトをファイルに書き出す。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="character">キャラクター</param>
        public void Write(string path, Character character)
        {
            XmlDocument doc = GenerateXmlDocument(character);
            doc.Save(path);
        }

        /// <summary>
        /// Characterオブジェクトを指定されたwriterに書き出す。
        /// </summary>
        /// <param name="writer">テキストライター</param>
        /// <param name="character">キャラクター</param>
        public void Write(System.IO.TextWriter writer, Character character)
        {
            XmlDocument doc = GenerateXmlDocument(character);
            doc.Save(writer);

        }

        /// <summary>
        /// Characterオブジェクトをストリームに書き出す。
        /// </summary>
        /// <param name="stream">ストリーム</param>
        /// <param name="character">キャラクター</param>
        public void Write(System.IO.Stream stream, Character character)
        {
            XmlDocument doc = GenerateXmlDocument(character);
            doc.Save(stream);
        }

        /// <summary>
        /// データモデルからXMLドキュメントを生成する。
        /// </summary>
        /// <param name="character">キャラクターオブジェクト</param>
        /// <returns>XMLドキュメント</returns>
        private XmlDocument GenerateXmlDocument(Character character)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootNode = doc.CreateElement(CharacterFileDefs.NodeCharacter);
            doc.AppendChild(rootNode);
            foreach (PartsType partsType in Enum.GetValues(typeof(PartsType)))
            {
                Parts parts = character.GetParts(partsType);
                if (parts == null)
                {
                    continue;
                }

                XmlElement partsElem = doc.CreateElement(CharacterFileDefs.NodeParts);
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrName, partsType.ToString());
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrMaterialName, parts.MaterialName);
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrOffsetX, parts.OffsetX.ToString());
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrOffsetY, parts.OffsetY.ToString());
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrColor1, parts.Color1.ToString());
                partsElem.SetAttribute(CharacterFileDefs.PartsAttrColor2, parts.Color2.ToString());

                rootNode.AppendChild(partsElem);
            }


            return doc;
        }
    }
}
