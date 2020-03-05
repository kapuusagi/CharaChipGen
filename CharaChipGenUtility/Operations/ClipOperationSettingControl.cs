using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// クリップ領域処理設定UI
    /// </summary>
    public partial class ClipOperationSettingControl : UserControl
    {
        private ClipOperationSetting model;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ClipOperationSettingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public ClipOperationSetting Model {
            get => model;
            set {
                if ((model == value) || ((model != null) && model.Equals(value)))
                {
                    return;
                }

                if (model != null)
                {
                    model.PropertyChanged -= OnPropertyChanged;
                }
                model = value;
                if (model != null)
                {
                    model.PropertyChanged += OnPropertyChanged;
                }
                ModelToUI();
            }
        }

        /// <summary>
        /// プロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ModelToUI();
        }

        /// <summary>
        /// モデルの設定をUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            selectDirectoryControl.Directory = Model.OutputDirectory;

            numericUpDownX.Value = Model.ClipBounds.X;
            numericUpDownY.Value = Model.ClipBounds.Y;
            numericUpDownWidth.Value = Model.ClipBounds.Width;
            numericUpDownHeight.Value = Model.ClipBounds.Height;
        }

        /// <summary>
        /// コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case nameof(selectDirectoryControl.Directory):
                    if (Model != null)
                    {
                        Model.OutputDirectory = selectDirectoryControl.Directory;
                    }
                    break;
            }
        }

        /// <summary>
        /// 数値入力欄の値が変更されたときに通知を受けとる。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs evt)
        {
            if (Model != null)
            {
                Model.ClipBounds = new Rectangle(
                    (int)(numericUpDownX.Value),
                    (int)(numericUpDownY.Value),
                    (int)(numericUpDownWidth.Value),
                    (int)(numericUpDownHeight.Value));
            }
        }
    }
}
