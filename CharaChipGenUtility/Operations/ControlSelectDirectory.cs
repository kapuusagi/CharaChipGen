using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// ディレクトリ選択コントロール
    /// </summary>
    public partial class ControlSelectDirectory : UserControl
    {
        private FolderSelectDialog folderSelectDialog;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ControlSelectDirectory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選択名
        /// </summary>
        public string SelectName {
            get { return labelSelectName.Text; }
            set {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => { labelSelectName.Text = value; }));
                }
                else
                {
                    labelSelectName.Text = value;
                }
            }
        }

        /// <summary>
        /// ディレクトリ
        /// </summary>
        public string Directory {
            get { return textBoxDirectory.Text; }
            set {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => { textBoxDirectory.Text = value; }));
                }
                else
                {
                    textBoxDirectory.Text = value;
                }
            }
        }

        /// <summary>
        /// フォルダ選択ボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonSelectFolderClick(object sender, EventArgs evt)
        {
            try
            {
                if (folderSelectDialog == null)
                {
                    folderSelectDialog = new FolderSelectDialog();
                    folderSelectDialog.Title = "フォルダ選択";
                    folderSelectDialog.Path = textBoxDirectory.Text;
                }

                DialogResult res = folderSelectDialog.ShowDialog(this.FindForm());
                if (res != DialogResult.OK)
                {
                    return;
                }
                if (textBoxDirectory.Text.Equals(folderSelectDialog.Path))
                {
                    // 変更なし。
                    return;
                }
                textBoxDirectory.Text = folderSelectDialog.Path;
                // Note: イベントはtextBoxDirectoryから出されるので特に通知しない。
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// テキストボックスの内容が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnTextBoxTextChanged(object sender, EventArgs evt)
        {
            NotifyPropertyChange("Directory");
        }

        /// <summary>
        /// プロパティが変更された時に通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 設定が変更されたときに通知を受け取る。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
