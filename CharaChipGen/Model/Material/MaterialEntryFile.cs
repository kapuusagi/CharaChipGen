using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.Layer;


namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// 素材エントリファイル。
    /// </summary>
    public class MaterialEntryFile
    {
        /// <summary>
        /// 素材エントリファイル拡張子
        /// </summary>
        public const string EntryFileSuffix = ".ccgmaterial";

        /// <summary>
        /// 素材エントリファイルかどうかを判定する。
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>素材エントリファイルの場合にはtrue, それ以外はfalse</returns>
        public static bool IsMaterialEntryFile(string path)
        {
            if (path.EndsWith(EntryFileSuffix))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialEntryFile()
        {
            DisplayNames = new Dictionary<string, string>();
            Layers = new Dictionary<string, MaterialLayerInfo>();
        }

        /// <summary>
        /// 表示名。
        /// カルチャ名と表示データのペアで構成される。一番先頭はデフォルトのものが格納される。
        /// </summary>
        public Dictionary<string, string> DisplayNames { get; private set; }

        /// <summary>
        /// レイヤー一覧
        /// </summary>
        public Dictionary<string, MaterialLayerInfo> Layers { get; private set; }


        /// <summary>
        /// デフォルトの表示名を取得する。
        /// </summary>
        /// <returns></returns>
        public string GetDisplayName()
        {
            string caltureName = System.Globalization.CultureInfo.CurrentCulture.NativeName;
            return GetDisplayName(caltureName);
        }

        /// <summary>
        /// レイヤー情報を取得する。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>レイヤー情報</returns>
        public MaterialLayerInfo GetLayer(int index)
        {
            if ((index >= 0) && (index < Layers.Count))
            {
                return Layers.ElementAt(index).Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// レイヤー数を得る。
        /// </summary>
        /// <returns></returns>
        public int GetLayerCount()
        {
            return Layers.Count;
        }

        /// <summary>
        /// カルチャ名に対応する表示名を取得する。
        /// </summary>
        /// <param name="caltureName">カルチャ名</param>
        /// <returns></returns>
        public string GetDisplayName(string caltureName)
        {
            if (DisplayNames.ContainsKey(caltureName))
            {
                return DisplayNames[caltureName];
            }
            else if (DisplayNames.ContainsKey("default"))
            {
                return DisplayNames["default"];
            }
            else
            {
                return DisplayNames.ElementAt(0).Value;
            }
        }

        /// <summary>
        /// パスにエントリファイルを書き出す。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public void Save(string path)
        {
            using (var writer = new System.IO.StreamWriter(System.IO.File.OpenWrite(path)))
            {
                // 表示名
                foreach (var entry in DisplayNames)
                {
                    writer.WriteLine($"Name.{entry.Key} = {entry.Value}");
                }

                // レイヤー名
                foreach (var entry in Layers)
                {
                    MaterialLayerInfo layer = entry.Value;
                    writer.WriteLine($"Layer.{layer.Name}.Path = {layer.Path}");
                    writer.WriteLine($"Layer.{layer.Name}.Type = {layer.LayerType.ToString()}");
                    if (layer.AttributeType != layer.LayerType)
                    {
                        writer.WriteLine($"Layer.{layer.Name}.Attribute = {layer.AttributeType.ToString()}");
                    }
                }
            }
        }


        /// <summary>
        /// パスからエントリファイルを読み込む。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public void Load(string path)
        {
            DisplayNames.Clear();
            Layers.Clear();

            using (var reader = new System.IO.StreamReader(System.IO.File.OpenRead(path)))
            {
                string[] lines = reader.ReadToEnd().Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    int index = line.IndexOf('=');
                    if (index <= 0)
                    {
                        continue;
                    }
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();
                    if (string.IsNullOrEmpty(key))
                    {
                        continue;
                    }
                    if (((value[0] == '\"') && (value[value.Length - 1] == '\"'))
                        || ((value[0] == '\'') && (value[value.Length - 1] == '\'')))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    SetValue(key, value);
                }
            }

            // 値チェック
            if (DisplayNames.Count == 0)
            {
                throw new NotSupportedException("Material entry file has no name.");
            }

            // 有効なレイヤーが一つ以上あるかどうか。
            if (!Layers.Any((entry) => entry.Value.IsValid()))
            {
                throw new NotSupportedException("Material entry file has no layers.");
            }
        }

        /// <summary>
        /// キーに値を設定する。
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">値</param>
        private void SetValue(string key, string value)
        {
            string[] keys = key.Split('.');
            switch (keys[0])
            {
                case "Name":
                    if ((keys.Length > 1) && !string.IsNullOrEmpty(keys[1]) && !string.IsNullOrEmpty(value))
                    {
                        string caltureName = keys[1];
                        DisplayNames[caltureName] = value;
                    }
                    break;
                case "Layer":
                    if (keys.Length < 3)
                    {
                        break;
                    }
                    string layerName = keys[1];
                    if (!Layers.ContainsKey(layerName))
                    {
                        Layers.Add(layerName, new MaterialLayerInfo(layerName));
                    }
                    MaterialLayerInfo layer = Layers[layerName];
                    switch (keys[2])
                    {
                        case "Path":
                            layer.Path = value;
                            break;
                        case "Type":
                            if (Enum.TryParse(value, out LayerType layerType))
                            {
                                layer.LayerType = layerType;
                            }
                            break;
                        case "Attribute":
                            if (Enum.TryParse(value, out LayerType attrType))
                            {
                                layer.AttributeType = attrType;
                            }
                            break;
                    }
                    break;

            }
        }

    }
}
