using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// 表示名
        private Dictionary<string, string> displayNames;

        /// レイヤー
        private Dictionary<string, MaterialLayerInfo> layers;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialEntryFile() : this(null)
        {
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public MaterialEntryFile(string path)
        {
            Path = path;
            displayNames = null;
            layers = null;
            displayNames = new Dictionary<string, string>();
            layers = new Dictionary<string, MaterialLayerInfo>();
        }

        /// <summary>
        /// エントリファイルパス
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 表示名。
        /// カルチャ名と表示データのペアで構成される。一番先頭はデフォルトのものが格納される。
        /// </summary>
        public Dictionary<string, string> DisplayNames { 
            get {
                if (displayNames == null)
                {
                    Load(Path);
                }

                return displayNames;
            }
        }

        /// <summary>
        /// レイヤー一覧
        /// </summary>
        public Dictionary<string, MaterialLayerInfo> Layers {
            get {
                if (layers == null)
                {
                    Load(Path);
                }
                return layers;
            }
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
        /// デフォルトの表示名を取得する。
        /// </summary>
        /// <returns>表示名</returns>
        public string GetDisplayName()
        {
            string caltureName = System.Globalization.CultureInfo.CurrentCulture.Name;
            return GetDisplayName(caltureName);
        }

        /// <summary>
        /// カルチャ名に対応する表示名を取得する。
        /// </summary>
        /// <param name="caltureName">カルチャ名</param>
        /// <returns>表示名</returns>
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
        /// 表示名を設定する。
        /// </summary>
        /// <param name="name">名前</param>
        public void SetDisplayName(string name)
        {
            string caltureName = System.Globalization.CultureInfo.CurrentCulture.Name;
            SetDisplayName(caltureName, name);
        }

        /// <summary>
        /// 表示名を設定する。
        /// </summary>
        /// <param name="caltureName">カルチャ名(en-USなど)</param>
        /// <param name="name">名前</param>
        public void SetDisplayName(string caltureName, string name)
        {
            if (DisplayNames.ContainsKey(caltureName))
            {
                DisplayNames[caltureName] = name;
            }
            else
            {
                DisplayNames.Add(caltureName, name);
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
                writer.WriteLine("# Material information.");
                // 表示名
                foreach (var entry in DisplayNames)
                {
                    writer.WriteLine($"Name.{entry.Key} = {entry.Value}");
                }

                // レイヤー名
                int no = 1;
                foreach (var entry in Layers)
                {
                    writer.WriteLine($"# Layer{no}");
                    MaterialLayerInfo layer = entry.Value;
                    writer.WriteLine($"Layer.{layer.Name}.Path = {layer.Path}");
                    writer.WriteLine($"Layer.{layer.Name}.Type = {layer.LayerType.ToString()}");
                    if (layer.ColorPartsRefs != null)
                    {
                        writer.WriteLine($"Layer.{layer.Name}.ColorPartsRefs = {layer.ColorPartsRefs.ToString()}");
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
            displayNames = new Dictionary<string, string>();
            layers = new Dictionary<string, MaterialLayerInfo>();

            using (var reader = new System.IO.StreamReader(System.IO.File.OpenRead(path)))
            {
                string[] lines = reader.ReadToEnd().Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line.StartsWith("#"))
                    {
                        continue;
                    }
                    int index = line.IndexOf('=');
                    if (index <= 0)
                    {
                        continue;
                    }
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
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
                            else if (Enum.TryParse(value, out int no))
                            {
                                LayerType[] layerTypes = (LayerType[])(Enum.GetValues(typeof(LayerType)));
                                if ((no >= 0) && (no < layerTypes.Length))
                                {
                                    layer.LayerType = layerTypes[no];
                                }
                            }
                            break;
                        case "ColorPartsRefs":
                            if (Enum.TryParse(value, out PartsType attrType))
                            {
                                layer.ColorPartsRefs = attrType;
                            }
                            break;
                    }
                    break;

            }
        }

    }
}
