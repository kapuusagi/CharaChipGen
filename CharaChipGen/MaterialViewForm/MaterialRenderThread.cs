using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using CGenImaging;
using CharaChipGen.Model;

namespace CharaChipGen.MaterialViewForm
{
    /// <summary>
    /// レンダリングスレッド
    /// </summary>
    public class MaterialRenderThread : RenderThreadBase
    {
        // レンダリングキャッシュ
        private MaterialRenderData renderData;
        // レンダリングするためのイメージバッファ
        private ImageBuffer imageBuffer;

        /// <summary>
        /// レンダリングスレッドを構築する。
        /// </summary>
        public MaterialRenderThread()
        {
            renderData = new MaterialRenderData();
            renderData.ImageChanged += OnImageChanged;
        }

        /// <summary>
        /// レンダリングデータを設定する。
        /// </summary>
        public MaterialRenderData RenderData {
            get => renderData;
            set {
                if (renderData != null)
                {
                    renderData.ImageChanged -= OnImageChanged;
                }
                renderData = value;
                if (renderData != null)
                {
                    renderData.ImageChanged += OnImageChanged;
                }
                RequestRender();
            }
        }

        /// <summary>
        /// 再描画が必要であると通知を受け取る
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageChanged(object sender, EventArgs e)
        {
            RequestRender();
        }


        /// <summary>
        /// レンダリングする
        /// </summary>
        /// <returns>レンダリングデータ</returns>
        protected override Image RenderingProc()
        {
            Size prefSize = renderData.PreferredSize;
            if ((prefSize.Width <= 0) || (prefSize.Height <= 0))
            {
                imageBuffer = null;
            }
            else
            {
                if ((imageBuffer == null) || (imageBuffer.Width != prefSize.Width) || (imageBuffer.Height != prefSize.Height))
                {
                    imageBuffer = ImageBuffer.Create(prefSize.Width, prefSize.Height);
                }

                int patternWidth = prefSize.Width / 3;
                int patternHeight = prefSize.Height / 4;

                // 3 x 4 のパターンを描画する。
                // workBuferにそれぞれのパターンを描画し、
                // imageBufferの所定のオフセット位置に書き込むしくみ。
                Parallel.For(0, 4, y =>
                {
                    ImageBuffer workBuffer = ImageBuffer.Create(patternWidth, patternHeight);
                    for (int x = 0; x < 3; x++)
                    {
                        int xoffs = workBuffer.Width * x;
                        int yoffs = workBuffer.Height * y;
                        MaterialRenderer.Draw(renderData, workBuffer, x, y);
                        imageBuffer.WriteImage(workBuffer, xoffs, yoffs);
                    }
                });

            }
            return imageBuffer?.GetImage() ?? null;
        }
    }
}
