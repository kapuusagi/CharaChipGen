using System.ComponentModel;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// ImageOperationSettingを設定するためのUI。
    /// </summary>
    public partial class ImageOperationSettingControl : UserControl
    {
        private ImageOperationSetting model;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ImageOperationSettingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public ImageOperationSetting Model {
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
        /// モデルをUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            selectDirectoryControl.Directory = model?.OutputDirectory ?? "";
        }



        /// <summary>
        /// ディレクトリ選択コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnSelectDirectoryControlPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(selectDirectoryControl.Directory)))
            {
                if (Model != null)
                {
                    Model.OutputDirectory = selectDirectoryControl.Directory;
                }
            }
        }
    }
}
