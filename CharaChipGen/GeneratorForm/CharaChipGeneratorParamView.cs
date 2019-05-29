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
    /// 1つのパラメータを設定するためのUIを提供するクラス。
    /// </summary>
    public partial class CharaChipGeneratorParamView : UserControl
    {
        private const string ItemNoSelect = "<選択なし>";
        private CharaChipParameterModel model; // データを格納するモデル

        private CharaChipParameterModel.ValueChangeHandler handler;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorParamView()
        {
            InitializeComponent();
            model = new CharaChipParameterModel();
            handler = new CharaChipParameterModel.ValueChangeHandler((object sender) =>
            {
                ApplyModelToView();
            });
            model.ValueChanged += handler;
        }

        /// <summary>
        /// 格納しているデータのモデル
        /// </summary>
        public CharaChipParameterModel Model
        {
            get { return model; }
            set
            {
                if ((value == null) || (value == model))
                {
                    return;
                }
                model.ValueChanged -= handler;
                model = value;
                model.ValueChanged += handler;
                
                ApplyModelToView();
            }
        }

        /// <summary>
        /// Yオフセット値の表示可否
        /// </summary>
        public bool EditYOffset
        {
            get { return numericUpDown.Visible; }
            set { numericUpDown.Visible = value; }
        }

        /// <summary>
        /// HSVの表示可否
        /// </summary>
        public bool EditHSV
        {
            get { return trackBarHue.Visible; }
            set
            {
                trackBarHue.Visible = value;
                numericUpDownSaturation.Visible = value;
                numericUpDownValue.Visible = value;
            }
        }

        /// <summary>
        /// モデルの設定値をビューに反映させる。
        /// </summary>
        private void ApplyModelToView()
        {
            if (model.MaterialName == "")
            {
                // 0番目のアイテムは未選択アイテムになる。
                if (comboBoxItem.Items.Count > 0)
                {
                    comboBoxItem.SelectedIndex = 0; // 0は未選択
                }
            }
            else
            { 
                // 何かしらが選択されている
                for (int i = 1; i < comboBoxItem.Items.Count; i++)
                {
                    Material item = (Material)(comboBoxItem.Items[i]);
                    if (item.Name == model.MaterialName)
                    {
                        comboBoxItem.SelectedIndex = i;
                        break;
                    }
                }
            }

            numericUpDown.Value = model.Offset;
            trackBarHue.Value = model.Hue;
            numericUpDownSaturation.Value = model.Saturation;
            numericUpDownValue.Value = model.Value;
            numericUpDownOpacity.Value = model.Opacity;
        }

        /// <summary>
        /// 項目名
        /// </summary>
        public string ParameterName
        {
            get { return labelItemName.Text; }
            set { labelItemName.Text = value; }
        }

        /// <summary>
        /// 選択可能なマテリアルリストを初期化する。
        /// </summary>
        /// <param name="ml"></param>
        public void SetMaterialList(MaterialList ml)
        {
            comboBoxItem.Items.Clear();
            comboBoxItem.Items.Add(ItemNoSelect);
            foreach (Material m in ml)
            {
                comboBoxItem.Items.Add(m);
            }

            comboBoxItem.SelectedIndex = 0; // 未選択状態

            comboBoxItem.Enabled = comboBoxItem.Items.Count > 1;

        }

        /// <summary>
        /// 素材名が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialNameChanged(object sender, EventArgs evt)
        {
            Object selItem = comboBoxItem.SelectedItem;
            if (selItem.ToString() == ItemNoSelect)
            {
                model.MaterialName = "";
            }
            else
            {
                model.MaterialName = (selItem != null) ? selItem.ToString() : "";
            }
        }

        /// <summary>
        /// オフセットが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnOffsetChanged(object sender, EventArgs evt)
        {
            model.Offset = (int)(numericUpDown.Value);
        }

        /// <summary>
        /// 色相が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnHueChanged(object sender, EventArgs evt)
        {
            model.Hue = trackBarHue.Value;
        }

        /// <summary>
        /// 彩度が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnSaturationChanged(object sender, EventArgs evt)
        {
            model.Saturation = (int)(numericUpDownSaturation.Value);
        }

        /// <summary>
        /// 輝度が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnValueChanged(object sender, EventArgs evt)
        {
            model.Value = (int)(numericUpDownValue.Value);
        }

        /// <summary>
        /// リセットボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnResetButtonClicked(object sender, EventArgs evt)
        {
            trackBarHue.Value = 0;
            numericUpDown.Value = 0;
            numericUpDownSaturation.Value = 0;
            numericUpDownValue.Value = 0;
        }

        /// <summary>
        /// 不当明度が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OpacityChanged(object sender, EventArgs evt)
        {
            model.Opacity = (int)(numericUpDownOpacity.Value);
        }
    }
}
