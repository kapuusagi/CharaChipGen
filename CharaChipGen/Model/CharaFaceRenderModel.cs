using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CGenImaging;

namespace CharaChipGen.Model
{
    /// <summary>
    /// フェイスデータをレンダリングする際のレンダリングデータを保持するモデル。
    /// 
    ///   top  [レイヤー]     [対応パラメータ]
    ///   ↑
    ///   ｜   0.Face-front   顔
    ///   ｜   1.Face-back    <なし>
    ///   ↓
    ///   bottom
    /// 
    /// </summary>
    class CharaFaceRenderModel
    {
        private CharaFaceRenderLayerModel[] layers; // レイヤーデータ
        private CharaChipDataModel dataModel; // キャラデータモデル
        private EventHandler paramChangeHandler; // ハンドラ
        public delegate void ImageChanged(Object sender); // ハンドラ
        public event ImageChanged OnImageChanged; // イメージが変更されたときのイベント

        public CharaFaceRenderModel()
        {
            layers = new CharaFaceRenderLayerModel[]
            {
                new CharaFaceRenderLayerModel("Face-front"),
                new CharaFaceRenderLayerModel("Face-back")
            };
            dataModel = new CharaChipDataModel();
            paramChangeHandler = new EventHandler((sender, e) =>
            {
                ApplySetting("Face");
            });
            ApplySettings();
            dataModel.OnFaceParamChanged += paramChangeHandler;
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
                dataModel.OnFaceParamChanged -= paramChangeHandler;
                dataModel = value;
                dataModel.OnFaceParamChanged += paramChangeHandler;

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
        /// <param name="index">インデックス番号</param>
        /// <returns></returns>
        public CharaFaceRenderLayerModel GetLayer(int index)
        {
            if ((index < 0) || (index > layers.Length))
            {
                return null;
            }
            return layers[index];
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
                int width = 0;
                foreach (CharaFaceRenderLayerModel layer in layers)
                {
                    if (layer.PreferredWidth > width)
                    {
                        width = layer.PreferredWidth;
                    }
                }

                return width;
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
                int height = 0;
                foreach (CharaFaceRenderLayerModel layer in layers)
                {
                    if (layer.PreferredHeight > height)
                    {
                        height = layer.PreferredHeight;
                    }
                }

                return height;
            }
        }

        /// <summary>
        /// 設定を適用する
        /// </summary>
        /// <param name="name">設定名</param>
        private void ApplySetting(string name)
        {
            switch (name)
            {
                case CharaChipDataModel.ParamNameFace:
                    ApplyFace();
                    break;
            }
            OnImageChanged?.Invoke(this);
        }

        /// <summary>
        /// モデルから設定を適用する。
        /// </summary>
        private void ApplySettings()
        {
            ApplyFace();
        }

        /// <summary>
        /// 顔設定を適用する。
        /// </summary>
        private void ApplyFace()
        {
            var m = AppData.GetInstance().GetFace(dataModel.Face.MaterialName);
            SetLayer(layers[0], m?.LoadLayerImage(0), dataModel.Face);
            SetLayer(layers[1], m?.LoadLayerImage(1), null);
            System.Diagnostics.Debug.WriteLine(String.Format("Face = {0}", (m != null) ? m.Name : ""));
        }

        /// <summary>
        /// レイヤーに設定を適用する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="layerImage">レイヤーに設定するイメージ</param>
        /// <param name="model">設定値を読み出すモデル</param>
        private static void SetLayer(CharaFaceRenderLayerModel layer, Image layerImage, CharaChipParameterModel model)
        {
            layer.Image = layerImage;
            layer.Hue = (model != null) ? model.Hue : 0;
            layer.Saturation = (model != null) ? model.Saturation : 0;
            layer.Value = (model != null) ? model.Value : 0;
        }

    }
}
