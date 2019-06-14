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
    /// 
    /// </summary>
    public partial class IconSetViewControl : UserControl
    {
        private Size iconSize = new Size(32, 32);
        private Image iconSetImage;
        private int hIconCount; // 水平アイコン数
        private int vIconCount; // 垂直アイコン数

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconSetViewControl()
        {
            iconSetImage = null;
            InitializeComponent();

        }

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

        private int selectedIndex = 0;

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
                }
            }
        }
        /// <summary>
        /// アイコン最大数
        /// </summary>
        public int MaxIconCount { get; private set; }
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

                using (Pen pen = new Pen(CorsorColor))
                {
                    g.DrawRectangle(pen, xOffs, yOffs, iconSize.Width - 1, iconSize.Height - 1);
                }
            }

        }
    }
}
