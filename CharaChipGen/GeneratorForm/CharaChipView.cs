using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラクターチップジェネレータのチップビュー
    /// </summary>
    public partial class CharaChipView : UserControl
    {
        private int viewCounter;

        public CharaChipView()
        {
            viewCounter = 0;
            InitializeComponent();
            AdjustPosition();
        }

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
        public void SetModel(CharaChipDataModel model)
        {
            charaChipView11.SetDataModel(model);
            charaChipView21.SetDataModel(model);
            charaChipView31.SetDataModel(model);
            charaChipView12.SetDataModel(model);
            charaChipView22.SetDataModel(model);
            charaChipView32.SetDataModel(model);
            charaChipView13.SetDataModel(model);
            charaChipView23.SetDataModel(model);
            charaChipView33.SetDataModel(model);
            charaChipView14.SetDataModel(model);
            charaChipView24.SetDataModel(model);
            charaChipView34.SetDataModel(model);
        }

        private void OnView_resized(object sender, EventArgs e)
        {
            AdjustPosition();
        }
        private void AdjustPosition()
        { 
            int inset = 8;
            int margin = 4;
            // リサイズ処理
            int width = (ClientSize.Width - (inset * 2 + 12 + margin * 2)) / 4;
            int height = (ClientSize.Height - (inset * 2 + margin * 4)) / 4;

            int x = inset;
            int y = inset;
            pictureBox1.SetBounds(x, y + (height + margin) * 0, width, height);
            pictureBox2.SetBounds(x, y + (height + margin) * 1, width, height);
            pictureBox3.SetBounds(x, y + (height + margin) * 2, width, height);
            pictureBox4.SetBounds(x, y + (height + margin) * 3, width, height);

            x += (width + 12);

            charaChipView11.SetBounds(x + (width + margin) * 0, y, width, height);
            charaChipView21.SetBounds(x + (width + margin) * 1, y, width, height);
            charaChipView31.SetBounds(x + (width + margin) * 2, y, width, height);

            y += (height + margin);
            charaChipView12.SetBounds(x + (width + margin) * 0, y, width, height);
            charaChipView22.SetBounds(x + (width + margin) * 1, y, width, height);
            charaChipView32.SetBounds(x + (width + margin) * 2, y, width, height);

            y += (height + margin);
            charaChipView13.SetBounds(x + (width + margin) * 0, y, width, height);
            charaChipView23.SetBounds(x + (width + margin) * 1, y, width, height);
            charaChipView33.SetBounds(x + (width + margin) * 2, y, width, height);

            y += (height + margin);
            charaChipView14.SetBounds(x + (width + margin) * 0, y, width, height);
            charaChipView24.SetBounds(x + (width + margin) * 1, y, width, height);
            charaChipView34.SetBounds(x + (width + margin) * 2, y, width, height);
        }
    }
}
