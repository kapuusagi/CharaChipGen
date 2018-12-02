using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラチップのレンダリングデータを保持するモデル。
    /// 
    /// CharaChipDataModelで指定された各設定をレイヤーに変換するような役割を持つ。
    /// 
    /// 対応関係は次のようになっている。
    /// 
    ///   top  [レイヤー]                [対応パラメータ]
    ///   ↑    0.Accessory3-front       アクセサリ3
    ///   ｜    1.Accessory2-front       アクセサリ2
    ///   ｜    2.Accessory1-front       アクセサリ1
    ///   ｜    3.HeadAccessory2-front   ヘッドアクセサリ2
    ///   ｜    4.HeadAccessory1-front   ヘッドアクセサリ1
    ///   ｜    5.FrontHairStyle-front   前髪
    ///   ｜    6.FrontHairStyle-back    前髪
    ///   ｜    7.Eye-front              目
    ///   ｜    8.Eye-back               目
    ///   ｜    9.Head-front             頭
    ///   ｜   10.Head-back              頭
    ///   ｜   11.HairStyle-front        髪型
    ///   ｜   12.Costume-front          衣装
    ///   ｜   13.Body-front             体
    ///   ｜   14.Body-back              頭
    ///   ｜   15.Costume-back           衣装
    ///   ｜   16.HairStyle-back         髪型
    ///   ｜   17.HeadAccessory1-back    ヘッドアクセサリ1
    ///   ｜   18.HeadAccessory2-back    ヘッドアクセサリ2
    ///   ｜   19.Accessory1-back        アクセサリ1
    ///   ｜   20.Accessory2-back        アクセサリ2
    ///   ↓   21.Accessory3-back        アクセサリ3
    ///   bottom
    ///   
    /// </summary>
    class CharaChipRenderModel
    {
        private CharaChipRenderLayerModel[] layers; // レイヤー
        private CharaChipDataModel dataModel; // レンダリング対象のデータモデル
        private CharaChipDataModel.ParamChangeHandler paramChangeHandler; // ハンドラ
        public delegate void ImageChanged(Object sender); // ハンドラ
        public event ImageChanged OnImageChanged; // イメージが変更されたときのイベント

        /// <summary>
        /// レンダリング用データモデル
        /// </summary>
        public CharaChipRenderModel()
        {
            layers = new CharaChipRenderLayerModel[]
            {
                new CharaChipRenderLayerModel("Accessory3-front"), // 0
                new CharaChipRenderLayerModel("Accessory2-front"), // 1
                new CharaChipRenderLayerModel("Accessory1-front"), // 2
                new CharaChipRenderLayerModel("HeadAccessory2-front"), // 3
                new CharaChipRenderLayerModel("HeadAccessory1-front"), // 4
                new CharaChipRenderLayerModel("FrontHairStyle-front"), // 5
                new CharaChipRenderLayerModel("FrontHairStyle-back"), // 6
                new CharaChipRenderLayerModel("Eye-front"), // 7
                new CharaChipRenderLayerModel("Eye-back"), // 8
                new CharaChipRenderLayerModel("Head-front"), // 9
                new CharaChipRenderLayerModel("Head-back"), // 10
                new CharaChipRenderLayerModel("HairStyle-front"), // 11
                new CharaChipRenderLayerModel("Costume-front"), // 12
                new CharaChipRenderLayerModel("Body-front"), // 13
                new CharaChipRenderLayerModel("Body-back"), // 14
                new CharaChipRenderLayerModel("Costume-back"), // 15
                new CharaChipRenderLayerModel("HairStyle-back"), // 16
                new CharaChipRenderLayerModel("HeadAccessory1-back"), // 17
                new CharaChipRenderLayerModel("HeadAccessory2-back"), // 18
                new CharaChipRenderLayerModel("Accessory1-front"), // 19
                new CharaChipRenderLayerModel("Accessory2-front"), // 20
                new CharaChipRenderLayerModel("Accessory3-front"), // 21
            };
            dataModel = new CharaChipDataModel();
            paramChangeHandler = new CharaChipDataModel.ParamChangeHandler((object sender, string name) =>
            {
                ApplySetting(name);
            });

            ApplySettings();
            dataModel.OnCharaChipParamChanged += paramChangeHandler;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public CharaChipDataModel CharaChipDataModel
        {
            get { return dataModel; }
            set
            {
                if ((value == null) || (dataModel == value))
                {
                    return;
                }
                dataModel.OnCharaChipParamChanged -= paramChangeHandler;
                dataModel = value;
                dataModel.OnCharaChipParamChanged += paramChangeHandler;

                ApplySettings();
            }
        }

        /// <summary>
        /// レイヤー数
        /// </summary>
        public int LayerCount
        {
            get { return layers.Length; }
        }
        /// <summary>
        /// 指定レイヤーのデータを取得する。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CharaChipRenderLayerModel GetLayer(int index)
        {
            if ((index < 0) || (index > layers.Length))
            {
                return null;
            }
            return layers[index];
        }

        /// <summary>
        /// 最適サイズを取得する。
        /// 
        /// 1キャラクタを表示するために必要なサイズが返る。
        /// </summary>
        public Size PreferredSize
        {
            get
            {
                int width = 0;
                int height = 0;
                foreach (CharaChipRenderLayerModel layer in layers)
                {
                    if (layer.PreferredWidth > width)
                    {
                        width = layer.PreferredWidth;
                    }
                    if (layer.PreferredHeight > height)
                    {
                        height = layer.PreferredHeight;
                    }
                }
                return new Size(width, height);
            }
        }

        /// <summary>
        /// 推奨される幅
        /// 
        /// 1キャラクタを表示するために必要な幅が返る。
        /// </summary>
        public int PreferredWidth
        {
            get
            {
                return PreferredSize.Width;
            }
        }

        /// <summary>
        /// 推奨される高さ
        /// 
        /// 1キャラクタを表示するために必要な高さが返る。
        /// </summary>
        public int PreferredHeight
        {
            get
            {
                return PreferredSize.Height;
            }
        }

        /// <summary>
        /// 設定を適用する。
        /// </summary>
        /// <param name="name">設定の種類名</param>
        private void ApplySetting(string name)
        {
            switch (name)
            {
                case CharaChipDataModel.ParamNameHead:
                    ApplyHead();
                    break;
                case CharaChipDataModel.ParamNameEye:
                    ApplyEye();
                    break;
                case CharaChipDataModel.ParamNameFrontHair:
                    ApplyFrontHairStyle();
                    break;
                case CharaChipDataModel.ParamNameHair:
                    ApplyHairStyle();
                    break;
                case CharaChipDataModel.ParamNameBody:
                    ApplyBody();
                    break;
                case CharaChipDataModel.ParamNameCostume:
                    ApplyCostume();
                    break;
                case CharaChipDataModel.ParamNameAccessory1:
                    ApplyAccessory1();
                    break;
                case CharaChipDataModel.ParamNameAccessory2:
                    ApplyAccessory2();
                    break;
                case CharaChipDataModel.ParamNameAccessory3:
                    ApplyAccessory3();
                    break;
                case CharaChipDataModel.ParamNameHeadAccessory1:
                    ApplyHeadAccessory1();
                    break;
                case CharaChipDataModel.ParamNameHeadAccessory2:
                    ApplyHeadAccessory2();
                    break;
            }
            OnImageChanged?.Invoke(this);
        }

        /// <summary>
        /// モデルから設定を適用する。
        /// </summary>
        private void ApplySettings()
        {
            ApplyHead();
            ApplyEye();
            ApplyFrontHairStyle();
            ApplyHairStyle();
            ApplyBody();
            ApplyCostume();
            ApplyAccessory1();
            ApplyAccessory2();
            ApplyAccessory3();
            ApplyHeadAccessory1();
            ApplyHeadAccessory2();
        }
        /// <summary>
        /// ヘッド設定を適用する。
        /// </summary>
        private void ApplyHead()
        {
            Material m = AppData.GetInstance().GetHead(dataModel.Head.MaterialName);
            SetLayer(layers[9], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Head);
            SetLayer(layers[10], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Head);
            SetLayer(layers[14], layers[14].Image, dataModel.Head); // 頭の設定値を体に適用。
            System.Diagnostics.Debug.WriteLine(String.Format("Head = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 目設定を適用する。
        /// </summary>
        private void ApplyEye()
        {
            Material m = AppData.GetInstance().GetEye(dataModel.Eye.MaterialName);
            SetLayer(layers[7], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Eye);
            SetLayer(layers[8], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Eye);
            System.Diagnostics.Debug.WriteLine(String.Format("Eye = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 前髪設定を適用する。
        /// </summary>
        private void ApplyFrontHairStyle()
        {
            Material m = AppData.GetInstance().GetHairStyle(dataModel.Hair.MaterialName);
            SetLayer(layers[5], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Hair);
            SetLayer(layers[6], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Hair);
            System.Diagnostics.Debug.WriteLine(String.Format("FrontHairStyle = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 髪型設定を適用する。
        /// </summary>
        private void ApplyHairStyle()
        {
            Material m = AppData.GetInstance().GetHairStyle(dataModel.Hair.MaterialName);
            SetLayer(layers[11], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Hair);
            SetLayer(layers[16], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Hair);
            System.Diagnostics.Debug.WriteLine(String.Format("HairStyle = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 体設定を適用する。
        /// </summary>
        private void ApplyBody()
        {
            Material m = AppData.GetInstance().GetBody(dataModel.Body.MaterialName);
            SetLayer(layers[13], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Body);
            SetLayer(layers[14], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Head); // 頭の設定値を体適用。
            System.Diagnostics.Debug.WriteLine(String.Format("Body = {0}", (m != null) ? m.Name : ""));
        }

        private void ApplyCostume()
        {
            Material m = AppData.GetInstance().GetCostume(dataModel.Costume.MaterialName);
            SetLayer(layers[12], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Costume);
            SetLayer(layers[15], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Costume);
            System.Diagnostics.Debug.WriteLine(String.Format("Costume = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// アクセサリ1設定を適用する。
        /// </summary>
        private void ApplyAccessory1()
        {
            Material m = AppData.GetInstance().GetAccessory(dataModel.Accessory1.MaterialName);
            SetLayer(layers[2], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Accessory1);
            SetLayer(layers[19], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Accessory1);
            System.Diagnostics.Debug.WriteLine(String.Format("Accessory1 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// アクセサリ2設定を適用する。
        /// </summary>
        private void ApplyAccessory2()
        {
            Material m = AppData.GetInstance().GetAccessory(dataModel.Accessory2.MaterialName);
            SetLayer(layers[1], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Accessory2);
            SetLayer(layers[20], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Accessory2);
            System.Diagnostics.Debug.WriteLine(String.Format("Accessory2 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// アクセサリ3設定を適用する。
        /// </summary>
        private void ApplyAccessory3()
        {
            Material m = AppData.GetInstance().GetAccessory(dataModel.Accessory3.MaterialName);
            SetLayer(layers[0], (m != null) ? m.GetPrimaryLayer() : null, dataModel.Accessory3);
            SetLayer(layers[21], (m != null) ? m.GetSecondaryLayer() : null, dataModel.Accessory3);
            System.Diagnostics.Debug.WriteLine(String.Format("Accessory3 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 頭部アクセサリ1設定を適用する。
        /// </summary>
        private void ApplyHeadAccessory1()
        {
            Material m = AppData.GetInstance().GetHeadAccessory(dataModel.HeadAccessory1.MaterialName);
            SetLayer(layers[4], (m != null) ? m.GetPrimaryLayer() : null, dataModel.HeadAccessory1);
            SetLayer(layers[17], (m != null) ? m.GetPrimaryLayer() : null, dataModel.HeadAccessory1);
            System.Diagnostics.Debug.WriteLine(String.Format("HeadAccessory1 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 頭部アクセサリ2設定を適用する。
        /// </summary>
        private void ApplyHeadAccessory2()
        {
            Material m = AppData.GetInstance().GetHeadAccessory(dataModel.HeadAccessory2.MaterialName);
            SetLayer(layers[3], (m != null) ? m.GetPrimaryLayer() : null, dataModel.HeadAccessory2);
            SetLayer(layers[18], (m != null) ? m.GetPrimaryLayer() : null, dataModel.HeadAccessory2);
            System.Diagnostics.Debug.WriteLine(String.Format("HeadAccessory2 = {0}", (m != null) ? m.Name : ""));
        }

        /// <summary>
        /// レイヤーに設定を適用する。
        /// </summary>
        /// <param name="layer">設定対象のレイヤー</param>
        /// <param name="layerImage">レイヤーに設定する画像</param>
        /// <param name="model">設定値を読み出すモデル</param>
        private static void SetLayer(CharaChipRenderLayerModel layer, Image layerImage, CharaChipParameterModel model)
        {
            layer.Image = layerImage;
            layer.Hue = model.Hue;
            layer.Saturation = model.Saturation;
            layer.Value = model.Value;
            layer.OffsetX = 0;
            layer.OffsetY = model.Offset;
        }
    }
}
