using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// 色設定コントロール
    /// </summary>
    public partial class ColorSettingView : UserControl
    {
        private ColorSetting colorSetting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorSettingView()
        {
            InitializeComponent();
            colorSetting = new ColorSetting();
        }

        /// <summary>
        /// 色設定
        /// </summary>
        public ColorSetting ColorSetting {
            get => colorSetting;
            set {
                colorSetting.PropertyChanged -= OnColorSettingPropertyChanged;
                colorSetting = value;
                colorSetting.PropertyChanged += OnColorSettingPropertyChanged;
                ModelToUI();
            }
        }

        /// <summary>
        /// モデルをUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(ModelToUI));
            }
            else
            {
                trackBarHue.Value = colorSetting.Hue;
                numericUpDownHue.Value = colorSetting.Hue;

                trackBarSaturation.Value = colorSetting.Saturation;
                numericUpDownSaturation.Value = colorSetting.Saturation;

                trackBarValue.Value = colorSetting.Value;
                numericUpDownValue.Value = colorSetting.Value;
                trackBarOpacity.Value = colorSetting.Opacity;
                numericUpDownOpacity.Value = colorSetting.Opacity;
            }
        }

        /// <summary>
        /// このビューに関連付けられているモデルのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColorSettingPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ColorSetting.Hue):
                    trackBarHue.Value = colorSetting.Hue;
                    numericUpDownHue.Value = colorSetting.Hue;
                    break;
                case nameof(ColorSetting.Saturation):
                    trackBarSaturation.Value = colorSetting.Saturation;
                    numericUpDownSaturation.Value = colorSetting.Saturation;
                    break;
                case nameof(ColorSetting.Value):
                    trackBarValue.Value = colorSetting.Value;
                    numericUpDownValue.Value = colorSetting.Value;
                    break;
                case nameof(ColorSetting.Opacity):
                    trackBarOpacity.Value = colorSetting.Opacity;
                    numericUpDownOpacity.Value = colorSetting.Opacity;
                    break;
            }
        }

        /// <summary>
        /// トラックバーの値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTrackBarValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)(sender);
            int value = trackBar.Value;
            if (sender == trackBarHue)
            {
                colorSetting.Hue = value;
            }
            else if (sender == trackBarSaturation)
            {
                colorSetting.Saturation = value;
            }
            else if (sender == trackBarValue)
            {
                colorSetting.Value = value;
            }
            else if (sender == trackBarOpacity)
            {
                colorSetting.Opacity = value;
            }
        }

        /// <summary>
        /// 数値入力欄の値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            int value = (int)(((NumericUpDown)(sender)).Value);
            if (sender == numericUpDownHue)
            {
                colorSetting.Hue = value;
            }
            else if (sender == numericUpDownSaturation)
            {
                colorSetting.Saturation = value;
            }
            else if (sender == numericUpDownValue)
            {
                colorSetting.Value = value;
            }
            else if (sender == numericUpDownOpacity)
            {
                colorSetting.Opacity = value;
            }
        }

        private bool editHSV = false;

        /// <summary>
        /// HSVの表示可否
        /// </summary>
        public bool EditHSV {
            get => editHSV;
            set {
                editHSV = value;
                numericUpDownHue.Visible = value;
                trackBarHue.Visible = value;
                numericUpDownSaturation.Visible = value;
                trackBarSaturation.Visible = value;
                numericUpDownValue.Visible = value;
                trackBarValue.Visible = value;
            }
        }
    }
}
