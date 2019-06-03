using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGenUtility
{
    public class OperationSettings
    {
        /// <summary>
        /// データエントリ
        /// </summary>
        private class DataEntry
        {
            /// <summary>
            /// キー文字列
            /// </summary>
            public string Key { get; set; }
            /// <summary>
            /// 値文字列
            /// </summary>
            public string Value { get; set; }
        }

        // データ
        private List<DataEntry> data;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public OperationSettings()
        {
            data = new List<DataEntry>();
        }

        /// <summary>
        /// 設定値
        /// </summary>
        /// <param name="name">設定値名</param>
        /// <returns>設定値</returns>
        public string this [string name] {
            get {
                return GetSetting(name);
            }
            set {
                SetSetting(name, value);
            }
        }

        /// <summary>
        /// 設定する
        /// </summary>
        /// <param name="name">設定名</param>
        /// <param name="value">設定値</param>
        public void SetSetting(string name, string value)
        {
            foreach (DataEntry entry in data)
            {
                if (entry.Key.Equals(name))
                {
                    entry.Value = value;
                    return;
                }
            }
            DataEntry newEntry = new DataEntry();
            newEntry.Key = name;
            newEntry.Value = value;
            data.Add(newEntry);

        }

        /// <summary>
        /// 設定を取得する。
        /// </summary>
        /// <param name="name">設定名</param>
        /// <returns>設定値</returns>
        public string GetSetting(string name)
        {
            foreach (DataEntry entry in data)
            {
                if (entry.Key.Equals(name))
                {
                    return entry.Value;
                }
            }
            return "";
        }

        /// <summary>
        /// 指定したパスに保存する。
        /// </summary>
        /// <param name="path">保存先パス</param>
        public void Save(string path)
        {
            using (System.IO.FileStream fs = System.IO.File.OpenWrite(path))
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
            {
                foreach (DataEntry entry in data)
                {
                    sw.WriteLine($"{entry.Key} = {entry.Value}");
                }

            }
        }

        /// <summary>
        /// 指定したパスから読み出す。
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            using (System.IO.FileStream fs = System.IO.File.OpenRead(path))
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fs))
            {
                string rawText = sr.ReadToEnd();
                string[] lines = rawText.Split('\n');
                foreach (string line in lines)
                {
                    int index = line.IndexOf('=');
                    if (index > 0)
                    {
                        string key = line.Substring(0, index - 1).Trim();
                        string value = line.Substring(index + 1).Trim();
                        SetSetting(key, value);
                    }
                }
            }
        }



    }
}
