using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageStacker
{
    public partial class FormMain : Form
    {
        // レイヤーセット
        private LayerSet layerSet;
        // マウスドラッグしているか
        private bool isLayerSetMouseDragging;
        // レイヤー位置調整モードかどうか。
        private bool isLayerSetAdjustMode;
        // レイヤードラッグ開始位置
        private Point layerSetDragLocation;

        /// <summary>
        /// 新しいFormMainを構築する。
        /// </summary>
        public FormMain()
        {
            layerSet = new LayerSet();
            isLayerSetMouseDragging = false;
            isLayerSetAdjustMode = false;
            layerSetDragLocation = new Point(0, 0);
            InitializeComponent();
            layerSet.Added += OnLayerAdded;
            layerSet.Removed += OnLayerRemoved;
            layerSetViewControl.LayerSet = layerSet;
        }

        /// <summary>
        /// EXITメニュー項目がクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemExitClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// フォームが閉じられようとしている時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Exportメニュー項目がクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemExportClick(object sender, EventArgs e)
        {
            try
            {
                ExportProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        /// <summary>
        /// エクスポートボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonExportClick(object sender, EventArgs e)
        {
            try
            {
                ExportProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }


        /// <summary>
        /// エクスポート操作されたときの処理を行う。
        /// </summary>
        private void ExportProc()
        {
            if (layerSet.Count == 0)
            {
                // レイヤーがないから何もしない。
                return;
            }

            var lastSaveFileName = Properties.Settings.Default.LastSavePath;
            if (System.IO.File.Exists(lastSaveFileName))
            {
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastSaveFileName);
                saveFileDialog.FileName = lastSaveFileName;
            }
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Properties.Settings.Default.LastSavePath = saveFileDialog.FileName;

            var renderer = layerSetViewControl.GetRenderer();
            var renderImage = renderer.GetRenderImage();
            renderImage.Save(saveFileDialog.FileName);
        }

        /// <summary>
        /// 追加ボタンがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                var lastOpenedFileName = Properties.Settings.Default.LastOpenPath;
                if (System.IO.File.Exists(lastOpenedFileName))
                {
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastOpenedFileName);
                    openFileDialog.FileName = lastOpenedFileName;
                }
                if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                string fileName = openFileDialog.FileName;
                AddNewLayer(fileName);
                Properties.Settings.Default.LastOpenPath = fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// 新しいレイヤーを追加する。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        private void AddNewLayer(string fileName)
        {
            var layer = new LayerEntry();
            layer.FileName = fileName;
            layerSet.Add(layer);
        }

        /// <summary>
        /// レイヤーが追加された
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerAdded(object sender, LayerEventArgs e)
        {
            // Note: 並び替えするのとどっちが楽かな？
            var controls = panelLayerParent.Controls;
            for (int i = 0; i < layerSet.Count; i++)
            {
                if (i < controls.Count)
                {
                    var control = (LayerEntryControl)(controls[i]);
                    control.LayerEntry = layerSet.Get(i);
                }
                else
                {
                    var control = new LayerEntryControl();
                    control.UpButtonClick += OnLayerUpButtonClick;
                    control.DownButtonClick += OnLayerDownButtonClick;
                    control.DeleteButtonClick += OnLayerDeleteButtonClick;
                    control.LayerEntry = layerSet.Get(i);
                    control.BorderStyle = BorderStyle.FixedSingle;
                    controls.Add(control);
                    control.Dock = DockStyle.Bottom;
                }
            }
            UpdateLayerButtonEnable();
        }

        /// <summary>
        /// レイヤーが削除された。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerRemoved(object sender, LayerEventArgs e)
        {
            var controls = panelLayerParent.Controls;
            if (e.Index < controls.Count)
            {
                controls.RemoveAt(e.Index);
            }
            UpdateLayerButtonEnable();
        }

        /// <summary>
        /// レイヤーのボタン有効/無効を更新する。
        /// </summary>
        private void UpdateLayerButtonEnable()
        {
            var controls = panelLayerParent.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                var control = (LayerEntryControl)(controls[i]);
                control.UpButtonEnabled = (i != 0);
                control.DownButtonEnabled = (i != (controls.Count - 1));
            }
        }

        /// <summary>
        /// 上へボタンがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerUpButtonClick(object sender, EventArgs e)
        {
            var control = (LayerEntryControl)(sender);
            var layer = control.LayerEntry;
            layerSet.MoveUp(layer);
            UpdateLayerOrder();
        }
        /// <summary>
        /// 下へボタンがクリックされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLayerDownButtonClick(object sender, EventArgs e)
        {
            var control = (LayerEntryControl)(sender);
            var layer = control.LayerEntry;
            layerSet.MoveDown(layer);
            UpdateLayerOrder();
        }

        /// <summary>
        /// レイヤー順を更新する。
        /// </summary>
        private void UpdateLayerOrder()
        {
            var controls = panelLayerParent.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                var control = (LayerEntryControl)(controls[i]);
                control.LayerEntry = layerSet.Get(i);
            }
        }
        /// <summary>
        /// 削除ボタンがクリックされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLayerDeleteButtonClick(object sender, EventArgs e)
        {
            var control = (LayerEntryControl)(sender);
            layerSet.Remove(control.LayerEntry);
        }

        /// <summary>
        /// ドラッグ操作されてきたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDragEnter(object sender, DragEventArgs e)
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
        /// ファイルがドロップ操作されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        AddNewLayer(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message);
                    }
                }
            }
        }

        private void OnLayerSetViewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLayerSetMouseDragging = true;
                isLayerSetAdjustMode = (ModifierKeys & Keys.Control) == Keys.Control;
                layerSetDragLocation = Cursor.Position;

            }
        }

        private void OnLayerSetViewMouseUp(object sender, MouseEventArgs e)
        {
            isLayerSetMouseDragging = false;
            isLayerSetAdjustMode = false;
        }

        private void OnLayerSetViewMoseMove(object sender, MouseEventArgs e)
        {
            if (isLayerSetMouseDragging)
            {
                var location = Cursor.Position;
                var moveX = location.X - layerSetDragLocation.X;
                var moveY = location.Y - layerSetDragLocation.Y;
                if (isLayerSetAdjustMode)
                {

                }
                else
                {
                    // スクロールさせる。
                    if (moveX != 0)
                    {
                        var scrollH = panelPicture.HorizontalScroll;
                        var newX = scrollH.Value + moveX;
                        if (newX < scrollH.Minimum)
                        {
                            newX = scrollH.Minimum;
                        }
                        else if (newX > scrollH.Maximum)
                        {
                            newX = scrollH.Maximum;
                        }
                        //                        scrollH.Value = (newX < scrollH.Minimum) ? scrollH.Minimum : ((newX > scrollH.Maximum) ? scrollH.Maximum : newX);
                        scrollH.Value = newX;
                        System.Diagnostics.Debug.WriteLine($"move=({moveX},{scrollH.Value})");
                    }
                    //var scrollV = panelPicture.VerticalScroll;
                    //var newY = scrollV.Value - offsetY;
                    //scrollV.Value = (newY < scrollV.Minimum) ? scrollV.Minimum : ((newY > scrollV.Maximum) ? scrollV.Maximum : newY);


                }
                layerSetDragLocation = location;
            }
        }
    }
}
