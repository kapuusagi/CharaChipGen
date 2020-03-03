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
                ReloadMaterial();

            }
        }

        /// <summary>
        /// 素材を再読込する。
        /// </summary>
        private void ReloadMaterial()
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
        }

        /// <summary>
        /// フォームを表示する。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            ReloadMaterial();
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
            buttonDeleteLayer.Enabled = (layer != null);
        }
    }
}
