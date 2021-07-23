using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace CharaChipGen.Model
{
    /// <summary>
    /// レンダリングスレッドの既定クラス。
    /// </summary>
    /// <remarks>
    /// スレッドの開始/要求発行/レンダリング処理/スレッドの停止を提供する。
    /// </remarks>
    public abstract class RenderThreadBase : IDisposable
    {
        // タスク
        private Task task;
        // 再レンダリング要求が出ているか
        private bool isRenderRequested;
        // 中止要求が出ているか
        private bool isAbortRequested;
        // イベント
        private readonly EventWaitHandle eventWaitHandle;
        // オブジェクトが破棄されたかどうか
        private bool isDisposed = false;
        // レンダリングした画像
        private Image image;

        /// <summary>
        /// レンダリングスレッドを構築する。
        /// </summary>
        public RenderThreadBase()
        {
            isRenderRequested = false;
            isAbortRequested = false;
            task = null;
            image = null;
            eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        }

        /// <summary>
        /// GCがオブジェクトのリソースを破棄するために呼び出す。
        /// </summary>
        ~RenderThreadBase()
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
        /// レンダリング要求を出す。
        /// </summary>
        protected void RequestRender()
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
            task = Task.Run(() => RenderThreadProc());
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
                if (millisecondsTimeout != 0)
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
                    var renderedImage = RenderingProc();
                    if (image != null)
                    {
                        image.Dispose();
                    }
                    image = renderedImage;

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
        protected abstract Image RenderingProc();

    }
}
