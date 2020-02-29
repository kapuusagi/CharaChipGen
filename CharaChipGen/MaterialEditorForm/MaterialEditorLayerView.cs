using System;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.MaterialEditorForm
{
    /// <summary>
    /// レイヤーのイメージを表示するためのビュー。
    /// </summary>
    public partial class MaterialEditorLayerView : UserControl
    {
        /// <summary>
        /// 素材の画像が変更されたときのハンドラ
        /// </summary>
        /// <param name="sender">送信元のオブジェクトお</param>
        /// <param name="e">イベントオブジェクト</param>
        public delegate void MaterialImageChangeHandler(object sender, EventArgs e);
        /// <summary>
        /// 素材の画像が変更されたときのイベント
        /// </summary>
        public event MaterialImageChangeHandler ImageChange;

        public MaterialEditorLayerView()
        {
            InitializeComponent();
        }

        private void OnControlResized(object sender, EventArgs e)
        {
            // 開くボタン
            int openBtnX = ClientSize.Width - 8 - buttonOpen.Width;
            int openBtnY = buttonOpen.Location.Y;
            buttonOpen.SetBounds(openBtnX, openBtnY, buttonOpen.Width, buttonOpen.Height);

            //  4x3view
            int viewX = materialView4x3.Location.X;
            int viewY = materialView4x3.Location.Y;
            int viewWidth = ClientSize.Width - 8 - viewX;
            int viewHeight = ClientSize.Height - 8 - viewY;
            materialView4x3.SetBounds(viewX, viewY, viewWidth, viewHeight);
        }

        /// <summary>
        /// このビューの画像オブジェクト
        /// </summary>
        public Image Image {
            get { return materialView4x3.Image; }
            set {
                materialView4x3.Image = value;

                UpdateView();

                if (ImageChange != null)
                {
                    ImageChange(this, new EventArgs());
                }
            }
        }

        public string LayerName {
            set { groupBoxLayerName.Text = value; }
            get { return groupBoxLayerName.Text; }
        }

        private void UpdateView()
        {
            Image image = materialView4x3.Image;
            if (image == null)
            {
                labelCharaSize.Text = "0 x 0 pixels";
                labelPictureSize.Text = "0 x 0 pixels";
                return;
            }

            int subImageWidth = image.Width / 3;
            int subImageHeight = image.Height / 4;

            labelPictureSize.Text = String.Format("{0} x {1} pixels", image.Width, image.Height);
            labelCharaSize.Text = String.Format("{0} x {1} pixels", subImageWidth, subImageHeight);
        }

        private void OnOpenButtonClicked(object sender, EventArgs evt)
        {
            DialogResult res = openFileDialog.ShowDialog(this);
            if (res != DialogResult.OK)
            {
                return;
            }

            string path = openFileDialog.FileName;

            try
            {
                Image = Image.FromFile(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }

        public Image GetSubImage(int x, int y)
        {
            return materialView4x3.GetSubImage(x, y);
        }
    }
}
