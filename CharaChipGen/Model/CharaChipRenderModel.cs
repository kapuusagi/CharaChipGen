using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CharaChipGen.Model.Material;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラチップの設定を元にレンダリングを行い、
    /// レンダリングしたデータを保持するモデル。
    /// </summary>
    /// <remarks>
    /// CharaChipDataModelで指定された各設定をレイヤーに変換するような役割を持つ。
    ///   
    /// </remarks>
    class CharaChipRenderModel
    {
        private CharaChipRenderLayerModel[] layers; // レイヤー
        private CharaChipDataModel dataModel; // レンダリング対象のデータモデル
        private PartsChangeEventHandler partsChangeHandler; // ハンドラ
        public delegate void ImageChanged(Object sender); // ハンドラ
        public event ImageChanged OnImageChanged; // イメージが変更されたときのイベント

        private enum LayerNames {
            EyeFront,
            EyeBack,
            HeadFront,
            HeadBack,
            BodyFront,
            BodyBack,
            HairStyleFront,
            HairStyleBack,
            HeadAccessory1Front,
            HeadAccessory1Back,
            HeadAccessory2Front,
            HeadAccessory2Back,
            Accessory1Front,
            Accessory1Back,
            Accessory2Front,
            Accessory2Back,
            Accessory3Front,
            Accessory3Back
        };
        private LayerNames[] layerOrder = new LayerNames[] {
            LayerNames.Accessory3Front,
            LayerNames.HeadAccessory2Front,
            LayerNames.HeadAccessory1Front,
            LayerNames.EyeFront,
            LayerNames.HeadFront,
            LayerNames.HairStyleFront,
            LayerNames.Accessory2Front,
            LayerNames.Accessory1Front,
            LayerNames.BodyFront,
            LayerNames.EyeBack,
            LayerNames.HeadBack,
            LayerNames.BodyBack,
            LayerNames.HairStyleBack,
            LayerNames.Accessory1Back,
            LayerNames.Accessory2Back,
            LayerNames.HeadAccessory1Back,
            LayerNames.HeadAccessory2Back,
            LayerNames.Accessory3Back
        };

        
        /// <summary>
        /// レンダリング用データモデル
        /// </summary>
        public CharaChipRenderModel()
        {
            layers = new CharaChipRenderLayerModel[layerOrder.Length];
            for (int i = 0; i < layerOrder.Length; i++) {
                layers[i] = new CharaChipRenderLayerModel(layerOrder[i].ToString());
            }
            dataModel = new CharaChipDataModel();
            partsChangeHandler = new PartsChangeEventHandler((sender, e) =>
            {
                ApplySetting(e.PartsType.ToString());
            });

            ApplySettings();
            dataModel.OnCharaChipParamChanged += partsChangeHandler;
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
                dataModel.OnCharaChipParamChanged -= partsChangeHandler;
                dataModel = value;
                dataModel.OnCharaChipParamChanged += partsChangeHandler;

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
        /// バッファをレンダリングするのい最適サイズを取得する。
        /// 1キャラクタをレンダリングするために必要なサイズが返る。
        /// 1キャラクターの1パターンを描画するサイズではないことに注意。
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
                case CharaChipDataModel.ParamNameHair:
                    ApplyHairStyle();
                    break;
                case CharaChipDataModel.ParamNameBody:
                    ApplyBody();
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
            ApplyHairStyle();
            ApplyBody();
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
            var m = AppData.GetInstance().GetHead(dataModel.Head.MaterialName);
            SetLayer(LayerNames.HeadFront, m?.LoadLayerImage(0), dataModel.Head);
            SetLayer(LayerNames.HeadBack, m?.LoadLayerImage(1), dataModel.Head);
            // 頭設定はちょっと複雑。
            // 体のバックレイヤーに輝度色差調整は頭のパラメータを参照する。
            CharaChipRenderLayerModel layer = GetLayer(LayerNames.BodyBack);
            layer.Hue = dataModel.Head.Hue;
            layer.Saturation = dataModel.Head.Saturation;
            layer.Value = dataModel.Head.Value;
            System.Diagnostics.Debug.WriteLine(String.Format("Head = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 目設定を適用する。
        /// </summary>
        private void ApplyEye()
        {
            var m = AppData.GetInstance().GetEye(dataModel.Eye.MaterialName);
            SetLayer(LayerNames.EyeFront, m?.LoadLayerImage(0), dataModel.Eye);
            SetLayer(LayerNames.EyeBack, m?.LoadLayerImage(1), dataModel.Eye);
            System.Diagnostics.Debug.WriteLine(String.Format("Eye = {0}", (m != null) ? m.Name : ""));
        }

        /// <summary>
        /// 髪型設定を適用する。
        /// </summary>
        private void ApplyHairStyle()
        {
            var m = AppData.GetInstance().GetHairStyle(dataModel.Hair.MaterialName);
            SetLayer(LayerNames.HairStyleFront, m?.LoadLayerImage(0), dataModel.Hair);
            SetLayer(LayerNames.HairStyleBack, m?.LoadLayerImage(1), dataModel.Hair);
            System.Diagnostics.Debug.WriteLine(
                String.Format("HairStyle = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 体設定を適用する。
        /// </summary>
        private void ApplyBody()
        {
            var m = AppData.GetInstance().GetBody(dataModel.Body.MaterialName);
            SetLayer(LayerNames.BodyFront, m?.LoadLayerImage(0), dataModel.Body);

            // 体設定はちょっと複雑。
            // オフセットはBodyを採用し、輝度色差調整は頭のパラメータを参照する。
            CharaChipRenderLayerModel layer = GetLayer(LayerNames.BodyBack);
            layer.Image = m?.LoadLayerImage(1);
            layer.OffsetX = 0;
            layer.OffsetY = dataModel.Body.Offset; // オフセットはボディを使用する。
            System.Diagnostics.Debug.WriteLine(String.Format("Body = {0}", (m != null) ? m.Name : ""));
        }


        /// <summary>
        /// アクセサリ1設定を適用する。
        /// </summary>
        private void ApplyAccessory1()
        {
            var m = AppData.GetInstance().GetAccessory(dataModel.Accessory1.MaterialName);
            SetLayer(LayerNames.Accessory1Front, m?.LoadLayerImage(0), dataModel.Accessory1);
            SetLayer(LayerNames.Accessory1Back, m?.LoadLayerImage(1), dataModel.Accessory1);
            System.Diagnostics.Debug.WriteLine(
                String.Format("Accessory1 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// アクセサリ2設定を適用する。
        /// </summary>
        private void ApplyAccessory2()
        {
            var m = AppData.GetInstance().GetAccessory(dataModel.Accessory2.MaterialName);
            SetLayer(LayerNames.Accessory2Front, m?.LoadLayerImage(0), dataModel.Accessory2);
            SetLayer(LayerNames.Accessory2Back, m?.LoadLayerImage(1), dataModel.Accessory2);
            System.Diagnostics.Debug.WriteLine(
                String.Format("Accessory2 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// アクセサリ3設定を適用する。
        /// </summary>
        private void ApplyAccessory3()
        {
            var m = AppData.GetInstance().GetAccessory(dataModel.Accessory3.MaterialName);
            SetLayer(LayerNames.Accessory3Front, m?.LoadLayerImage(0), dataModel.Accessory3);
            SetLayer(LayerNames.Accessory3Back, m?.LoadLayerImage(1), dataModel.Accessory3);
            System.Diagnostics.Debug.WriteLine(
                String.Format("Accessory3 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 頭部アクセサリ1設定を適用する。
        /// </summary>
        private void ApplyHeadAccessory1()
        {
            var m = AppData.GetInstance().GetHeadAccessory(dataModel.HeadAccessory1.MaterialName);
            SetLayer(LayerNames.HeadAccessory1Front, m?.LoadLayerImage(0), dataModel.HeadAccessory1);
            SetLayer(LayerNames.HeadAccessory1Back, m?.LoadLayerImage(0), dataModel.HeadAccessory1);
            System.Diagnostics.Debug.WriteLine(
                String.Format("HeadAccessory1 = {0}", (m != null) ? m.Name : ""));
        }
        /// <summary>
        /// 頭部アクセサリ2設定を適用する。
        /// </summary>
        private void ApplyHeadAccessory2()
        {
            var m = AppData.GetInstance().GetHeadAccessory(dataModel.HeadAccessory2.MaterialName);
            SetLayer(LayerNames.HeadAccessory2Front, m?.LoadLayerImage(0), dataModel.HeadAccessory2);
            SetLayer(LayerNames.HeadAccessory2Back, m?.LoadLayerImage(0), dataModel.HeadAccessory2);
            System.Diagnostics.Debug.WriteLine(
                String.Format("HeadAccessory2 = {0}", (m != null) ? m.Name : ""));
        }

        /// <summary>
        /// レイヤーに設定を適用する。
        /// </summary>
        /// <param name="layer">設定対象のレイヤー</param>
        /// <param name="layerImage">レイヤーに設定する画像</param>
        /// <param name="model">設定値を読み出すモデル</param>
        private void SetLayer(LayerNames layerName, Image layerImage, CharaChipPartsModel model)
        {
            CharaChipRenderLayerModel layer = GetLayer(layerName);
            if (layer == null) {
                throw new NullReferenceException(layerName.ToString() + " not exists.");
            }
            layer.Image = layerImage;
            layer.Hue = model.Hue;
            layer.Saturation = model.Saturation;
            layer.Value = model.Value;
            layer.OffsetX = 0;
            layer.OffsetY = model.Offset;
            layer.Opacity = model.Opacity;
        }

        /// <summary>
        /// nameに一致するレイヤーを取得する。
        /// </summary>
        /// <param name="name">レイヤー名</param>
        /// <returns>レイヤーモデルが返る。見つからない場合にはnullが返る。</returns>
        private CharaChipRenderLayerModel GetLayer(LayerNames name)
        {
            foreach (CharaChipRenderLayerModel layer in layers) {
                if (layer.LayerName.Equals(name.ToString())) {
                    return layer;
                }
            }
            return null;
        }
    }
}
