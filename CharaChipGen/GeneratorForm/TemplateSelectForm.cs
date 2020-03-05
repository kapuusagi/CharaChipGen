using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// テンプレート選択フォーム
    /// </summary>
    public partial class TemplateSelectForm : Form
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public TemplateSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームが最初に表示されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            comboBoxTemplate.Items.Clear();
            var templateEntries = AppData.Instance.CharacterTemplates;
            if (templateEntries.Count > 0)
            {
                comboBoxTemplate.Items.AddRange(templateEntries.Select((entry) => entry.Key).ToArray()); ;
                comboBoxTemplate.SelectedIndex = 0;
            }

            buttonOK.Enabled = comboBoxTemplate.Items.Count > 0;
        }

        /// <summary>
        /// OKボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonOKClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// テンプレート名
        /// </summary>
        public string TemplateName {
            get => comboBoxTemplate.SelectedItem as string;
            set => comboBoxTemplate.SelectedItem = value;
        }
    }
}
