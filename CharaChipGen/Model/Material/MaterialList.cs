using System;
using System.Collections;
using System.Collections.Generic;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// 素材リスト
    /// </summary>
    public class MaterialList : IEnumerable<Material>
    {
        private List<Material> materials; // 素材

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// サブディレクトリ名はmaterialType.ToString()が使用される。
        /// </summary>
        /// <param name="materialType">素材種別</param>
        /// <param name="name">素材種別名</param>
        public MaterialList(MaterialType materialType, string name)
            : this(materialType, name, materialType.ToString())
        {

        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="materialType">素材種別</param>
        /// <param name="name">素材種別名</param>
        /// <param name="subDirectoryName">サブディレクトリ名(Accessoriesなど)</param>
        public MaterialList(MaterialType materialType, string name, string subDirectoryName)
        {
            MaterialType = materialType;
            Name = name;
            SubDirectoryName = subDirectoryName;
            materials = new List<Material>();
        }

        /// <summary>
        /// 部品種別
        /// </summary>
        public MaterialType MaterialType { get; private set; }
        /// <summary>
        /// 素材種別名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 素材が存在するサブディレクトリ名。
        /// Accessoriesなど。
        /// </summary>
        /// <remarks>
        /// 相対パス。データフォルダのルートパスを除いたもの。Accessoriesなど。
        /// 素材のルートディレクトリは含まれない。
        /// マテリアルディレクトリのフルパスを取得するには、
        /// ルートディレクトリとこのディレクトリ名を結合する。
        /// </remarks>
        public string SubDirectoryName { get; private set; }

        /// <summary>
        /// マテリアルリストを読み込む
        /// </summary>
        /// <param name="materialDirectory">ルートディレクトリ</param>
        public void LoadMaterials(string materialDirectory)
        {
            materials.Clear();

            string dirPath = System.IO.Path.Combine(materialDirectory, SubDirectoryName);

            string[] paths = System.IO.Directory.GetFiles(dirPath);
            foreach (string path in paths)
            {
                if (MaterialEntryFile.IsMaterialEntryFile(path))
                {
                    string fname = System.IO.Path.GetFileName(path);

                    try
                    {
                        MaterialEntryFile entryFile = MaterialEntryFile.LoadFrom(path);

                        string relativePath = System.IO.Path.Combine(SubDirectoryName, fname);
                        Material material = new Material(relativePath, entryFile);
                        Add(material);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                }
            }
        }

        /// <summary>
        /// 素材数。
        /// </summary>
        public int Count { get => materials.Count; }

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
            }
            else
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

        /// <summary>
        /// nameで指定される素材が存在するかどうかを判定する。
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>存在する場合にはture, 存在しない場合にはfalse</returns>
        public bool Contains(string name)
        {
            return (materials.Find((m) => m.Name.Equals(name)) != null);
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
