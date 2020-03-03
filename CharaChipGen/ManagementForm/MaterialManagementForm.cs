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
            if (materialList != null)
            {
                if (materialList.Name == groupBoxMaterial.Text)
                {
                    // 既に設定されている。
                    return;
                }
                groupBoxMaterial.Text = materialList.Name;
                listViewMaterials.Items.Clear();
                listViewMaterials.Enabled = true;

                // リストビューへの追加
                foreach (Material m in materialList)
                {
                    string[] item = { m.Name, m.GetDisplayName(), m.Path };
                    listViewMaterials.Items.Add(new ListViewItem(item));
                }
                listViewMaterials.View = View.Details;
            }
            else
            {
                // 未選択
                listViewMaterials.Items.Clear();
                listViewMaterials.Enabled = false;
                groupBoxMaterial.Text = "素材一覧";
            }

            buttonAdd.Enabled = (materialList != null);
            buttonEdit.Enabled = (materialList != null);
            buttonDelete.Enabled = (materialList != null);
            buttonNew.Enabled = (materialList != null);
            buttonRename.Enabled = (materialList != null);
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
        /// <param name="entryFilePath">エントリファイルパス</param>
        private void AddMaterial(string entryFilePath)
        {
            AppData data = AppData.Instance;
            MaterialList materialList = GetCurrentMaterialList();
            string dstDir = System.IO.Path.Combine(data.MaterialDirectory, materialList.SubDirectoryName);

            MaterialEntryFile entryFile = new MaterialEntryFile();
            entryFile.Load(entryFilePath);


            // レイヤーを構成するファイルをコピーする。
            string entryFileDir = System.IO.Path.GetDirectoryName(entryFilePath);
            foreach (var layerEntry in entryFile.Layers)
            {
                if (!string.IsNullOrEmpty(layerEntry.Value.Path))
                {
                    CopyFile(entryFileDir, dstDir, layerEntry.Value.Path);
                }
            }

            // エントリファイルをコピーする。
            string entryFileName = System.IO.Path.GetFileName(entryFilePath);
            CopyFile(entryFileDir, dstDir, entryFileName);

            string materialName = System.IO.Path.GetFileNameWithoutExtension(entryFilePath);
            Material existMaterial = materialList.Get(materialName);
            if (existMaterial != null)
            {
                materialList.Delete(materialName);
            }
            string relPath = System.IO.Path.Combine(materialList.SubDirectoryName, entryFileName);
            materialList.Add(new Material(relPath, entryFile));
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
            System.IO.File.Copy(srcPath, dstPath);
        }

        /// <summary>
        /// 編集ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialEditClicked(object sender, EventArgs evt)
        {
            ListViewItem selectedItem = listViewMaterials.SelectedItems[0];
            MaterialList ml = GetCurrentMaterialList();
            string materialName = selectedItem.SubItems[0].Text;
            Material m = ml.Get(materialName);
            if (m == null)
            {
                return;
            }

            try
            {
                MaterialEditorForm.MaterialEditorForm form
                    = new MaterialEditorForm.MaterialEditorForm();
                string entryFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory,m.Path);
                MaterialEntryFile entryFile = new MaterialEntryFile();
                entryFile.Load(entryFilePath);

                form.MaterialEntryFile = entryFile;
                DialogResult res = form.ShowDialog(this);
                if (res != DialogResult.OK)
                {
                    return;
                }

                // 編集反映処理
                ApplyEdit(entryFile);


                m.Reload(); // 更新する。
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
                    // コピーして相対パスに変更する。
                    string newFileName = $"{entryFile.Name}.{layer.Name}.png";
                    string newPath = System.IO.Path.Combine(entryFileDir, newFileName);
                    System.IO.File.Copy(layer.Path, newPath);
                    layer.Path = newFileName;
                }
            }

            // 設定変更を書き出す。
            entryFile.Save();
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

            AppData data = AppData.Instance;

            ListView.SelectedListViewItemCollection selItems = listViewMaterials.SelectedItems;

            try
            {
                MaterialList materialList = GetCurrentMaterialList();
                foreach (ListViewItem item in selItems)
                {
                    string materialName = item.SubItems[0].Text;
                    Material m = materialList.Get(materialName);
                    if (m == null)
                    {
                        return;
                    }

                    materialList.Delete(m.Name); // リストビューアイテムの1項目目はマテリアル名

                    // 実際のファイルの削除処理
                    // エントリファイルだけ削除する。
                    string path = System.IO.Path.Combine(data.MaterialDirectory, m.Path);
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
        /// 
        /// </summary>
        /// <returns></returns>
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
            string newName = InputForm.InputForm.ShowDialog(this, "素材名を入力", "素材名変更", targetMaterial.Name);
            if ((newName == null) || newName.Equals(targetMaterial.Name))
            {
                // キャンセルされたか、変更なし。
                return;
            }

            // 素材の名前を変更しよう！
            try
            {
                // 使用不可能な文字が使われていないか？
                if (!MaterialEntryFile.IsValidName(newName))
                {
                    throw new Exception("素材名として使用できない文字が使用されています。");
                }


                // 同名のファイルが存在しないか？
                if (materialList.Contains(newName))
                {
                    throw new Exception("同名の素材が既にあります。");
                }

                string entryFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, targetMaterial.Path);
                string dstRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                    $"{newName}{MaterialEntryFile.EntryFileSuffix}");
                string dstFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, dstRelativePath);
                System.IO.File.Move(entryFilePath, dstFilePath);
                Material newMaterial = new Material(dstRelativePath, new MaterialEntryFile(dstFilePath));
                materialList.Delete(targetMaterial);
                materialList.Add(newMaterial);

                listViewMaterials.Items.Remove(items[0]);
                listViewMaterials.Items.Add(new ListViewItem(new string[] {
                    newMaterial.Name, newMaterial.GetDisplayName(), newMaterial.Path }));
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
            string newName = InputForm.InputForm.ShowDialog(this, "素材名を入力", "素材名変更", defaultName);
            if (newName == null)
            {
                // キャンセルされたか、変更なし。
                return;
            }
            
            try
            {
                // 使用不可能な文字が使われていないか？
                if (!MaterialEntryFile.IsValidName(newName))
                {
                    throw new Exception("素材名として使用できない文字が使用されています。");
                }

                // 同名のファイルが存在しないか？
                if (materialList.Contains(newName))
                {
                    throw new Exception("同名の素材が既にあります。");
                }

                string newRelativePath = System.IO.Path.Combine(materialList.SubDirectoryName,
                    $"{newName}{MaterialEntryFile.EntryFileSuffix}");
                string newEntryFilePath = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, newRelativePath);

                MaterialEntryFile entryFile = new MaterialEntryFile(newEntryFilePath);
                entryFile.Save();

                Material newMaterial = new Material(newRelativePath, entryFile);
                materialList.Add(newMaterial);

                listViewMaterials.Items.Add(new ListViewItem(new string[] {
                    newMaterial.Name, newMaterial.GetDisplayName(), newMaterial.Path }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
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
    }
}
