using CGenImaging;
using CharaChipGen.Model;
using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// 3x4のビューの1つを表すビュー。
    /// </summary>
    public partial class CharaChipViewNN : UserControl
    {
        enum RenderState
        {
            Stop,
            Requested,
            Renderring,
        }
        // X位置
        private int positionX = 0;
        // Y位置
        private int positionY = 0;
        // レンダリング完了済みデータ
        private Image renderedImage = null;
        // レンダリングモデル
        private CharaChipRenderData renderData = new CharaChipRenderData();
        // ハンドラ
        private CharaChipRenderData.ImageChangedEventHandler handler;
        // 描画処理状態
        private RenderState renderState = RenderState.Stop;
        // リクエストミューテックス
        private readonly object requestMutex = new object();

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipViewNN()
        {
            handler = (sender, e) =>
            {
                RequestRenderImage();
            };
            renderData.ImageChanged += handler;
            InitializeComponent();
        }

        /// <summary>
        /// 描画要求を出す。
        /// </summary>
        private void RequestRenderImage()
        {
            // 表示データの変更が入った場合にはイメージを削除して
            // 表示の更新が必要であるとマークする。
            // 更にレンダリングをバックグラウンドで行う。
            lock (requestMutex)
            {
                if (renderState == RenderState.Stop)
                {
                    renderState = RenderState.Requested;
                    System.Diagnostics.Debug.WriteLine($"{positionX}-{positionY}:Start thread. ");
                    Task.Run(() =>
                    {
                        RenderLayerProc();
                    });
                }
                else
                {
                    renderState = RenderState.Requested;
                }
            }
        }

        /// <summary>
        /// レンダリングをする。
        /// </summary>
        private void RenderLayerProc()
        {
            while (true)
            {
                lock (requestMutex)
                {
                    if (renderState != RenderState.Requested)
                    {
                        renderState = RenderState.Stop;
                        break;
                    }
                    else
                    {
                        renderState = RenderState.Renderring;
                    }
                }
                // イメージをレンダリング
                Size prefSize = renderData.PreferredSize;
                if ((prefSize.Width > 0) && (prefSize.Height > 0))
                {
                    Size imageSize = new Size(prefSize.Width / 3, prefSize.Height / 4);

                    ImageBuffer renderBuffer = ImageBuffer.Create(imageSize.Width, imageSize.Height);

                    // レンダリングする。
                    CharaChipRenderer.Draw(renderData, renderBuffer, positionX, positionY);
                    renderedImage = renderBuffer.GetImage();
                    Invalidate();
                }
            }
            System.Diagnostics.Debug.WriteLine($"{positionX}-{positionY}:Thread exit. ");
        }

        /// <summary>
        /// データモデルを設定する
        /// </summary>
        /// <param name="character">データモデル</param>
        public void SetCharacter(Character character)
        {
            // データモデルを置き換える。
            // 置き換えたことによってイベントが飛ぶので
            // そちらで更新処理が行われる。
            renderData.Character = character;
        }

        /// <summary>
        /// エラーが発生したかどうかを取得する。
        /// </summary>
        public bool HasError {
            get => renderData.HasError;
        }

        /// <summary>
        /// エラーの部品を返す。
        /// </summary>
        /// <returns>エラーのパーツ種別</returns>
        public PartsType[] GetErrorPartsTypes()
        {
            List<PartsType> partsTypes = new List<PartsType>();
            foreach (RenderLayer layer in renderData)
            {
                if ((layer.HasError) && !partsTypes.Contains(layer.PartsType))
                {
                    partsTypes.Add(layer.PartsType);
                }
            }
            return partsTypes.ToArray();
        }

        /// <summary>
        /// 水平位置
        /// </summary>
        public int CharaChipPositionX {
            get { return positionX; }
            set {
                if ((value >= 0) && (value < 3))
                {
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
        public int CharaChipPositionY {
            get { return positionY; }
            set {
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

            // 表示領域と同じグラフィックバッファを作成し、
            // それに対してレンダリングを行う実装になっている。
            // すると等倍にできるでしょ？

            // 背景色でクリア
            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }


            if (renderedImage != null)
            {
                // グラフィクスに描画する。
                if ((ClientSize.Width >= (renderedImage.Width * 2))
                    && (ClientSize.Height >= (renderedImage.Height * 2)))
                {
                    // 2倍以上でいけるんじゃない？
                    Rectangle drawRect = new Rectangle();
                    drawRect.Width = renderedImage.Width * 2;
                    drawRect.Height = renderedImage.Height * 2;
                    drawRect.X = (ClientSize.Width - drawRect.Width) / 2;
                    drawRect.Y = (ClientSize.Height - drawRect.Height) / 2;
                    g.DrawImage(renderedImage, drawRect);
                }
                else
                {
                    // 描画対象範囲が等倍以上でしか表示できないサイズ
                    int xoffs = (ClientSize.Width - renderedImage.Width) / 2;
                    int yoffs = (ClientSize.Height - renderedImage.Height) / 2;

                    g.DrawImageUnscaled(renderedImage, xoffs, yoffs);
                }
            }
            // 枠を描画
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        /// <summary>
        /// 表示領域背景色
        /// </summary>
        public Color ImageBackground {
            get; set;
        } = Color.Transparent;

        /// <summary>
        /// フォームのサイズが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormResized(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
