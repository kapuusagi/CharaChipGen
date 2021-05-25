using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGen.Model;
using CharaChipGen.CommonControl;
using CharaChipGen.Model.Material;

namespace CharaChipGen.MaterialViewForm
{
    /// <summary>
    /// 素材のビュー
    /// </summary>
    public partial class MaterialView : UserControl
    {
        // 表示カウンタ
        private int viewCounter;
        // アニメーションコントロール
        private ImageViewControl[] animationControls;
        // プレビューコントロール
        private ImageViewControl[,] previewControls;
        // レンダリングスレッド
        private MaterialRenderThread renderThread;
        // 素材チップ幅
        private int mateChipWidth;
        // 素材チップ高さ
        private int mateChipHeight;

        /// <summary>
        /// 新しいインスタンスを構築する
        /// </summary>
        public MaterialView()
        {
            viewCounter = 0;
            InitializeComponent();
            animationControls = new ImageViewControl[4]
            {
                imageViewControl1_0, imageViewControl2_0, imageViewControl3_0, imageViewControl4_0
            };
            previewControls = new ImageViewControl[4, 3]
            {
                { imageViewControl1_1, imageViewControl1_2, imageViewControl1_3 },
                { imageViewControl2_1, imageViewControl2_2, imageViewControl2_3 },
                { imageViewControl3_1, imageViewControl3_2, imageViewControl3_3 },
                { imageViewControl4_1, imageViewControl4_2, imageViewControl4_3 }
            };

            renderThread = new MaterialRenderThread();
            renderThread.Rendered += OnImageRendered;

        }
        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            renderThread.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (renderThread != null))
            {
                renderThread.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// レンダリングが完了したときに通知を受け取る。
        /// </summary>
        public event EventHandler ImageRendered;

        /// <summary>
        /// コントロールが最初に表示されたときの処理を行う。
        /// </summary>
        public void OnShown()
        {
            renderThread.Start();
            timer.Start();
        }

        /// <summary>
        /// 閉じたときの処理を行う。
        /// </summary>
        public void OnClosed()
        {
            timer.Stop();
            renderThread.Stop();
            renderThread.Dispose();
        }

        /// <summary>
        /// イメージがレンダリングされたときに処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageRendered(object sender, EventArgs e)
        {
            // イメージと矩形領域を設定する。
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(ApplyRenderedImage));
            }
            else
            {
                ApplyRenderedImage();
            }


            ImageRendered?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// レンダリングされたイメージを適用する。
        /// </summary>
        private void ApplyRenderedImage()
        {
            var image = renderThread.RenderedImage;
            mateChipWidth = (image != null) ? image.Width / 3 : 0;
            mateChipHeight = (image != null) ? image.Height / 4 : 0;

            foreach (var control in animationControls)
            {
                control.Image = image;
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    var control = previewControls[y, x];
                    control.Image = image;
                    control.ImageRect = new Rectangle(x * mateChipWidth, y * mateChipHeight, mateChipWidth, mateChipHeight);
                }
                viewCounter = 1;
            }

            UpdateAnimationRect();

        }

        /// <summary>
        /// レンダリングエラーがあったかどうかを得る。
        /// </summary>
        /// <returns>エラーがある場合にはtrue, 無い場合にはfalse</returns>
        public bool HasError
        {
            get => renderThread.RenderData.HasError;
        }

        /// <summary>
        /// タイマーTICKを更新する。
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
        /// アニメーションするための表示領域更新処理を行う。
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
                    x = mateChipWidth;
                    break;
                case 2: // 右
                    x = mateChipWidth * 2;
                    break;
                case 3: // 真ん中
                    x = mateChipWidth;
                    break;
                default:
                    x = 0;
                    break;
            }

            int y = 0;
            for (int i = 0; i < animationControls.Length; i++)
            {
                animationControls[i].ImageRect = new Rectangle(x, y, mateChipWidth, mateChipHeight);
                y += mateChipHeight;
            }
        }

        /// <summary>
        /// 描画する素材を設定する。
        /// </summary>
        /// <param name="material"></param>
        public void SetMaterial(Material material)
        {
            renderThread.RenderData.Material = material;
        }



        /// <summary>
        /// 画像の背景色
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
        /// タイマー処理
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateTick();
        }
    }
}
