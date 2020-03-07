using CharaChipGen.Model.Material;
using System;
using System.Windows.Forms;

namespace CharaChipGen.ManagementForm
{
    /// <summary>
    /// 素材の管理画面を提供する。
    /// </summary>
    public partial class MaterialManagementForm : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialManagementForm()
        {
            InitializeComponent();
            treeViewMaterials.ExpandAll();
            labelDirectory.Text = AppData.Instance.MaterialDirectory;
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
            MaterialList materialList = GetCurrentMaterialList();
            groupBoxMaterial.Text = materialList?.Name ?? "素材一覧";
            listViewMaterials.Enabled = (materialList != null);
            listViewMaterials.Items.Clear();
            if (materialList != null)
            {
                // リストビューへの追加
                foreach (Material material in materialList)
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
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialAddClicked(object sender, EventArgs evt)
        {
            // 追加ボタンが押されたとき、外部の素材をコピーしてくる。
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
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
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
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
            MaterialList materialList = GetCurrentMaterialList();
            string srcEntryFileDir = System.IO.Path.GetDirectoryName(srcEntryFilePath);
            string dstEntryFileDir = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, materialList.SubDirectoryName);
            string materialName = System.IO.Path.GetFileNameWithoutExtension(srcEntryFilePath);

            MaterialEntryFile srcEntryFile = MaterialEntryFile.LoadFrom(srcEntryFilePath);


            // レイヤーを構成する画像ファイルをコピーする。
            foreach (var layerEntry in srcEntryFile.Layers)
            {
                if (!string.IsNullOrEmpty(layerEntry.Value.Path))
                {
                    CopyFile(srcEntryFileDir, dstEntryFileDir, layerEntry.Value.Path);
                }
            }

            // エントリファイルをコピーする。
            string entryFileName = System.IO.Path.GetFileName(srcEntryFilePath);
            CopyFile(srcEntryFileDir, dstEntryFileDir, entryFileName);

            // 既存のエントリがあるなら削除
            if (materialList.Contains(materialName))
            {
                materialList.Delete(materialName);
            }
            string relPath = System.IO.Path.Combine(materialList.SubDirectoryName, entryFileName);
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
            string srcPath = System.IO.Path.Combine(srcDir, relativePath);
            string dstPath = System.IO.Path.Combine(dstDir, relativePath);
            string dir = System.IO.Path.GetDirectoryName(dstPath);
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
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialEditClicked(object sender, EventArgs evt)
        {
            var selectedIndices = listViewMaterials.SelectedIndices;
            if (selectedIndices.Count != 1)
            {
                return;
            }

            try
            {
                int selectedIndex = selectedIndices[0];
                ListViewItem selectedItem = listViewMaterials.Items[selectedIndex];
                MaterialList materialList = GetCurrentMaterialList();
                string materialName = selectedItem.SubItems[0].Text;
                Material material = materialList.Get(materialName);
                if (material == null)
                {
                    return;
                }
                MaterialEditorForm.MaterialEditorForm form
                    = new MaterialEditorForm.MaterialEditorForm();

                string entryFilePath = System.IO.Path.Combine(
                    AppData.Instance.MaterialDirectory, material.RelativePath);
                MaterialEntryFile entryFile = MaterialEntryFile.LoadFrom(entryFilePath);

                form.MaterialEntryFile = entryFile;
                DialogResult res = form.ShowDialog(this);
                if (res != DialogResult.OK)
                {
                    return;
                }

                // 編集反映処理
                ApplyEdit(entryFile);

                material.Reload(); // 更新する。

                listViewMaterials.Items.RemoveAt(selectedIndex);
                listViewMaterials.Items.Insert(selectedIndex, GenerateListViewMaterial(material));
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        /// <summary>
        /// 編集結果を反映させる。
        /// </summary>
        /// <param name="entryFile">エントリファイル</param>
        private void ApplyEdit(MaterialEntryFile entryFile)
        {
            string entryFileDir = System.IO.Path.GetDirectoryName(entryFile.Path);

            foreach (var layerEntry in entryFile.Layers)
            {
                MaterialLayerInfo layer = layerEntry.Value;
                if (string.IsNullOrEmpty(layer.Path))
                {
                    // 普通はここに来ないけど。
                    continue;
                }
                if (System.IO.Path.IsPathRooted(layer.Path))
                {
                    // 絶対パス指定になってるので変更されたやつである。
                    if (layer.Path.StartsWith(entryFileDir))
                    {
                        // エントリファイルと同じフォルダかサブフォルダにあるので
                        // 相対パスに書き換えるだけで良い。
                        layer.Path = RemoveRootDirectory(layer.Path, entryFileDir);
                    }
                    else
                    {
                        // コピーして相対パスに変更する。
                        string newFileName = $"{entryFile.Name}.{layer.Name}.png";
                        string newPath = System.IO.Path.Combine(entryFileDir, newFileName);
                        System.IO.File.Copy(layer.Path, newPath, true);
                        layer.Path = newFileName;
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
            int index = rootDirectory.Length;
            while (index < path.Length)
            {
                if (path[index] != System.IO.Path.DirectorySeparatorChar)
                {
                    return path.Substring(index);
                }
                index++;
            }

            throw new Exception("path is same to rootDirectory.");
        }



        /// <summary>
        /// 削除操作が行われたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialDeleteClicked(object sender, EventArgs evt)
        {
            DialogResult res = MessageBox.Show(this,
                "選択されている部品を削除してもよろしいですか？",
                "確認", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes)
            {
                return;
            }

            ListView.SelectedListViewItemCollection selItems = listViewMaterials.SelectedItems;

            try
            {
                MaterialList materialList = GetCurrentMaterialList();
                foreach (ListViewItem item in selItems)
                {
                    string materialName = item.SubItems[0].Text;
                    Material material = materialList.Get(materialName);
                    if (material == null)
                    {
                        return;
                    }

                    // リストビューアイテムの1項目目はマテリアル名
                    materialList.Delete(material.Name);

                    // 実際のファイルの削除処理
                    // エントリファイルだけ削除する。
                    string path = System.IO.Path.Combine(
                        AppData.Instance.MaterialDirectory, material.RelativePath);
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
            UpdateMaterialListView();
        }


        /// <summary>
        /// 現在選択されているマテリアルリストを取得する。
        /// 
        /// 選択されているマテリアルリストが存在しない場合にはnullが返る。
        /// </summary>
        /// <returns></returns>
        private MaterialList GetCurrentMaterialList()
        {
            return GetMaterialList(GetCurrentNodeName());
        }

        /// <summary>
        /// ツリービューで、現在選択されているノードの名前を取得する。
        /// </summary>
        /// <returns>ノードの名前</returns>
        private string GetCurrentNodeName()
        {
            TreeNode node = treeViewMaterials.SelectedNode;
            return (node != null) ? node.Name : "";
        }

        /// <summary>
        /// 指定した名前の素材リストを取得する。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private MaterialList GetMaterialList(string name)
        {
            AppData data = AppData.Instance;
            return data.GetMaterialList(name);
        }

        /// <summary>
        /// リネームボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonRenameClick(object sender, EventArgs e)
        {
            var items = listViewMaterials.SelectedItems;
            if (items.Count != 1)
            {
                return;
            }

            MaterialList materialList = GetCurrentMaterialList();
            Material targetMaterial = materialList.Get(items[0].SubItems[0].Text);
            string inputText = InputForm.InputForm.ShowDialog(this, "素材名を入力", "素材名変更", targetMaterial.Name);
            if ((inputText == null) || inputText.Trim().Equals(targetMaterial.Name))
            {
                // キャンセルされたか、変更なし。
                return;
            }

            // 素材の名前を変更する
            try
            {
                string newName = inputText.Trim();
                CheckMaterialName(materialList, newName);

                // エントリファイルのパス名を変更
                string entryFilePath = System.IO.Path.Combine(
                    AppData.Instance.MaterialDirectory, targetMaterial.RelativePath);
                string dstRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                    $"{newName}{MaterialEntryFile.EntryFileSuffix}");
                string dstFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, dstRelativePath);
                System.IO.File.Move(entryFilePath, dstFilePath);

                // 素材リストの素材を入れ替え
                Material newMaterial = new Material(dstRelativePath, new MaterialEntryFile(dstFilePath));
                materialList.Delete(targetMaterial);
                materialList.Add(newMaterial);

                listViewMaterials.Items.Remove(items[0]);
                listViewMaterials.Items.Add(GenerateListViewMaterial(newMaterial));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 新規追加ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonNewClick(object sender, EventArgs e)
        {
            MaterialList materialList = GetCurrentMaterialList();
            string defaultName = GenerateName(materialList);
            string intputText = InputForm.InputForm.ShowDialog(this, "素材名を入力", "素材名変更", defaultName);
            if (intputText == null)
            {
                // キャンセルされた。
                return;
            }
            string newName = intputText.Trim();

            try
            {
                CheckMaterialName(materialList, newName);

                string newRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                    $"{newName}{MaterialEntryFile.EntryFileSuffix}");
                string newEntryFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, newRelativePath);

                MaterialEntryFile entryFile = new MaterialEntryFile(newEntryFilePath);
                entryFile.Save();

                Material newMaterial = new Material(newRelativePath, entryFile);
                materialList.Add(newMaterial);

                listViewMaterials.Items.Add(GenerateListViewMaterial(newMaterial));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
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
                throw new Exception("素材名が指定されていません。");
            }
            // 使用不可能な文字が使われていないか？
            if (!MaterialEntryFile.IsValidName(name))
            {
                throw new Exception("素材名として使用できない文字が使用されています。");
            }

            // 同名のファイルが存在しないか？
            if (materialList.Contains(name))
            {
                throw new Exception("同名の素材が既にあります。");
            }
        }

        /// <summary>
        /// デフォルト名を生成する。
        /// </summary>
        /// <param name="materialList">素材リスト</param>
        /// <returns>デフォルト名</returns>
        private string GenerateName(MaterialList materialList)
        {
            string baseName = materialList.SubDirectoryName;
            for (int i = 0; i < 999; i++)
            {
                string name = $"{baseName}{i.ToString("000")}";
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
            ListViewItem selectedItem = listViewMaterials.Items[selectedIndex];
            MaterialList materialList = GetCurrentMaterialList();
            string materialName = selectedItem.SubItems[0].Text;
            Material material = materialList.Get(materialName);
            if (material == null)
            {
                return;
            }

            MaterialViewForm.MaterialViewForm form
                = new CharaChipGen.MaterialViewForm.MaterialViewForm() {
                    Text = material.GetDisplayName(),
                    Material = material
                };
            form.ShowDialog();
        }

        /// <summary>
        /// フォルダ閲覧ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonBrowseDirectoryClick(object sender, EventArgs e)
        {
            string materialDir = AppData.Instance.MaterialDirectory;
            System.Diagnostics.Process.Start("EXPLORER.EXE", materialDir);
        }
    }
}
