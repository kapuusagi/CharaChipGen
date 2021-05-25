using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using CGenImaging;
using CharaChipGen.Model;
using CharaChipGen.Model.Layer;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// ウラで描画を行うスレッド
    /// </summary>
    public class CharaChipRenderThread : RenderThreadBase
    {
        // レンダリングキャッシュ
        private CharaChipRenderData renderData;
        // レンダリングするためのイメージバッファ
        private ImageBuffer imageBuffer;

        /// <summary>
        /// レンダリングスレッドを構築する。
        /// </summary>
        public CharaChipRenderThread()
        {
            renderData = new CharaChipRenderData();
            renderData.ImageChanged += OnImageChanged;
        }

        /// <summary>
        /// レンダリングデータを設定する。
        /// </summary>
        public CharaChipRenderData RenderData {
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
        /// <returns>レンダリングしたイメージ</returns>
        protected override Image RenderingProc()
        {
            Size prefSize = renderData.PreferredCharaChipSize;
            if ((prefSize.Width <= 0) || (prefSize.Height <= 0))
            {
                imageBuffer = null;
            }
            else
            {
                int imageWidth = prefSize.Width * 3;
                int imageHeight = prefSize.Height * 4;
                if ((imageBuffer == null) || (imageBuffer.Width != imageWidth) || (imageBuffer.Height != imageHeight))
                {
                    imageBuffer = ImageBuffer.Create(imageWidth, imageHeight);
                }

                Parallel.For(0, 4, y =>
                {
                    ImageBuffer workBuffer = ImageBuffer.Create(prefSize.Width, prefSize.Height);
                    for (int x = 0; x < 3; x++)
                    {
                        int xoffs = workBuffer.Width * x;
                        int yoffs = workBuffer.Height * y;
                        CharaChipRenderer.Draw(renderData, workBuffer, x, y);
                        imageBuffer.WriteImage(workBuffer, xoffs, yoffs);
                    }
                });

            }
            return imageBuffer?.GetImage() ?? null;
        }
    }
}
