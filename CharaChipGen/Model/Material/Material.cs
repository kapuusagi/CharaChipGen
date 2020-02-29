using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// ひとつのマテリアルを表すクラス
    /// </summary>
    public class Material
    {
        private MaterialEntryFile entryFile;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ルートディレクトリを除いたパス名 (Accessories\image.pngなど))</param>
        /// <param name="entryFile">エントリファイル</param>
        public Material(string path, MaterialEntryFile entryFile)
        {
            this.Name = System.IO.Path.GetFileNameWithoutExtension(path);
            this.Path = path;
            this.entryFile = entryFile;
        }

        /// <summary>
        /// 素材の識別名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// エントリファイルの相対バス。
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// 表示名を得る。
        /// </summary>
        /// <returns>表示名</returns>
        public string GetDisplayName()
            => entryFile.GetDisplayName();

        /// <summary>
        /// 表示名を設定する。
        /// </summary>
        /// <param name="name">名前</param>
        public void SetDisplayName(string name)
            => entryFile.SetDisplayName(name);

        /// <summary>
        /// レイヤーのリストを得る。
        /// </summary>
        public MaterialLayerInfo[] Layers {
            get => entryFile.Layers.Select((entry) => entry.Value).ToArray();
        }

        /// <summary>
        /// レイヤーの画像データを取得する。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>画像データ。該当インデックスの画像データが無い場合にはnullが返る。</returns>
        public Image LoadLayerImage(int index)
        {
            if ((index >= 0) && (index < entryFile.GetLayerCount()))
            {
                string materialDir = AppData.Instance.MaterialDirectory;
                string subDirectory = System.IO.Path.GetDirectoryName(Path);
                var layerInfo = entryFile.GetLayer(index);

                string materialPath = System.IO.Path.Combine(new string[] {
                    materialDir, subDirectory, layerInfo.Path
                });
                return Bitmap.FromFile(materialPath);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// レイヤー数を得る。
        /// </summary>
        public int GetLayerCount()
        {
            return entryFile.Layers.Count;
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    
    }
}
