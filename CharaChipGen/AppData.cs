using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CharaChipGen.Model;

namespace CharaChipGen
{
    /// <summary>
    /// アプリケーションデータクラス
    /// </summary>
    class AppData
    {
        public const string NameAccessories = "Accessories";
        public const string NameFrontHairStyles = "FrontHairStyles";
        public const string NameHairStyles = "HairStyles";
        public const string NameEyes = "Eyes";
        public const string NameHeads = "Heads";
        public const string NameBodies = "Bodies";
        public const string NameHeadAccessories = "HeadAccessories";
        public const string NameFaces = "Faces";

        private static AppData instance = new AppData();

        /// <summary>
        /// アプリケーションデータのインスタンスを得る
        /// </summary>
        /// <returns></returns>
        public static AppData GetInstance()
        {
            return instance;
        }

        private MaterialList accessories; // アクセサリ
        private MaterialList frontHairStyles; // 前髪
        private MaterialList hairStyles; // 髪型
        private MaterialList eyes; // 目
        private MaterialList heads; // 頭
        private MaterialList bodies; // 体
        private MaterialList headAccessories; // 頭部アクセサリ
        private MaterialList faces; // 顔
        private string materialDirectory = ""; // 素材ディレクトリ

        private CharaChipDataModel[] charaChipDataModels; //  キャラチップデータモデル
        private ExportSetting exportSetting; // エクスポート設定


        /// <summary>
        /// コンストラクタ
        /// </summary>
        private AppData()
        {
            accessories = new MaterialList("アクセサリ", NameAccessories);
            frontHairStyles = new MaterialList("前髪", NameFrontHairStyles);
            hairStyles = new MaterialList("髪型", NameHairStyles);
            eyes = new MaterialList("目", NameEyes);
            heads = new MaterialList("頭", NameHeads);
            bodies = new MaterialList("体", NameBodies);
            headAccessories = new MaterialList("頭部アクセサリ", NameHeadAccessories);
            faces = new MaterialList("顔", NameFaces);
            charaChipDataModels = new CharaChipDataModel[8];
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

            // アクセサリ
            LoadMaterials(dir, accessories);
            // 前髪
            LoadMaterials(dir, frontHairStyles);
            // 髪型
            LoadMaterials(dir, hairStyles);
            // 目
            LoadMaterials(dir, eyes);
            // 頭
            LoadMaterials(dir, heads);
            // 体
            LoadMaterials(dir, bodies);
            // 頭部アクセサリ
            LoadMaterials(dir, headAccessories);
            // 顔
            LoadMaterials(dir, faces);

            materialDirectory = dir;
            return true;
        }

        /// <summary>
        /// アクセサリ
        /// </summary>
        public MaterialList Accessories
        {
            get { return this.accessories; }
        }
        /// <summary>
        /// アクセサリディレクトリへのパス
        /// </summary>
        public string AccessoryDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.accessories.SubDirectoryName); }
        }
        /// <summary>
        /// アクセサリを取得する。
        /// </summary>
        /// <param name="name">マテリアル名</param>
        /// <returns>マテリアル</returns>
        public Material GetAccessory(string name)
        {
            return accessories.Get(name);
        }


        /// <summary>
        /// 前髪
        /// </summary>
        public MaterialList FrontHairStyles
        {
            get { return this.frontHairStyles; }
        }
        /// <summary>
        /// 前髪ディレクトリへのパス
        /// </summary>
        public string FrontHairStyleDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.frontHairStyles.SubDirectoryName); }
        }
        /// <summary>
        /// 前髪素材を取得する。
        /// </summary>
        /// <param name="name">マテリアル名</param>
        /// <returns>マテリアル</returns>
        public Material GetFrontHairStyle(string name)
        {
            return frontHairStyles.Get(name);
        }

        /// <summary>
        /// 髪
        /// </summary>
        public MaterialList HairStyles
        {
            get { return this.hairStyles; }
        }
        /// <summary>
        /// 髪ディレクトリへのパス
        /// </summary>
        public string HairStyleDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.hairStyles.SubDirectoryName); }
        }
        /// <summary>
        /// 髪素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHairStyle(string name)
        {
            return hairStyles.Get(name);
        }


        /// <summary>
        /// 目
        /// </summary>
        public MaterialList Eyes
        {
            get { return this.eyes; }
        }
        /// <summary>
        /// 目ディレクトリへのパス
        /// </summary>
        public string EyeDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.eyes.SubDirectoryName); }
        }
        /// <summary>
        /// 目素材を取得する。
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetEye(string name)
        {
            return eyes.Get(name);
        }

        /// <summary>
        /// 頭
        /// </summary>
        public MaterialList Heads
        {
            get { return this.heads; }
        }
        /// <summary>
        /// 頭ディレクトリへのパス
        /// </summary>
        public string HeadDirectory
        {
            get { return this.HeadDirectory; }
        }
        /// <summary>
        /// 頭素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHead(string name)
        {
            return heads.Get(name);
        }

        /// <summary>
        /// 体
        /// </summary>
        public MaterialList Bodies
        {
            get { return this.bodies; }
        }
        /// <summary>
        /// 体ディレクトリへのパス
        /// </summary>
        public string BodyDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.bodies.SubDirectoryName); }
        }
        /// <summary>
        /// 体素材を取得する
        /// </summary>
        /// <param name="name">マテリアル名</param>
        /// <returns>マテリアル</returns>
        public Material GetBody(string name)
        {
            return bodies.Get(name);
        }

        /// <summary>
        /// ヘッドアクセサリ
        /// </summary>
        public MaterialList HeadAccessories
        {
            get { return this.headAccessories; }
        }
        /// <summary>
        /// 頭アクセサリディレクトリへのパス
        /// </summary>
        public string HeadAccessoryDirectory
        {
            get { return System.IO.Path.Combine(materialDirectory, this.heads.SubDirectoryName); }
        }
        /// <summary>
        /// ヘッドアクセサリ素材を取得する。
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetHeadAccessory(string name)
        {
            return headAccessories.Get(name);
        }

        /// <summary>
        /// 顔
        /// </summary>
        public MaterialList Faces
        {
            get { return this.faces; }
        }
        /// <summary>
        /// 顔ディレクトリへのパス
        /// </summary>
        public string FaceDirectory
        {
            get { return System.IO.Path.Combine(FaceDirectory, this.faces.SubDirectoryName); }
        }
        /// <summary>
        /// 顔素材を取得する
        /// </summary>
        /// <param name="name">素材名</param>
        /// <returns>マテリアル</returns>
        public Material GetFace(string name)
        {
            return faces.Get(name);
        }

        /// <summary>
        ///  マテリアルリストを保存する
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MaterialList getMaterialList(string name)
        {
            switch (name)
            {
                case AppData.NameAccessories:
                    return this.accessories;
                case AppData.NameBodies:
                    return this.bodies;
                case AppData.NameEyes:
                    return this.eyes;
                case AppData.NameFrontHairStyles:
                    return this.frontHairStyles;
                case AppData.NameHairStyles:
                    return this.hairStyles;
                case AppData.NameHeads:
                    return this.heads;
                case AppData.NameHeadAccessories:
                    return this.headAccessories;
                case AppData.NameFaces:
                    return this.faces;
                default:
                    return null;
            }
        }

        /// <summary>
        /// マテリアルを読み込む
        /// </summary>
        /// <param name="materialDirectory"></param>
        /// <param name="list"></param>
        private static void LoadMaterials(string materialDirectory, MaterialList list)
        {
            string dirPath = System.IO.Path.Combine(materialDirectory, list.SubDirectoryName);
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            list.LoadMaterials(materialDirectory);
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
