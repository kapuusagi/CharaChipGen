using CharaChipGen.Model;
using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Material;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharaChipGen
{
    /// <summary>
    /// アプリケーションデータクラス
    /// </summary>
    class AppData
    {
        private static AppData instance;

        /// <summary>
        /// アプリケーションデータのインスタンスを得る
        /// </summary>
        /// <returns></returns>
        public static AppData Instance {
            get {
                if (instance == null)
                {
                    instance = new AppData();
                }
                return instance;
            }
        }

        // 素材ディレクトリ
        private string materialDirectory = "";
        // 部品エントリ
        private MaterialList[] materialLists;

        private Dictionary<PartsType, MaterialType> materialTable;
        // テンプレートリスト
        private Dictionary<string, Character> templates;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private AppData()
        {
            materialLists = new MaterialList[] {
                new MaterialList(MaterialType.Accessories, Properties.Resources.NameAccessories),
                new MaterialList(MaterialType.HairStyles, Properties.Resources.NameHairStyles),
                new MaterialList(MaterialType.Eyes, Properties.Resources.NameEyes),
                new MaterialList(MaterialType.Heads, Properties.Resources.NameHeads),
                new MaterialList(MaterialType.Bodies, Properties.Resources.NameBodies),
                new MaterialList(MaterialType.HeadAccessories, Properties.Resources.NameHeadAccessories),
            };
            materialTable = new Dictionary<PartsType, MaterialType>();
            materialTable.Add(PartsType.Accessory1, MaterialType.Accessories);
            materialTable.Add(PartsType.Accessory2, MaterialType.Accessories);
            materialTable.Add(PartsType.Accessory3, MaterialType.Accessories);
            materialTable.Add(PartsType.Body, MaterialType.Bodies);
            materialTable.Add(PartsType.Eye, MaterialType.Eyes);
            materialTable.Add(PartsType.HairStyle, MaterialType.HairStyles);
            materialTable.Add(PartsType.Head, MaterialType.Heads);
            materialTable.Add(PartsType.HeadAccessory1, MaterialType.HeadAccessories);
            materialTable.Add(PartsType.HeadAccessory2, MaterialType.HeadAccessories);

            GeneratorSetting = new GeneratorSetting();

            templates = new Dictionary<string, Character>();
        }

        /// <summary>
        /// マテリアルリストとテンプレートリストを読み込む。
        /// ディレクトリを探索して、所定のディレクトリにあるファイルをリストする。
        /// </summary>
        /// <param name="directory">ディレクトリ</param>
        /// <returns>リストが構築できた場合にはtrue, それ以外はfalse</returns>
        public bool Initialize(string directory)
        {
            string dir = System.IO.Path.GetFullPath(directory);
            if (!System.IO.Directory.Exists(dir))
            {
                return false;
            }

            foreach (MaterialList materialList in materialLists)
            {
                if (materialList.Count == 0)
                {
                    LoadMaterials(dir, materialList);
                }
            }

            // テンプレート読み込み(あれば)
            string templateDir = System.IO.Path.Combine(dir, "Template");
            if (System.IO.Directory.Exists(templateDir))
            {
                LoadTemplates(templateDir);
            }

            MaterialDirectory = dir;
            return true;
        }

        /// <summary>
        /// templateDirからテンプレートを読み込む。
        /// </summary>
        /// <param name="templateDir">テンプレート</param>
        private void LoadTemplates(string templateDir)
        {
            string[] paths = System.IO.Directory.GetFiles(templateDir, "*.ccgtemplate");
            CharacterReader reader = new CharacterReader();
            foreach (string path in paths)
            {
                try
                {
                    string name = System.IO.Path.GetFileNameWithoutExtension(path);
                    Character character = reader.Read(path);
                    // テンプレートリストに追加。
                    templates.Add(name, character);

                }
                catch { /* ここでの例外は無視 */ }
            }
        }

        /// <summary>
        /// アクセサリ
        /// </summary>
        public MaterialList Accessories { get => GetMaterialList(MaterialType.Accessories); }

        /// <summary>
        /// アクセサリを取得する。
        /// </summary>
        /// <param name="name">マテリアル名</param>
        /// <returns>マテリアル</returns>
        public Material GetAccessory(string name) => Accessories.Get(name);


        /// <summary>
        /// 髪
        /// </summary>
        public MaterialList HairStyles { get => GetMaterialList(MaterialType.HairStyles); }


        /// <summary>
        /// 髪素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHairStyle(string name) => HairStyles.Get(name);


        /// <summary>
        /// 目
        /// </summary>
        public MaterialList Eyes { get => GetMaterialList(MaterialType.Eyes); }

        /// <summary>
        /// 目素材を取得する。
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetEye(string name) => Eyes.Get(name);

        /// <summary>
        /// 頭
        /// </summary>
        public MaterialList Heads { get => GetMaterialList(MaterialType.Heads); }

        /// <summary>
        /// 頭素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHead(string name) => Heads.Get(name);

        /// <summary>
        /// <summary>
        /// 体
        /// </summary>
        public MaterialList Bodies { get => GetMaterialList(MaterialType.Bodies); }

        /// <summary>
        /// 体素材を取得する
        /// </summary>
        /// <param name="name">マテリアル名</param>
        /// <returns>マテリアル</returns>
        public Material GetBody(string name) => Bodies.Get(name);

        /// <summary>
        /// ヘッドアクセサリ
        /// </summary>
        public MaterialList HeadAccessories { get => GetMaterialList(MaterialType.HeadAccessories); }


        /// <summary>
        /// ヘッドアクセサリ素材を取得する。
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHeadAccessory(string name) => HeadAccessories.Get(name);

        /// <summary>
        /// nameで指定される素材リストを取得する。
        /// </summary>
        /// <param name="name">部品名(=サブディレクトリ名)</param>
        /// <returns></returns>
        public MaterialList GetMaterialList(string name)
        {
            if (Enum.TryParse(name, out MaterialType materialType))
            {
                return GetMaterialList(materialType);
            }
            else if (Enum.TryParse(name, out PartsType partsType))
            {
                return GetMaterialList(partsType);
            }
            return null;
        }

        /// <summary>
        /// materialTypeに対応する素材リストを取得する。
        /// </summary>
        /// <param name="materialType">素材種類</param>
        /// <returns>素材リスト</returns>
        public MaterialList GetMaterialList(MaterialType materialType)
        {
            return materialLists.First((list) => list.MaterialType == materialType);
        }

        /// <summary>
        /// partsTypeに対応する素材リストを取得する。
        /// </summary>
        /// <param name="partsType">パーツタイプ</param>
        /// <returns>素材リスト</returns>
        public MaterialList GetMaterialList(PartsType partsType)
        {
            return GetMaterialList(materialTable[partsType]);
        }

        /// <summary>
        /// materialRootDirectory下にある、list.SubDirectoryNameフォルダの中をスキャンし、
        /// 素材のリストを構築する。
        /// </summary>
        /// <param name="materialRootDirectory">素材ディレクトリ</param>
        /// <param name="list">読み込むリスト</param>
        private static void LoadMaterials(string materialRootDirectory, MaterialList list)
        {
            string dirPath = System.IO.Path.Combine(materialRootDirectory, list.SubDirectoryName);
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            list.LoadMaterials(materialRootDirectory);
        }

        /// <summary>
        /// マテリアルデータのルートディレクトリを表すプロパティ。
        /// </summary>
        public string MaterialDirectory {
            get { return materialDirectory; }
            set {
                if ((materialDirectory == value)
                    || ((materialDirectory != null) && materialDirectory.Equals(value)))
                {
                    return;
                }
                Properties.Settings.Default.MaterialDirectory = value;
                materialDirectory = value;
            }
        }

        /// <summary>
        /// キャラクタチップジェネレータ設定
        /// </summary>
        public GeneratorSetting GeneratorSetting { get; private set; }

        /// <summary>
        /// キャラクタテンプレート
        /// </summary>
        public Dictionary<string, Character> CharacterTemplates { get => templates; }

    }
}
