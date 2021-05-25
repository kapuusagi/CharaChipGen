using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using CharaChipGen.Model;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.CharaChip;
using CGenImaging;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラクターチップジェネレータのチップビュー
    /// </summary>
    public partial class CharaChipView : UserControl
    {
        private int viewCounter;

        // アニメーションさせるコントロール
        private CommonControl.ImageViewControl[] animationControls;
        // プレビューコントロール
        private CommonControl.ImageViewControl[,] previewControls;
        // レンダリングデータ
        private CharaChipRenderData renderData;
        // レンダリングデータを書き込むバッファ
        private ImageBuffer imageBuffer;
        // ワークバッファ
        private ImageBuffer workBuffer;
        // レンダリングイメージ
        private Image image;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipView()
        {
            viewCounter = 0;
            renderData = new CharaChipRenderData();
            renderData.ImageChanged += OnImageChanged;

            InitializeComponent();

            animationControls = new CommonControl.ImageViewControl[4]
            {   imageViewControl1_0, imageViewControl2_0, imageViewControl3_0,imageViewControl4_0,};
            previewControls = new CommonControl.ImageViewControl[4, 3]
            {
                { imageViewControl1_1, imageViewControl1_2, imageViewControl1_3 },
                { imageViewControl2_1, imageViewControl2_2, imageViewControl2_3 },
                { imageViewControl3_1, imageViewControl3_2, imageViewControl3_3 },
                { imageViewControl4_1, imageViewControl4_2, imageViewControl4_3 }
            };
        }
        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (image != null))
            {
                foreach (var control in animationControls)
                {
                    control.Image = null;
                }
                foreach (var control in previewControls)
                {
                    control.Image = null;
                }
                image.Dispose();
                image = null;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// レンダリングイメージが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageChanged(object sender, EventArgs e)
        {
            // 再レンダリング
            Size prefSize = renderData.PreferredCharaChipSize;
            if ((prefSize.Width > 0) && (prefSize.Height > 0))
            {
                int imageWidth = prefSize.Width * 3;
                int imageHeight = prefSize.Height * 4;
                if ((imageBuffer == null) || (imageBuffer.Width != imageWidth) || (imageBuffer.Height != imageHeight))
                {
                    imageBuffer = ImageBuffer.Create(imageWidth, imageHeight);
                    workBuffer = ImageBuffer.Create(prefSize.Width, prefSize.Height);
                }

                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        int xoffs = workBuffer.Width * x;
                        int yoffs = workBuffer.Height * y;
                        CharaChipRenderer.Draw(renderData, workBuffer, x, y);
                        imageBuffer.WriteImage(workBuffer, xoffs, yoffs);
                    }
                }

                if (image != null)
                {
                    image.Dispose();
                }
                image = imageBuffer.GetImage();
            }
            else
            {
                imageBuffer = null;
                workBuffer = null;
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }

            ApplyRenderedImage();
        }

        /// <summary>
        /// レンダリングしたイメージを適用する。
        /// </summary>
        private void ApplyRenderedImage()
        { 

            foreach (var control in animationControls)
            {
                control.Image = image;
            }

            int charaChipWidth = (imageBuffer != null) ? imageBuffer.Width / 3 : 0;
            int charaChipHeight = (imageBuffer != null) ? imageBuffer.Height / 4 : 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x< 3; x++)
                {
                    var control = previewControls[y, x];
                    control.Image = image;
                    control.ImageRect = new Rectangle(x * charaChipWidth, y * charaChipHeight, charaChipWidth, charaChipHeight);
                }
            }

            UpdateTick();
        }

        /// <summary>
        /// 更新する。
        /// </summary>
        public void UpdateTick()
        {
            int x;
            int charaChipWidth = (imageBuffer != null) ? imageBuffer.Width / 3 : 0;

            switch (viewCounter)
            {
                case 0: // 左
                    x = 0;
                    break;
                case 1: // 真ん中
                    x = charaChipWidth;
                    break;
                case 2: // 右
                    x = charaChipWidth * 2;
                    break;
                case 3: // 真ん中
                    x = charaChipWidth;
                    break;
                default:
                    x = 0;
                    break;
            }

            int charaChipHeight = (imageBuffer != null) ? imageBuffer.Height / 4 : 0;
            int y = 0;
            for (int i = 0; i < animationControls.Length; i++)
            {
                animationControls[i].ImageRect = new Rectangle(x, y, charaChipWidth, charaChipHeight);
                y += charaChipHeight;
            }

            viewCounter++;
            if (viewCounter >= 4)
            {
                viewCounter = 0;
            }
        }

        /// <summary>
        /// モデルを設定する
        /// </summary>
        /// <param name="model">データモデル</param>
        public void SetCharacter(Character model)
        {
            renderData.Character = model;
        }

        /// <summary>
        /// レンダリングでエラーがあったかどうかを返す。
        /// </summary>
        public bool HasError {
            get {
                return renderData.HasError;
            }
        }

        /// <summary>
        /// エラーの部品を返す。
        /// </summary>
        /// <returns>エラーのパーツ種別</returns>
        /// <remarks>
        /// charaChipViewXXは、全て同じパーツの参照を持っているので、
        /// charaChipView11のエラー部品種別だけ取得すればよい。
        /// </remarks>
        public PartsType[] GetErrorPartsTypes()
        {
            List<PartsType> partsTypes = new List<PartsType>();
            foreach (RenderLayer layer in renderData)
            {
                if ((layer.HasError) && !partsTypes.Contains(layer.PartsType))
                {
                    partsTypes.Add(layer.PartsType);
                }
            }
            return partsTypes.ToArray();
        }

        /// <summary>
        /// 画像表示領域の背景色
        /// </summary>
        public Color ImageBackground {
            get => imageViewControl1_0.BackColor;
            set {
                foreach (var control in animationControls)
                {
                    control.BackColor = value;
                }
                foreach (var control in previewControls)
                {
                    control.BackColor = value;
                }
            }
        }
    }
}
