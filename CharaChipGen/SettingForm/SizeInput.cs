using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.SettingForm
{
    public partial class SizeInput : UserControl
    {
        public SizeInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定値
        /// </summary>
        public Size Value {
            get {
                return new Size((int)(numericUpDownWidth.Value),
                    (int)(numericUpDownHeight.Value));
            }
            set {
                if (Value.Equals(value))
                {
                    return;
                }

                int width = GetLimited(value.Width, 
                    (int)(numericUpDownWidth.Minimum), (int)(numericUpDownWidth.Maximum));
                int height = GetLimited(value.Height,
                    (int)(numericUpDownHeight.Minimum), (int)(numericUpDownHeight.Maximum));
                numericUpDownWidth.Value = width;
                numericUpDownHeight.Value = height;
            }
        }

        /// <summary>
        /// 最大値
        /// </summary>
        public Size MaximumValue {
            get {
                return new Size((int)(numericUpDownWidth.Maximum),
                    (int)(numericUpDownHeight.Maximum));
            }
            set {
                if (MaximumValue.Equals(value))
                {
                    return;
                }
                numericUpDownWidth.Maximum = value.Width;
                numericUpDownHeight.Maximum = value.Height;
            }
        }

        /// <summary>
        /// 最小値
        /// </summary>
        public Size MinimumValue {
            get {
                return new Size((int)(numericUpDownWidth.Minimum),
                    (int)(numericUpDownHeight.Minimum));
            }
            set {
                if (MinimumValue.Equals(value))
                {
                    return;
                }
                numericUpDownWidth.Minimum = value.Width;
                numericUpDownHeight.Minimum = value.Height;
            }

        }
        /// <summary>
        /// valueをmin～maxの間に制限した値を取得する。
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="min">下限値</param>
        /// <param name="max">上限値</param>
        /// <returns>制限された値</returns>
        private int GetLimited(int value, int min, int max)
        {
            return (value < min) ? min : ((value > max) ? max : value);
        }
    }
}
