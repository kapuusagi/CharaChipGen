using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageStacker
{
    /// <summary>
    /// 色設定コントロール
    /// </summary>
    public partial class ColorSettingControl : UserControl
    {
        private LayerEntry entry;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorSettingControl()
        {
            entry = null;
            InitializeComponent();
        }

        /// <summary>
        /// 色設定
        /// </summary>
        [Browsable(false)]
        public LayerEntry LayerEntry {
            get => entry;
            set {
                if (entry != null)
                {
                    entry.PropertyChanged -= OnPropertyChanged;
                }
                entry = value;
                if (entry != null)
                {
                    entry.PropertyChanged += OnPropertyChanged;
                }
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
                if (entry != null)
                {
                    trackBarHue.Value = entry.Hue;
                    numericUpDownHue.Value = entry.Hue;

                    trackBarSaturation.Value = entry.Saturation;
                    numericUpDownSaturation.Value = entry.Saturation;

                    trackBarValue.Value = entry.Value;
                    numericUpDownValue.Value = entry.Value;
                    trackBarOpacity.Value = entry.Opacity;
                    numericUpDownOpacity.Value = entry.Opacity;
                }
                else
                {
                    trackBarHue.Value = 0;
                    numericUpDownHue.Value = 0;
                    trackBarSaturation.Value = 0;
                    numericUpDownSaturation.Value = 0;
                    trackBarValue.Value = 0;
                    numericUpDownValue.Value = 0;
                    trackBarOpacity.Value = 0;
                    numericUpDownOpacity.Value = 0;
                }
            }
        }

        /// <summary>
        /// このビューに関連付けられているモデルのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (entry != sender)
            {
                return;
            }
            switch (e.PropertyName)
            {
                case nameof(LayerEntry.Hue):
                    trackBarHue.Value = entry.Hue;
                    numericUpDownHue.Value = entry.Hue;
                    break;
                case nameof(LayerEntry.Saturation):
                    trackBarSaturation.Value = entry.Saturation;
                    numericUpDownSaturation.Value = entry.Saturation;
                    break;
                case nameof(LayerEntry.Value):
                    trackBarValue.Value = entry.Value;
                    numericUpDownValue.Value = entry.Value;
                    break;
                case nameof(LayerEntry.Opacity):
                    trackBarOpacity.Value = entry.Opacity;
                    numericUpDownOpacity.Value = entry.Opacity;
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
            if (entry == null)
            {
                return;
            }
            TrackBar trackBar = (TrackBar)(sender);
            int value = trackBar.Value;
            if (sender == trackBarHue)
            {
                entry.Hue = value;
            }
            else if (sender == trackBarSaturation)
            {
                entry.Saturation = value;
            }
            else if (sender == trackBarValue)
            {
                entry.Value = value;
            }
            else if (sender == trackBarOpacity)
            {
                entry.Opacity = value;
            }
        }

        /// <summary>
        /// 数値入力欄の値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (entry == null)
            {
                return;
            }
            int value = (int)(((NumericUpDown)(sender)).Value);
            if (sender == numericUpDownHue)
            {
                entry.Hue = value;
            }
            else if (sender == numericUpDownSaturation)
            {
                entry.Saturation = value;
            }
            else if (sender == numericUpDownValue)
            {
                entry.Value = value;
            }
            else if (sender == numericUpDownOpacity)
            {
                entry.Opacity = value;
            }
        }

        /// <summary>
        /// HSVの表示可否
        /// </summary>
        public bool EditHSV {
            get { return numericUpDownHue.Visible; }
            set {
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
