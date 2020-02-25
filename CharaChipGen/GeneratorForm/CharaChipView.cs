﻿using System;
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
    }
}
