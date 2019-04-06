using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.ExportSettingForm
{
    public partial class ExportSettingForm : Form
    {
        public ExportSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// キャラチップサイズ
        /// </summary>
        public Size CharaChipSize
        {
            get
            {
                int width = (int)(numericUpDownCharaChipWidth.Value);
                int height = (int)(numericUpDownCharaChipHeight.Value);
                return new Size(width, height);
            }
            set
            {
                numericUpDownCharaChipWidth.Value = value.Width;
                numericUpDownCharaChipHeight.Value = value.Height;
            }
        }

        /// <summary>
        /// 顔サイズ
        /// </summary>
        public Size FaceSize
        {
            get
            {
                int width = (int)(numericUpDownFaceWidth.Value);
                int height = (int)(numericUpDownFaceHeight.Value);
                return new Size(width, height);
            }
            set
            {
                numericUpDownFaceWidth.Value = value.Width;
                numericUpDownFaceHeight.Value = value.Height;
            }

        }

        /// <summary>
        /// 2倍のサイズで出力するかどうか
        /// </summary>
        public bool IsExpandTwice 
        {
            get
            {
                return checkBoxRenderTwice.Checked;
            }
            set 
            {
                checkBoxRenderTwice.Checked = value;
            }

        }

        private void OnOKButton_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnCancelButton_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
