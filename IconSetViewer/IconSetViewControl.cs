using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IconSetViewer
{
    /// <summary>
    /// アイコンセットビュー
    /// </summary>
    public partial class IconSetViewControl : UserControl
    {
        private Size iconSize = new Size(32, 32); // アイコンサイズ
        private Image iconSetImage; // アイコンセットの画像
        private int hIconCount; // 水平アイコン数
        private int vIconCount; // 垂直アイコン数
        private int selectedIndex = 0; // 選択されているアイコンのインデックス番号

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconSetViewControl()
        {
            iconSetImage = null;
            InitializeComponent();

        }

        /// <summary>
        /// 選択インデックスが変更されたときに通知を受け取る。
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// アイコンセット画像
        /// </summary>
        public Image IconSetImage {
            get { return iconSetImage; }
            set {
                iconSetImage = value;
                if (iconSetImage != null)
                {
                    Size = iconSetImage.Size;
                }
                else
                {
                    Size = Size.Empty;
                }
                UpdateIconData();
            }
        }

        /// <summary>
        /// カーソル色
        /// </summary>
        public Color CorsorColor { get; set; } = Color.Red;

        /// <summary>
        /// アイコンサイズ
        /// </summary>
        public Size IconSize {
            get { return iconSize; }
            set {
                if ((value.Width <= 0) || (value.Height <= 0))
                {
                    throw new ArgumentException($"Size is incorrect. ({value.Width},{value.Height})");
                }
                iconSize = value;
                UpdateIconData();
            }
        }

        /// <summary>
        /// アイコンインデックス番号(0, 1, 2, ... (MaxIconCount - 1))
        /// </summary>
        public int SelectedIndex {
            get { return selectedIndex; }
            set {
                int newIndex = value;
                if (newIndex < 0)
                {
                    newIndex = 0;
                }
                else if (newIndex >= MaxIconCount)
                {
                    newIndex = MaxIconCount - 1;
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
        /// アイコン最大数
        /// </summary>
        public int MaxIconCount { get; private set; } = 0;

        /// <summary>
        /// アイコンデータを更新する。
        /// </summary>
        private void UpdateIconData()
        {
            if (iconSetImage != null)
            {
                hIconCount = iconSetImage.Width / iconSize.Width;
                vIconCount = iconSetImage.Height / iconSize.Height;
                MaxIconCount = hIconCount * vIconCount;
            }
            selectedIndex = -1; // 表示インデックスリセット
            Invalidate();
        }

        /// <summary>
        /// 表示を更新する。
        /// </summary>
        /// <param name="evt">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs evt)
        {
            Graphics g = evt.Graphics;

            // 背景描画
            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, 0, 0, ClientSize.Width, ClientSize.Height);
            }

            if (IconSetImage == null)
            {
                return;
            }

            // アイコンセット描画
            g.DrawImageUnscaled(IconSetImage, 0, 0);

            // さ・ら・に、選択されているアイコンのところを赤枠で囲む。
            if ((SelectedIndex >= 0) && (MaxIconCount > 0))
            {
                int yOffs = (SelectedIndex / hIconCount) * IconSize.Width;
                int xOffs = (SelectedIndex % hIconCount) * IconSize.Height;

                using (Pen pen = new Pen(CorsorColor, 2))
                {
                    g.DrawRectangle(pen, xOffs, yOffs, iconSize.Width - 1, iconSize.Height - 1);
                }
            }

        }

        /// <summary>
        /// マウスでクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMouseClick(object sender, MouseEventArgs evt)
        {
            Point p = evt.Location;
            int iconIndex = (p.Y / iconSize.Height) * hIconCount + p.X / iconSize.Width;
            if ((iconIndex >= 0) && (iconIndex < MaxIconCount))
            {
                SelectedIndex = iconIndex;
            }
        }
    }
}
