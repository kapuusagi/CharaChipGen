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
    /// <summary>
    /// 1つのレイヤーエントリコントロール
    /// </summary>
    public partial class LayerEntryControl : UserControl
    {
        // レイヤーエントリモデル
        private LayerEntry layerEntry;
        // 画像ファイル名
        private string imageFileName;
        // 選択状態での背景色
        private Color selectedBackColor;
        /// <summary>
        /// 新しいLayerEntryControlを構築する。
        /// </summary>
        public LayerEntryControl()
        {
            layerEntry = null;
            selectedBackColor = Color.Aqua;
            imageFileName = string.Empty;
            InitializeComponent();
        }

        public override Color BackColor { 
            get => base.BackColor;
            set {
                base.BackColor = value;
                panelBackground.BackColor = (checkBoxSelect.Checked) ? SelectedBackColor : BackColor;
            }
        }

        
        public Color SelectedBackColor {
            get => selectedBackColor;
            set {
                if (!selectedBackColor.Equals(value))
                {
                    selectedBackColor = value;
                    panelBackground.BackColor = (checkBoxSelect.Checked) ? SelectedBackColor : BackColor;
                }
            }
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        public event EventHandler DeleteButtonClick;
        /// <summary>
        /// 上ボタンクリック
        /// </summary>
        public event EventHandler UpButtonClick;
        /// <summary>
        /// 下ボタンクリック
        /// </summary>
        public event EventHandler DownButtonClick;

        /// <summary>
        /// レイヤーエントリ
        /// </summary>
        [Browsable(false)]
        public LayerEntry LayerEntry {
            get => layerEntry;
            set {
                if (layerEntry != value)
                {
                    if (layerEntry != null)
                    {
                        layerEntry.PropertyChanged -= OnPropertyChanged;
                    }
                    layerEntry = value;
                    if (layerEntry != null)
                    {
                        layerEntry.PropertyChanged += OnPropertyChanged;
                    }
                    UpdateView();
                }
            }
        }
        /// <summary>
        /// プロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateView();
        }

        /// <summary>
        /// 表示を更新する。
        /// </summary>
        private void UpdateView()
        {
            // 表示を更新する。
            if (layerEntry != null)
            {
                labelFileName.Text = System.IO.Path.GetFileName(layerEntry.FileName);
                if ((layerEntry.OffsetX < numericUpDownX.Minimum) || (layerEntry.OffsetX > numericUpDownX.Maximum))
                {
                    System.Diagnostics.Debug.WriteLine("layerOffsetX illegal. " + layerEntry.OffsetX);
                }
                if ((layerEntry.OffsetY < numericUpDownY.Minimum) || (layerEntry.OffsetY > numericUpDownY.Maximum))
                {
                    System.Diagnostics.Debug.WriteLine("layerOffsetY illegal. " + layerEntry.OffsetY);
                }


                numericUpDownX.Value = Math.Max(numericUpDownX.Minimum, Math.Min(numericUpDownX.Maximum, layerEntry.OffsetX));
                numericUpDownY.Value = Math.Max(numericUpDownY.Minimum, Math.Min(numericUpDownY.Maximum, layerEntry.OffsetY));
                checkBoxSelect.Checked = layerEntry.Selected;
                panelBackground.BackColor = (checkBoxSelect.Checked) ? SelectedBackColor : BackColor;
            }
            else
            {
                labelFileName.Text = string.Empty;
                numericUpDownX.Value = 0;
                numericUpDownY.Value = 0;
                checkBoxSelect.Checked = false;
                panelBackground.BackColor = BackColor;
            }

            try
            {
                if (!imageFileName.Equals(layerEntry.FileName))
                {
                    pictureBox.Image = Image.FromFile(layerEntry.FileName);
                    imageFileName = layerEntry.FileName;
                }
            }
            catch (Exception ex)
            {
                // do nothing.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 削除ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// 下へボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonDownClick(object sender, EventArgs e)
        {
            DownButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// 上へボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonUpperClick(object sender, EventArgs e)
        {
            UpButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// アップボタンが有効かどうか
        /// </summary>
        public bool UpButtonEnabled {
            get => buttonUp.Enabled;
            set {
                if (buttonUp.Enabled != value)
                {
                    buttonUp.Enabled = value;
                }
            }
        }
        /// <summary>
        /// ダウンボタンが有効かどうか
        /// </summary>
        public bool DownButtonEnabled {
            get => buttonDown.Enabled;
            set {
                if (buttonDown.Enabled != value)
                {
                    buttonDown.Enabled = value;
                }
            }
        }

        /// <summary>
        /// チェックボックスがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCheckBoxClick(object sender, EventArgs e)
        {
            if (LayerEntry != null)
            {
                var checkBox = (CheckBox)(sender);
                LayerEntry.Selected = !checkBox.Checked;
            }
        }

        /// <summary>
        /// 数値入力ボックスの値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (LayerEntry != null)
            {
                if (sender == numericUpDownX)
                {
                    LayerEntry.OffsetX = (int)(numericUpDownX.Value);
                }
                else if (sender == numericUpDownY)
                {
                    LayerEntry.OffsetY = (int)(numericUpDownY.Value);
                }
            }
        }

        /// <summary>
        /// ドラッグ操作がコントロール領域に入ったときに通知を受け取る。
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
        /// ドロップ操作を受けたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
                if (layerEntry != null)
                {
                    layerEntry.FileName = fileNames[0];
                }
            }

        }

        /// <summary>
        /// パネルがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnClick(object sender, EventArgs e)
        {
            if (layerEntry != null)
            {
                layerEntry.Selected = !layerEntry.Selected;
            }
        }
    }
}
