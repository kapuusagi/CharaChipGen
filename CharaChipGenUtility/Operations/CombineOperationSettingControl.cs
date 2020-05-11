using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 結合処理設定コントロール
    /// </summary>
    public partial class CombineOperationSettingControl : UserControl
    {
        /// <summary>
        /// データモデル
        /// </summary>
        private CombineOperationSetting model;
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CombineOperationSettingControl()
        {
            model = null;
            InitializeComponent();
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public CombineOperationSetting Model {
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
        /// プロパティが変更されたときに通知を受け取る。
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
            numericUpDownH.Value = Model?.HorizontalCount ?? 1;
            numericUpDownV.Value = Model?.VerticalCount ?? 1;
        }

        /// <summary>
        /// 水平カウント欄の値が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownHValueChanged(object sender, EventArgs e)
        {
            if (Model != null)
            {
                Model.HorizontalCount = (int)(numericUpDownH.Value);
            }
        }

        /// <summary>
        /// 垂直カウント欄の値が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownVValueChanged(object sender, EventArgs e)
        {
            if (Model != null)
            {
                Model.VerticalCount = (int)(numericUpDownV.Value);
            }
        }

        /// <summary>
        /// フォルダ選択コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <remarks>
        /// 関数名長い。
        /// </remarks>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnControlSelectDirectoryPropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(SelectDirectoryControl.Directory)))
            {
                if (Model != null)
                {
                    Model.OutputDirectory = controlSelectDirectory.Directory;
                }
            }
        }
    }
}
