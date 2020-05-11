using System;
using System.Drawing;
using System.Windows.Forms;

namespace IconSetViewer
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            iconSetViewControl.SelectedIndexChanged += OnIconSetViewControlSelectedIndexChanged;
        }

        /// <summary>
        /// アイコンセットビューで項目が選択変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnIconSetViewControlSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNumber.SelectedIndex = iconSetViewControl.SelectedIndex;
            iconViewControl.Number = iconSetViewControl.SelectedIndex;
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
                SetNewIconImage(fileNames[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
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
                if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                string fileName = openFileDialog.FileName;
                SetNewIconImage(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
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
                if ((number > 0) && (number <= iconViewControl.MaxIconCount))
                {
                    iconViewControl.Number = number - 1;
                    iconSetViewControl.SelectedIndex = number - 1;
                }
            }
            catch (Exception ex)
            {
                iconViewControl.Number = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 新しいアイコン画像を設定する。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        private void SetNewIconImage(string filePath)
        {
            using (Image image = Image.FromFile(filePath))
            {
                iconViewControl.Image = (Image)(image.Clone());
                iconSetViewControl.IconSetImage = iconViewControl.Image;

                // イメージがセットできたら最大数(=コンボボックス)を更新
                int maxIconCount = iconViewControl.MaxIconCount;
                comboBoxNumber.Items.Clear();
                for (int i = 0; i < maxIconCount; i++)
                {
                    string item = (i + 1).ToString();
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
                iconViewControl.Number = (number - 1);
                iconSetViewControl.SelectedIndex = (number - 1);
            }
            catch (Exception ex)
            {
                iconViewControl.Number = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
