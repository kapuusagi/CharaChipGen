using CharaChipGen.Model.CharaChip;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    public partial class PartsEditView : UserControl
    {
        // パラメータモデル
        private Parts model;

        /// <summary>
        /// 新しいインスタンスを構築する
        /// </summary>
        public PartsEditView()
        {
            InitializeComponent();
            model = new Parts(PartsType.HairStyle);
            model.PropertyChanged += OnPartsPropertyChanged;

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
                += (s, e) => { model.OffsetY = (int)(numericUpDownYPos.Value); };
            trackBarYPos.ValueChanged
                += (s, e) => { model.OffsetY = trackBarYPos.Value; };
            colorSettingView1.ColorSetting = model.Color1;
            colorSettingView2.ColorSetting = model.Color2;
        }


        /// <summary>
        /// パラメータモデル。
        /// </summary>
        public Parts Parts {
            get { return model; }
            set {
                if ((model == null) || (model == value))
                {
                    // nullまたは同一のオブジェクト
                    return;
                }
                model.PropertyChanged -= OnPartsPropertyChanged;
                model = value;
                model.PropertyChanged += OnPartsPropertyChanged;
                ModelToUI();
            }
        }

        /// <summary>
        /// パラメータが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        private void OnPartsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ModelToUI();
        }

        /// <summary>
        /// モデルの設定値をビューに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            // Note: 全部設定するとコストかかるのが課題か。
            //       データバインディング使った方がいい？

            // Y位置
            trackBarYPos.Value = model.OffsetY;
            numericUpDownYPos.Value = model.OffsetY;

            colorSettingView1.ColorSetting = model.Color1;
            colorSettingView2.ColorSetting = model.Color2;
        }

        /// <summary>
        /// リセットボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonResetClick(object sender, EventArgs e)
        {
            model.OffsetY = 0;
            model.Color1.Reset();
            model.Color2.Reset();
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
            get => colorSettingView1.EditHSV;
            set {
                colorSettingView1.EditHSV = value;
                colorSettingView2.EditHSV = value;
            }
        }
    }
}
