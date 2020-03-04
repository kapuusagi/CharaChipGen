using CharaChipGen.Model.Material;
using System;
using System.Windows.Forms;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// 素材エディタ用のUIを提供する。
    /// </summary>
    public partial class MaterialEditorForm : Form
    {
        private MaterialEntryFile entryFile;

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
        public MaterialEntryFile MaterialEntryFile { 
            get => entryFile; 
            set {
                entryFile = value;
                ModelToUI();

            }
        }

        /// <summary>
        /// モデルの設定をUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            textBoxMaterialName.Text = entryFile?.GetDisplayName() ?? "";

            listBoxLayers.Items.Clear();
            if (entryFile != null)
            {
                foreach (var entry in entryFile.Layers)
                {
                    listBoxLayers.Items.Add(entry.Value);
                }
                if (listBoxLayers.Items.Count > 0)
                {
                    listBoxLayers.SelectedIndex = 0;
                }
            }
            buttonRenameLayer.Enabled = (listBoxLayers.SelectedIndex >= 0);
            buttonDeleteLayer.Enabled = (listBoxLayers.SelectedIndex >= 0);

        }

        /// <summary>
        /// フォームを表示する。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            ModelToUI();
        }

        /// <summary>
        /// キャンセルボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
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
            entryFile.SetDisplayName(textBoxMaterialName.Text);

            DialogResult = DialogResult.OK;
            Close();
        }


        /// <summary>
        /// リストボックスの項目を描画する際に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                MaterialLayerInfo item = ((ListBox)(sender)).Items[e.Index] as MaterialLayerInfo;
                using (System.Drawing.Brush brush = new System.Drawing.SolidBrush(e.ForeColor))
                {
                    string text = item.Name;
                    e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// レイヤー削除ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDeleteLayerButtonClicked(object sender, EventArgs e)
        {
            int index = listBoxLayers.SelectedIndex;
            if (index >= 0)
            {
                MaterialLayerInfo sel = (MaterialLayerInfo)(listBoxLayers.SelectedItem);
                listBoxLayers.Items.RemoveAt(listBoxLayers.SelectedIndex);
                entryFile.Layers.Remove(sel.Name);
            }
        }

        /// <summary>
        /// レイヤーリストの選択状態が変化したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersSelectedValueChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)(sender);
            MaterialLayerInfo layer = listBox.SelectedItem as MaterialLayerInfo;
            materialEditorLayerView.Visible = (layer != null);
            if (layer != null)
            {
                materialEditorLayerView.SetLayerInfo(entryFile, layer);
            }
            buttonRenameLayer.Enabled = (layer != null);
            buttonDeleteLayer.Enabled = (layer != null);
        }

        /// <summary>
        /// レイヤー追加ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonAddLayerClick(object sender, EventArgs e)
        {
            string layerName = InputForm.InputForm.ShowDialog(this, "レイヤー名を入力", "入力");
            if (layerName == null)
            {
                return;
            }

            try
            {
                CheckLayerName(layerName);

                // 適用可能
                MaterialLayerInfo layerInfo = new MaterialLayerInfo(layerName);
                entryFile.Layers.Add(layerName, layerInfo);
                listBoxLayers.Items.Add(layerInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// レイヤー名変更ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonRenameLayerClick(object sender, EventArgs e)
        {
            MaterialLayerInfo targetLayerInfo = (MaterialLayerInfo)(listBoxLayers.SelectedItem);
            string layerName = InputForm.InputForm.ShowDialog(this, "レイヤー名を入力", "入力", targetLayerInfo.Name);
            if (layerName == null)
            {
                return;
            }
            // 既に使用済みでないか？
            if (targetLayerInfo.Name.Equals(layerName))
            {
                // 名前変更なし。
                return;
            }

            try
            {
                // 使用不可能な文字が使われていないか？
                CheckLayerName(layerName);

                // 適用可能
                entryFile.Layers.Remove(targetLayerInfo.Name);
                int selIndex = listBoxLayers.SelectedIndex;
                listBoxLayers.Items.RemoveAt(selIndex);

                MaterialLayerInfo layerInfo = new MaterialLayerInfo(layerName) { 
                    Path = targetLayerInfo.Path,
                    LayerType = targetLayerInfo.LayerType,
                    ColorPartsRefs = targetLayerInfo.ColorPartsRefs
                };

                entryFile.Layers.Add(layerName, layerInfo);
                listBoxLayers.Items.Insert(selIndex, layerInfo);

                listBoxLayers.SelectedIndex = selIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// レイヤー名として適当であることを確認する。
        /// 適当でない場合には例外をスルーする。
        /// </summary>
        /// <param name="name">レイヤー名</param>
        private void CheckLayerName(string name)
        {
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            if (MaterialEntryFile.IsValidName(name))
            {
                throw new Exception("レイヤー名として使用できない文字が使用されています。");
            }

            if (entryFile.Layers.ContainsKey(name))
            {
                throw new Exception("既に同名のレイヤーが存在します。");
            }
        }


    }
}
