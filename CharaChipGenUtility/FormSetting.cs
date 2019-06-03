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

namespace CharaChipGenUtility
{
    public partial class FormSetting : Form
    {
        private IOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormSetting()
        {
            InitializeComponent();
            UpdateSettingControl();
        }

        /// <summary>
        /// オペレーション設定
        /// </summary>
        public IOperationSetting Setting {
            get {
                return setting;
            }
            set {
                setting = value;
                UpdateSettingControl();
            }
        }

        /// <summary>
        /// UIのコントロールを更新する。
        /// </summary>
        private void UpdateSettingControl()
        {
            panelMain.Controls.Clear();
            if (Setting == null)
            {
                return;
            }
            else
            {
                Control control = Setting.GetControl();
                panelMain.Controls.Add(control);
                control.Dock = DockStyle.Top;
            }
        }

        /// <summary>
        /// フォームが表示された時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs evt)
        {
        }

        /// <summary>
        /// 閉じるボタンが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonCloseClick(object sender, EventArgs evt)
        {
            Close();
        }
    }
}
