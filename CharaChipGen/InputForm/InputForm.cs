using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.InputForm
{
    public partial class InputForm : Form
    {

        /// <summary>
        /// テキスト入力ダイアログを表示する。
        /// </summary>
        /// <param name="prompt">ダイアログに表示するメッセージ</param>
        /// <param name="title">タイトル</param>
        /// <returns>OKボタンが押された場合には入力された文字列が返る。
        /// OKボタンが押されなかった場合にはnullが返る。</returns>
        public static string ShowDialog(string prompt, string title)
            => ShowDialog(null, prompt, title, "", null);

        /// <summary>
        /// テキスト入力ダイアログを表示する。
        /// </summary>
        /// <param name="prompt">ダイアログに表示するメッセージ</param>
        /// <param name="title">タイトル</param>
        /// <param name="defaultText">デフォルト値</param>
        /// <returns>OKボタンが押された場合には入力された文字列が返る。
        /// OKボタンが押されなかった場合にはnullが返る。</returns>
        public static string ShowDialog(string prompt, string title, string defaultText)
            => ShowDialog(null, prompt, title, defaultText, null);

        /// <summary>
        /// テキスト入力ダイアログを表示する。
        /// </summary>
        /// <param name="owner">モーダルダイアログのオーナー</param>
        /// <param name="prompt">ダイアログに表示するメッセージ</param>
        /// <param name="title">タイトル</param>
        /// <returns>OKボタンが押された場合には入力された文字列が返る。
        /// OKボタンが押されなかった場合にはnullが返る。</returns>
        public static string ShowDialog(IWin32Window owner, string prompt, string title)
            => ShowDialog(owner, prompt, title, "", null);

        /// <summary>
        /// テキスト入力ダイアログを表示する。
        /// </summary>
        /// <param name="owner">モーダルダイアログのオーナー</param>
        /// <param name="prompt">ダイアログに表示するメッセージ</param>
        /// <param name="title">タイトル</param>
        /// <param name="defaultText">デフォルト値</param>
        /// <returns>OKボタンが押された場合には入力された文字列が返る。
        /// OKボタンが押されなかった場合にはnullが返る。</returns>
        public static string ShowDialog(IWin32Window owner, string prompt, string title, string defaultText)
            => ShowDialog(owner, prompt, title, defaultText, null);


        /// <summary>
        /// テキスト入力ダイアログを表示する。
        /// </summary>
        /// <param name="owner">モーダルダイアログのオーナー</param>
        /// <param name="prompt">ダイアログに表示するメッセージ</param>
        /// <param name="title">タイトル</param>
        /// <param name="defaultText">デフォルト値</param>
        /// <param name="location">表示位置（既定はnull）</param>
        /// <returns>OKボタンが押された場合には入力された文字列が返る。
        /// OKボタンが押されなかった場合にはnullが返る。</returns>
        public static string ShowDialog(IWin32Window owner, string prompt, string title, string defaultText, Point? location)
        {
            InputForm inputForm = new InputForm();
            inputForm.Prompt = prompt;
            inputForm.Text = title;
            inputForm.InputText = defaultText;
            if (location != null)
            {
                inputForm.Location = (Point)(location);
            }

            if (owner != null)
            {
                inputForm.ShowDialog(owner);
            }
            else
            {
                inputForm.ShowDialog();
            }

            return (inputForm.DialogResult == DialogResult.OK) ? inputForm.InputText : null;
        }


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public InputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示文字列
        /// </summary>
        public string Prompt {
            get => labelPrompt.Text;
            set => labelPrompt.Text = value;
        }

        /// <summary>
        /// 入力文字列
        /// </summary>
        public string InputText {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        /// <summary>
        /// OKボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonOKClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
