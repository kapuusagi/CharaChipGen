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
    }
}
