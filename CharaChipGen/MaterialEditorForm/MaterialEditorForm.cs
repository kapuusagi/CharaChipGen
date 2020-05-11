using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CharaChipGen.Model.Material;
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
                MaterialLayerInfo[] layers = entryFile.Layers.Select((entry) => entry.Value).ToArray();
                listBoxLayers.Items.AddRange(layers);
                if (listBoxLayers.Items.Count > 0)
                {
                    listBoxLayers.SelectedIndex = 0;
                }
            }
            UpdateComponentEnables();

        }

        /// <summary>
        /// 操作ボタンの有効・無効を更新する。
        /// </summary>
        private void UpdateComponentEnables()
        {
            materialEditorLayerView.Enabled = (listBoxLayers.SelectedIndex >= 0);
            buttonRenameLayer.Enabled = (listBoxLayers.SelectedIndex >= 0);
            buttonDeleteLayer.Enabled = (listBoxLayers.SelectedIndex >= 0);
            buttonUpLayer.Enabled = (listBoxLayers.SelectedIndex > 0);
            buttonDownLayer.Enabled = (listBoxLayers.SelectedIndex >= 0)
                && (listBoxLayers.SelectedIndex < (listBoxLayers.Items.Count - 1));
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
            UpdateComponentEnables();
        }

        /// <summary>
        /// レイヤー追加ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonAddLayerClick(object sender, EventArgs e)
        {
            string defaultLayerName = GenerateDefaultLayerName();
            string inputText = InputForm.InputForm.ShowDialog(this, "レイヤー名を入力", "入力", defaultLayerName);
            if (inputText == null)
            {
                return;
            }

            try
            {
                string layerName = inputText.Trim();
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
            string inputText = InputForm.InputForm.ShowDialog(this, "レイヤー名を入力", "入力", targetLayerInfo.Name);
            if (inputText == null)
            {
                return;
            }
            string newLayerName = inputText.Trim();
            // 既に使用済みでないか？
            if (targetLayerInfo.Name.Equals(newLayerName))
            {
                // 名前変更なし。
                return;
            }

            try
            {
                // 使用不可能な文字が使われていないか？
                CheckLayerName(newLayerName);

                // 適用可能
                entryFile.Layers.Remove(targetLayerInfo.Name);
                int selIndex = listBoxLayers.SelectedIndex;
                listBoxLayers.Items.RemoveAt(selIndex);

                MaterialLayerInfo layerInfo = new MaterialLayerInfo(newLayerName)
                {
                    Path = targetLayerInfo.Path,
                    LayerType = targetLayerInfo.LayerType,
                    ColorPartsRefs = targetLayerInfo.ColorPartsRefs
                };

                entryFile.Layers.Add(newLayerName, layerInfo);
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
            if (name.Length == 0)
            {
                throw new Exception("レイヤー名が正しくありません。");
            }
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            if (!MaterialEntryFile.IsValidName(name))
            {
                throw new Exception("レイヤー名として使用できない文字が使用されています。");
            }

            if (entryFile.Layers.ContainsKey(name))
            {
                throw new Exception("既に同名のレイヤーが存在します。");
            }
        }

        /// <summary>
        /// デフォルトレイヤー名を生成して返す。
        /// </summary>
        /// <returns>レイヤー名</returns>
        private string GenerateDefaultLayerName()
        {
            return $"layer{entryFile.Layers.Count.ToString("000")}";
        }

        /// <summary>
        /// 上へ移動ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonUpLayerClick(object sender, EventArgs e)
        {
            try
            {
                ModifyLayerOrder(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 下へ移動ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonDownLayerClick(object sender, EventArgs e)
        {
            try
            {
                ModifyLayerOrder(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }

        }

        /// <summary>
        /// レイヤー順を移動させる。
        /// </summary>
        /// <param name="moveCount">移動数(負数で前に、正数で後に)</param>
        private void ModifyLayerOrder(int moveCount)
        {
            int selectedIndex = listBoxLayers.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }
            int newIndex = selectedIndex + moveCount;
            if ((newIndex == selectedIndex) || (newIndex < 0) || (newIndex >= listBoxLayers.Items.Count))
            {
                // 移動先が範囲外なので移動しない。
                return;
            }

            // 並び替え用に配列取得
            List<MaterialLayerInfo> layers
                = new List<MaterialLayerInfo>(entryFile.Layers.Select((entry) => entry.Value));

            MaterialLayerInfo targetLayer = layers[selectedIndex];
            layers.RemoveAt(selectedIndex);
            layers.Insert(newIndex, targetLayer);

            // Dictionaryを再構築。なんて面倒な！
            entryFile.Layers.Clear();
            listBoxLayers.Items.Clear();
            foreach (MaterialLayerInfo layer in layers)
            {
                entryFile.Layers.Add(layer.Name, layer);
                listBoxLayers.Items.Add(layer);
            }

            listBoxLayers.SelectedIndex = newIndex;
        }

        /// <summary>
        /// レイヤーリストボックスでキーが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Control) == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        ModifyLayerOrder(-1);
                        e.Handled = true;
                        break;
                    case Keys.Down:
                        ModifyLayerOrder(1);
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// プレビューボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonPreviewClick(object sender, EventArgs e)
        {
            Material material = new Material("", entryFile);
            MaterialViewForm.MaterialViewForm form
                = new MaterialViewForm.MaterialViewForm() { 
                    Text = textBoxMaterialName.Text, 
                    Material = material 
                };
            form.ShowDialog(this);
        }

        /// <summary>
        /// D&Dにてドラッグされてきたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// D&Dにて放り込まれた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop, false));

                // ファイルが png ならレイヤーを追加する。
                foreach (string fileName in fileNames)
                {
                    if (fileName.EndsWith(".png"))
                    {
                        AddNewLayer(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// pathで指定されたレイヤー画像を持つレイヤーを追加する。
        /// </summary>
        /// <param name="path">パス</param>
        private void AddNewLayer(string path)
        {
            string layerName = GenerateDefaultLayerName();
            CheckLayerName(layerName);

            // 適用可能
            MaterialLayerInfo layerInfo = new MaterialLayerInfo(layerName);
            string dirStr = System.IO.Path.GetDirectoryName(entryFile.Path) + System.IO.Path.DirectorySeparatorChar;
            if (path.StartsWith(dirStr))
            {
                layerInfo.Path = path.Substring(dirStr.Length);
            }
            else
            {
                layerInfo.Path = path;
            }
            entryFile.Layers.Add(layerName, layerInfo);
            listBoxLayers.Items.Add(layerInfo);
        }
    }
}
