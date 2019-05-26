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

            charaFaceView.SetModel(dataModel);

            paramViewFace.Model = dataModel.Face;
        }

        public CharaChipDataModel CharaChipDataModel
        {
            get { return dataModel; }
            set { value.CopyTo(dataModel); }
        }

        private void InitializeComboBoxItems()
        {
            AppData data = AppData.GetInstance();
            paramViewHead.SetMaterialList(data.Heads);
            paramViewEye.SetMaterialList(data.Eyes);
            paramViewHairStyle.SetMaterialList(data.HairStyles);
            paramViewBody.SetMaterialList(data.Bodies);
            paramViewAccessory1.SetMaterialList(data.Accessories);
            paramViewAccessory2.SetMaterialList(data.Accessories);
            paramViewAccessory3.SetMaterialList(data.Accessories);
            paramViewHeadAccessory1.SetMaterialList(data.HeadAccessories);
            paramViewHeadAccessory2.SetMaterialList(data.HeadAccessories);

            paramViewFace.SetMaterialList(data.Faces);
        }


        private void OnTimerEvent(object sender, EventArgs e)
        {
            charaChipView.UpdateTick();
        }

        private void OnForm_shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void OnForm_closed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void OnCancelButton_clicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOKButton_clicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
