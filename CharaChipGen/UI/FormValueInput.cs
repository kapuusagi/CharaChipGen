using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.UI
{
    /// <summary>
    /// NumericUpDownの下にトラックバーを表示させてドラッグで調整するためのフォーム。
    /// なんだけど,ToolStripDropDownを使うともっと簡単にできた。
    /// </summary>
    /// <remarks>
    /// ToolStripDropDownを使う場合。
    /// 
    /// インスタンス生成
    ///     ToolStripDropDown dropDown = new TooLStripDropDown();
    ///     TrackBar trackBar = new TrackBar();
    ///     dropDown.Items.Add(new ToolStripControlHost(trackBar));
    /// 
    /// 表示時
    ///     dropDown.Show(control.PointToScreen(control.Location));
    ///     
    /// うはぁ簡単にできてしまう。
    /// </remarks>
    /// 
    public partial class FormValueInput : Form
    {
        /// <summary>
        /// nudで指定されるコントロールの下にちょろっと数値調整バーを表示する。
        /// 非アクティブ化したときに閉じます。
        /// リソースもったいないかな。
        /// </summary>
        /// <param name="nud">数値入力欄</param>
        public static void Show(NumericUpDown nud)
        {
            FormValueInput fvi = new FormValueInput();
            fvi.Minimum = (int)(nud.Minimum);
            fvi.Maximum = (int)(nud.Maximum);
            fvi.Value = (int)(nud.Value);

            // 中央下に表示する。
            int dispX = nud.Width / 2 - fvi.Width / 2;
            int dispY = nud.Height;
            fvi.Location = nud.PointToScreen(new Point(dispX, dispY));

            fvi.StartPosition = FormStartPosition.Manual;
            fvi.ValueChanged = (int value) => { nud.Value = value; };
            fvi.Show();
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormValueInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示した時にアクティブ化するかどうかを設定する。
        /// </summary>
        protected override bool ShowWithoutActivation {
            get { return true; }
        }

        /// <summary>
        /// フォームが表示されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs evt)
        {
            //trackBar.Focus();
        }

        /// <summary>
        /// フォームがアクティブ化したときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormActivated(object sender, EventArgs evt)
        {
        }

        /// <summary>
        /// フォームが非アクティブ化した時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormDeactivate(object sender, EventArgs evt)
        {
            Close();
        }

        /// <summary>
        /// 値
        /// </summary>
        public int Value {
            get { return trackBar.Value; }
            set {
                trackBar.Value = value;
                labelCurrent.Text = value.ToString();
            }
        }

        /// <summary>
        /// 設定可能な最小値
        /// </summary>
        public int Minimum {
            get { return trackBar.Minimum; }
            set {
                trackBar.Minimum = value;
                labelMinimum.Text = value.ToString();
            }
        }
        /// <summary>
        /// 設定可能な最大値
        /// </summary>
        public int Maximum {
            get { return trackBar.Maximum; }
            set {
                trackBar.Maximum = value;
                labelMaximum.Text = value.ToString();
            }
        }

        /// <summary>
        /// 値が変更された時に通知を受け取る。
        /// </summary>
        public Action<int> ValueChanged;

        public int LargeChange {
            get { return trackBar.LargeChange; }
            set { trackBar.LargeChange = value; }
        }

        /// <summary>
        /// トラックバーの値が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnTrackBarValueChanged(object sender, EventArgs evt)
        {
            labelCurrent.Text = Value.ToString();
            ValueChanged?.Invoke(Value);
        }
    }
}
