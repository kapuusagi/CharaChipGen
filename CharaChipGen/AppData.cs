using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CharaChipGen.Model;
using CharaChipGen.Model.Material;

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
        public static AppData Instance
        {
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
        //  キャラチップデータモデル
        private CharaChipDataModel[] charaChipDataModels;
        // エクスポート設定
        private ExportSetting exportSetting;
        // 部品エントリ
        private MaterialList[] materialLists;

        private Dictionary<PartsType, MaterialType> materialTable;

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

            charaChipDataModels = new CharaChipDataModel[9];
            for (int i = 0; i < charaChipDataModels.Length; i++)
            {
                charaChipDataModels[i] = new CharaChipDataModel();
            }
            exportSetting = new ExportSetting();
        }

        /// <summary>
        /// マテリアルリストを読み込む。
        /// ディレクトリを探索して、所定のディレクトリにあるファイルをリストする。
        /// </summary>
        /// <param name="directory">ディレクトリ</param>
        /// <returns>リストが構築できた場合にはtrue, それ以外はfalse</returns>
        public bool LoadMatrialList(string directory)
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

            materialDirectory = dir;
            return true;
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
        public Material GetHead(string name)=> Heads.Get(name);

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
        public Material GetBody(string name)=> Bodies.Get(name);

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
        public string MaterialDirectory
        {
            get { return materialDirectory; }
        }

        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting ExportSetting
        {
            get { return exportSetting; }
        }

        /// <summary>
        /// データ数を取得する
        /// </summary>
        public int CharaChipDataCount
        {
            get { return charaChipDataModels.Length; }
        }

        /// <summary>
        /// キャラチップデータを取得する。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CharaChipDataModel GetCharaChipData(int index)
        {
            if ((index < 0) || (index > charaChipDataModels.Length))
            {
                return null;
            }

            return charaChipDataModels[index];
        }
    }
}
