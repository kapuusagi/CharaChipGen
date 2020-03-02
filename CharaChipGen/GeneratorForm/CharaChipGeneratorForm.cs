using CharaChipGen.Model.CharaChip;
using System;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラチップ生成フォーム
    /// </summary>
    public partial class CharaChipGeneratorForm : Form
    {
        private Character dataModel; // キャラクターチップデータモデル

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorForm()
        {
            dataModel = new Character();
            InitializeComponent();
            InitializeComboBoxItems();

            charaChipView.SetModel(dataModel);

            partsViewHead.Model = dataModel.Head;
            partsViewEye.Model = dataModel.Eye;
            partsViewHairStyle.Model = dataModel.Hair;
            partsViewBody.Model = dataModel.Body;
            partsViewAccessory1.Model = dataModel.Accessory1;
            partsViewAccessory2.Model = dataModel.Accessory2;
            partsViewAccessory3.Model = dataModel.Accessory3;
            partsViewHeadAccessory1.Model = dataModel.HeadAccessory1;
            partsViewHeadAccessory2.Model = dataModel.HeadAccessory2;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public Character CharaChipDataModel {
            get { return dataModel; }
            set { value.CopyTo(dataModel); }
        }

        /// <summary>
        /// コンボボックスの項目を初期化する。
        /// </summary>
        private void InitializeComboBoxItems()
        {
            AppData data = AppData.Instance;
            partsViewHead.SetMaterialList(data.Heads);
            partsViewEye.SetMaterialList(data.Eyes);
            partsViewHairStyle.SetMaterialList(data.HairStyles);
            partsViewBody.SetMaterialList(data.Bodies);
            partsViewAccessory1.SetMaterialList(data.Accessories);
            partsViewAccessory2.SetMaterialList(data.Accessories);
            partsViewAccessory3.SetMaterialList(data.Accessories);
            partsViewHeadAccessory1.SetMaterialList(data.HeadAccessories);
            partsViewHeadAccessory2.SetMaterialList(data.HeadAccessories);
        }

        /// <summary>
        /// タイマーイベントの通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTimerEvent(object sender, EventArgs e)
        {
            charaChipView.UpdateTick();
        }

        /// <summary>
        /// フォームが最初に表示された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// フォームが閉じられた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// キャンセルボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// OKボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnOKButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
