using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGenUtility.Operations;
using CharaChipGenUtility.Imaging;

namespace CharaChipGenUtility
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// D&Dにてドラッグされてきたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void OnPanelAcceptDragEnter(object sender, DragEventArgs evt)
        {
            if (evt.Data.GetDataPresent(DataFormats.FileDrop))
            {
                evt.Effect = DragDropEffects.Copy;
            }
            else
            {
                evt.Effect = DragDropEffects.None;
            } 

        }

        /// <summary>
        /// D&Dにて放り込まれた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnPanelAcceptDragDrop(object sender, DragEventArgs evt)
        {
            try
            {
                string[] fileNames = (string[])(evt.Data.GetData(DataFormats.FileDrop, false));
                string dir = Properties.Settings.Default.SaveDirectory;
                if (!System.IO.Directory.Exists(dir))
                {
                    dir = System.IO.Directory.GetCurrentDirectory();
                }

                IImageOperation operation = (IImageOperation)(comboBoxOperation.SelectedItem);
                foreach (string fileName in fileNames)
                {
                    Task.Run(() => DoImageProcess(fileName, dir, operation));
                }
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(this, ae.InnerException.Message, "エラー");
                System.Diagnostics.Debug.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 画像に対して処理を行う。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="saveDir">保存先ディレクトリ</param>
        /// <param name="operation">処理</param>
        private void DoImageProcess(string path, string saveDir, IImageOperation operation)
        {
            // 画像読み出し。
            Image srcImage = Image.FromFile(path);
            ImageBuffer src = ImageBuffer.CreateFrom(srcImage);
            srcImage.Dispose();

            // 処理
            ImageBuffer result = operation.Process(src);

            // 保存
            string fileName = System.IO.Path.GetFileName(path);
            string saveFilePath = System.IO.Path.Combine(saveDir, fileName);
            Image dstImage = result.GetImage();
            dstImage.Save(saveFilePath, System.Drawing.Imaging.ImageFormat.Png);
            dstImage.Dispose();
        }

        /// <summary>
        /// メニューボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonMenuClick(object sender, EventArgs evt)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog(this);
        }

        /// <summary>
        /// 画面が表示された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs evt)
        {
            comboBoxOperation.Items.Clear();
            comboBoxOperation.Items.AddRange(new IImageOperation[] {
                new EmptyOperation(),
                new ExtendX2(),
                new SmartExtendX2(),
            });


            comboBoxOperation.SelectedIndex = 0;
        }
    }
}
