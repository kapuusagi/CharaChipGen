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
                textBoxDirectory.Text = folderSelectDialog.Path;

                DirectoryChanged?.Invoke(textBoxDirectory.Text);
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
            DirectoryChanged?.Invoke(textBoxDirectory.Text);
        }

        /// <summary>
        /// ディレクトリが変更された時に通知を受け取る。
        /// </summary>
        public event Action<string> DirectoryChanged;
    }
}
