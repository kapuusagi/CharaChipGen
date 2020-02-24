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
            AdjustComponentPosition();
            treeViewMaterials.ExpandAll();
            labelDirectory.Text = AppData.GetInstance().MaterialDirectory;
        }

        private void OnCloseMenuStripClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void OnFormResized(object sender, EventArgs e)
        {
            AdjustComponentPosition();
        }

        /// <summary>
        /// コンポーネントの位置を調整する。
        /// 
        /// Note:
        /// Javaと違ってレイアウト調整めんどくさいね。
        /// </summary>
        private void AdjustComponentPosition()
        {
            int x, y;
            // closeButtonの位置調整
            x = ClientSize.Width - 4 - buttonClose.Width;
            y = ClientSize.Height - 4 - buttonClose.Height;
            buttonClose.SetBounds(x, y, buttonClose.Width, buttonClose.Height);

            // 表示領域のサイズはメニューと下方の閉じるボタン領域を除いた部分になる。
            System.Drawing.Point viewOrigin = new System.Drawing.Point(4, menuStrip1.Height + 4);
            int viewWidth = ClientSize.Width - 8;
            int viewHeight = ClientSize.Height - 8 - buttonClose.Height - viewOrigin.Y;

            // ラベルの設定
            int labelX = viewOrigin.X;
            int labelY = viewOrigin.Y;
            labelDirectory.SetBounds(labelX, labelY, viewWidth, labelDirectory.Height);

            // 左側ツリーペインの配置
            int treeX = viewOrigin.X;
            int treeY = viewOrigin.Y + labelDirectory.Height + 4;
            treeViewMaterials.SetBounds(treeX, treeY, 100, viewHeight - labelDirectory.Height - 4);

            // マテリアルリストビューの配置
            int mViewX = treeViewMaterials.Location.X + treeViewMaterials.Width + 4;
            int mViewY = treeY;
            int mViewWidth = ClientSize.Width - mViewX - 4;
            int mViewHeight = viewHeight - labelDirectory.Height - 4;
            groupBoxMaterial.SetBounds(mViewX, mViewY, mViewWidth, mViewHeight);

            Rectangle r = groupBoxMaterial.ClientRectangle;
            int lViewX = 8;
            int lViewY = 16;
            int lViewWidth = r.Width - 8 - lViewX;
            int lViewHeight = r.Height - 8 - lViewY;

            int minButtonWidth = buttonAdd.Width + buttonEdit.Width + buttonDelete.Width + 8;
            buttonAdd.Visible = (lViewWidth >= minButtonWidth);
            buttonEdit.Visible = (lViewWidth >= minButtonWidth);
            buttonDelete.Visible = (lViewWidth >= minButtonWidth);

            int buttonX = lViewX + (lViewWidth - minButtonWidth);
            int buttonY = lViewY;
            buttonAdd.SetBounds(buttonX, buttonY, buttonAdd.Width, buttonAdd.Height);
            buttonX += buttonAdd.Width + 4;
            buttonEdit.SetBounds(buttonX, buttonY, buttonEdit.Width, buttonEdit.Height);
            buttonX += buttonEdit.Width + 4;
            buttonDelete.SetBounds(buttonX, buttonY, buttonDelete.Width, buttonDelete.Height);

            int listX = lViewX;
            int listY = lViewY + buttonAdd.Height + 4;
            int listWidth = lViewWidth;
            int listHeight = lViewHeight - buttonAdd.Height - 4;
            listViewMaterials.SetBounds(listX, listY, listWidth, listHeight);
        }

        private void OnTreeViewItemSelected(object sender, TreeViewEventArgs e)
        {
            // 選択が変更された
            AppData data = AppData.GetInstance();

            MaterialList materialList = getCurrentMaterialList();
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
            buttonEdit.Enabled = (listViewMaterials.SelectedItems.Count == 1) && (getCurrentNodeName() != AppData.NameFaces);
        }

        private void OnMaterialAddClicked(object sender, EventArgs evt)
        {
            /**
             * 追加ボタンが押されたとき、外部の素材をコピーしてくる。
             */
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            throw new NotSupportedException();
#if false
            string[] selectedPaths = openFileDialog.FileNames;

            AppData data = AppData.GetInstance();
            MaterialList ml = getCurrentMaterialList();

            try
            {
                foreach (string srcPath in selectedPaths)
                {
                    if (!MaterialEntryFile.IsMaterialEntryFile(srcPath))
                    {
                        continue;
                    }

                    string srcDir = System.IO.Path.GetDirectoryName(srcPath); // srcDir = X:\Pictures
                    string primaryFileName = System.IO.Path.GetFileName(srcPath); // primaryFileName = hogehoge.png
                    string materialName = System.IO.Path.GetFileNameWithoutExtension(srcPath); // materialName = hogehoge
                    string srcPrimaryPath = srcPath; // srcPrimaryPath = X:\Pictures\hogehoge.png
                    string secondaryFileName = materialName + ".back.png"; // srcSecondaryFileName = hogehoge.back.png
                    string srcSecondaryPath = System.IO.Path.Combine(srcDir, secondaryFileName); // srcSecondaryPath = X:\Pictures\hogehoge.back.png


                    string dstDir = System.IO.Path.Combine(data.MaterialDirectory, ml.SubDirectoryName);
                    string dstPrimaryPath = System.IO.Path.Combine(dstDir, primaryFileName);
                    string dstSecondaryPath = System.IO.Path.Combine(dstDir, secondaryFileName);

                    Material existMaterial = ml.Get(materialName);


                    // プライマリのレイヤーファイルをコピー
                    System.IO.File.Copy(srcPrimaryPath, dstPrimaryPath, true);
                    // セカンダリはインポート元があるかどうかで処理が変わる
                    if (System.IO.File.Exists(srcSecondaryPath))
                    {
                        // インポート元にセカンダリレイヤーファイルが存在するので
                        // セカンダリレイヤーファイルをコピーする。
                        System.IO.File.Copy(srcSecondaryPath, dstSecondaryPath, true);
                    } else
                    {
                        if (System.IO.File.Exists(dstSecondaryPath))
                        {
                            // インポート元でセカンダリのファイルが存在しないのに、
                            // インポート先にセカンダリファイルがある。
                            // インポート先のセカンダリファイルは削除する。
                            System.IO.File.Delete(dstSecondaryPath);
                        }

                    }

                    if (existMaterial == null)
                    {
                        // 既存の素材が存在しない場合には
                        // 新しい素材として登録する。
                        string relPath = System.IO.Path.Combine(ml.SubDirectoryName, primaryFileName);
                        Material newMaterial = new Material(relPath);
                        ml.Add(newMaterial);
                        string[] item = { newMaterial.Name, newMaterial.Path };
                        listViewMaterials.Items.Add(new ListViewItem(item));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
#endif
        }

        private void OnMaterialEditClicked(object sender, EventArgs evt)
        {
            /**
             * 編集ボタンが押された場合、編集用のフォームを立ち上げる。
             */
            ListViewItem selectedItem = listViewMaterials.SelectedItems[0];
            MaterialList ml = getCurrentMaterialList();
            string materialName = selectedItem.SubItems[0].Text;
            Material m = ml.Get(materialName);
            if (m == null)
            {
                return;
            }

            CharaChipGen.MaterialEditorForm.MaterialEditorForm form
                = new CharaChipGen.MaterialEditorForm.MaterialEditorForm();
            form.Material = m;
            DialogResult res = form.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            throw new NotSupportedException();
#if false
            // 編集用のフォームでOKが押された場合にはデータを保存する。
            try
            {
                Material editedMaterial = form.Material;
                if (ml.Contains(editedMaterial))
                {
                    editedMaterial.SavePrimaryLayer();
                    editedMaterial.SaveSecondaryLayer();
                }
                else
                {
                    // 新規追加になる。
                    editedMaterial.SavePrimaryLayer();
                    editedMaterial.SaveSecondaryLayer();

                    ml.Add(editedMaterial);

                    string[] item = { editedMaterial.Name, editedMaterial.Path };
                    listViewMaterials.Items.Add(new ListViewItem(item));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
#endif
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

            throw new NotSupportedException();
#if false

            AppData data = AppData.GetInstance();

            ListView.SelectedListViewItemCollection selItems = listViewMaterials.SelectedItems;

            try
            {
                foreach (ListViewItem item in selItems)
                {
                    MaterialList ml = getCurrentMaterialList();
                    string materialName = item.SubItems[0].Text;
                    Material m = ml.Get(materialName);
                    if (m == null)
                    {
                        return;
                    }

                    ml.Delete(m.Name); // リストビューアイテムの1項目目はマテリアル名
                    listViewMaterials.Items.Remove(item);

                    // 実際のファイルの削除処理
                    string path = System.IO.Path.Combine(data.MaterialDirectory, m.Path);
                    System.IO.File.Delete(path);

                    string subPath = System.IO.Path.Combine(data.MaterialDirectory, m.SubLayerPath);
                    if (System.IO.File.Exists(subPath))
                    {
                        System.IO.File.Delete(subPath);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
#endif
        }

        /// <summary>
        /// 現在選択されているマテリアルリストを取得する。
        /// 
        /// 選択されているマテリアルリストが存在しない場合にはnullが返る。
        /// </summary>
        /// <returns></returns>
        private MaterialList getCurrentMaterialList()
        {
            return getMaterialList(getCurrentNodeName());
        }

        private string getCurrentNodeName()
        {
            TreeNode node = treeViewMaterials.SelectedNode;
            return (node != null) ? node.Name : "";
        }

        private MaterialList getMaterialList(string name)
        {
            AppData data = AppData.GetInstance();
            return data.getMaterialList(name);
        }
    }
}
