using System;
using System.Drawing;
using System.Linq;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// ひとつのマテリアルを表すクラス。
    /// </summary>
    /// <remarks>
    /// 素材識別名(Name)はエントリファイルの名前(拡張子抜き)となっていることに注意する。
    /// </remarks>
    public class Material
    {
        private MaterialEntryFile entryFile;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="relativePath">素材フォルダルートからの相対パス名 (Accessories\image.pngなど))</param>
        /// <param name="entryFile">エントリファイル</param>
        public Material(string relativePath, MaterialEntryFile entryFile)
        {
            this.RelativePath = relativePath;
            this.entryFile = entryFile;
        }

        /// <summary>
        /// 素材の識別名
        /// </summary>
        public string Name { get => entryFile.Name; }

        /// <summary>
        /// エントリファイルの相対バス。
        /// </summary>
        public string RelativePath { get; private set; }

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
        /// <exception cref="Exception">読み出しに失敗した場合</exception>
        public Image LoadLayerImage(int index)
        {
            if ((index < 0) || (index >= entryFile.GetLayerCount()))
            {
                return null;
            }

            string entryFileDir = System.IO.Path.GetDirectoryName(entryFile.Path);
            var layerInfo = entryFile.GetLayer(index);

            if (string.IsNullOrEmpty(layerInfo.Path))
            {
                return null;
            }
            else
            {
                string materialPath = System.IO.Path.Combine(entryFileDir, layerInfo.Path);
                return Bitmap.FromFile(materialPath);
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
        /// 再読み込みする。
        /// </summary>
        public void Reload()
        {
            entryFile.Load();
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
