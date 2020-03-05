using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// キャラクターチップのレイヤーを3x4で表示するためのUI。
    /// </summary>
    public partial class MaterialView3x4 : UserControl
    {
        // ピクチャーボックス
        private PictureBox[] pictureBoxes;
        // 表示するイメージ
        private Bitmap image;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MaterialView3x4()
        {
            InitializeComponent();

            pictureBoxes = new PictureBox[]
            {
                pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6,
                pictureBox7, pictureBox8, pictureBox9,
                pictureBox10, pictureBox11, pictureBox12
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
        /// コントロールのサイズが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlResized(object sender, EventArgs evt)
        {
            int pictureBoxWidth = (ClientSize.Width - 8) / 3;
            int pictureBoxHeight = (ClientSize.Height - 10) / 4;

            for (int y = 0; y < 4; y++)
            {
                int ypos = 2 + (2 + pictureBoxHeight) * y;
                for (int x = 0; x < 3; x++)
                {
                    int xpos = 2 + (2 + pictureBoxWidth) * x;
                    pictureBoxes[y * 3 + x].SetBounds(xpos, ypos, pictureBoxWidth, pictureBoxHeight);
                }
            }
        }

        /// <summary>
        /// 背景色を設定する。
        /// </summary>
        public override Color BackColor {
            get { return pictureBox1.BackColor; }
            set {
                pictureBox1.BackColor = value;
                pictureBox2.BackColor = value;
                pictureBox3.BackColor = value;
                pictureBox4.BackColor = value;
                pictureBox5.BackColor = value;
                pictureBox6.BackColor = value;
                pictureBox7.BackColor = value;
                pictureBox8.BackColor = value;
                pictureBox9.BackColor = value;
                pictureBox10.BackColor = value;
                pictureBox11.BackColor = value;
                pictureBox12.BackColor = value;
            }
        }

        /// <summary>
        /// レイヤーの画像データ
        /// </summary>
        public Image Image {
            get { return image; }
            set {
                if (value == null)
                {
                    image = null;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    pictureBox7.Image = null;
                    pictureBox8.Image = null;
                    pictureBox9.Image = null;
                    pictureBox10.Image = null;
                    pictureBox11.Image = null;
                    pictureBox12.Image = null;
                }
                else
                {
                    image = new Bitmap(value);
                    // 必要ならここでPixelFormatを変更する事。
                    UpdateImageView();
                }
            }
        }

        /// <summary>
        /// 3ｘ4ビューのそれぞれに表示されているイメージを取得する。
        /// </summary>
        /// <param name="x">水平方向位置(0<=x<3)</param>
        /// <param name="y">垂直方向位置(0<=y<4)</param>
        /// <returns></returns>
        public Image GetSubImage(int x, int y)
        {
            if ((x < 0) || (x > 2) || (y < 0) || (y > 3))
            {
                return null;
            }
            return pictureBoxes[x + y * 3].Image;
        }

        /// <summary>
        /// 画像表示を更新する。
        /// </summary>
        private void UpdateImageView()
        {
            if (image == null)
            {
                foreach (PictureBox pb in pictureBoxes)
                {
                    pb.Image = null;
                }
            }

            int subImageWidth = image.Width / 3;
            int subImageHeight = image.Height / 4;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Rectangle clipArea = new Rectangle(
                        x * subImageWidth, y * subImageHeight,
                        subImageWidth, subImageHeight);
                    pictureBoxes[x + y * 3].Image
                        = image.Clone(clipArea, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                }
            }
        }
    }
}
