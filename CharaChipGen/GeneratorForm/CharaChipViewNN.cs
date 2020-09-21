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
        // レンダリングステート
        private enum RendererState { Stop, Requested, Rendering };
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
        // ミューテックス
        private readonly object lockObject = new object();
        // レンダリングステート
        private RendererState rendererState = RendererState.Stop;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipViewNN()
        {
            positionX = 0;
            positionY = 0;
            renderedImage = null;
            renderData = new CharaChipRenderData();
            handler = (sender, e) => RequestRenderImage();
            renderData.ImageChanged += handler;
            InitializeComponent();
        }

        /// <summary>
        /// レンダリング要求を出す。
        /// </summary>
        private void RequestRenderImage()
        {
            lock (lockObject) 
            { 
                if (rendererState == RendererState.Stop)
                {
                    rendererState = RendererState.Requested;
                    Task.Run(() => RenderImageProc());
                }
                else
                {
                    rendererState = RendererState.Requested;
                }
            }
        }

        /// <summary>
        /// レンダリング処理
        /// </summary>
        private void RenderImageProc()
        {
            ImageBuffer renderBuffer = null;
            while (true)
            {
                lock (lockObject) 
                {
                    if (rendererState == RendererState.Requested)
                    {
                        rendererState = RendererState.Rendering;
                    }
                    else
                    {
                        rendererState = RendererState.Stop;
                        break;
                    }
                }
                Size prefSize = renderData.PreferredSize;
                if ((prefSize.Width > 0) && (prefSize.Height > 0))
                {
                    Size imageSize = new Size(prefSize.Width / 3, prefSize.Height / 4);
                    renderBuffer = CreateRenderBuffer(renderBuffer, imageSize);
                    // レンダリングする。
                    CharaChipRenderer.Draw(renderData, renderBuffer, positionX, positionY);
                    renderedImage = renderBuffer.GetImage();
                }
                else
                {
                    renderedImage = null;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// レンダリング用バッファを作成する。
        /// </summary>
        /// <param name="buffer">バッファ(null時は必ず作成)</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <returns>レンダリング用バッファ</returns>
        private static ImageBuffer CreateRenderBuffer(ImageBuffer buffer, Size imageSize)
        {
            if ((buffer != null)
                && (buffer.Width == imageSize.Width) 
                && (buffer.Height == imageSize.Height))
            {
                buffer.Clear();
                return buffer;
            }
            return ImageBuffer.Create(imageSize.Width, imageSize.Height);
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
