using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// 素材エディタ用のUIを提供する。
    /// </summary>
    public partial class MaterialEditorForm : Form
    {
        private Material editMaterial; // 編集対象の素材

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MaterialEditorForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 編集対象の素材
        /// </summary>
        public Material Material
        {
            get { return editMaterial; }
            set {
                editMaterial = value;
                ReloadMaterial();
            }
        }

        private void ReloadMaterial()
        {
            // マテリアルを読み出す。
            if (editMaterial == null)
            {
                // 新規作成 → マテリアルなし。
                return;
            }

            textBoxMaterialName.Text = editMaterial.Name;

            // プライマリレイヤーを設定する
            materialEditorLayerView1.Image = editMaterial.GetPrimaryLayer();

            // セカンダリレイヤーを設定する
            materialEditorLayerView2.Image = editMaterial.GetSecondaryLayer();
        }

        private void OnForm_shown(object sender, EventArgs e)
        {
            AdjustPosition();
            ReloadMaterial();
        }

        private void OnForm_resied(object sender, EventArgs e)
        {
            AdjustPosition();
        }
        private void AdjustPosition() {
            /**
             * 可変サイズのウィンドウはこれが面倒。
             * DockやAnchor以外にもっといいのがないのか
             */


            // エディットボックスの配置
            int txtBoxX = textBoxMaterialName.Location.X;
            int txtBOxY = textBoxMaterialName.Location.Y;
            int txtBoxWidth = ClientSize.Width - 4 - textBoxMaterialName.Location.X;
            int txtBoxHeight = textBoxMaterialName.Height;
            textBoxMaterialName.SetBounds(txtBoxX, txtBOxY, txtBoxWidth, txtBoxHeight);


            // OK, キャンセルボタンの配置
            int btnOKX = ClientSize.Width - 4 - buttonSave.Width - buttonCancel.Width;
            int btnOKY = ClientSize.Height - 2 - buttonSave.Height;
            buttonSave.SetBounds(btnOKX, btnOKY, buttonSave.Width, buttonSave.Height);
            int btnCancelX = btnOKX + 2 + buttonSave.Width;
            int btnCancelY = btnOKY;
            buttonCancel.SetBounds(btnCancelX, btnCancelY, buttonCancel.Width, buttonCancel.Height);

            // Viewの配置
            int viewX = 4;
            int viewY = materialEditorLayerView1.Location.Y;
            int viewWidth = ClientSize.Width - 8;
            int viewHeight = btnOKY - 2 - viewY;

            int layerView1X = viewX;
            int layerView1Y = materialEditorLayerView2.Location.Y;
            int layerViewWidth = (viewWidth - 120 - 4) / 2;
            int layerViewHeight = viewHeight;
            materialEditorLayerView1.SetBounds(layerView1X, layerView1Y, layerViewWidth, layerViewHeight);

            int layerView2X = viewX + layerViewWidth + 2;
            int layerView2Y = layerView1Y;
            materialEditorLayerView2.SetBounds(layerView2X, layerView2Y, layerViewWidth, layerViewHeight);

            // 操作ボタンなど
            int btnRm2ndLayerX = layerView2X + 4 + materialEditorLayerView2.Width;
            int btnRm2ndLayerY = layerView1Y;
            int btnRm2ndLayerWidth = viewWidth - btnRm2ndLayerX - 2;
            int btnRm2ndLayerHeight = buttonDelete2ndLayer.Height;
            buttonDelete2ndLayer.SetBounds(btnRm2ndLayerX, btnRm2ndLayerY, btnRm2ndLayerWidth, btnRm2ndLayerHeight);

            // プレビュー画面の配置

            int previewX = layerView2X + 4 + materialEditorLayerView2.Width;
            int previewY = layerView1Y + viewHeight - viewHeight / 4;
            int previewWidth = btnRm2ndLayerWidth;
            int previewHeight = viewHeight / 4;
            pictureBoxPreview.SetBounds(previewX, previewY, previewWidth, previewHeight);
        }

        private void OnCancelButton_clicked(object sender, EventArgs e)
        {
            Close();
        }

        private void OnSaveButton_clicked(object sender, EventArgs e)
        {
            /**
             * 保存ボタンが押された場合
             */
            if (textBoxMaterialName.Text.Length == 0)
            {
                MessageBox.Show(this, "素材名が設定されていません。");
                return;
            }


            DialogResult = DialogResult.OK;

            if ((editMaterial == null) || (editMaterial.Name != textBoxMaterialName.Text))
            {
                /* 編集対象のマテリアルが起動時と異なる場合には
                 * 編集対象のマテリアルを新しく構築する。 */
                string subDir = System.IO.Path.GetDirectoryName(editMaterial.Path);
                string fileName = textBoxMaterialName.Text + ".png";
                string filePath = System.IO.Path.Combine(subDir, fileName);

                Material m = new Material(filePath);
                editMaterial = m;
            }
            editMaterial.SetPrimaryLayer(materialEditorLayerView1.Image);
            editMaterial.SetSecondaryLayer(materialEditorLayerView2.Image);

            Close();
        }

        private void OnDelete2ndLayerButton_clicked(object sender, EventArgs e)
        {
            materialEditorLayerView2.Image = null;
        }

        private void OnLayerView_imageChanged(object sender, Image newImage)
        {
            pictureBoxPreview.Image = materialEditorLayerView1.GetSubImage(1, 0);
            pictureBoxPreview.BackgroundImage = materialEditorLayerView2.GetSubImage(1, 0);
        }
    }
}
