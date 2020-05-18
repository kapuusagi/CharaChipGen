using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Material;
using CharaChipGen.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// 1つの部品を設定するためのUIを提供するクラス。
    /// </summary>
    public partial class CharaChipGeneratorPartsView : UserControl
    {
        // 未選択を表すコンボボックスのアイテム。
        private readonly string ItemNoSelect = Resources.ItemNoSelect;
        // このビューが表すデータのモデル。
        private Parts parts;
        // モデルのデータ変更を受け取るためのハンドラ
        private PropertyChangedEventHandler handler;
        // パラメータ編集ビュー
        private PartsEditView view;
        // ドロップダウン表示
        private ToolStripDropDown toolStripDropDown;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorPartsView()
        {
            InitializeComponent();
            parts = new Parts(PartsType.Accessory1);
            handler = new PropertyChangedEventHandler((sender, e) =>
            {
                ModelToUI();
            });
            parts.PropertyChanged += handler;
            toolStripDropDown = new ToolStripDropDown();
            view = new PartsEditView();
            view.Parts = Parts;
            toolStripDropDown.Items.Add(new ToolStripControlHost(view));
        }

        /// <summary>
        /// 格納しているデータのモデル
        /// </summary>
        public Parts Parts {
            get { return parts; }
            set {
                if ((value == null) || (value == parts))
                {
                    return;
                }
                parts.PropertyChanged -= handler;
                parts = value;
                parts.PropertyChanged += handler;

                ModelToUI();
            }
        }

        /// <summary>
        /// Yオフセット値の表示可否
        /// </summary>
        public bool EditYOffset {
            get { return view.EditYOffset; }
            set { view.EditYOffset = value; }
        }

        /// <summary>
        /// HSVの表示可否
        /// </summary>
        public bool EditHSV {
            get { return view.EditHSV; }
            set { view.EditHSV = value; }
        }

        /// <summary>
        /// モデルの設定値をビューに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            if (string.IsNullOrEmpty(parts.MaterialName))
            {
                // 0番目のアイテムは未選択アイテムになる。
                if (comboBoxItem.Items.Count > 0)
                {
                    comboBoxItem.SelectedIndex = 0; // 0は未選択
                }
            }
            else
            {
                // 何かしらが選択されている
                for (int i = 1; i < comboBoxItem.Items.Count; i++)
                {
                    Material item = (Material)(comboBoxItem.Items[i]);
                    if (item.Name == parts.MaterialName)
                    {
                        comboBoxItem.SelectedIndex = i;
                        break;
                    }
                }
            }

            view.Parts = parts;
        }

        /// <summary>
        /// 部品名
        /// </summary>
        public string PartsName {
            get { return labelItemName.Text; }
            set { labelItemName.Text = value; }
        }

        /// <summary>
        /// 選択可能なマテリアルリストを初期化する。
        /// </summary>
        /// <param name="materialList">マテリアルリスト</param>
        public void SetMaterialList(MaterialList materialList)
        {
            comboBoxItem.Items.Clear();
            comboBoxItem.Items.Add(ItemNoSelect);
            foreach (Material material in materialList)
            {
                comboBoxItem.Items.Add(material);
            }

            comboBoxItem.SelectedIndex = 0; // 未選択状態

            comboBoxItem.Enabled = comboBoxItem.Items.Count > 1;

        }

        /// <summary>
        /// 素材名が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMaterialNameChanged(object sender, EventArgs e)
        {
            Object selItem = comboBoxItem.SelectedItem;
            if (selItem.Equals(ItemNoSelect))
            {
                parts.MaterialName = "";
            }
            else
            {
                parts.MaterialName = (selItem != null) ? selItem.ToString() : string.Empty;
            }
        }



        /// <summary>
        /// 調整ボタンがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonAdjustClick(object sender, EventArgs e)
        {
            toolStripDropDown.Show(Cursor.Position);
        }


        /// <summary>
        /// コンボボックスで項目が描画されるときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnComboBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            ComboBox cb = sender as ComboBox;

            if ((e.Index >= 0) && (e.Index < cb.Items.Count))
            {
                object item = cb.Items[e.Index];
                string text = item.Equals(ItemNoSelect) ? ItemNoSelect
                    : ((Material)(item)).GetDisplayName();

                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    var metrix = e.Graphics.MeasureString(text, e.Font);
                    float x = e.Bounds.X;
                    float y = e.Bounds.Y + (e.Bounds.Height - metrix.Height) / 2;
                    e.Graphics.DrawString(text, e.Font, brush, x, y);
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(e.BackColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }
    }
}
