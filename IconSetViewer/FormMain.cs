using IconSetViewer.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace IconSetViewer
{
    public partial class FormMain : Form
    {
        private string editingFileName;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            editingFileName = "";
            InitializeComponent();
            panelScroll.BackColor = Settings.Default.ImageBackground;
            iconViewControl.BackColor = Settings.Default.ImageBackground;
            Settings.Default.PropertyChanged += OnSettingsPropertyChanged;
            iconSetViewControl.SelectedIndexChanged += OnIconSetViewControlSelectedIndexChanged;
            iconSetViewControl.IconSet = iconViewControl.IconSet;
        }

        /// <summary>
        /// アイコンセットビューで項目が選択変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnIconSetViewControlSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNumber.SelectedIndex = iconSetViewControl.SelectedIndex;
            iconViewControl.SelectedIndex = iconSetViewControl.SelectedIndex;

            UpdateControlEnables();
        }

        /// <summary>
        /// ドラッグ&ドロップされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormDragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
            try
            {
                Settings.Default.DirectoryIconSet = System.IO.Path.GetDirectoryName(fileNames[0]);
                editingFileName = System.IO.Path.GetFileName(fileNames[0]);
                SetNewIconImage(fileNames[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }

            UpdateControlEnables();
        }

        /// <summary>
        /// ドラッグされてきた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormDragEnter(object sender, DragEventArgs e)
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
        /// オープンメニューがクリックされた。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuOpenClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = Settings.Default.DirectoryIconSet;
                openFileDialog.FileName = string.Empty;
                if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                Settings.Default.DirectoryIconSet = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                editingFileName = System.IO.Path.GetFileName(openFileDialog.FileName);

                string fileName = openFileDialog.FileName;
                SetNewIconImage(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }

            UpdateControlEnables();
        }

        /// <summary>
        /// 終了メニューがクリックされた。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnExitMenuClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// コンボボックスのテキスト入力が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxNumberTextUpdate(object sender, EventArgs e)
        {
            try
            {
                string text = comboBoxNumber.Text;
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                int number = Convert.ToInt32(text);
                if ((number > 0) && (number <= iconViewControl.IconSet.IconCount))
                {
                    iconViewControl.SelectedIndex = number - 1;
                    iconSetViewControl.SelectedIndex = number - 1;
                }
            }
            catch (Exception ex)
            {
                iconViewControl.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 新しいアイコン画像を設定する。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        private void SetNewIconImage(string filePath)
        {
            IconSet iconSet = iconViewControl.IconSet;
            using (Image image = ReadImage(filePath))
            {
                iconSet.Image = (Image)(image.Clone());

                // イメージがセットできたら最大数(=コンボボックス)を更新
                int maxIconCount = iconSet.IconCount;
                comboBoxNumber.Items.Clear();
                for (int i = 0; i < maxIconCount; i++)
                {
                    string item = i.ToString();
                    comboBoxNumber.Items.Add(item);
                }

                // デフォルトを選択
                if (comboBoxNumber.Items.Count > 0)
                {
                    comboBoxNumber.SelectedIndex = 0;
                    iconSetViewControl.SelectedIndex = 0;
                }

                // 有効・無効状態を更新する。
                comboBoxNumber.Enabled = (comboBoxNumber.Items.Count > 0);
            }

        }
        /// <summary>
        /// pathで指定された画像を読み込む。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>Imageオブジェクト</returns>
        private static Image ReadImage(string path)
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(path))
            {
                return Image.FromStream(stream, false, false);
            }
        }
        /// <summary>
        /// ドロップダウンリストでの番号選択がされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxNumberSelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string text = (string)(comboBoxNumber.SelectedItem);
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                int number = Convert.ToInt32(text);
                iconViewControl.SelectedIndex = number;
                iconSetViewControl.SelectedIndex = number;
            }
            catch (Exception ex)
            {
                iconViewControl.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            UpdateControlEnables();
        }

        /// <summary>
        /// アイコン選択状態が変わった場合などに、コントロールの有効・無効を設定する。
        /// </summary>
        private void UpdateControlEnables()
        {
            IconSet iconSet = iconSetViewControl.IconSet;

            // TODO: 有効・無効設定が必要なものをここに書く。
            menuItemSave.Enabled = iconSet.IconCount > 0;
            menuItemSaveAs.Enabled = iconSet.IconCount > 0;
            buttonIconSave.Enabled = iconSetViewControl.SelectedIndex >= 0;
            buttonIconChange.Enabled = iconSetViewControl.SelectedIndex >= 0;
        }

        /// <summary>
        /// フォームが閉じられた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Settings.Default.Save();
            }
            catch { /* ここでのエラーは無視する */ }
        }

        /// <summary>
        /// アプリケーション設定のプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnSettingsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Settings.ImageBackground)))
            {
                panelScroll.BackColor = Settings.Default.ImageBackground;
                iconViewControl.BackColor = Settings.Default.ImageBackground;
            }
        }

        /// <summary>
        /// 表示背景色メニューがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemImageBackgroundClick(object sender, EventArgs e)
        {
            Color defaultColor = Settings.Default.ImageBackground;
            Color selectedColor = CGenImaging.Forms.ColorSelectDialog.ShowDialog(this, defaultColor);
            Settings.Default.ImageBackground = selectedColor;
        }

        /// <summary>
        /// アイコン保存ボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonIconSaveClick(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Settings.Default.DirectoryIcon;
            saveFileDialog.FileName = "icon.png";
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Settings.Default.DirectoryIcon = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);

            try
            {
                string path = saveFileDialog.FileName;
                IconSet iconSet = iconSetViewControl.IconSet;
                Image originalImage = iconSet.Image;
                Rectangle region = iconSet.GetIconRegion(iconSetViewControl.SelectedIndex);
                using (Bitmap saveImage = new Bitmap(region.Width, region.Height, originalImage.PixelFormat))
                {
                    using (Graphics g = Graphics.FromImage(saveImage))
                    {
                        g.DrawImage(originalImage, new Rectangle(0, 0, region.Width, region.Height), region,
                            GraphicsUnit.Pixel);
                        saveImage.Save(path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }

        }

        /// <summary>
        /// アイコン変更ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonIconChangeClick(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Settings.Default.DirectoryIcon;
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Settings.Default.DirectoryIcon = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

            try
            {
                // Note: Graphicsでやろうとしたが、部分クリアの方法がうまくいかなかったため、
                // ImageBufferを使用する実装に変更した。
                // (FillRectで透過色設定はできなかった)
                IconSet iconSet = iconSetViewControl.IconSet;
                int selectedIndex = iconSetViewControl.SelectedIndex;
                string path = openFileDialog.FileName;

                using (Image srcImage = ReadImage(path))
                {
                    Rectangle region = iconSet.GetIconRegion(selectedIndex);

                    // コピー先領域クリア
                    var imageBuffer = CGenImaging.ImageBuffer.CreateFrom(iconSet.Image);
                    for (int y = region.Top; y < region.Bottom; y++)
                    {
                        for (int x = region.Left; x < region.Right; x++)
                        {
                            imageBuffer.SetPixel(x, y, Color.Transparent);
                        }
                    }

                    // アイコン描画
                    var srcImageBuffer = CGenImaging.ImageBuffer.CreateFrom(srcImage);
                    int width = Math.Min(srcImageBuffer.Width, region.Width);
                    int height = Math.Min(srcImageBuffer.Height, region.Height);
                    int srcX = (srcImageBuffer.Width - width) / 2;
                    int srcY = (srcImageBuffer.Height - height) / 2;
                    int dstX = region.X + (region.Width - width) / 2;
                    int dstY = region.Y + (region.Height - width) / 2;

                    imageBuffer.WriteImage(srcImageBuffer, srcX, srcY, dstX, dstY, width, height);

                    iconSet.Image = imageBuffer.GetImage();
                    // 再設定されたのでインデックス戻す。
                    iconSetViewControl.SelectedIndex = selectedIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// 名前をつけて保存がクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemSaveAsClick(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Settings.Default.DirectoryIconSet;
            saveFileDialog.FileName = editingFileName;
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Settings.Default.DirectoryIconSet = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
            editingFileName = System.IO.Path.GetFileName(saveFileDialog.FileName);

            try
            {
                string path = saveFileDialog.FileName;
                Image image = iconSetViewControl.IconSet.Image;
                image.Save(path, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);
            }
        }

        /// <summary>
        /// 保存メニューが選択されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            try
            {
                string path = System.IO.Path.Combine(Settings.Default.DirectoryIconSet, editingFileName);
                Image image = iconSetViewControl.IconSet.Image;
                image.Save(path, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Resources.DialogTitleError);

            }
        }
    }
}
