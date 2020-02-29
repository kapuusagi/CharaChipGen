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
    public partial class PartsEditView : UserControl
    {
        // パラメータモデル
        private CharaChipPartsModel model;

        /// <summary>
        /// 新しいインスタンスを構築する
        /// </summary>
        public PartsEditView()
        {
            InitializeComponent();
            model = new CharaChipPartsModel(PartsType.HairStyle);
            model.PropertyChanged += OnModelParameterChanged;

            InitHandlers();
        }

        /// <summary>
        /// イベントハンドラを登録する。
        /// </summary>
        /// <remarks>
        /// デザイナーから登録しても良かったのだが、ハンドラでやることが単純すぎるため
        /// サクッと実装するためにここでやることにした。
        /// </remarks>
        private void InitHandlers()
        {
            numericUpDownYPos.ValueChanged
                += (s, evt) => { model.OffsetY = (int)(numericUpDownYPos.Value); };
            numericUpDownHue.ValueChanged
                += (s, evt) => { model.Hue = (int)(numericUpDownHue.Value); };
            numericUpDownSaturation.ValueChanged
                += (s, evt) => { model.Saturation = (int)(numericUpDownSaturation.Value); };
            numericUpDownValue.ValueChanged
                += (s, evt) => { model.Value = (int)(numericUpDownValue.Value); };
            numericUpDownOpacity.ValueChanged
                += (s, evt) => { model.Opacity = (int)(numericUpDownOpacity.Value); };

            trackBarYPos.ValueChanged
                += (s, evt) => { model.OffsetY = trackBarYPos.Value; };
            trackBarHue.ValueChanged
                += (s, evt) => { model.Hue = trackBarHue.Value; };
            trackBarSaturation.ValueChanged
                += (s, evt) => { model.Saturation = trackBarSaturation.Value; };
            trackBarValue.ValueChanged
                += (s, evt) => { model.Value = trackBarValue.Value; };
            trackBarOpacity.ValueChanged
                += (s, evt) => { model.Opacity = trackBarOpacity.Value; };
        }


        /// <summary>
        /// パラメータモデル。
        /// </summary>
        public CharaChipPartsModel Model {
            get { return model; }
            set {
                if ((model == null) || (model == value))
                {
                    // nullまたは同一のオブジェクト
                    return;
                }
                model.PropertyChanged -= OnModelParameterChanged;
                model = value;
                model.PropertyChanged += OnModelParameterChanged;
                ApplyModelToView();
            }
        }

        /// <summary>
        /// パラメータが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        private void OnModelParameterChanged(object sender, PropertyChangedEventArgs e)
        {
            ApplyModelToView();
        }

        /// <summary>
        /// モデルの設定値をビューに反映させる。
        /// </summary>
        private void ApplyModelToView()
        {
            // Note: 全部設定するとコストかかるのが課題か。
            //       データバインディング使った方がいい？

            // Y位置
            trackBarYPos.Value = model.OffsetY;
            numericUpDownYPos.Value = model.OffsetY;

            // 色相
            trackBarHue.Value = model.Hue;
            numericUpDownHue.Value = model.Hue;

            // 彩度
            trackBarSaturation.Value = model.Saturation;
            numericUpDownSaturation.Value = model.Saturation;

            // 輝度
            trackBarValue.Value = model.Value;
            numericUpDownValue.Value = model.Value;

            // 不当明度
            trackBarOpacity.Value = model.Opacity;
            numericUpDownOpacity.Value = model.Opacity;
        }

        /// <summary>
        /// リセットボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonResetClick(object sender, EventArgs evt)
        {
            model.OffsetY = 0;
            model.Hue = 0;
            model.Saturation = 0;
            model.Value = 0;
            model.Opacity = 100;
        }

        /// <summary>
        /// Yオフセット表示可否
        /// </summary>
        public bool EditYOffset {
            get { return numericUpDownYPos.Visible; }
            set {
                numericUpDownYPos.Visible = value;
                trackBarYPos.Visible = value;
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
