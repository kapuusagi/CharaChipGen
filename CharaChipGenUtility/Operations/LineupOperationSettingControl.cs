using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 並べる操作の設定UI
    /// </summary>
    public partial class LineupOperationSettingControl : UserControl
    {
        private LineupOperationSetting model;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public LineupOperationSettingControl()
        {
            InitializeComponent();
            comboBoxDirection.SelectedIndex = 0;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public LineupOperationSetting Model {
            get => model;
            set {
                if ((model == value) || ((model != null) && model.Equals(value)))
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
            controlSelectDirectory.Directory = Model?.OutputDirectory ?? "";
            comboBoxDirection.SelectedIndex = Model?.Direction ?? 0;
        }


        /// <summary>
        /// ディレクトリ選択コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlSelectDirectoryPropertyChanged(object sender,
            PropertyChangedEventArgs evt)
        {
            if (evt.PropertyName.Equals(nameof(SelectDirectoryControl.Directory)))
            {
                if (Model != null)
                {
                    Model.OutputDirectory = controlSelectDirectory.Directory;
                }
            }

        }

        /// <summary>
        /// 方向コンボボックスで選択が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnComboBoxDirectionSelectedIndexChanged(object sender, EventArgs evt)
        {
            if (Model != null)
            {
                Model.Direction = comboBoxDirection.SelectedIndex;
            }
        }
    }
}
