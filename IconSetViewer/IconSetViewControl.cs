using System;
using System.Drawing;
using System.Windows.Forms;

namespace IconSetViewer
{
    /// <summary>
    /// アイコンセットビュー
    /// </summary>
    public partial class IconSetViewControl : UserControl
    {
        // アイコンセット
        private IconSet iconSet;
        // 選択されているアイコンのインデックス番号
        private int selectedIndex = 0; 

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconSetViewControl()
        {
            iconSet = new IconSet();
            iconSet.PropertyChanged += OnIconSetPropertyChanged;
            InitializeComponent();

        }

        /// <summary>
        /// アイコンセットのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnIconSetPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SelectedIndex = -1;
            Invalidate();
        }

        /// <summary>
        /// 選択インデックスが変更されたときに通知を受け取る。
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// アイコンセット
        /// </summary>
        public IconSet IconSet {
            get => iconSet;
            set {
                if (iconSet == null)
                {
                    throw new ArgumentNullException("IconSetにnullは設定できません。");
                }

                iconSet.PropertyChanged -= OnIconSetPropertyChanged;
                iconSet = value;
                iconSet.PropertyChanged += OnIconSetPropertyChanged;

                SelectedIndex = -1;
                Invalidate();
            }
        }

        /// <summary>
        /// カーソル色
        /// </summary>
        public Color CorsorColor { get; set; } = Color.Red;

        /// <summary>
        /// アイコンインデックス番号(0, 1, 2, ... (IconCount - 1))
        /// </summary>
        public int SelectedIndex {
            get { return selectedIndex; }
            set {
                int newIndex = value;
                if (newIndex < -1)
                {
                    newIndex = -1;
                }
                else if (newIndex >= iconSet.IconCount)
                {
                    newIndex = iconSet.IconCount - 1;
                }

                if (newIndex != selectedIndex)
                {
                    selectedIndex = newIndex;
                    Invalidate();
                    SelectedIndexChanged?.Invoke(this, new EventArgs());
                }
            }
        }


        /// <summary>
        /// 表示を更新する。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (iconSet.Image == null)
            {
                return;
            }

            // アイコンセット描画
            g.DrawImageUnscaled(iconSet.Image, 0, 0);

            // さ・ら・に、選択されているアイコンのところを赤枠で囲む。
            if ((SelectedIndex >= 0) && (SelectedIndex < iconSet.IconCount))
            {
                Rectangle r = iconSet.GetIconRegion(SelectedIndex);

                using (Pen pen = new Pen(CorsorColor, 2))
                {
                    g.DrawRectangle(pen, r);
                }
            }

        }

        /// <summary>
        /// マウスでクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            SelectedIndex = iconSet.GetIconIndexAt(p.X, p.Y);
        }
    }
}
