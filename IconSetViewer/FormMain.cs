using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IconSetViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ドラッグ&ドロップされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormDragDrop(object sender, DragEventArgs evt)
        {
            string[] fileNames = (string[])(evt.Data.GetData(DataFormats.FileDrop, false));
            try
            {
                SetNewIconImage(fileNames[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        /// <summary>
        /// ドラッグされてきた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormDragEnter(object sender, DragEventArgs evt)
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
        /// オープンメニューがクリックされた。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMenuOpenClick(object sender, EventArgs evt)
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
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        /// <summary>
        /// 終了メニューがクリックされた。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnExitMenuClick(object sender, EventArgs evt)
        {
            Close();
        }

        /// <summary>
        /// コンボボックスのテキスト入力が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnComboBoxNumberTextUpdate(object sender, EventArgs evt)
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
                }
            }
            catch (Exception e)
            {
                iconViewControl.Number = -1;
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private void SetNewIconImage(string filePath)
        {
            using (Image image = Image.FromFile(filePath))
            {
                iconViewControl.Image = (Image)(image.Clone());

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
                }

                // 有効・無効状態を更新する。
                comboBoxNumber.Enabled = (comboBoxNumber.Items.Count > 0);
            }

        }

        /// <summary>
        /// ドロップダウンリストでの番号選択がされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnComboBoxNumberSelectionChangeCommitted(object sender, EventArgs evt)
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
            }
            catch (Exception e)
            {
                iconViewControl.Number = -1;
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
