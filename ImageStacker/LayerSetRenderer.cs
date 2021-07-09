using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;
using System.Drawing;
using System.ComponentModel;

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
            RenderSize = new Size(0, 0);
        }

        /// <summary>
        /// オブジェクトがGCから破棄される際に呼び出される。
        /// </summary>
        ~LayerSetRenderer()
        {
            Dispose(false);
        }
        /// <summary>
        /// 描画サイズが変更された
        /// </summary>
        public event EventHandler RenderSizeChanged;
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
                        layerSet.PropertyChanged -= OnLayerSetPropertyChanged;
                    }
                    layerSet = value;
                    if (layerSet != null)
                    {
                        layerSet.Added += OnLayerSetChanged;
                        layerSet.Removed += OnLayerSetChanged;
                        layerSet.Modifired += OnLayerSetChanged;
                        layerSet.DataChanged += OnLayerSetDataChanged;
                        layerSet.PropertyChanged += OnLayerSetPropertyChanged;
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
        /// レイヤーセットのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerSetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            isNeedRedraw = true;
            if (e.PropertyName.Equals(nameof(LayerSet.RenderScale)))
            {
                UpdatePreferredSize();
            }
            UpdateRenderSize();
            NeedRedraw?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// レイヤーセット変更処理
        /// </summary>
        private void LayerSetChangedProc()
        {
            LoadImageResources();
            UpdatePreferredSize();
            UpdateRenderSize();
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
        private Size PreferredSize { get; set; }

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
            // レンダリングスケールを考慮する。
            width = (int)(width * layerSet.RenderScale + 0.5);
            height = (int)(height * layerSet.RenderScale + 0.5);
            PreferredSize = new Size(width, height);
        }
        /// <summary>
        /// レンダリングサイズ
        /// </summary>
        public Size RenderSize { get; private set; }

        /// <summary>
        /// レンダリングサイズを更新する。
        /// </summary>
        private void UpdateRenderSize()
        {
            var width = (layerSet.RenderWidth > 0) ? layerSet.RenderWidth : PreferredSize.Width;
            var height = (layerSet.RenderHeight > 0) ? layerSet.RenderHeight : PreferredSize.Height;
            if ((width != RenderSize.Width) || (height != RenderSize.Height))
            {
                RenderSize = new Size(width, height);
                RenderSizeChanged?.Invoke(this, new EventArgs());
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
            Size renderSize = RenderSize;
            if ((renderSize.Width > 0) && (renderSize.Height > 0) && (layerSet.RenderScale > 0))
            {
                if ((renderBuf == null)
                    || ((renderBuf.Width != renderSize.Width) || (renderBuf.Height != renderSize.Height)))
                {
                    renderBuf = ImageBuffer.Create(renderSize.Width, renderSize.Height);
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
                        RenderLayer(layer, layerSet.RenderScale);
                    }
                }
                renderImage = renderBuf.GetImage();
            }
        }
        /// <summary>
        /// レイヤーを描画する。
        /// </summary>
        /// <param name="layer">レイヤー</param>
        /// <param name="scale">レンダリングスケール</param>
        private void RenderLayer(LayerEntry layer, double scale)
        {
            var srcImage = images[layer.FileName];

            double rev_scale = 1.0 / scale;

            // ほんとはバイキュービックとかやった方がいいんだけど、面倒なのでやらない。
            Parallel.For(0, renderBuf.Height, (dstY) => {
                for (int dstX = 0; dstX < renderBuf.Width; dstX++)
                {
                    var srcX = (int)((dstX - layer.OffsetX) * rev_scale + 0.5);
                    var srcY = (int)((dstY - layer.OffsetY) * rev_scale + 0.5);
                    var srcColor = srcImage.GetPixel(srcX, srcY);
                    if (layer.Opacity < 255)
                    {
                        int newAlpha = (int)(srcColor.A * layer.Opacity / 255.0f);
                        srcColor = Color.FromArgb(newAlpha, srcColor.R, srcColor.G, srcColor.B);
                    }

                    if (srcColor.A > 0)
                    {
                        // 色があるのでレンダリングバッファへの書き込みが必要。
                        if (layer.MonoricConversionEnabled)
                        {
                            srcColor = ImageProcessor.MonoricColor(srcColor, layer.MonoricConvertColor);
                        }
                        // レイヤーに設定されているHSL変換を適用
                        srcColor = ImageProcessor.ProcessHSLFilter(srcColor, layer.Hue, layer.Saturation, layer.Value);
                        Color writeColor;
                        Color dstColor = renderBuf.GetPixel(dstX, dstY);
                        writeColor = ImageProcessor.Blend(srcColor, dstColor);
                        renderBuf.SetPixel(dstX, dstY, writeColor);
                    }
                }
            });

        }

    }
}
