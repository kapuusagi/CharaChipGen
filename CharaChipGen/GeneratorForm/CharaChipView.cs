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
        // 表示カウンタ
        private int viewCounter;
        // アニメーションさせるコントロール
        private CommonControl.ImageViewControl[] animationControls;
        // プレビューコントロール
        private CommonControl.ImageViewControl[,] previewControls;
        // レンダリングスレッド
        private CharaChipRenderThread renderThread;
        // 幅(キャッシュ)
        private int charaChipWidth;
        // 高さ(キャッシュ)
        private int charaChipHeight;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipView()
        {
            viewCounter = 0;
            charaChipWidth = 0;
            charaChipHeight = 0;
            renderThread = new CharaChipRenderThread();
            renderThread.Rendered += OnImageChanged;

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
            if (disposing && (renderThread != null))
            {
                foreach (var control in animationControls)
                {
                    control.Image = null;
                }
                foreach (var control in previewControls)
                {
                    control.Image = null;
                }
                renderThread.Dispose();
                renderThread = null;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// レンダリングが完了したときに通知を受け取る。
        /// </summary>
        public event EventHandler ImageRendered;

        /// <summary>
        /// レンダリングイメージが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageChanged(object sender, EventArgs e)
        {
            ImageRendered?.Invoke(this, new EventArgs());
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(ApplyRenderedImage));
            }
            else
            {
                ApplyRenderedImage();
            }
        }

        /// <summary>
        /// レンダリングしたイメージを適用する。
        /// </summary>
        private void ApplyRenderedImage()
        {
            var image = renderThread.RenderedImage;

            charaChipWidth = (image != null) ? image.Width / 3 : 0;
            charaChipHeight = (image != null) ? image.Height / 4 : 0;


            foreach (var control in animationControls)
            {
                control.Image = image;
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x< 3; x++)
                {
                    var control = previewControls[y, x];
                    control.Image = image;
                    control.ImageRect = new Rectangle(x * charaChipWidth, y * charaChipHeight, charaChipWidth, charaChipHeight);
                }
                viewCounter = 1;
            }

            UpdateAnimationRect();
        }

        /// <summary>
        /// 最初に表示されたときの処理を行う。
        /// </summary>
        public void OnShown()
        {
            renderThread.Start();
            timer.Start();
        }

        /// <summary>
        /// 終了するときの処理を行う。
        /// </summary>
        public void OnClosed()
        {
            timer.Stop();
            renderThread.Stop(500);
        }

        /// <summary>
        /// アニメーションするための表示領域を更新する。
        /// viewCounterの値を元に表示領域を更新する。
        /// </summary>
        private void UpdateAnimationRect()
        {
            int x;

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

            int y = 0;
            for (int i = 0; i < animationControls.Length; i++)
            {
                animationControls[i].ImageRect = new Rectangle(x, y, charaChipWidth, charaChipHeight);
                y += charaChipHeight;
            }
        }


        /// <summary>
        /// 更新する。
        /// </summary>
        private void UpdateTick()
        {
            UpdateAnimationRect();
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
            renderThread.RenderData.Character = model;
        }

        /// <summary>
        /// レンダリングでエラーがあったかどうかを返す。
        /// </summary>
        public bool HasError {
            get {
                return renderThread.RenderData.HasError;
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
            foreach (RenderLayer layer in renderThread.RenderData)
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

        /// <summary>
        /// タイマーインターバル処理をする。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateTick();
        }
    }
}
