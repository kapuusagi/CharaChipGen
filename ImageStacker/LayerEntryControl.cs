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
        /// <summary>
        /// 新しいLayerEntryControlを構築する。
        /// </summary>
        public LayerEntryControl()
        {
            layerEntry = null;
            imageFileName = string.Empty;
            InitializeComponent();
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
            // TODO : 表示を更新する。

            labelFileName.Text = (layerEntry != null) ? System.IO.Path.GetFileName(layerEntry.FileName) : string.Empty;
            numericUpDownX.Value = (layerEntry != null) ? layerEntry.OffsetX : 0;
            numericUpDownY.Value = (layerEntry != null) ? layerEntry.OffsetY : 0;
            checkBoxSelect.Checked = (layerEntry != null) ? layerEntry.Selected : false;


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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonDownClick(object sender, EventArgs e)
        {
            DownButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
