using CharaChipGen.Model.CharaChip;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラクターチップジェネレータのチップビュー
    /// </summary>
    public partial class CharaChipView : UserControl
    {
        private int viewCounter;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipView()
        {
            viewCounter = 0;
            InitializeComponent();
        }

        /// <summary>
        /// 更新する。
        /// </summary>
        public void UpdateTick()
        {
            switch (viewCounter)
            {
                case 0:
                    pictureBox1.Image = charaChipView11.GetRenderedImage();
                    pictureBox2.Image = charaChipView12.GetRenderedImage();
                    pictureBox3.Image = charaChipView13.GetRenderedImage();
                    pictureBox4.Image = charaChipView14.GetRenderedImage();
                    break;
                case 1:
                    pictureBox1.Image = charaChipView21.GetRenderedImage();
                    pictureBox2.Image = charaChipView22.GetRenderedImage();
                    pictureBox3.Image = charaChipView23.GetRenderedImage();
                    pictureBox4.Image = charaChipView24.GetRenderedImage();
                    break;
                case 2:
                    pictureBox1.Image = charaChipView31.GetRenderedImage();
                    pictureBox2.Image = charaChipView32.GetRenderedImage();
                    pictureBox3.Image = charaChipView33.GetRenderedImage();
                    pictureBox4.Image = charaChipView34.GetRenderedImage();
                    break;
                case 3:
                    pictureBox1.Image = charaChipView21.GetRenderedImage();
                    pictureBox2.Image = charaChipView22.GetRenderedImage();
                    pictureBox3.Image = charaChipView23.GetRenderedImage();
                    pictureBox4.Image = charaChipView24.GetRenderedImage();
                    break;
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
            charaChipView11.SetCharacter(model);
            charaChipView21.SetCharacter(model);
            charaChipView31.SetCharacter(model);
            charaChipView12.SetCharacter(model);
            charaChipView22.SetCharacter(model);
            charaChipView32.SetCharacter(model);
            charaChipView13.SetCharacter(model);
            charaChipView23.SetCharacter(model);
            charaChipView33.SetCharacter(model);
            charaChipView14.SetCharacter(model);
            charaChipView24.SetCharacter(model);
            charaChipView34.SetCharacter(model);
        }

        /// <summary>
        /// レンダリングでエラーがあったかどうかを返す。
        /// </summary>
        public bool HasError {
            get {
                return charaChipView11.HasError;
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
            => charaChipView11.GetErrorPartsTypes();

        /// <summary>
        /// 画像表示領域の背景色
        /// </summary>
        public Color ImageBackground {
            get => charaChipView11.BackColor; 
            set {
                charaChipView11.BackColor = value;
                charaChipView21.BackColor = value;
                charaChipView31.BackColor = value;
                charaChipView12.BackColor = value;
                charaChipView22.BackColor = value;
                charaChipView32.BackColor = value;
                charaChipView13.BackColor = value;
                charaChipView23.BackColor = value;
                charaChipView33.BackColor = value;
                charaChipView14.BackColor = value;
                charaChipView24.BackColor = value;
                charaChipView34.BackColor = value;

                pictureBox1.BackColor = value;
                pictureBox2.BackColor = value;
                pictureBox3.BackColor = value;
                pictureBox4.BackColor = value;
            }
        }
    }
}
