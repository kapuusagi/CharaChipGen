﻿using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing.Text;

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
        /// 有効な名前かどうかを返す。
        /// </summary>
        /// <param name="name">名前</param>
        /// <returns>有効な名前の場合にはtrue, それ以外はfalse</returns>
        public static bool IsValidName(string name)
        {
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            return ((name.Length > 0) && (name.IndexOfAny(invalidChars) < 0));
        }


        /// <summary>
        /// パスからエントリファイルを読み込む。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public static MaterialEntryFile LoadFrom(string path)
        {
            MaterialEntryFile materialEntryFile = new MaterialEntryFile(path);
            materialEntryFile.Load();
            return materialEntryFile;
        }

        /// <summary>
        /// path, dataTextにより、新しい素材情報を構築する。
        /// 本メソッドはdataTextから素材情報を構築し、新しいファイルとして保存する。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="dataText">データテキスト</param>
        /// <returns>MaterialEntryFileオブジェクト</returns>
        public static MaterialEntryFile CreateFrom(string path, string dataText)
        {
            var materialEntryFile = new MaterialEntryFile(path);

            var binary = Encoding.UTF8.GetBytes(dataText);
            using (var reader = new System.IO.StreamReader(new System.IO.MemoryStream(binary)))
            {
                materialEntryFile.Load(reader);
                materialEntryFile.Save();
            }
            return materialEntryFile;
        }

        // 表示名リスト
        // key:ロケール名, value:表示名
        private Dictionary<string, string> displayNames = new Dictionary<string, string>();
        // レイヤーリスト
        private MaterialLayerList layers = new MaterialLayerList();

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// インスタンス生成時にpathで指定されたファイルは読み込まず、
        /// 最初にメンバにアクセスされた時に読み込んで返す。
        /// 高速にインスタンスを生成したい場合に使用する。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public MaterialEntryFile(string path)
        {
            IsNeedLoad = System.IO.File.Exists(path); // pathのファイルが存在するなら遅延ロード対象。
            Path = path;
            displayNames["default"] = System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        /// <summary>
        /// このエントリーファイルの識別名を得る。
        /// ディレクトリ名、拡張子を抜いたものが返る。
        /// </summary>
        public string Name {
            get => System.IO.Path.GetFileNameWithoutExtension(Path);
        }

        /// <summary>
        /// エントリファイルパス。
        /// フルパスで返る。
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// 素材エントリファイルをロードする必要があるかどうかを返す。
        /// </summary>
        private bool IsNeedLoad { get; set; }

        /// <summary>
        /// 表示名。
        /// カルチャ名と表示データのペアで構成される。一番先頭はデフォルトのものが格納される。
        /// </summary>
        public Dictionary<string, string> DisplayNames {
            get {
                if (IsNeedLoad)
                {
                    Load();
                }

                return displayNames;
            }
        }

        /// <summary>
        /// レイヤー一覧。
        /// </summary>
        public MaterialLayerList Layers {
            get {
                if (IsNeedLoad)
                {
                    Load();
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
            => Layers.Get(index);

        /// <summary>
        /// レイヤー数を得る。
        /// </summary>
        /// <returns>レイヤー数</returns>
        public int GetLayerCount()
            => Layers.Count;

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
        /// エントリファイルを上書きする。
        /// </summary>
        public void Save() => SaveAs(Path);


        /// <summary>
        /// パスにエントリファイルを書き出す。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public void SaveAs(string path)
        {
            using (var writer = new System.IO.StreamWriter(
                new System.IO.FileStream(path, System.IO.FileMode.Create)))
            {
                string defaultName = System.IO.Path.GetFileNameWithoutExtension(path);
                SaveAs(writer, defaultName);
            }
        }

        /// <summary>
        /// ストリームにエントリファイルを書き出す。
        /// </summary>
        /// <param name="writer">ライター</param>
        public void SaveAs(System.IO.StreamWriter writer)
        {
            string defaultName = System.IO.Path.GetFileNameWithoutExtension(Path);
            SaveAs(writer, defaultName);
            writer.Flush();
        }


        /// <summary>
        /// ストリームにエントリファイルを書き出す。
        /// </summary>
        /// <param name="writer">デフォルト素材名</param>
        public void SaveAs(System.IO.StreamWriter writer, string defaultName)
        {
            writer.WriteLine("# Material information.");
            // 表示名
            if (displayNames != null)
            {
                foreach (var entry in DisplayNames)
                {
                    writer.WriteLine($"Name.{entry.Key} = {entry.Value}");
                }
            }
            else
            {
                writer.WriteLine($"Name.default = {defaultName}");
            }


            // レイヤー
            if (layers != null)
            {
                int no = 1;
                foreach (var layer in Layers)
                {
                    writer.WriteLine($"# Layer{no}");
                    writer.WriteLine($"Layer.{layer.Name}.Path = {layer.Path}");
                    writer.WriteLine($"Layer.{layer.Name}.Type = {layer.LayerType.ToString()}");
                    if (layer.ColorPartsRefs != null)
                    {
                        writer.WriteLine($"Layer.{layer.Name}.ColorPartsRefs = {layer.ColorPartsRefs.ToString()}");
                    }
                    if (!string.IsNullOrEmpty(layer.ColorPropertyName))
                    {
                        writer.WriteLine($"Layer.{layer.Name}.ColorPropertyName = {layer.ColorPropertyName}");
                    }
                    writer.WriteLine($"Layer.{layer.Name}.Attribute = {GetAttributeString(layer)}");
                    no++;
                }
            }
        }

        /// <summary>
        /// レイヤー属性文字列を得る。
        /// </summary>
        /// <param name="info">レイヤー情報</param>
        /// <returns>属性文字列</returns>
        private string GetAttributeString(MaterialLayerInfo info)
        {
            StringBuilder sb = new StringBuilder();
            if (info.ColorImmutable)
            {
                sb.Append(nameof(info.ColorImmutable));
            }
            if (info.Coloring)
            {
                sb.Append(nameof(info.Coloring));
            }
            return sb.ToString();
        }

        /// <summary>
        /// エントリファイルを再読み込みする。
        /// </summary>
        public void Load()
        {
            IsNeedLoad = false;

            using (var reader = new System.IO.StreamReader(System.IO.File.OpenRead(Path)))
            {
                Load(reader);
            }
        }

        /// <summary>
        /// ストリームから読み込みする。
        /// </summary>
        /// <param name="reader">読み込み元</param>
        private void Load(System.IO.StreamReader reader)
        {
            displayNames.Clear();
            displayNames["default"] = System.IO.Path.GetFileNameWithoutExtension(Path);
            layers.Clear();

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
                    if (!Layers.Contains(layerName)) // 既にインスタンスがある？
                    {
                        Layers.Add(new MaterialLayerInfo(layerName)); // インスタンスを追加。
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
                            else if (int.TryParse(value, out int no))
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
                        case "ColorPropertyName":
                            if (Parts.GetColorSettingNames().Contains(value))
                            {
                                layer.ColorPropertyName = value;
                            }
                            break;
                        case "Attribute":
                            SetAttributeString(layer, value);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// レイヤー情報に属性を追加する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="attrString">属性文字列</param>
        private void SetAttributeString(MaterialLayerInfo layer, string attrString)
        {
            string[] attributes = attrString.Split(',');
            foreach (string str in attributes)
            {
                switch (str)
                {
                    case nameof(layer.ColorImmutable):
                        layer.ColorImmutable = true;
                        break;
                    case nameof(layer.Coloring):
                        layer.Coloring = true;
                        break;
                }
            }
        }
    }
}
