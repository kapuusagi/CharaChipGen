using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 設定ファイルの入出力を行うクラス
    /// </summary>
    /// <remarks>
    /// 実装が汚いのでリファクタリングしたい。
    /// WriterとReaderで分ける&CharaChipDataFileConstantsクラスで定数宣言するようにした方がいい。</remarks>
    public class SettingFileController
    {
        private const string NodeNameCharacters = "characters";
        private const string NodeNameExportSetting = "export-setting";
        private const string NodeNameCharacter = "character";
        private const string NodeNameCharacterParam = "character-param";
        private const string AttrNameParamName = "param-name";
        private const string AttrNameMaterialName = "material-name";
        private const string AttrNameXOffset = "x-offset";
        private const string AttrNameYOffset = "y-offset";
        private const string AttrNameHue = "hue";
        private const string AttrNameSaturation = "saturation";
        private const string AttrNameBrightness = "brightness";
        private const string NodeNameCharaChipSize = "charachip-size";
        private const string AttrNameNumber = "number";
        private const string NodeNameRoot = "charachip-gen";
        private const string AttrNameOpacity = "opacity";


        /// <summary>
        /// コンストラクタ -> 何もしない
        /// </summary>
        private SettingFileController()
        {
        }

        /// <summary>
        /// ファイルへ書き出す
        /// </summary>
        /// <param name="filePath"></param>
        public static void Save(string filePath)
        {
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;

            // データをXMLモデルで構築する。
            XmlDocument doc = new XmlDocument();

            XmlElement rootNode = doc.CreateElement(NodeNameRoot);
            doc.AppendChild(rootNode);

            // キャラクター設定ノード
            XmlElement charactersElem = doc.CreateElement(NodeNameCharacters);
            rootNode.AppendChild(charactersElem);

            for (int i = 0; i < setting.GetCharactorCount(); i++)
            {
                Charactor data = setting.GetCharactor(i);
                AddCharaChipDataNode(doc, charactersElem, i + 1, data);
            }


            // エクスポート設定ノード
            XmlElement exportConfigElem = doc.CreateElement(NodeNameExportSetting);
            AddConfigNode(doc, exportConfigElem, setting.ExportSetting);
            rootNode.AppendChild(exportConfigElem);

            doc.Save(filePath);
        }

        private static void AddCharaChipDataNode(XmlDocument doc, XmlElement parent, int index, Charactor dataModel)
        {
            XmlElement charaElem = doc.CreateElement("character");
            charaElem.SetAttribute(AttrNameNumber, index.ToString());

            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                string partsTypeName = AppData.Instance.GetMaterialList(partsType).Name;
                AddCharaChipParamNode(doc, charaElem, partsTypeName, dataModel.GetParts(partsType));
            }

            parent.AppendChild(charaElem);
        }

        private static void AddCharaChipParamNode(XmlDocument doc, XmlElement parent, string paramName, Parts param)
        {
            // nodeNameでなく、param.ParameterNameでも良さそうだが、使うモデルによってはParamterNameで""が返る事があるのでやらない。
            XmlElement paramElem = doc.CreateElement(NodeNameCharacterParam);
            paramElem.SetAttribute(AttrNameParamName, paramName);
            paramElem.SetAttribute(AttrNameMaterialName, param.MaterialName);
            paramElem.SetAttribute(AttrNameXOffset, param.OffsetX.ToString());
            paramElem.SetAttribute(AttrNameYOffset, param.OffsetY.ToString());
            paramElem.SetAttribute(AttrNameHue, param.Hue.ToString());
            paramElem.SetAttribute(AttrNameSaturation, param.Saturation.ToString());
            paramElem.SetAttribute(AttrNameBrightness, param.Value.ToString());
            paramElem.SetAttribute(AttrNameOpacity, param.Opacity.ToString());

            parent.AppendChild(paramElem);
        }

        private static void AddConfigNode(XmlDocument doc, XmlElement parent, ExportSetting setting)
        {
            XmlElement chipSizeElem = doc.CreateElement(NodeNameCharaChipSize);
            chipSizeElem.SetAttribute("width", setting.CharaChipSize.Width.ToString());
            chipSizeElem.SetAttribute("height", setting.CharaChipSize.Height.ToString());
            parent.AppendChild(chipSizeElem);
        }


        /// <summary>
        /// ファイルから読み込む
        /// </summary>
        /// <param name="filePath"></param>
        public static  void Load(string filePath)
        {
            GeneratorSetting setting = AppData.Instance.GeneratorSetting;
            Charactor[] tmpData = new Charactor[setting.GetCharactorCount()];
            ExportSetting tmpSetting = new ExportSetting();

            XmlDocument doc = new XmlDocument();

            doc.Load(filePath);

            // ツリーからXMLで取得する。
            foreach (XmlNode rootNode in doc.ChildNodes)
            {
                if (rootNode.Name != NodeNameRoot)
                {
                    return;
                }
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case NodeNameCharacters:
                            LoadCharactersNode(node, tmpData);
                            break;
                        case NodeNameExportSetting:
                            LoadConfigNode(node, tmpSetting);
                            break;
                    }
                }
            }

            // アプリケーションに設定する。
            for (int i = 0; i < setting.GetCharactorCount(); i++)
            {
                Charactor src = tmpData[i];
                if (src == null)
                {
                    // 対象なし。
                    continue;
                }
                Charactor dst = setting.GetCharactor(i);
                if (src == null)
                {
                    // 対象なし。リセットする。
                    dst.Reset();
                }
                else
                {
                    // 読み出したデータあり
                    src.CopyTo(dst);
                }
            }

            // エクスポート設定
            setting.ExportSetting.CharaChipSize = tmpSetting.CharaChipSize;
        }

        private static void LoadCharactersNode(XmlNode node, Charactor[] tmpData)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                try
                {
                    if (node.ChildNodes[i].Name != NodeNameCharacter)
                    {
                        continue;
                    }
                    XmlAttribute attr = node.ChildNodes[i].Attributes[AttrNameNumber];
                    if (attr == null)
                    {
                        continue; // number 属性がない。
                    }
                    int index = Int32.Parse(attr.Value) - 1;
                    if ((index < 0) || (index >= tmpData.Length))
                    {
                        continue;
                    }
                    tmpData[index] = LoadCharaDataNode(node.ChildNodes[i]);
                }
                catch (Exception)
                { // 解析の例外は無視する。
                }
            }
        }


        private static Charactor LoadCharaDataNode(XmlNode node)
        {
            Charactor model = new Charactor();

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode subNode = node.ChildNodes[i];
                if (subNode.Name != NodeNameCharacterParam)
                {
                    continue;
                }
                XmlAttribute attr = subNode.Attributes[AttrNameParamName];
                if (attr == null)
                {
                    continue;
                }

                if (Enum.TryParse(attr.Value, out PartsType partsType))
                {
                    LoadCharaDataParamNode(subNode, model.GetParts(partsType));
                }
            }

            return model;
        }


        private static void LoadCharaDataParamNode(XmlNode node, Parts param)
        {
            foreach (XmlAttribute attr in node.Attributes)
            { // 全ての子要素に対して読み出す。
                try
                {
                    switch (attr.Name)
                    {
                        case AttrNameMaterialName:
                            param.MaterialName = attr.Value;
                            break;
                        case AttrNameXOffset:
                            param.OffsetX = Int32.Parse(attr.Value);
                            break;
                        case AttrNameYOffset:
                            param.OffsetY = Int32.Parse(attr.Value);
                            break;
                        case AttrNameHue:
                            param.Hue = Int32.Parse(attr.Value);
                            break;
                        case AttrNameSaturation:
                            param.Saturation = Int32.Parse(attr.Value);
                            break;
                        case AttrNameBrightness:
                            param.Value = Int32.Parse(attr.Value);
                            break;
                        case AttrNameOpacity:
                            param.Opacity = Int32.Parse(attr.Value);
                            break;
                    }
                }
                catch (Exception )
                { // ここの解析例外は無視する。
                }
            }
        }

        private static void LoadConfigNode(XmlNode node, ExportSetting setting)
        {
            foreach (XmlNode subNode in node.ChildNodes)
            {
                try {
                    switch (subNode.Name)
                    {
                        case NodeNameCharaChipSize:
                            {
                                XmlAttribute wAttr = subNode.Attributes["width"];
                                XmlAttribute hAttr = subNode.Attributes["height"];
                                if ((wAttr != null) && (hAttr != null))
                                {
                                    setting.CharaChipSize
                                        = new Size(Int32.Parse(wAttr.Value), Int32.Parse(hAttr.Value));
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
