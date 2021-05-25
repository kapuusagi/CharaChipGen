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
    public class RenderThread : IDisposable
    {
        // レンダリングキャッシュ
        private CharaChipRenderData renderData;
        // タスク
        private Task task;
        // 再レンダリング要求が出ているか
        private bool isRenderRequested;
        // 中止要求が出ているか
        private bool isAbortRequested;
        // レンダリングするためのイメージバッファ
        private ImageBuffer imageBuffer;
        // イベント
        private readonly EventWaitHandle eventWaitHandle;
        // オブジェクトが破棄されたかどうか
        private bool isDisposed = false;
        // レンダリングした画像
        private Image image;

        /// <summary>
        /// レンダリングスレッドを構築する。
        /// </summary>
        public RenderThread()
        {
            renderData = new CharaChipRenderData();
            renderData.ImageChanged += OnImageChanged;
            isRenderRequested = false;
            isAbortRequested = false;
            task = null;
            image = null;
            eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        }

        /// <summary>
        /// GCがオブジェクトのリソースを破棄するために呼び出す。
        /// </summary>
        ~RenderThread()
        {
            Dispose(false);
        }

        /// <summary>
        /// オブジェクトのリソースを破棄する。
        /// </summary>
        /// <param name="isDisposing">Dispose()からの呼び出しの場合にはtrue, GC空の呼び出しの場合にはfalse</param>
        protected void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }
            if (IsRunning)
            {
                Stop();
            }
            if (isDisposing && (task != null))
            {
                task.Dispose();
            }

            if (isDisposing && (eventWaitHandle != null))
            {
                eventWaitHandle.Dispose();
            }
            if (isDisposing && (image != null))
            {
                image.Dispose();
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
        /// 画像がレンダリングされた。
        /// </summary>
        public event EventHandler Rendered;

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
            }
        }

        /// <summary>
        /// 再描画が必要であると通知を受け取る
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageChanged(object sender, EventArgs e)
        {
            isRenderRequested = true;
            eventWaitHandle.Set();
        }

        /// <summary>
        /// スレッドを開始する。
        /// </summary>
        public void Start()
        {
            if (IsRunning)
            {
                return;
            }
            if (task != null)
            {
                task.Dispose();
            }
            isAbortRequested = false;
            isRenderRequested = true;
            task = Task.Run(RenderThreadProc);
        }

        /// <summary>
        /// スレッドが動作中かどうか。
        /// </summary>
        public bool IsRunning {
            get => (task != null) && !task.IsCompleted;
        }

        /// <summary>
        /// スレッドに停止要求を出し、終了するまで待つ。
        /// </summary>
        public void Stop()
            => Stop(Timeout.Infinite);

        /// <summary>
        /// スレッドを停止する。
        /// </summary>
        /// <param name="millisecondsTimeout">タイムアウト時間。(0で待機しない)</param>
        public void Stop(int millisecondsTimeout)
        {
            if (IsRunning)
            {
                isAbortRequested = true;
                eventWaitHandle.Set();
                if (millisecondsTimeout > 0)
                {
                    task.Wait(millisecondsTimeout);
                }
            }
        }

        /// <summary>
        /// レンダリングスレッド
        /// </summary>
        private void RenderThreadProc()
        {
            while (!isAbortRequested)
            {
                eventWaitHandle.WaitOne(10000);
                if (isRenderRequested)
                {
                    isRenderRequested = false;
                    // レンダリングする。
                    RenderingProc();
                    // レンダリング完了通知
                    Rendered?.Invoke(this, new EventArgs());
                }
            }
            System.Diagnostics.Debug.WriteLine("Render thread exit.");
        }

        /// <summary>
        /// レンダリングした画像を得る。
        /// </summary>
        public Image RenderedImage {
            get => image;
        }

        /// <summary>
        /// レンダリングする
        /// </summary>
        private void RenderingProc()
        {
            Size prefSize = renderData.PreferredCharaChipSize;
            if ((prefSize.Width <= 0) || (prefSize.Height <= 0))
            {
                imageBuffer = null;
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
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

                if (image != null)
                {
                    image.Dispose();
                }
                image = imageBuffer.GetImage();
            }
        }
    }
}
