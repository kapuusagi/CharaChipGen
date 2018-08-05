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
    /// 顔データを表示するためのビュー
    /// </summary>
    public partial class CharaFaceView : UserControl
    {
        private ImageBuffer renderBuffer; // レンダリング用バッファ
        private Image renderedImage; // レンダリング完了済みデータ
        private CharaFaceRenderModel renderModel; // レンダリングモデル
        private CharaFaceRenderModel.ImageChanged handler; //ハンドラ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaFaceView()
        {
            renderBuffer = null;
            renderedImage = null;
            renderModel = new CharaFaceRenderModel();
            handler = new CharaFaceRenderModel.ImageChanged((Object sender) =>
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
        /// リサイズ時に呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnView_resized(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// モデルを設定する
        /// </summary>
        /// <param name="model">データモデル</param>
        public void SetModel(CharaChipDataModel model)
        {
            renderModel.OnImageChanged -= handler;
            // データモデルを置き換える
            // 置き換えたことによってイベントが飛ぶので
            // そちらで更新処理が行われる。
            renderModel.CharaChipDataModel = model;

            renderModel.OnImageChanged += handler;
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
                CharaFaceGenerator.Draw(renderModel, renderBuffer);
                renderedImage = renderBuffer.GetImage();
            }
            // グラフィクスに描画する。
            g.DrawImage(renderedImage, 0, 0, renderedImage.Width, renderedImage.Height);

            // 枠を描画
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

    }
}
