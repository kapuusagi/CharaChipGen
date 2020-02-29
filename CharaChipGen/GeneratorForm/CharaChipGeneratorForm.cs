using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラチップ生成フォーム
    /// </summary>
    public partial class CharaChipGeneratorForm : Form
    {
        private CharaChipDataModel dataModel; // キャラクターチップデータモデル

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorForm()
        {
            dataModel = new CharaChipDataModel();
            InitializeComponent();
            InitializeComboBoxItems();

            charaChipView.SetModel(dataModel);

            paramViewHead.Model = dataModel.Head;
            paramViewEye.Model = dataModel.Eye;
            paramViewHairStyle.Model = dataModel.Hair;
            paramViewBody.Model = dataModel.Body;
            paramViewAccessory1.Model = dataModel.Accessory1;
            paramViewAccessory2.Model = dataModel.Accessory2;
            paramViewAccessory3.Model = dataModel.Accessory3;
            paramViewHeadAccessory1.Model = dataModel.HeadAccessory1;
            paramViewHeadAccessory2.Model = dataModel.HeadAccessory2;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public CharaChipDataModel CharaChipDataModel
        {
            get { return dataModel; }
            set { value.CopyTo(dataModel); }
        }

        /// <summary>
        /// コンボボックスの項目を初期化する。
        /// </summary>
        private void InitializeComboBoxItems()
        {
            AppData data = AppData.Instance;
            paramViewHead.SetMaterialList(data.Heads);
            paramViewEye.SetMaterialList(data.Eyes);
            paramViewHairStyle.SetMaterialList(data.HairStyles);
            paramViewBody.SetMaterialList(data.Bodies);
            paramViewAccessory1.SetMaterialList(data.Accessories);
            paramViewAccessory2.SetMaterialList(data.Accessories);
            paramViewAccessory3.SetMaterialList(data.Accessories);
            paramViewHeadAccessory1.SetMaterialList(data.HeadAccessories);
            paramViewHeadAccessory2.SetMaterialList(data.HeadAccessories);
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
