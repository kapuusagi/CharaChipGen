using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model.Material;

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
        public Material Material {
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

            textBoxMaterialName.Text = editMaterial.GetDisplayName();

            // プライマリレイヤーを設定する
            materialEditorLayerView1.Image = editMaterial.LoadLayerImage(0);

            // セカンダリレイヤーを設定する
            materialEditorLayerView2.Image = editMaterial.LoadLayerImage(1);
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            ReloadMaterial();
        }

        private void OnForm_resied(object sender, EventArgs e)
        {
        }


        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Saveボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (textBoxMaterialName.Text.Length == 0)
            {
                MessageBox.Show(this, "素材名が設定されていません。");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    
        /// <summary>
        /// 素材の変更を適用する。
        /// </summary>
        public void ApplyMaterialEdit()
        { 
            string materialDir = AppData.GetInstance().MaterialDirectory;
            string dir = System.IO.Path.Combine(materialDir, editMaterial.Path);

            editMaterial.SetDisplayName(textBoxMaterialName.Text);

            // 各イメージを保存する。
            string baseName = System.IO.Path.GetFileNameWithoutExtension(editMaterial.Path);
            if (materialEditorLayerView1.Image != null)
            {
                if (string.IsNullOrEmpty(editMaterial.Layers[0].Path))
                {
                    editMaterial.Layers[0].Path = $"{baseName}_primary.png";
                }
                string path = System.IO.Path.Combine(dir, editMaterial.Layers[0].Path);
                materialEditorLayerView1.Image.Save(path);
            }
            else
            {
                editMaterial.Layers[0].Path = null;
            }

            if (materialEditorLayerView2.Image != null)
            {
                if (string.IsNullOrEmpty(editMaterial.Layers[1].Path))
                {
                    editMaterial.Layers[1].Path = $"{baseName}_primary.png";
                }
                string path = System.IO.Path.Combine(dir, editMaterial.Layers[1].Path);
                materialEditorLayerView2.Image.Save(path);
            }
            else
            {
                editMaterial.Layers[0].Path = null;
            }

        }

        private void OnDelete2ndLayerButtonClicked(object sender, EventArgs e)
        {
            materialEditorLayerView2.Image = null;
        }

        /// <summary>
        /// レイヤービューの画像が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="newImage">新しい画像データ</param>
        private void OnLayerViewImageChanged(object sender, Image newImage)
        {
            pictureBoxPreview.Image = materialEditorLayerView1.GetSubImage(1, 0);
            pictureBoxPreview.BackgroundImage = materialEditorLayerView2.GetSubImage(1, 0);
        }
    }
}
