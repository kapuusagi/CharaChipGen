using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.ColorEditForm
{
    public partial class ColorEditForm : Form
    {
        // デフォルトタイトル
        private const string DefaultTitle = "Color Selection";


        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static new Color ShowDialog()
            => ShowDialog(null, Color.Black, DefaultTitle);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="defaultColor">デフォルト色</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(Color defaultColor)
            => ShowDialog(null, defaultColor, DefaultTitle);


        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="defaultColor">デフォルト色</param>
        /// <param name="prompt">メッセージ</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(Color defaultColor, string prompt)
            => ShowDialog(null, defaultColor, prompt);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static new Color ShowDialog(IWin32Window owner)
            => ShowDialog(owner, Color.Black, DefaultTitle);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="defaultColor">デフォルト色</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(IWin32Window owner, Color defaultColor)
            => ShowDialog(owner, defaultColor, DefaultTitle);

        /// <summary>
        /// 色選択ダイアログを表示する。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="defaultColor">デフォルト色</param>
        /// <param name="prompt">メッセージ</param>
        /// <returns>選択された色が返る。キャンセルされた場合にはdefaultColorが返る。</returns>
        public static Color ShowDialog(IWin32Window owner, Color defaultColor, string prompt)
        {
            ColorEditForm form = new ColorEditForm();
            form.Text = prompt;
            form.Color = defaultColor;
            if (owner != null)
            {
                form.Show(owner);
            }
            else
            {
                form.Show();
            }

            return (form.DialogResult == DialogResult.OK) ? form.Color : defaultColor;
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ColorEditForm()
        {
            Color = Color.Black;
            InitializeComponent();
        }

        /// <summary>
        /// 選択されている色
        /// </summary>
        public Color Color {
            get; set;
        }

        /// <summary>
        /// OKボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonOKClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// フォームが閉じられようとしているときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
