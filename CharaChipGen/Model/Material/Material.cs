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
    public class Material : IDisposable
    {
        private string path; // 素材のファイル名。
        private string name; // 素材の識別名
        private string subPath; // サブレイヤーのパス
        private Image primary; // プライマリレイヤー
        private Image secondary; // セカンダリレイヤー

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ルートディレクトリを除いたパス名 (Accessories\image.pngなど))</param>
        public Material(string path)
        {
            this.name = System.IO.Path.GetFileNameWithoutExtension(path);
            this.path = path;

            string dir = System.IO.Path.GetDirectoryName(path);
            string subFileName = System.IO.Path.GetFileNameWithoutExtension(path) + ".back.png";
            this.subPath = System.IO.Path.Combine(dir, subFileName);
            primary = null;
            secondary = null;
        }

        ~Material()
        {
            Dispose();
        }

        /// <summary>
        /// 素材の識別名
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }
        /// <summary>
        /// 素材のパス
        /// </summary>
        public string Path
        {
            get { return this.path; }
        }

        /// <summary>
        /// サブレイヤー素材のパス
        /// </summary>
        public string SubLayerPath
        {
            get { return this.subPath; }
        }

        /// <summary>
        /// プライマリレイヤーを取得する。
        /// </summary>
        /// <returns>プライマリレイヤーの画像データ。</returns>
        public Image GetPrimaryLayer()
        {
            if (primary == null)
            {
                string materialDir = AppData.GetInstance().MaterialDirectory;
                string materialPath = System.IO.Path.Combine(materialDir, path);
                primary = Bitmap.FromFile(materialPath);
            }
            return primary;
        }

        /// <summary>
        /// プライマリレイヤーを設定する。
        /// </summary>
        /// <param name="image">プライマリレイヤーの画像</param>
        public void SetPrimaryLayer(Image image)
        {
            if (primary != null)
            {
                primary.Dispose();
            }
            primary = image;
        }

        /// <summary>
        /// プライマリレイヤーをファイルに保存する。
        /// </summary>
        public void SavePrimaryLayer()
        {
            if (primary == null)
            {
                return;
            }
            // 保存処理
            string materialDir = AppData.GetInstance().MaterialDirectory;
            string materialPath = System.IO.Path.Combine(materialDir, path);

            primary.Save(materialPath, System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// セカンダリレイヤーを取得する。
        /// 
        /// セカンダリレイヤーが設定されていない場合にはnullが返る。
        /// </summary>
        /// <returns>セカンダリレイヤーの画像</returns>
        public Image GetSecondaryLayer()
        {
            if (secondary == null)
            {
                string materialDir = AppData.GetInstance().MaterialDirectory;
                string materialPath = System.IO.Path.Combine(materialDir, subPath);
                if (System.IO.File.Exists(materialPath))
                {
                    // セカンダリレイヤーはファイルが存在するなら読み込む。
                    secondary = Bitmap.FromFile(materialPath);
                }
            }
            return secondary;
        }

        /// <summary>
        /// セカンダリレイヤーを設定する
        /// </summary>
        /// <param name="image">セカンダリレイヤー名</param>
        public void SetSecondaryLayer(Image image)
        {
            if (secondary != null)
            {
                secondary.Dispose();
            }
            secondary = image;
        }

        /// <summary>
        /// セカンダリレイヤーを保存する。
        /// もしセカンダリレイヤーが存在しない場合にはなにもしない。
        /// </summary>
        public void SaveSecondaryLayer()
        {
            string materialDir = AppData.GetInstance().MaterialDirectory;
            string materialPath = System.IO.Path.Combine(materialDir, subPath);

            if (secondary == null)
            {
                if (System.IO.File.Exists(materialPath))
                {
                    // このセカンダリレイヤーは削除する必要がある。
                    System.IO.File.Delete(materialPath);
                }
            }
            else
            {
                secondary.Save(materialPath, System.Drawing.Imaging.ImageFormat.Png);
            }

        }

        public void Dispose()
        {
            if (primary != null)
            {
                primary.Dispose();
                primary = null;
            }
            if (secondary != null)
            {
                secondary.Dispose();
                secondary = null;
            }
        }

        public override string ToString()
        {
            return name;
        }
    
    }
}
