using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 単色化処理設定用コントロール
    /// </summary>
    public partial class MonoColorOperationSettingControl : UserControl
    {
        private MonoColorOperationSetting model;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MonoColorOperationSettingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public MonoColorOperationSetting Model {
            get => model;
            set {
                if ((model == value) || ((model != null) && (model.Equals(value))))
                {
                    return;
                }

                if (model != null)
                {
                    model.PropertyChanged -= OnModelPropertyChanged;
                }
                model = value;
                if (model != null)
                {
                    model.PropertyChanged += OnModelPropertyChanged;
                }
                ModelToUI();
            }
        }

        /// <summary>
        /// モデルのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ModelToUI();
        }

        /// <summary>
        /// モデルの設定をUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            selectDirectoryControl.Directory = Model?.OutputDirectory ?? "";
            textBoxColor.BackColor = Model?.Color ?? Color.Black;
        }


        /// <summary>
        /// コントロールのプロパティが変更された時に通知を受け取る。
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
        /// 色選択ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnSelectColorButtonClick(object sender, EventArgs evt)
        {
            colorDialog.Color = textBoxColor.BackColor;
            if (colorDialog.ShowDialog(FindForm()) != DialogResult.OK)
            {
                return;
            }

            textBoxColor.BackColor = colorDialog.Color;
            if (Model != null)
            {
                Model.Color = colorDialog.Color;
            }
        }
    }
}
