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

namespace CharaChipGen.MaterialViewForm
{
    /// <summary>
    /// 素材のビュー
    /// </summary>
    public partial class MaterialView : UserControl
    {
        private int viewCounter;
        /// <summary>
        /// 新しいインスタンスを構築する
        /// </summary>
        public MaterialView()
        {
            viewCounter = 0;
            InitializeComponent();
        }

        public void UpdateTick()
        {
            switch (viewCounter)
            {
                case 0:
                    pictureBox1.Image = materialView11.GetRenderedImage();
                    pictureBox2.Image = materialView12.GetRenderedImage();
                    pictureBox3.Image = materialView13.GetRenderedImage();
                    pictureBox4.Image = materialView14.GetRenderedImage();
                    break;
                case 1:
                    pictureBox1.Image = materialView21.GetRenderedImage();
                    pictureBox2.Image = materialView22.GetRenderedImage();
                    pictureBox3.Image = materialView23.GetRenderedImage();
                    pictureBox4.Image = materialView24.GetRenderedImage();
                    break;
                case 2:
                    pictureBox1.Image = materialView31.GetRenderedImage();
                    pictureBox2.Image = materialView32.GetRenderedImage();
                    pictureBox3.Image = materialView33.GetRenderedImage();
                    pictureBox4.Image = materialView34.GetRenderedImage();
                    break;
                case 3:
                    pictureBox1.Image = materialView21.GetRenderedImage();
                    pictureBox2.Image = materialView22.GetRenderedImage();
                    pictureBox3.Image = materialView23.GetRenderedImage();
                    pictureBox4.Image = materialView24.GetRenderedImage();
                    break;
            }
            viewCounter++;
            if (viewCounter >= 4)
            {
                viewCounter = 0;
            }
        }

        /// <summary>
        /// 描画するデータ
        /// </summary>
        [Browsable(false)]
        public MaterialRenderData MaterialRenderData {
            get => materialView11.MaterialRenderData;
            set {
                materialView11.MaterialRenderData = value;
                materialView21.MaterialRenderData = value;
                materialView31.MaterialRenderData = value;
                materialView12.MaterialRenderData = value;
                materialView22.MaterialRenderData = value;
                materialView32.MaterialRenderData = value;
                materialView13.MaterialRenderData = value;
                materialView23.MaterialRenderData = value;
                materialView33.MaterialRenderData = value;
                materialView14.MaterialRenderData = value;
                materialView24.MaterialRenderData = value;
                materialView34.MaterialRenderData = value;
            }
        }
    }
}
