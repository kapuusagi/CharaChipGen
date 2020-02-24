using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model.Material;

namespace CharaChipGen.ManagementForm
{
    /// <summary>
    /// 素材の管理画面を提供する。
    /// </summary>
    public partial class MaterialManagementForm : Form
    {
        public MaterialManagementForm()
        {
            InitializeComponent();
            treeViewMaterials.ExpandAll();
            labelDirectory.Text = AppData.GetInstance().MaterialDirectory;
        }

        private void OnCloseMenuStripClicked(object sender, EventArgs e)
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
            AppData data = AppData.GetInstance();

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
                    string[] item = { m.Name, m.Path };
                    listViewMaterials.Items.Add(new ListViewItem(item));
                }
                listViewMaterials.View = View.Details;

                buttonAdd.Enabled = true;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
            }
            else
            {
                // 未選択
                listViewMaterials.Items.Clear();
                listViewMaterials.Enabled = false;
                groupBoxMaterial.Text = "素材一覧";
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void OnMaterialListSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            /**
             * マテリアルリストの選択状態が変更された場合、
             * 削除ボタンと編集ボタンのEnalbe状態を更新する。
             */
            buttonDelete.Enabled = (listViewMaterials.SelectedItems.Count > 0);
            buttonEdit.Enabled = (listViewMaterials.SelectedItems.Count == 1) && (GetCurrentNodeName() != AppData.NameFaces);
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
            AppData data = AppData.GetInstance();
            MaterialList ml = GetCurrentMaterialList();
            string dstDir = System.IO.Path.Combine(data.MaterialDirectory, ml.SubDirectoryName);

            MaterialEntryFile entryFile = new MaterialEntryFile();
            entryFile.Load(entryFilePath);


            // レイヤーを構成するファイルをコピーする。
            string entryFileDir = System.IO.Path.GetDirectoryName(entryFilePath);
            foreach (var li in entryFile.Layers)
            {
                if (!string.IsNullOrEmpty(li.Value.Path))
                {
                    CopyFile(entryFileDir, dstDir, li.Value.Path);
                }
            }

            // エントリファイルをコピーする。
            string entryFileName = System.IO.Path.GetFileName(entryFilePath);
            CopyFile(entryFileDir, dstDir, entryFileName);

            string materialName = System.IO.Path.GetFileNameWithoutExtension(entryFilePath);
            Material existMaterial = ml.Get(materialName);
            if (existMaterial != null)
            {
                ml.Delete(materialName);
            }
            string relPath = System.IO.Path.Combine(ml.SubDirectoryName, entryFileName);
            ml.Add(new Material(relPath, entryFile));
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

            MaterialEditorForm.MaterialEditorForm form
                = new MaterialEditorForm.MaterialEditorForm();
            form.Material = m;
            DialogResult res = form.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            try
            {
                form.ApplyMaterialEdit();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        private void OnMaterialDeleteClicked(object sender, EventArgs evt)
        {
            /**
             * 削除ボタンがクリックされた場合、削除確認を行い、
             * 該当するマテリアルをDisposeしてから削除処理する。
             */

            DialogResult res = MessageBox.Show(this,
                "選択されているマテリアルを削除してもよろしいですか？",
                "確認", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes)
            {
                return;
            }

            AppData data = AppData.GetInstance();

            ListView.SelectedListViewItemCollection selItems = listViewMaterials.SelectedItems;

            try
            {
                foreach (ListViewItem item in selItems)
                {
                    MaterialList ml = GetCurrentMaterialList();
                    string materialName = item.SubItems[0].Text;
                    Material m = ml.Get(materialName);
                    if (m == null)
                    {
                        return;
                    }

                    ml.Delete(m.Name); // リストビューアイテムの1項目目はマテリアル名

                    // 実際のファイルの削除処理
                    // 面倒なのでエントリファイルだけ削除してお茶を濁す。
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

        private string GetCurrentNodeName()
        {
            TreeNode node = treeViewMaterials.SelectedNode;
            return (node != null) ? node.Name : "";
        }

        private MaterialList GetMaterialList(string name)
        {
            AppData data = AppData.GetInstance();
            return data.getMaterialList(name);
        }
    }
}
