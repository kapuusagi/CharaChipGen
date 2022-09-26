using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FImageEditor
{
    public partial class FaceViewControl : UserControl
    {
        // モデル
        private FaceImageEntry entry;
        // 画像ファイル名
        private string imageFileName;
        // ピクチャがドラッグされているかどうか
        private bool isPictureDragging;
        // ピクチャドラッグ時の位置
        private Point pictureDragStartPosition;

        /// <summary>
        /// 新しいFaceViewControlを構築する。
        /// </summary>
        public FaceViewControl()
        {
            entry = null;
            imageFileName = string.Empty;
            isPictureDragging = false;
            pictureDragStartPosition = new Point();
            InitializeComponent();
            UpdatePicturePosition();
        }

        /// <summary>
        /// 顔グラフィックエントリ
        /// </summary>
        public FaceImageEntry FaceImageEntry {
            get => entry;
            set {
                if (entry != value)
                {
                    if (entry != null)
                    {
                        entry.PropertyChanged -= OnFaceImageEntryChanged;
                    }
                    entry = value;
                    if (entry != null)
                    {
                        entry.PropertyChanged += OnFaceImageEntryChanged;
                    }
                    UpdateView();
                }
            }
        }

        /// <summary>
        /// データが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFaceImageEntryChanged(object sender, PropertyChangedEventArgs e)
        {
            try {
                UpdateView();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// 表示を更新する。
        /// </summary>
        private void UpdateView()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)UpdateView);
            }
            else
            {
                if (entry != null)
                {
                    labelFileName.Text = System.IO.Path.GetFileName(entry.FileName);
                    if (!imageFileName.Equals(entry.FileName))
                    {
                        SetImage(entry.FileName);
                    }
                    else
                    {
                        facePictureControl.ImageRect = new Rectangle(entry.X, entry.Y, entry.Width, entry.Height);
                        numericUpDownX.Value = entry.X;
                        numericUpDownY.Value = entry.Y;
                    }
                }
                else
                {
                    labelFileName.Text = string.Empty;
                }
            }
            buttonSelect.Enabled = (entry != null);
            numericUpDownX.Enabled = (entry != null);
            numericUpDownY.Enabled = (entry != null);
        }

        /// <summary>
        /// パネルのサイズが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPanelResized(object sender, EventArgs e)
        {
            UpdatePicturePosition();
        }

        /// <summary>
        /// 画像表示コンポーネントの位置とサイズを更新する。
        /// </summary>
        private void UpdatePicturePosition()
        {
            var parentSize = panelPictureParent.Size;
            var padding = panelPictureParent.Padding;
            var innerWidth = parentSize.Width - padding.Horizontal;
            var innerHeight = parentSize.Height - padding.Vertical;
            var pictureSize = Math.Min(innerWidth, innerHeight); // 正方形にする。
            var x = padding.Left + (innerWidth - pictureSize) / 2;
            var y = padding.Top + (innerHeight - pictureSize) / 2;
            facePictureControl.SetBounds(x, y, pictureSize, pictureSize);
        }

        /// <summary>
        /// 選択ボタンがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSelectClick(object sender, EventArgs e)
        {
            try
            {
                var lastOpenFile = Properties.Settings.Default.LastOpenPath;
                if (System.IO.File.Exists(lastOpenFile))
                {
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastOpenFile);
                }
                if (string.IsNullOrEmpty(entry.FileName))
                {
                    openFileDialog.FileName = Properties.Settings.Default.LastOpenPath;
                }
                else
                {
                    openFileDialog.FileName = entry.FileName;
                }

                if (openFileDialog.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                SetImage(openFileDialog.FileName);
                Properties.Settings.Default.LastOpenPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), ex.Message);
            }
        }

        /// <summary>
        /// 画像をエントリに設定する。
        /// </summary>
        /// <param name="fileName">ファイルパス</param>
        private void SetImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                imageFileName = string.Empty;
                facePictureControl.Image = null;
            }
            else
            {
                using (var image = Image.FromFile(fileName))
                {
                    if ((image.Width < entry.Width) || (image.Height < entry.Height))
                    {
                        throw new Exception($"Image size incorrect. [width={image.Width},height={image.Height}]");
                    }

                    int width = image.Width;
                    int height = image.Height;

                    var setImage = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using (var g = Graphics.FromImage(setImage))
                    {
                        g.DrawImage(image, 0, 0);
                    }

                    int maxX = width - entry.Width;
                    int maxY = height - entry.Height;
                    entry.X = Math.Min(entry.X, maxX);
                    entry.Y = Math.Min(entry.Y, maxY);
                    entry.FileName = fileName;
                    imageFileName = entry.FileName;

                    numericUpDownX.Maximum = maxX;
                    numericUpDownY.Maximum = maxY;
                    numericUpDownX.Value = entry.X;
                    numericUpDownY.Value = entry.Y;

                    if (facePictureControl.Image != null)
                    {
                        var prevImage = facePictureControl.Image;
                        facePictureControl.Image = null;
                        prevImage.Dispose();
                    }
                    facePictureControl.Image = setImage;
                    facePictureControl.ImageRect = new Rectangle(entry.X, entry.Y, entry.Width, entry.Height);
                }
            }
            numericUpDownX.Enabled = facePictureControl.Image != null;
            numericUpDownY.Enabled = facePictureControl.Image != null;
        }

        /// <summary>
        /// 値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (sender == numericUpDownX)
            {
                entry.X = (int)(numericUpDownX.Value);
            }
            else if (sender == numericUpDownY)
            {
                entry.Y = (int)(numericUpDownY.Value);
            }
        }

        /// <summary>
        /// ピクチャボックスでマウスボタンが押されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPictureDragging = true;
                pictureDragStartPosition = e.Location;
            }

        }

        /// <summary>
        /// ピクチャボックスでマウスボタンが放されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            isPictureDragging = false;
        }

        /// <summary>
        /// ピクチャボックスでマウスが移動したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (isPictureDragging)
            {
                var mouseLocation = e.Location;
                int moveX = mouseLocation.X - pictureDragStartPosition.X;
                int moveY = mouseLocation.Y - pictureDragStartPosition.Y;

                if (entry != null)
                {
                    var maxX = (int)(numericUpDownX.Maximum);
                    var maxY = (int)(numericUpDownY.Maximum);
                    var x = entry.X - moveX;
                    var y = entry.Y - moveY;
                    entry.X = (x < 0) ? 0 : ((x > maxX) ? maxX : x);
                    entry.Y = (y < 0) ? 0 : ((y > maxY) ? maxY : y);
                }

                pictureDragStartPosition = mouseLocation;
            }
        }

        /// <summary>
        /// ドラッグ操作された状態でドラッグ対象に移動してきたときに通知を受け取る。
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
        /// ドラッグ操作された状態でドロップされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop));
                    SetImage(files[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), ex.Message);
            }
        }
    }
}
