using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.MainForm
{
    public partial class VersionForm : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public VersionForm()
        {
            InitializeComponent();

            labelApplicationName.Text = Application.ProductName;
            labelApplicationVersion.Text = $"Version.{Application.ProductVersion}";
        }

        /// <summary>
        /// 閉じるボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
