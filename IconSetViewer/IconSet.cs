using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IconSetViewer
{
    /// <summary>
    /// アイコンセットを表すモデル。
    /// </summary>
    public class IconSet : INotifyPropertyChanged
    {
        /// <summary>
        /// デフォルトアイコンサイズ
        /// </summary>
        public static readonly Size DefaultIconSize = new Size(32, 32);
        // 画像サイズ
        private Size imageSize;
        // アイコンサイズ
        private Size iconSize;
        // 画像
        private Image image;
        // 水平アイコン数
        private int horizontalIconCount;
        // 垂直アイコン数
        private int verticalIconCount;
        // 最大アイコン数
        private int iconCount;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public IconSet()
        {
            image = null;
            imageSize = Size.Empty;
            iconSize = DefaultIconSize;
            horizontalIconCount = 0;
            verticalIconCount = 0;
            iconCount = 0;
        }

        /// <summary>
        /// プロパティが変更された。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたことを通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 全体のイメージ
        /// </summary>
        public Image Image { 
            get => image;
            set {
                if ((image == value) || ((image != null) && image.Equals(value)))
                {
                    return;
                }

                image = value;
                imageSize = (image != null) ? image.Size : Size.Empty;
                UpdateCache();
                NotifyPropertyChanged(nameof(Image));
            }
        }

        /// <summary>
        /// アイコンサイズ
        /// </summary>
        public Size IconSize {
            get => iconSize;
            set {
                if ((value.Width <= 0) || (value.Height <= 0))
                {
                    throw new ArgumentException($"IconSizeが正しくありません。 {value}");
                }
                if (iconSize.Equals(value))
                {
                    return;
                }


                iconSize = value;
                UpdateCache();
                NotifyPropertyChanged(nameof(IconSize));
            }

        }

        /// <summary>
        /// アイコンに関するキャッシュ値を更新する。
        /// </summary>
        private void UpdateCache()
        {
            horizontalIconCount = imageSize.Width / iconSize.Width;
            verticalIconCount = imageSize.Height / iconSize.Height;
            iconCount = horizontalIconCount * verticalIconCount;
        }

        /// <summary>
        /// 水平アイコン数
        /// </summary>
        public int HorizontalIconCount {
            get => horizontalIconCount;
        }

        /// <summary>
        /// 垂直アイコン数
        /// </summary>
        public int VerticalIconCount {
            get => verticalIconCount;
        }

        /// <summary>
        /// アイコン数
        /// </summary>
        public int IconCount {
            get => iconCount;
        }

        /// <summary>
        /// iconNoで指定されるアイコン番号のアイコンデータが格納されている、
        /// Image上の領域を取得する。
        /// </summary>
        /// <param name="iconNo">アイコン番号(0≦iconNo＜IconCount)</param>
        /// <returns>Rectangleオブジェクトが返る。</returns>
        public Rectangle GetIconRegion(int iconNo)
        {
            if ((iconNo < 0) || (iconNo >= iconCount))
            {
                throw new IndexOutOfRangeException($"アイコン番号が不正です。{iconNo}");
            }

            int yPos = iconNo / horizontalIconCount;
            int xPos = iconNo - (horizontalIconCount * yPos);
            int srcXOffs = xPos * iconSize.Width;
            int srcYOffs = yPos * iconSize.Height;
            return new Rectangle(srcXOffs, srcYOffs, iconSize.Width, iconSize.Height);
        }

        /// <summary>
        /// (x, y)で指定される位置のアイコン番号を得る。
        /// </summary>
        /// <param name="x">水平方向座標</param>
        /// <param name="y">垂直方向座標</param>
        /// <returns></returns>
        public int GetIconIndexAt(int x, int y)
        {
            int index = (y / iconSize.Height) * horizontalIconCount + x / iconSize.Width;
            return (index < iconCount) ? index : -1;
        }
    }
}
