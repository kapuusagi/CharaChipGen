using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CharaChipGen.Model.Material;
using CharaChipGen.Model.CharaChip;
using CharaChipGen.Properties;
using System.Drawing;
using CharaChipGen.Model;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// 素材エディタ用のUIを提供する。
    /// </summary>
    public partial class MaterialEditorForm : Form
    {
        // 対象のエントリファイル
        private MaterialEntryFile entryFile;
        // リストビューのキーショットカット
        private List<KeyActionEntry> listViewActions = new List<KeyActionEntry>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MaterialEditorForm()
        {
            InitializeComponent();
            materialEditorLayerView.ImageBackground = Properties.Settings.Default.ImageBackground;
            Settings.Default.PropertyChanged += OnSettingsPropertyChanged;
            DialogResult = DialogResult.Cancel;
            listViewActions.Add(new KeyActionEntry(Keys.Up, Keys.Shift, () => ModifyLayerOrder(-1)));
            listViewActions.Add(new KeyActionEntry(Keys.Down, Keys.Shift, () => ModifyLayerOrder(1)));
            listViewActions.Add(new KeyActionEntry(Keys.Delete, Keys.Control, () => ProcessDeleteLayer()));
            listViewActions.Add(new KeyActionEntry(Keys.F2, Keys.None, () => ProcessRenameLayer()));
            listViewActions.Add(new KeyActionEntry(Keys.N, Keys.Control, () => ProcessAddLayer()));
            listViewActions.Add(new KeyActionEntry(Keys.P, Keys.Control, () => ProcessShowMaterialPreview()));
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
            => ProcessCancel();

        /// <summary>
        /// キャンセル処理してウィンドウを閉じる。
        /// </summary>
        private void ProcessCancel()
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
            ProcessSave();
        }

        /// <summary>
        /// 保存処理をしてウィンドウを閉じる
        /// </summary>
        private void ProcessSave()
        {
            if (textBoxMaterialName.Text.Length == 0)
            {
                MessageBox.Show(this, Resources.MessageMaterialNameNotSpecified);
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
            try
            {
                ProcessDeleteLayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// レイヤーの削除処理をする。
        /// </summary>
        private void ProcessDeleteLayer()
        {
            int index = listBoxLayers.SelectedIndex;
            if (index >= 0)
            {
                MaterialLayerInfo sel = (MaterialLayerInfo)(listBoxLayers.SelectedItem);
                listBoxLayers.Items.RemoveAt(listBoxLayers.SelectedIndex);
                entryFile.Layers.Remove(sel.Name);
                if (index < listBoxLayers.Items.Count)
                {
                    listBoxLayers.SelectedIndex = index; // 次を選択。
                }
                else
                {
                    listBoxLayers.SelectedIndex = listBoxLayers.Items.Count - 1; // 最後尾を選択
                }
            }
        }

        /// <summary>
        /// レイヤーリストの選択状態が変化したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersSelectedValueChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            var layer = listBox.SelectedItem as MaterialLayerInfo;
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
            try
            {
                ProcessAddLayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// レイヤーの追加処理を行う。
        /// </summary>
        private void ProcessAddLayer()
        { 
            string defaultLayerName = GenerateDefaultLayerName();
            string inputText = InputForm.InputForm.ShowDialog(this, Resources.MessageInputLayerName, 
                Resources.DialogTitleInput, defaultLayerName);
            if (inputText == null)
            {
                return;
            }


            string layerName = inputText.Trim();
            CheckLayerName(layerName);

            // 適用可能
            MaterialLayerInfo layerInfo = new MaterialLayerInfo(layerName);
            entryFile.Layers.Add(layerName, layerInfo);
            listBoxLayers.Items.Add(layerInfo);
        }

        /// <summary>
        /// レイヤー名変更ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonRenameLayerClick(object sender, EventArgs e)
        {
            try
            {
                ProcessRenameLayer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }
        /// <summary>
        /// レイヤーリネーム処理を行う。
        /// </summary>
        private void ProcessRenameLayer()
        {
            var targetLayerInfo = listBoxLayers.SelectedItem as MaterialLayerInfo;
            if (targetLayerInfo == null)
            {
                return;
            }
            string inputText = InputForm.InputForm.ShowDialog(this, Resources.MessageInputLayerName,
                Resources.DialogTitleInput, targetLayerInfo.Name);
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


            // 使用不可能な文字が使われていないか？
            CheckLayerName(newLayerName);

            // 適用可能
            entryFile.Layers.Remove(targetLayerInfo.Name);
            int selIndex = listBoxLayers.SelectedIndex;
            listBoxLayers.Items.RemoveAt(selIndex);

            var layerInfo = new MaterialLayerInfo(newLayerName)
            {
                Path = targetLayerInfo.Path,
                LayerType = targetLayerInfo.LayerType,
                ColorPartsRefs = targetLayerInfo.ColorPartsRefs,
                ColorPropertyName = targetLayerInfo.ColorPropertyName
            };

            entryFile.Layers.Add(newLayerName, layerInfo);
            listBoxLayers.Items.Insert(selIndex, layerInfo);
            listBoxLayers.SelectedIndex = selIndex; // リネーム後、選択状態を復元する。
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
                throw new Exception(Resources.MessageInvalidLayerName);
            }
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            if (!MaterialEntryFile.IsValidName(name))
            {
                throw new Exception(Resources.MessageInvalidLayerNameCharacter);
            }

            if (entryFile.Layers.ContainsKey(name))
            {
                throw new Exception(Resources.MessageLayernameUsed);
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
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// 下へ移動ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonDownLayerClick(object sender, EventArgs e)
        {
            try
            {
                ModifyLayerOrder(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
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

            // Dictionaryの並び順は制御できないので、
            // Dictionaryを再構築する。なんて面倒な！
            entryFile.Layers.Clear();
            foreach (MaterialLayerInfo layer in layers)
            {
                entryFile.Layers.Add(layer.Name, layer);
            }

            ModelToUI();
            listBoxLayers.SelectedIndex = newIndex;
        }

        /// <summary>
        /// レイヤーリストボックスでキーが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListBoxLayersKeyDown(object sender, KeyEventArgs e)
        {
            foreach (var keyAction in listViewActions)
            {
                if (keyAction.IsAccept(e.KeyCode, e.Modifiers))
                {
                    try
                    {
                        keyAction.Invoke();
                        e.Handled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
                    }
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
            ProcessShowMaterialPreview();
        }

        /// <summary>
        /// プレビューを表示する。
        /// </summary>
        private void ProcessShowMaterialPreview()
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

        /// <summary>
        /// アプリケーション設定が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnSettingsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Settings.ImageBackground)))
            {
                materialEditorLayerView.ImageBackground = Settings.Default.ImageBackground;
            }
        }

        /// <summary>
        /// フォームが閉じられた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.PropertyChanged -= OnSettingsPropertyChanged;
        }

        /// <summary>
        /// 表示背景色メニュー項目が選択されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemImageBackgroundClick(object sender, EventArgs e)
        {
            Color defaultColor = Settings.Default.ImageBackground;
            Color selectColor = CGenImaging.Forms.ColorSelectDialog.ShowDialog(this, defaultColor);
            Settings.Default.ImageBackground = selectColor;
        }

        /// <summary>
        /// フォームでキーが押された時にイベント通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ProcessSave();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    ProcessCancel();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// Shiftキーが押下されているかどうかを判定する。
        /// </summary>
        /// <returns>Shiftキーが押下されている場合にはtrue, それ以外はfalse.</returns>
        private bool IsShiftKeyDown()
        {
            return ((ModifierKeys & Keys.Shift) == Keys.Shift);
        }
        /// <summary>
        /// Controlキーが押下されているかどうかを判定する。
        /// </summary>
        /// <returns>Controlキーが押下されている場合にはtrue, それ以外はfalse.</returns>
        private bool IsControlKeyDown()
        {
            return ((ModifierKeys & Keys.Control) == Keys.Control);
        }
    }
}
