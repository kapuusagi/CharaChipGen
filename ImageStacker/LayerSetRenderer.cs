using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;
using System.Drawing;

namespace ImageStacker
{
    /// <summary>
    /// レイヤーセットレンダラー
    /// </summary>
    public class LayerSetRenderer : IDisposable
    {
        // レンダリング用バッファ
        private ImageBuffer renderBuf;
        // レンダリング済みイメージ
        private Image renderImage;
        // レイヤーセット
        private LayerSet layerSet;
        // イメージ
        private Dictionary<string, ImageBuffer> images;
        // 再描画が必要かどうか
        private bool isNeedRedraw;
        // 破棄されたかどうか
        private bool isDisposed;
        /// <summary>
        /// 新しいLayerSetRendererを構築する。
        /// </summary>
        public LayerSetRenderer()
        {
            renderImage = null;
            layerSet = null;
            isDisposed = false;
            isNeedRedraw = false;
            images = new Dictionary<string, ImageBuffer>();
            PreferredSize = new Size(0, 0);
        }

        /// <summary>
        /// オブジェクトがGCから破棄される際に呼び出される。
        /// </summary>
        ~LayerSetRenderer()
        {
            Dispose(false);
        }
        /// <summary>
        /// 最適サイズが変更された
        /// </summary>
        public event EventHandler PreferredSizeChanged;
        /// <summary>
        /// 再描画が必要になった
        /// </summary>
        public event EventHandler NeedRedraw;

        /// <summary>
        /// オブジェクトのリソースを破棄する。
        /// </summary>
        /// <param name="isDisposing">Disposeからの呼び出しの場合にはtrue, それ以外はfalse</param>
        protected void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (renderImage != null)
            {
                renderImage.Dispose();
            }


            isDisposed = true;
        }

        /// <summary>
        /// オブジェクトのリソースを破棄する。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// レイヤーセット
        /// </summary>
        public LayerSet LayerSet {
            get => layerSet;
            set {
                if (layerSet != value)
                {
                    if (layerSet != null)
                    {
                        layerSet.Added -= OnLayerSetChanged;
                        layerSet.Removed -= OnLayerSetChanged;
                        layerSet.Modifired -= OnLayerSetChanged;
                        layerSet.DataChanged -= OnLayerSetDataChanged;
                    }
                    layerSet = value;
                    if (layerSet != null)
                    {
                        layerSet.Added += OnLayerSetChanged;
                        layerSet.Removed += OnLayerSetChanged;
                        layerSet.Modifired += OnLayerSetChanged;
                        layerSet.DataChanged += OnLayerSetDataChanged;
                    }
                    LoadImageResources();
                    UpdatePreferredSize();
                    isNeedRedraw = true;
                    NeedRedraw?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// レイヤーセットが更新されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerSetChanged(object sender, LayerEventArgs e)
        {
            LayerSetChangedProc();
        }

        /// <summary>
        /// レイヤーセットのデータが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerSetDataChanged(object sender, EventArgs e)
        {
            LayerSetChangedProc();
        }

        /// <summary>
        /// レイヤーセット変更処理
        /// </summary>
        private void LayerSetChangedProc()
        {
            LoadImageResources();
            UpdatePreferredSize();
            isNeedRedraw = true;
            NeedRedraw?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// 画像リソースを更新する。
        /// </summary>
        private void LoadImageResources()
        {
            if (layerSet != null)
            {
                var keys = images.Keys.ToArray();
                foreach (string fileName in keys)
                {
                    if (!IsUsingImage(fileName))
                    {
                        images.Remove(fileName);
                    }
                }
                foreach (var layer in layerSet)
                {
                    if (!images.ContainsKey(layer.FileName))
                    {
                        // リソース読み込み
                        try
                        {
                            using (var image = Image.FromFile(layer.FileName))
                            {
                                var imageBuf = ImageBuffer.CreateFrom(image);
                                images.Add(layer.FileName, imageBuf);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
            else
            {
                images.Clear();
            }
        }
        /// <summary>
        /// fileNameで指定される画像リソースを使用しているかどうかを得る。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>使用している場合にはtrue, それ以外はfalse.</returns>
        private bool IsUsingImage(string fileName)
            => layerSet.Any(layer => layer.FileName.Equals(fileName));

        /// <summary>
        /// 最適サイズ
        /// </summary>
        public Size PreferredSize { get; private set; }

        /// <summary>
        /// 最適サイズを更新する。
        /// </summary>
        private void UpdatePreferredSize()
        {
            int width = 0;
            int height = 0;
            foreach (var imageBuf in images.Values)
            {
                if (imageBuf.Width > width)
                {
                    width = imageBuf.Width;
                }
                if (imageBuf.Height > height)
                {
                    height = imageBuf.Height;
                }
            }
            if ((PreferredSize.Width != width) || (PreferredSize.Height != height))
            {
                PreferredSize = new Size(width, height);
                PreferredSizeChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// レンダリングしたイメージを得る。
        /// </summary>
        /// <returns>レンダリングイメージ</returns>
        public Image GetRenderImage()
        {
            if ((renderImage == null) || isNeedRedraw)
            {
                Redraw();
            }

            return renderImage;
        }

        /// <summary>
        /// 再描画する。
        /// </summary>
        private void Redraw()
        {
            if (renderImage != null)
            {
                renderImage.Dispose();
                renderImage = null;
            }
            Size prefSize = PreferredSize;
            if ((prefSize.Width > 0) && (prefSize.Height > 0))
            {
                if ((renderBuf == null)
                    || ((renderBuf.Width != prefSize.Width) || (renderBuf.Height != prefSize.Height)))
                {
                    renderBuf = ImageBuffer.Create(prefSize.Width, prefSize.Height);
                }
                else
                {
                    renderBuf.Clear();
                }

                // レイヤーを描画(下のレイヤーから順に描画する) 
                for (int index = layerSet.Count - 1; index >= 0; index--)
                {
                    var layer = layerSet.Get(index);
                    if (images.ContainsKey(layer.FileName))
                    {
                        RenderLayer(layer);
                    }
                }
                renderImage = renderBuf.GetImage();
            }
        }
        /// <summary>
        /// レイヤーを描画する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        private void RenderLayer(LayerEntry layer)
        {
            var srcImage = images[layer.FileName];

            Parallel.For(0, srcImage.Height, y =>
            {
                int dstY = layer.OffsetY + y;
                if ((dstY >= 0) && (dstY < renderBuf.Height))
                {
                    int srcX, dstX;
                    if (layer.OffsetX >= 0)
                    {
                        srcX = 0;
                        dstX = layer.OffsetX;
                    }
                    else
                    {
                        srcX = -layer.OffsetX;
                        dstX = 0;
                    }

                    while ((srcX < srcImage.Width) && (dstX < renderBuf.Width))
                    {
                        var srcColor = srcImage.GetPixel(srcX, y);
                        if (layer.Opacity < 255)
                        {
                            int newAlpha = (int)(srcColor.A * layer.Opacity / 255.0f);
                            srcColor = Color.FromArgb(newAlpha, srcColor.R, srcColor.G, srcColor.B);
                        }

                        if (srcColor.A > 0)
                        {
                            srcColor = ImageProcessor.ProcessHSLFilter(srcColor,
                                layer.Hue, layer.Saturation, layer.Value);

                            Color writeColor;
                            if (srcColor.A >= 255)
                            {
                                // 塗りつぶし
                                writeColor = srcColor;
                            }
                            else
                            {
                                writeColor = ImageProcessor.Blend(srcColor, renderBuf.GetPixel(dstX, dstY));
                            }
                            renderBuf.SetPixel(dstX, dstY, writeColor);
                        }
                        srcX++;
                        dstX++;
                    }
                }
            });
        }

    }
}
