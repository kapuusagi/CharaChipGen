using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGen.Model.Material;
using CharaChipGen.Model;

namespace CharaChipGen.MaterialViewForm
{
    /// <summary>
    /// 素材のプレビューフォーム
    /// </summary>
    public partial class MaterialViewForm : Form
    {
        //　描画する素材。
        private Material material;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MaterialViewForm()
        {
            material = null;
            InitializeComponent();
        }

        /// <summary>
        /// 描画する素材
        /// </summary>
        [Browsable(false)]
        public Material Material {
            get => material;
            set {
                if ((material == value) && ((material != null) && material.Equals(value)))
                {
                    return;
                }

                material = value;
                MaterialRenderData renderData = new MaterialRenderData() { Material = material };
                materialView.MaterialRenderData = renderData;
            }
        }


        /// <summary>
        /// クローズボタンが押されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// タイマーにより、所定の時間経過毎に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            materialView.UpdateTick();
        }

        /// <summary>
        /// フォームが最初に表示されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// フォームが閉じられようとしている時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
