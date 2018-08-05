using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CharaChipGen.Model;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// 3x4のビューの1つを表すビュー。
    /// </summary>
    public partial class CharaChipViewNN : UserControl
    {
        private int positionX; // X位置
        private int positionY; // Y位置
        private ImageBuffer renderBuffer; // レンダリング用バッファ
        private Image renderedImage; // レンダリング完了済みデータ
        private CharaChipRenderModel renderModel; // レンダリングモデル
        private CharaChipRenderModel.ImageChanged handler; // ハンドラ

        public CharaChipViewNN()
        {
            positionX = 0;
            positionY = 0;
            renderBuffer = null;
            renderedImage = null;
            renderModel = new CharaChipRenderModel();
            handler = new CharaChipRenderModel.ImageChanged((Object sender) =>
            {
                // 表示データの変更が入った場合にはイメージを削除して
                // 表示の更新が必要であるとマークする。
                renderedImage = null;
                Invalidate();
            });
            renderModel.OnImageChanged += handler;
            InitializeComponent();
        }

        /// <summary>
        /// データモデルを設定する
        /// </summary>
        /// <param name="model">データモデル</param>
        public void SetDataModel(CharaChipDataModel model)
        {
            renderModel.OnImageChanged -= handler;
            // データモデルを置き換える。
            // 置き換えたことによってイベントが飛ぶので
            // そちらで更新処理が行われる。
            renderModel.CharaChipDataModel = model;

            renderModel.OnImageChanged += handler;
        }

        /// <summary>
        /// 水平位置
        /// </summary>
        public int CharaChipPositionX
        {
            get { return positionX; }
            set {
                if ((value >= 0) && (value < 3)) {
                    positionX = value;
                }
            }
        }

        /// <summary>
        /// レンダリング済みデータを取得する
        /// </summary>
        /// <returns>レンダリング済みデータ</returns>
        public Image GetRenderedImage()
        {
            return renderedImage;
        }

        /// <summary>
        /// 垂直位置
        /// </summary>
        public int CharaChipPositionY
        {
            get { return positionY; }
            set
            {
                if ((value >= 0) && (value < 4))
                {
                    positionY = value;
                }
            }
        }

        /// <summary>
        /// 描画処理を行う。
        /// </summary>
        /// <param name="args"></param>
        protected override void OnPaint(PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            // 背景色でクリア
            Brush brush = new SolidBrush(BackColor);
            g.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            
            // イメージをレンダリング
            if ((renderBuffer == null) || (renderedImage == null)) 
            {
                if (renderBuffer == null)
                {
                    renderBuffer = ImageBuffer.Create(ClientSize.Width, ClientSize.Height);
                }

                // レンダリングする。
                CharaChipGenerator.Draw(renderModel, renderBuffer, positionX, positionY);
                renderedImage = renderBuffer.GetImage();
            }
            // グラフィクスに描画する。
            g.DrawImageUnscaled(renderedImage, 0, 0);

            // 枠を描画
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

        private void OnForm_resized(object sender, EventArgs evt)
        {
            renderBuffer = null;
            Invalidate();
        }
    }
}
