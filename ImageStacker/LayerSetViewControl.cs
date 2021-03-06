﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGenImaging;

namespace ImageStacker
{
    /// <summary>
    /// レイヤーセットビュー
    /// </summary>
    public partial class LayerSetViewControl : UserControl
    {
        // レンダラー
        private LayerSetRenderer renderer;

        /// <summary>
        /// 新しいLayerSetViewControlを構築する。
        /// </summary>
        public LayerSetViewControl()
        {
            renderer = new LayerSetRenderer();
            InitializeComponent();
            renderer.RenderSizeChanged += OnImageSizeChanged;
            renderer.NeedRedraw += OnLayerNeedRedraw;
            DoubleBuffered = true;
        }
        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (renderer != null))
            {
                renderer.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// レイヤーセットレンダラー
        /// </summary>
        [Browsable(false)]
        public LayerSetRenderer LayerSetRenderer {
            get => renderer;
            set {
                if ((value != null) && (renderer != value)) 
                { 
                    if (renderer != null)
                    {
                        renderer.RenderSizeChanged -= OnImageSizeChanged;
                        renderer.NeedRedraw -= OnLayerNeedRedraw;
                    }
                    renderer = value;
                    if (renderer != null)
                    {
                        renderer.RenderSizeChanged += OnImageSizeChanged;
                        renderer.NeedRedraw += OnLayerNeedRedraw;
                    }
                }
            }
        }

        /// <summary>
        /// レイヤーの再描画が必要な時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnLayerNeedRedraw(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// 画像サイズが変更された時に通知を受け取る
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnImageSizeChanged(object sender, EventArgs e)
        {
            if (!AutoSize)
            {
                return;
            }

            var location = Location;
            var size = renderer.RenderSize;
            SetBounds(location.X, location.Y, size.Width, size.Height);
        }

        /// <summary>
        /// コントロールを配置するのに最適なサイズを得る。
        /// </summary>
        /// <param name="proposedSize">コントロールを配置しているサイズ</param>
        /// <returns>最適なサイズ</returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            return renderer.RenderSize;
        }


        /// <summary>
        /// 再描画する。
        /// </summary>
        /// <param name="e">イベントオブジェクト</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            // 背景描画
            PaintBackground(g);
            // 面描画
            Image renderImage = renderer.GetRenderImage();
            if (renderImage != null)
            {
                g.DrawImage(renderImage, 0, 0);
            }
        }
        /// <summary>
        /// 背景を描画する
        /// </summary>
        private void PaintBackground(Graphics g)
        {
            if (BackgroundImage != null)
            {
                using (var brush = new TextureBrush(BackgroundImage))
                {
                    brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                    g.FillRectangle(brush, g.ClipBounds);
                }
            }
            else
            {
                using (var brush = new SolidBrush(Color.Black))
                {
                    g.FillRectangle(brush, g.ClipBounds);
                }
            }
        }
    }
}
