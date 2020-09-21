using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGenImaging;

namespace RoundRect
{
    /// <summary>
    /// Main画面
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ボタンをクローズされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonClose(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// カラーラベルがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLabelColorClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            labelColor.BackColor = colorDialog.Color;
            try
            {
                UpdateImage();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// サイズが変更されたときの処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnSizeChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateImage();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// 更新する。
        /// </summary>
        private void UpdateImage()
        {
            int fillAreaWidth = (int)(numericUpDownWidth.Value);
            int fillAreaHeight = (int)(numericUpDownHeight.Value);
            int outlineWidth = (int)(numericUpDownOutline.Value);
            Color c = labelColor.BackColor;
            int width = fillAreaWidth + outlineWidth * 2;
            int height = fillAreaHeight + outlineWidth * 2;

            if ((width > 0) || (height > 0))
            {
                ImageBuffer imageBuffer = ImageBuffer.Create(width, height);
                PaintRoundRect(imageBuffer, outlineWidth, c);
                pictureBox.Image = imageBuffer.GetImage();
            }
            else
            {
                pictureBox.Image = null;
            }
        }

        /// <summary>
        /// RoundRectを描画する。
        /// </summary>
        /// <param name="imageBuffer">イメージバッファ</param>
        /// <param name="outlineWidth">アウトライン幅</param>
        /// <param name="color">色</param>
        private void PaintRoundRect(ImageBuffer imageBuffer, int outlineWidth, Color color)
        {
            Point leftTop = new Point(outlineWidth, outlineWidth);
            Point rightTop = new Point(imageBuffer.Width - outlineWidth, outlineWidth);
            Point leftBottom = new Point(outlineWidth, imageBuffer.Width - outlineWidth);
            Point rightBottom = new Point(imageBuffer.Width - outlineWidth, imageBuffer.Height - outlineWidth);

            for (int y = 0; y < outlineWidth; y++)
            {
                // 左上
                for (int x = 0; x < outlineWidth; x++)
                {
                    int a = GetAlpha(leftTop.X, leftTop.Y, x, y, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }
                // 上端
                int alphaY = GetAlpha(leftTop.Y, y, outlineWidth);
                Color colorY = Color.FromArgb(alphaY, color);
                for (int x = leftTop.X; x < rightTop.X; x++)
                {
                    imageBuffer.SetPixel(x, y, colorY);
                }

                // 右上
                for (int x = rightTop.X; x < imageBuffer.Width; x++)
                {
                    int a = GetAlpha(rightTop.X, rightTop.Y, x, y, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }
            }

            for (int y = leftTop.Y; y < leftBottom.Y; y++)
            {
                // 左端
                for (int x = 0; x < leftTop.X; x++)
                {
                    int a = GetAlpha(leftTop.X, x, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }

                // 中央矩形
                for (int x = leftTop.X; x < rightTop.X; x++)
                {
                    imageBuffer.SetPixel(x, y, color);
                }
                // 右端
                for (int x = rightTop.X; x < imageBuffer.Width; x++)
                {
                    int a = GetAlpha(rightTop.X, x, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }
            }

            for (int y = leftBottom.Y; y < imageBuffer.Height; y++)
            {
                // 左下
                for (int x = 0; x < leftBottom.X; x++)
                {
                    int a = GetAlpha(leftBottom.X, leftBottom.Y, x, y, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }

                // 下端
                int alphaY = GetAlpha(leftBottom.Y, y, outlineWidth);
                Color colorY = Color.FromArgb(alphaY, color);
                for (int x = leftBottom.X; x < rightBottom.X; x++)
                {
                    imageBuffer.SetPixel(x, y, colorY);
                }

                // 右下
                for (int x = rightBottom.X; x < imageBuffer.Width; x++)
                {
                    int a = GetAlpha(rightBottom.X, rightBottom.Y, x, y, outlineWidth);
                    Color c = Color.FromArgb(a, color);
                    imageBuffer.SetPixel(x, y, c);
                }
            }

        }

        /// <summary>
        /// アルファの値を得る。
        /// </summary>
        /// <param name="centerP">センター位置</param>
        /// <param name="pos">X位置</param>
        /// <param name="width">Y位置</param>
        /// <returns>アルファの値</returns>
        private int GetAlpha(int centerP, int pos, int width)
        {
            double r = Math.Abs((double)(pos - centerP) / (double)(width));
            int a = (int)(Math.Round((1.0 - r) * 255.0));
            return (a > 255) ? 255 : (a < 0) ? 0 : a;
        }

        /// <summary>
        /// アルファの値を得る。
        /// </summary>
        /// <param name="centerX">中央X位置</param>
        /// <param name="centerY">中央Y位置</param>
        /// <param name="x">X位置</param>
        /// <param name="y">Y位置</param>
        /// <param name="width">幅</param>
        /// <returns>アルファの値</returns>
        private int GetAlpha(int centerX, int centerY, int x, int y, int width)
        {
            double dis = Math.Sqrt((centerX - x) * (centerX - x) + (centerY - y) * (centerY - y));
            int a = (int)(Math.Round((1.0 - dis / width) * 255.0));
            return (a > 255) ? 255 : (a < 0) ? 0 : a;
        }

        /// <summary>
        /// フォームが表示されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnShown(object sender, EventArgs e)
        {
            try
            {
                UpdateImage();
            }
            catch
            {
                // do nothing.
            }
        }

        /// <summary>
        /// クリップボードにコピーが選択された。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCopyToCliboardClick(object sender, EventArgs e)
        {
            Image image = pictureBox.Image;
            Clipboard.SetImage(image);
        }

        /// <summary>
        /// Saveボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            try
            {
                Image image = pictureBox.Image;
                if (image == null)
                {
                    return;
                }
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                string path = saveFileDialog.FileName;
                image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show(this, ex.Message);
            }
        }
    }
}
