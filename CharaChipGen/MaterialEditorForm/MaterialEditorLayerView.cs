﻿using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.Material;
using CharaChipGen.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// レイヤーのイメージを表示するためのビュー。
    /// </summary>
    public partial class MaterialEditorLayerView : UserControl
    {
        // エントリファイル
        private MaterialEntryFile entryFile;
        // レイヤー情報
        private MaterialLayerInfo layerInfo;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialEditorLayerView()
        {
            InitializeComponent();

            foreach (LayerType layerType in Enum.GetValues(typeof(LayerType)))
            {
                comboBoxLayerType.Items.Add(layerType);
            }

            comboBoxColorRefs.Items.Add(Properties.Resources.ItemNameUsePartsSetting);
            foreach (PartsType partsType in Enum.GetValues(typeof(PartsType)))
            {
                comboBoxColorRefs.Items.Add(partsType);
            }

            string[] colorPropertyNames = Parts.GetColorSettingNames();
            foreach (string colorPropertyName in colorPropertyNames)
            {
                comboBoxColorProperty.Items.Add(colorPropertyName);
            }
        }

        /// <summary>
        /// レイヤーの設定が変更された。
        /// </summary>
        public event EventHandler LayerChanged;

        /// <summary>
        /// レイヤーの設定が変更された時に通知する。
        /// </summary>
        private void NotifyLayerChanged()
        {
            LayerChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// レイヤー情報を設定する
        /// </summary>
        /// <param name="entryFile">エントリーファイル</param>
        /// <param name="layerInfo">レイヤー情報</param>
        public void SetLayerInfo(MaterialEntryFile entryFile, MaterialLayerInfo layerInfo)
        {
            this.entryFile = entryFile;
            this.layerInfo = layerInfo;
            ModelToUI();
        }


        /// <summary>
        /// レイヤー情報モデルの設定をUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            string fileName = "";
            Color fileNameColor = Color.Black;
            if ((entryFile == null) || (layerInfo == null))
            {
                SetImage(null);
            }
            else
            {
                string dir = System.IO.Path.GetDirectoryName(entryFile.Path);
                if (string.IsNullOrEmpty(layerInfo.Path))
                {
                    SetImage(null);
                }
                else
                {
                    // レイヤーにパスが設定されている
                    fileName = System.IO.Path.GetFileName(layerInfo.Path);
                    string path = System.IO.Path.Combine(dir, layerInfo.Path);
                    try
                    {
                        using (System.IO.Stream stream = System.IO.File.OpenRead(path))
                        {
                            SetImage(Image.FromStream(stream, false, false));
                        }
                    }
                    catch
                    {
                        fileNameColor = Color.Red;
                        SetImage(null);
                    }
                }
            }

            // 画像のパス
            labelFileName.Text = fileName;
            labelFileName.ForeColor = fileNameColor;
            // レイヤー名
            groupBoxLayerName.Text = layerInfo?.Name ?? "";
            // 描画するレイヤー
            SetLayerType(layerInfo?.LayerType ?? null);
            // カラー参照
            SetColorRefs(layerInfo?.ColorPartsRefs ?? null);
            SetColorPropertyName(layerInfo?.ColorPropertyName ?? null);
            // 色不変設定
            checkBoxColorImmutable.Checked = layerInfo.ColorImmutable;
            // 着色設定
            checkBoxColoring.Checked = layerInfo.Coloring;
        }

        /// <summary>
        /// レイヤー種別の設定をUIに反映させる。
        /// </summary>
        /// <param name="selValue">レイヤーの設定(null可)</param>
        private void SetLayerType(LayerType? selValue)
        {
            if (selValue == null)
            {
                comboBoxLayerType.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < comboBoxLayerType.Items.Count; i++)
                {
                    if (comboBoxLayerType.Items[i].Equals(selValue))
                    {
                        comboBoxLayerType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 色参照部品設定をUIに反映させる。
        /// </summary>
        /// <param name="selValue">レイヤーの設定(null可)</param>
        private void SetColorRefs(PartsType? selValue)
        {
            if (selValue == null)
            {
                comboBoxColorRefs.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < comboBoxColorRefs.Items.Count; i++)
                {
                    if (comboBoxColorRefs.Items[i].Equals(selValue))
                    {
                        comboBoxColorRefs.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 色プロパティ名選択をpropertyNameで指定された値に選択状態とする。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void SetColorPropertyName(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                comboBoxColorProperty.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < comboBoxColorProperty.Items.Count; i++)
                {
                    if (comboBoxColorProperty.Items[i].Equals(propertyName))
                    {
                        comboBoxColorProperty.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// イメージを設定する。
        /// </summary>
        /// <param name="image">イメージ</param>
        private void SetImage(Image image)
        {
            materialView4x3.Image = image;

            int width = image?.Width ?? 0;
            int height = image?.Height ?? 0;
            int subImageWidth = width / 3;
            int subImageHeight = height / 4;

            labelPictureSize.Text = $"{width} x {height} pixels";
            labelCharaSize.Text = $"{subImageWidth} x {subImageHeight} pixels";

        }


        /// <summary>
        /// レイヤーファイルを開くボタン
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnOpenButtonClicked(object sender, EventArgs e)
        {
            string entryFileDir = System.IO.Path.GetDirectoryName(entryFile.Path);
            openFileDialog.InitialDirectory = entryFileDir;
            if (!string.IsNullOrEmpty(layerInfo.Path))
            {
                if (System.IO.Path.IsPathRooted(layerInfo.Path))
                {
                    // 絶対パス指定(編集中) 
                    openFileDialog.FileName = layerInfo.Path;
                }
                else
                {
                    // 相対パス(確定済み)
                    string path = System.IO.Path.Combine(entryFileDir, layerInfo.Path);
                    openFileDialog.FileName = path;
                }
            }
            else
            {
                openFileDialog.FileName = null;
            }
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            try
            {
                layerInfo.Path = openFileDialog.FileName;
                ModelToUI();
                NotifyLayerChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// レイヤー種別の選択が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxLayerTypeSelectedValueChanged(object sender, EventArgs e)
        {
            if (layerInfo == null)
            {
                return;
            }

            ComboBox comboBox = (ComboBox)(sender);
            if (comboBox.SelectedItem != null)
            {
                layerInfo.LayerType = (LayerType)(comboBox.SelectedItem);
                NotifyLayerChanged();
            }
        }

        /// <summary>
        /// 色参照コンボボックスの選択が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxColorRefsSelectedValueChanged(object sender, EventArgs e)
        {
            if (layerInfo == null)
            {
                return;
            }

            ComboBox comboBox = (ComboBox)(sender);
            object selectedItem = comboBox.SelectedItem;
            if ((selectedItem != null) && (selectedItem is PartsType partsType))
            {
                layerInfo.ColorPartsRefs = partsType;
            }
            else
            {
                layerInfo.ColorPartsRefs = null;
            }
            NotifyLayerChanged();
        }

        /// <summary>
        /// 色不変設定チェックボックスの選択状態が変化したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCheckBoxColorImmutableCheckedChanged(object sender, EventArgs e)
        {
            layerInfo.ColorImmutable = checkBoxColorImmutable.Checked;
        }

        /// <summary>
        /// 画像表示背景色
        /// </summary>
        public Color ImageBackground {
            get => materialView4x3.ImageBackground;
            set => materialView4x3.ImageBackground = value;
        }

        /// <summary>
        /// 色プロパティ名選択コンボボックスの選択状態が変わったときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxColorPropertySelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerInfo == null)
            {
                return;
            }

            ComboBox comboBox = (ComboBox)(sender);
            object selectedItem = comboBox.SelectedItem;
            if ((selectedItem != null) && (selectedItem is string propertyName))
            {
                layerInfo.ColorPropertyName = propertyName;
            }
            else
            {
                layerInfo.ColorPropertyName = string.Empty;
            }
            NotifyLayerChanged();
        }

        /// <summary>
        /// Coloringチェックボックスの選択が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCheckBoxColoringCheckedChanged(object sender, EventArgs e)
        {
            layerInfo.Coloring = checkBoxColoring.Checked;
        }

        /// <summary>
        /// ファイルがドラッグされてきたときに通知を受け取る。
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
        /// ファイルがドロップされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
                layerInfo.Path = fileNames[0];
                ModelToUI();
                NotifyLayerChanged();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }

        }
    }
}
