using System;
using System.Drawing;
using System.Windows.Forms;
using CharaChipGen.CommonControl;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// キャラクターチップのレイヤーを3x4で表示するためのUI。
    /// </summary>
    public partial class LayerView3x4 : UserControl
    {
        // ピクチャーボックス
        private ImageViewControl[,] imageViewControls;
        // 表示するイメージ
        private Image image;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LayerView3x4()
        {
            InitializeComponent();

            imageViewControls = new ImageViewControl[4,3]
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
                image.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// レイヤーの画像データ
        /// </summary>
        public Image Image {
            get { return image; }
            set {
                if (image != value)
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                    image = value;
                    // 必要ならここでPixelFormatを変更する事。
                    UpdateImageView();

                }
            }
        }

        /// <summary>
        /// 画像表示を更新する。
        /// </summary>
        private void UpdateImageView()
        {
            int subImageWidth = (image != null) ? image.Width / 3 : 0;
            int subImageHeight = (image != null) ? image.Height / 4 : 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    int xoffs = x * subImageWidth;
                    int yoffs = y * subImageHeight;

                    imageViewControls[y, x].Image = image;
                    imageViewControls[y, x].ImageRect = new Rectangle(xoffs, yoffs, subImageWidth, subImageHeight);
                }
            }
        }

        /// <summary>
        /// 画像の背景色
        /// </summary>
        public Color ImageBackground {
            get => imageViewControl1_1.BackColor;
            set {
                foreach (var control in imageViewControls)
                {
                    control.BackColor = value;
                }
            }
        }
    }
}
