using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CharaChipGen.Model
{
    public class MaterialList : IEnumerable<Material> 
    {
        private string name; // 素材種別名
        private List<Material> materials; // マテリアル
        private string directory; // この素材のルートディレクトリ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">素材種別名</param>
        /// <param name="dirName">ディレクトリ名(Accessoriesなど)</param>
        public MaterialList(string name, string dirName)
        {
            this.name = name;
            materials = new List<Material>();
            directory = dirName;
        }

        /// <summary>
        /// マテリアルリストを読み込む
        /// </summary>
        /// <param name="materialDirectory">ルートディレクトリ</param>
        public void LoadMaterials(string materialDirectory)
        {
            materials.Clear();

            string dirPath = System.IO.Path.Combine(materialDirectory, directory);

            string[] paths = System.IO.Directory.GetFiles(dirPath);
            foreach (string path in paths)
            {
                if (IsMaterialEntryFile(path))
                {
                    string fname = System.IO.Path.GetFileName(path);

                    Material material = new Material(System.IO.Path.Combine(directory, fname));
                    Add(material);
                }
            }
        }

        /// <summary>
        /// 素材を追加する
        /// </summary>
        /// <param name="material">素材</param>
        public void Add(Material material)
        {
            int insertPos = -1;
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].Name.CompareTo(material.Name) > 0)
                {
                    insertPos = i;
                    break;
                }
            }
            if (insertPos >= 0)
            {
                materials.Insert(insertPos, material);
            } else
            {
                materials.Add(material);
            }
        }

        /// <summary>
        /// 指定した素材を削除する
        /// </summary>
        /// <param name="name">素材名</param>
        public void Delete(string name)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].Name == name)
                {
                    materials.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// 指定した素材を削除する。
        /// </summary>
        /// <param name="material">マテリアル</param>
        public void Delete(Material material)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].Name == material.Name)
                {
                    materials.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// 指定した名前の素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns></returns>
        public Material Get(string name)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                if (materials[i].Name == name)
                {
                    return materials[i];
                }
            }
            return null;
        }

        public static bool IsMaterialEntryFile(string path)
        {
            if (!path.EndsWith(".png"))
            {
                // PNGファイルでない
                return false;
            }
            if (path.EndsWith(".back.png"))
            {
                // サブレイヤーのPNGファイルである
                return false;
            }

            if (System.IO.Directory.Exists(path))
            {
                // ディレクトリ
                return false;
            }

            return true;
        }

        /// <summary>
        /// 素材種別名
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// 素材が存在するディレクトリm名。
        /// 素材のルートディレクトリは含まれない。
        /// マテリアルディレクトリのフルパスを取得するには、
        /// ルートディレクトリとこのディレクトリ名を結合する。
        /// Accessoriesなど。
        /// </summary>
        public string SubDirectoryName
        {
            get { return directory; }
        }


        public IEnumerator<Material> GetEnumerator()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                yield return materials[i]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
