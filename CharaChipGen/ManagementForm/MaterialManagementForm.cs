using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CharaChipGen.Model.Material;
using CharaChipGen.Properties;
using CharaChipGen.Model;

namespace CharaChipGen.ManagementForm
{
    /// <summary>
    /// 素材の管理画面を提供する。
    /// </summary>
    public partial class MaterialManagementForm : Form
    {
        private List<KeyActionEntry> formKeyActions = new List<KeyActionEntry>();
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialManagementForm()
        {
            InitializeComponent();
            treeViewMaterials.ExpandAll();
            labelDirectory.Text = AppData.Instance.MaterialDirectory;

            formKeyActions.Add(new KeyActionEntry(Keys.Enter, Keys.None, () => ProcessEditMaterial()));
            formKeyActions.Add(new KeyActionEntry(Keys.F2, Keys.None, () => ProcessRename()));
            formKeyActions.Add(new KeyActionEntry(Keys.Delete, Keys.Control, () => ProcessDelete()));
            formKeyActions.Add(new KeyActionEntry(Keys.C, Keys.Control, () => ProcessCopyToClipboard()));
            formKeyActions.Add(new KeyActionEntry(Keys.V, Keys.Control, () => ProcessCopyFromClipboard()));
        }

        /// <summary>
        /// 閉じるメニュー/ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemCloseClick(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// ツリービューの選択が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTreeViewItemSelected(object sender, TreeViewEventArgs e)
        {
            // 選択が変更された
            UpdateMaterialListView();
        }

        /// <summary>
        /// 素材リストビューを更新する。
        /// </summary>
        private void UpdateMaterialListView()
        {
            var materialList = GetCurrentMaterialList();
            groupBoxMaterial.Text = materialList?.Name ?? Resources.DialogTitleMaterials;
            listViewMaterials.Enabled = (materialList != null);
            listViewMaterials.Items.Clear();
            if (materialList != null)
            {
                // リストビューへの追加
                foreach (var material in materialList)
                {
                    listViewMaterials.Items.Add(GenerateListViewMaterial(material));
                }
                listViewMaterials.View = View.Details;
            }

            buttonNew.Enabled = (materialList != null);
            buttonAdd.Enabled = (materialList != null);
            buttonDelete.Enabled = (listViewMaterials.SelectedItems.Count > 0);
            buttonEdit.Enabled = (listViewMaterials.SelectedItems.Count == 1);
            buttonRename.Enabled = (listViewMaterials.SelectedItems.Count == 1);
        }

        /// <summary>
        /// MaterialからListViewItemを構築する。
        /// </summary>
        /// <param name="material">Materialオブジェクト</param>
        /// <returns>ListViewItemオブジェクト</returns>
        private ListViewItem GenerateListViewMaterial(Material material)
        {
            return new ListViewItem(new string[] {
                material.Name, material.GetDisplayName(), material.RelativePath });
        }

        /// <summary>
        /// 素材リストの選択状態が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMaterialListSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            buttonDelete.Enabled = (listViewMaterials.SelectedItems.Count > 0);
            buttonEdit.Enabled = (listViewMaterials.SelectedItems.Count == 1);
            buttonRename.Enabled = (listViewMaterials.SelectedItems.Count == 1);
            buttonPreview.Enabled = (listViewMaterials.SelectedItems.Count == 1);
        }

        /// <summary>
        /// 追加ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMaterialAddClicked(object sender, EventArgs e)
        {
            // 追加ボタンが押されたとき、外部の素材をコピーしてくる。
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                foreach (string selectedPath in openFileDialog.FileNames)
                {
                    // 1つずつ追加する。
                    AddMaterial(selectedPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }

            // ビュー更新
            UpdateMaterialListView();
        }

        /// <summary>
        /// 素材を追加する。
        /// </summary>
        /// <param name="srcEntryFilePath">追加するエントリファイルパス</param>
        private void AddMaterial(string srcEntryFilePath)
        {
            var materialList = GetCurrentMaterialList();
            var srcEntryFileDir = System.IO.Path.GetDirectoryName(srcEntryFilePath);
            var dstEntryFileDir = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, materialList.SubDirectoryName);
            var materialName = System.IO.Path.GetFileNameWithoutExtension(srcEntryFilePath);

            var srcEntryFile = MaterialEntryFile.LoadFrom(srcEntryFilePath);


            // レイヤーを構成する画像ファイルをコピーする。
            foreach (var layerEntry in srcEntryFile.Layers)
            {
                if (!string.IsNullOrEmpty(layerEntry.Value.Path))
                {
                    CopyFile(srcEntryFileDir, dstEntryFileDir, layerEntry.Value.Path);
                }
            }

            // エントリファイルをコピーする。
            var entryFileName = System.IO.Path.GetFileName(srcEntryFilePath);
            CopyFile(srcEntryFileDir, dstEntryFileDir, entryFileName);

            // 既存のエントリがあるなら削除
            if (materialList.Contains(materialName))
            {
                materialList.Delete(materialName);
            }
            var relPath = System.IO.Path.Combine(materialList.SubDirectoryName, entryFileName);
            materialList.Add(new Material(relPath, srcEntryFile));
        }

        /// <summary>
        /// ファイルをコピーする。
        /// コピー元ファイルがない場合はエラー。
        /// コピー先に同名のファイルがある場合には上書きする。
        /// </summary>
        /// <param name="srcDir">コピー元ディレクトリ</param>
        /// <param name="dstDir">コピー先ディレクトリ</param>
        /// <param name="relativePath">ファイル名(相対パス)</param>
        private void CopyFile(string srcDir, string dstDir, string relativePath)
        {
            var srcPath = System.IO.Path.Combine(srcDir, relativePath);
            var dstPath = System.IO.Path.Combine(dstDir, relativePath);
            var dir = System.IO.Path.GetDirectoryName(dstPath);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            System.IO.File.Copy(srcPath, dstPath, true);
        }

        /// <summary>
        /// 編集ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMaterialEditClicked(object sender, EventArgs e)
        {

            try
            {
                ProcessEditMaterial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// indexで指定された素材の編集操作を行う。
        /// </summary>
        private void ProcessEditMaterial()
        {
            var selectedIndices = listViewMaterials.SelectedIndices;
            if (selectedIndices.Count != 1)
            {
                return;
            }
            int index = selectedIndices[0];

            var selectedItem = listViewMaterials.Items[index];
            var materialList = GetCurrentMaterialList();
            var materialName = selectedItem.SubItems[0].Text;
            var material = materialList.Get(materialName);
            if (material == null)
            {
                return;
            }
            var form = new MaterialEditorForm.MaterialEditorForm();

            string entryFilePath = System.IO.Path.Combine(
                AppData.Instance.MaterialDirectory, material.RelativePath);
            var entryFile = MaterialEntryFile.LoadFrom(entryFilePath);
            form.MaterialEntryFile = entryFile;
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            // 編集反映処理
            ApplyEdit(entryFile);

            material.Reload(); // 更新する。

            listViewMaterials.Items.RemoveAt(index);
            listViewMaterials.Items.Insert(index, GenerateListViewMaterial(material));
            listViewMaterials.SelectedIndices.Clear();
            listViewMaterials.SelectedIndices.Add(index);
        }

        /// <summary>
        /// 編集結果を反映させる。
        /// </summary>
        /// <param name="entryFile">エントリファイル</param>
        private void ApplyEdit(MaterialEntryFile entryFile)
        {
            var entryFileDir = System.IO.Path.GetDirectoryName(entryFile.Path);

            foreach (var layerEntry in entryFile.Layers)
            {
                var layerInfo = layerEntry.Value;
                if (string.IsNullOrEmpty(layerInfo.Path))
                {
                    // 普通はここに来ないけど。
                    continue;
                }
                if (System.IO.Path.IsPathRooted(layerInfo.Path))
                {
                    // 絶対パス指定になってるので変更されたやつである。
                    if (layerInfo.Path.StartsWith(entryFileDir))
                    {
                        // エントリファイルと同じフォルダかサブフォルダにあるので
                        // 相対パスに書き換えるだけで良い。
                        layerInfo.Path = RemoveRootDirectory(layerInfo.Path, entryFileDir);
                    }
                    else
                    {
                        // コピーして相対パスに変更する。
                        var newFileName = $"{entryFile.Name}.{layerInfo.Name}.png";
                        var newPath = System.IO.Path.Combine(entryFileDir, newFileName);
                        System.IO.File.Copy(layerInfo.Path, newPath, true);
                        layerInfo.Path = newFileName;
                    }
                }
            }

            // 設定変更を書き出す。
            entryFile.Save();
        }


        /// <summary>
        /// pathの先頭にあるrootDirectory部分を削ったサブディレクトリ以下の相対パスを得る。
        /// </summary>
        /// <param name="path">パス</param>
        /// <param name="rootDirectory">ルートディレクトリ</param>
        /// <returns>相対パス</returns>
        private string RemoveRootDirectory(string path, string rootDirectory)
        {
            for (int index = rootDirectory.Length; index < path.Length; index++)
            {
                if (path[index] != System.IO.Path.DirectorySeparatorChar)
                {
                    return path.Substring(index);
                }
            }

            throw new Exception(Resources.MessagePathIsRootDirectory);
        }



        /// <summary>
        /// 削除操作が行われたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                ProcessDelete();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
            UpdateMaterialListView();
        }


        /// <summary>
        /// 現在選択されているマテリアルリストを取得する。
        /// 
        /// 選択されているマテリアルリストが存在しない場合にはnullが返る。
        /// </summary>
        /// <returns>MaterialListオブジェクト</returns>
        private MaterialList GetCurrentMaterialList()
        {
            return GetMaterialList(GetCurrentNodeName());
        }

        /// <summary>
        /// 現在選択されているマテリアルリスト上の、indexで指定される素材エントリを得る。
        /// 
        /// 選択されているマテリアルリストが無かったり、indexが範囲外の場合にはnullが帰る。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>Materialオブジェクト</returns>
        private Material GetMaterial(int index)
        {
            var selectedItem = listViewMaterials.Items[index];
            var materialList = GetCurrentMaterialList();
            if (selectedItem == null)
            {
                return null;
            }
            else
            {
                var materialName = selectedItem.SubItems[0].Text;
                return materialList.Get(materialName);
            }
        }

        /// <summary>
        /// ツリービューで、現在選択されているノードの名前を取得する。
        /// </summary>
        /// <returns>ノードの名前</returns>
        private string GetCurrentNodeName()
        {
            var node = treeViewMaterials.SelectedNode;
            return (node != null) ? node.Name : "";
        }

        /// <summary>
        /// 指定した名前の素材リストを取得する。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private MaterialList GetMaterialList(string name)
        {
            var data = AppData.Instance;
            return data.GetMaterialList(name);
        }

        /// <summary>
        /// リネームボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonRenameClick(object sender, EventArgs e)
        {

            try
            {
                ProcessRename();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }
        /// <summary>
        /// リネーム処理する
        /// </summary>
        private void ProcessRename()
        {
            var items = listViewMaterials.SelectedItems;
            if (items.Count != 1)
            {
                return;
            }
            var listViewItem = items[0];
            var materialList = GetCurrentMaterialList();
            var targetMaterial = materialList.Get(listViewItem.SubItems[0].Text);
            string inputText = InputForm.InputForm.ShowDialog(this,
                Resources.MessageInputMaterialName, Resources.DialogTitleChangeMaterialName,
                targetMaterial.Name);
            if ((inputText == null) || inputText.Trim().Equals(targetMaterial.Name))
            {
                // キャンセルされたか、変更なし。
                return;
            }

            // 素材の名前を変更する
            var newName = inputText.Trim();
            CheckMaterialName(materialList, newName);

            // エントリファイルをリネーム
            var entryFilePath = System.IO.Path.Combine(
                AppData.Instance.MaterialDirectory, targetMaterial.RelativePath);
            var dstRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                $"{newName}{MaterialEntryFile.EntryFileSuffix}");
            var dstFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory,
                dstRelativePath);
            System.IO.File.Move(entryFilePath, dstFilePath);

            // 素材リストの素材を入れ替え
            var newMaterial = new Material(dstRelativePath, new MaterialEntryFile(dstFilePath));
            materialList.Delete(targetMaterial);
            materialList.Add(newMaterial);

            listViewMaterials.Items.Remove(listViewItem);
            var newListViewItem = GenerateListViewMaterial(newMaterial);
            listViewMaterials.Items.Add(newListViewItem);
            var index = listViewMaterials.Items.IndexOf(newListViewItem);
            listViewMaterials.SelectedIndices.Add(index);
        }

        /// <summary>
        /// 新規追加ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonNewClick(object sender, EventArgs e)
        {
            var materialList = GetCurrentMaterialList();
            var defaultName = GenerateName(materialList);
            var intputText = InputForm.InputForm.ShowDialog(this,
                Resources.MessageInputMaterialName,
                Resources.DialogTitleNewMaterial, defaultName);
            if (intputText == null)
            {
                // キャンセルされた。
                return;
            }
            string newName = intputText.Trim();

            try
            {
                CheckMaterialName(materialList, newName);

                var newRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                    $"{newName}{MaterialEntryFile.EntryFileSuffix}");
                var newEntryFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, newRelativePath);

                var entryFile = MaterialUtils.CreateDefaultEntryFile(
                    newEntryFilePath, materialList.MaterialType);
                entryFile.Save();

                var newMaterial = new Material(newRelativePath, entryFile);
                materialList.Add(newMaterial);

                listViewMaterials.Items.Add(GenerateListViewMaterial(newMaterial));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }


        /// <summary>
        /// 素材名が有効かどうかを確認する。
        /// 正しくない場合には例外がスルーされる。
        /// </summary>
        /// <param name="materialList">マテリアルリスト</param>
        /// <param name="name">素材名</param>
        private void CheckMaterialName(MaterialList materialList, string name)
        {
            if (name.Length == 0)
            {
                throw new Exception(Resources.MessageMaterialNameNotSpecified);
            }
            // 使用不可能な文字が使われていないか？
            if (!MaterialEntryFile.IsValidName(name))
            {
                throw new Exception(Resources.MessageInvalidMaterialNameCharacter);
            }

            // 同名のファイルが存在しないか？
            if (materialList.Contains(name))
            {
                throw new Exception(Resources.MessageMaterialNameUsed);
            }
        }

        /// <summary>
        /// デフォルト名を生成する。
        /// </summary>
        /// <param name="materialList">素材リスト</param>
        /// <returns>デフォルト名</returns>
        private string GenerateName(MaterialList materialList)
        {
            var baseName = materialList.SubDirectoryName;
            for (int i = 0; i < 999; i++)
            {
                var name = $"{baseName}{i.ToString("000")}";
                if (!materialList.Contains(name))
                {
                    return name;
                }
            }
            return "";
        }
        
        /// <summary>
        /// プレビューボタンが押されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonPreviewClick(object sender, EventArgs e)
        {
            int selectedIndex = listViewMaterials.SelectedIndices[0];
            var selectedItem = listViewMaterials.Items[selectedIndex];
            var materialList = GetCurrentMaterialList();
            var materialName = selectedItem.SubItems[0].Text;
            var material = materialList.Get(materialName);
            if (material == null)
            {
                return;
            }

            try
            {
                var form = new MaterialViewForm.MaterialViewForm()
                {
                    Text = material.GetDisplayName(),
                    Material = material
                };
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }



        /// <summary>
        /// フォルダ閲覧ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonBrowseDirectoryClick(object sender, EventArgs e)
        {
            var materialDir = AppData.Instance.MaterialDirectory;
            System.Diagnostics.Process.Start("EXPLORER.EXE", materialDir);
        }

        /// <summary>
        /// リストビューでキーが押されたときの処理を行う
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnListViewMaterialsKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                foreach (var keyAction in formKeyActions)
                {
                    if (keyAction.CanAccept(e.KeyCode, e.Modifiers))
                    {
                        keyAction.Invoke();
                        e.Handled = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// 選択されている項目を削除する。
        /// </summary>
        private void ProcessDelete()
        {
            var selItems = listViewMaterials.SelectedItems;
            if (selItems.Count == 0)
            {
                return;
            }


            var res = MessageBox.Show(this,
                Resources.MessageConfirmRemoveParts,
                Resources.DialogTitleConfirm, MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes)
            {
                return;
            }

            foreach (ListViewItem item in selItems)
            {
                var materialName = item.SubItems[0].Text;
                var materialList = GetCurrentMaterialList();
                var material = materialList.Get(materialName);
                if (material == null)
                {
                    return;
                }

                // リストビューアイテムの1項目目はマテリアル名
                materialList.Delete(material.Name);

                // 実際のファイルの削除処理
                // エントリファイルだけ削除する。
                var path = System.IO.Path.Combine(
                    AppData.Instance.MaterialDirectory, material.RelativePath);
                System.IO.File.Delete(path);
            }

        }

        /// <summary>
        /// クリップボードにコピーする。
        /// </summary>
        private void ProcessCopyToClipboard()
        {
            var selectedIndex = (listViewMaterials.SelectedIndices.Count == 1) ? listViewMaterials.SelectedIndices[0] : -1;
            if (selectedIndex == -1)
            {
                return;
            }

            var material = GetMaterial(selectedIndex);
            if (material == null)
            {
                return;
            }

            Clipboard.SetText(material.GetData());
        }

        /// <summary>
        /// クリップボードからコピーする。
        /// </summary>
        private void ProcessCopyFromClipboard()
        {
            var materialList = GetCurrentMaterialList();
            var newName = GenerateName(materialList);
            CheckMaterialName(materialList, newName);

            var dstRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                $"{newName}{MaterialEntryFile.EntryFileSuffix}");
            var dstFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory,
                dstRelativePath);

            var dataText = Clipboard.GetText();
            var newMaterial = new Material(dstRelativePath, MaterialEntryFile.CreateFrom(dstFilePath, dataText));

            materialList.Add(newMaterial);

            var newListViewItem = GenerateListViewMaterial(newMaterial);
            listViewMaterials.Items.Add(newListViewItem);
            var index = listViewMaterials.Items.IndexOf(newListViewItem);
            listViewMaterials.SelectedIndices.Clear();
            listViewMaterials.SelectedIndices.Add(index);
        }
    }
}
