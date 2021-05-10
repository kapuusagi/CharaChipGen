using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FImageEditor
{
    public class FaceImageSet
    {
        private FaceImageEntry[] entries;
        /// <summary>
        /// 画像エントリセットを作成する。
        /// </summary>
        public FaceImageSet()
        {
            entries = new FaceImageEntry[8];
            for (int i = 0; i < entries.Length; i++)
            {
                entries[i] = new FaceImageEntry();
            }
        }

        /// <summary>
        /// エントリ数を得る。
        /// </summary>
        public int EntryCount {
            get => entries.Length;
        }

        /// <summary>
        /// エントリを得る。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>エントリ</returns>
        public FaceImageEntry GetEntry(int index)
        {
            return entries[index];
        }

        /// <summary>
        /// エクスポートする幅
        /// </summary>
        public int ExportWidth {
            get => entries[0].Width * HorizontalEntryCount;
        }

        /// <summary>
        /// エクスポートする高さ
        /// </summary>
        public int ExportHeight {
            get => entries[0].Height * VerticalEntryCount;
        }

        /// <summary>
        /// 水平エントリ数
        /// </summary>
        public int HorizontalEntryCount {
            get => 4;
        }
        /// <summary>
        /// 垂直エントリ数
        /// </summary>
        public int VerticalEntryCount {
            get => 2;
        }

        /// <summary>
        /// 設定をクリアする。
        /// </summary>
        public void Clear()
        {
            foreach (var entry in entries)
            {
                entry.Reset();
            }
        }

        public void SaveTo(string fileName)
        {
            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write))
            {
                SaveTo(fs);
            }
        }
        public void SaveTo(System.IO.Stream stream)
        {
            using (var sw = new System.IO.StreamWriter(stream))
            {
                foreach (var entry in entries)
                {
                    sw.WriteLine(entry.ToString());
                }
            }
        }

        public void LoadFrom(string fileName)
        {
            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                LoadFrom(fs);
            }
        }

        public void LoadFrom(System.IO.Stream stream)
        {
            var newEntries = new List<FaceImageEntry>();
            using (var sr = new System.IO.StreamReader(stream))
            {
                int lineNo = 1;
                try
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        var entry = FaceImageEntry.Parse(line);
                        newEntries.Add(entry);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Line{lineNo}:{ex.Message}");
                }
            }

            for (int index = 0; (index < entries.Length) && (index < newEntries.Count); index++)
            {
                entries[index].FileName = newEntries[index].FileName;
                entries[index].X = newEntries[index].X;
                entries[index].Y = newEntries[index].Y;
            }

        }
    }
}
