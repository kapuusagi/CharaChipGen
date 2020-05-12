using CGenImaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.ColorEditForm
{
    public partial class ColorEditForm : Form
    {
        // デフォルトタイトル
        private const string DefaultTitle = "Color Selection";

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="defaultColor">デフォルト色</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(Color defaultColor)
            => ShowDialog(null, defaultColor, DefaultTitle);


        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="defaultColor">デフォルト色</param>
        /// <param name="prompt">メッセージ</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(Color defaultColor, string prompt)
            => ShowDialog(null, defaultColor, prompt);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="defaultColor">デフォルト色</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(IWin32Window owner, Color defaultColor)
            => ShowDialog(owner, defaultColor, DefaultTitle);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="defaultColor">デフォルト色</param>
        /// <param name="prompt">メッセージ</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(IWin32Window owner, Color defaultColor, string prompt)
        {
            ColorEditForm form = new ColorEditForm();
            form.Text = prompt;
            form.Color = defaultColor;
            if (owner != null)
            {
                form.ShowDialog(owner);
            }
            else
            {
                form.ShowDialog();
            }

            return (form.DialogResult == DialogResult.OK) ? form.Color : defaultColor;
        }

        private bool isModifing;
        private Color color;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorEditForm()
        {
            isModifing = false;
            color = Color.Black;
            InitializeComponent();
        }

        /// <summary>
        /// 選択されている色
        /// </summary>
        public Color Color {
            get => color;
            set {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => {
                        Color = value;
                    }));
                }
                else
                {
                    color = value;

                    ModelToUI();

                }
            }
        }

        /// <summary>
        /// モデルをUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            isModifing = true;
            try
            {
                numericUpDownR.Value = color.R;
                numericUpDownG.Value = color.G;
                numericUpDownB.Value = color.B;
                numericUpDownA.Value = color.A;

                colorSelectBarR.Value = color.R;
                colorSelectBarG.Value = color.B;
                colorSelectBarB.Value = color.B;
                colorSelectBarA.Value = color.A;

                ColorHSV hsv = CGenImaging.ColorConverter.ConvertRGBtoHSV(color);
                colorHSVSelectView.Hue = hsv.Hue;
                colorHSVSelectView.Saturation = hsv.Saturation;
                colorHSVSelectView.Value = hsv.Value;

                labelSelectedColor.BackColor = color;
            }
            finally
            {
                isModifing = false;
            }
        }

        /// <summary>
        /// OKボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonOKClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 値入力欄の数値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (isModifing)
            {
                return;
            }
            int r = (int)(numericUpDownR.Value);
            int g = (int)(numericUpDownG.Value);
            int b = (int)(numericUpDownB.Value);
            int a = (int)(numericUpDownA.Value);
            color = Color.FromArgb(a, r, g, b);
            labelSelectedColor.BackColor = color;

            try
            {
                isModifing = true;
                colorSelectBarR.Value = r;
                colorSelectBarG.Value = g;
                colorSelectBarB.Value = b;
                colorSelectBarA.Value = a;

                ColorHSV hsv = CGenImaging.ColorConverter.ConvertRGBtoHSV(color);
                colorHSVSelectView.Hue = hsv.Hue;
                colorHSVSelectView.Saturation = hsv.Saturation;
                colorHSVSelectView.Value = hsv.Value;

            }
            finally
            {
                isModifing = false;
            }

        }

        /// <summary>
        /// 色選択バーの選択が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColorSelectBarValueChanged(object sender, EventArgs e)
        {
            if (isModifing)
            {
                return;
            }

            int r = colorSelectBarR.Value;
            int g = colorSelectBarG.Value;
            int b = colorSelectBarB.Value;
            int a = colorSelectBarA.Value;

            color = Color.FromArgb(a, r, g, b);
            labelSelectedColor.BackColor = color;

            try
            {
                isModifing = true;
                numericUpDownR.Value = r;
                numericUpDownG.Value = g;
                numericUpDownB.Value = b;
                numericUpDownA.Value = a;

                ColorHSV hsv = CGenImaging.ColorConverter.ConvertRGBtoHSV(color);
                colorHSVSelectView.Hue = hsv.Hue;
                colorHSVSelectView.Saturation = hsv.Saturation;
                colorHSVSelectView.Value = hsv.Value;
            }
            finally
            {
                isModifing = false;
            }
        }

        /// <summary>
        /// HSV色選択ビューの選択が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColorSLSelectViewValueChanged(object sender, EventArgs e)
        {
            if (isModifing)
            {
                return;
            }

            float h = colorHSVSelectView.Hue;
            float s = colorHSVSelectView.Saturation;
            float v = colorHSVSelectView.Value;
            int a = (int)(numericUpDownA.Value);

            color = CGenImaging.ColorConverter.ConvertHSVtoRGB(ColorHSV.FromHSV(h, s, v), (byte)(a));
            labelSelectedColor.BackColor = color;

            // バーと値入力欄に設定
            try
            {
                isModifing = true;

                numericUpDownR.Value = color.R;
                numericUpDownG.Value = color.G;
                numericUpDownB.Value = color.B;
                numericUpDownA.Value = color.A;

                colorSelectBarR.Value = color.R;
                colorSelectBarG.Value = color.G;
                colorSelectBarB.Value = color.B;
                colorSelectBarA.Value = color.A;
            }
            finally
            {
                isModifing = false;
            }

        }
    }
}
