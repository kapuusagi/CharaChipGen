using System;
using System.Drawing;
using System.Windows.Forms;

namespace IconSetViewer
{
    /// <summary>
    /// アイコンセット中の、特定のアイコンを表示するためのコントロール。
    /// </summary>
    public partial class IconViewControl : UserControl
    {
        private int selectedIndex;

        private IconSet iconSet; 

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconViewControl()
        {
            selectedIndex = -1;
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
            Invalidate();
        }


        /// <summary>
        /// 表示を更新する。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 表示対象がある場合、もりもり描画。
            if ((iconSet.Image != null) && (selectedIndex >= 0) && (selectedIndex < iconSet.IconCount))
            {
                // 表示元画像部分の座標を計算
                Rectangle srcRect = iconSet.GetIconRegion(selectedIndex);

                System.Diagnostics.Debug.WriteLine($"{srcRect}");

                // 表示先範囲の座標を計算
                Rectangle dstRect = CalcIconDisplayRectangel();

                // 描画
                g.DrawImage(iconSet.Image, dstRect, srcRect, GraphicsUnit.Pixel);
            }

        }

        private Rectangle CalcIconDisplayRectangel()
        {
            Size iconSize = iconSet.IconSize;
            int drawWidth = ClientSize.Width;
            int drawHeight = (int)(Math.Ceiling(drawWidth
                * (float)(iconSize.Height) / (float)(iconSize.Width)));
            if (drawHeight > ClientSize.Height)
            {
                // アスペクト比を維持して描画に必要な高さが足りない
                drawHeight = ClientSize.Height;
                drawWidth = (int)(Math.Ceiling(drawHeight
                    * (float)(iconSize.Width) / (float)(iconSize.Height)));
            }
            int dstXOffs = (ClientSize.Width - drawWidth) / 2;
            int dstYOffs = (ClientSize.Height - drawHeight) / 2;
            return new Rectangle(dstXOffs, dstYOffs, drawWidth, drawHeight);
        }

        public IconSet IconSet {
            get => iconSet;
            set {
                if (value == null)
                {
                    throw new ArgumentNullException("IconSetにnullは指定できません。");
                }
                iconSet.PropertyChanged -= OnIconSetPropertyChanged;
                iconSet = value;
                iconSet.PropertyChanged += OnIconSetPropertyChanged;

                SelectedIndex = -1;
                Invalidate();
            }
        }

        /// <summary>
        /// アイコンインデックス番号(0, 1, 2, ... (MaxIconCount - 1))
        /// </summary>
        public int SelectedIndex {
            get => selectedIndex; 
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
                }

            }
        }

        /// <summary>
        /// コントロールのサイズが変更された時に通知を受け取る
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // 再描画しないとくずれたおかしな画像が表示される。
            Invalidate();
        }
    }
}
