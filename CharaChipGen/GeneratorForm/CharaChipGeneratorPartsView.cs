using CharaChipGen.Model.CharaChip;
using CharaChipGen.Model.Material;
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
        private const string ItemNoSelect = "<選択なし>";
        // このビューが表すデータのモデル。
        private Parts model;
        // modelのデータ変更を受け取るためのハンドラ
        private PropertyChangedEventHandler handler;
        // パラメータ編集ビュー
        private PartsEditView paramEditView;
        // ドロップダウン表示
        private ToolStripDropDown toolStripDropDown;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorPartsView()
        {
            InitializeComponent();
            model = new Parts(PartsType.Accessory1);
            handler = new PropertyChangedEventHandler((sender, e) =>
            {
                ApplyModelToView();
            });
            model.PropertyChanged += handler;
            toolStripDropDown = new ToolStripDropDown();
            paramEditView = new PartsEditView();
            paramEditView.Model = Model;
            toolStripDropDown.Items.Add(new ToolStripControlHost(paramEditView));
        }

        /// <summary>
        /// 格納しているデータのモデル
        /// </summary>
        public Parts Model {
            get { return model; }
            set {
                if ((value == null) || (value == model))
                {
                    return;
                }
                model.PropertyChanged -= handler;
                model = value;
                model.PropertyChanged += handler;

                ApplyModelToView();
            }
        }

        /// <summary>
        /// Yオフセット値の表示可否
        /// </summary>
        public bool EditYOffset {
            get { return paramEditView.EditYOffset; }
            set { paramEditView.EditYOffset = value; }
        }

        /// <summary>
        /// HSVの表示可否
        /// </summary>
        public bool EditHSV {
            get { return paramEditView.EditHSV; }
            set { paramEditView.EditHSV = value; }
        }

        /// <summary>
        /// モデルの設定値をビューに反映させる。
        /// </summary>
        private void ApplyModelToView()
        {
            if (model.MaterialName == "")
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
                    if (item.Name == model.MaterialName)
                    {
                        comboBoxItem.SelectedIndex = i;
                        break;
                    }
                }
            }

            paramEditView.Model = model;
        }

        /// <summary>
        /// 項目名
        /// </summary>
        public string ParameterName {
            get { return labelItemName.Text; }
            set { labelItemName.Text = value; }
        }

        /// <summary>
        /// 選択可能なマテリアルリストを初期化する。
        /// </summary>
        /// <param name="ml"></param>
        public void SetMaterialList(MaterialList ml)
        {
            comboBoxItem.Items.Clear();
            comboBoxItem.Items.Add(ItemNoSelect);
            foreach (Material m in ml)
            {
                comboBoxItem.Items.Add(m);
            }

            comboBoxItem.SelectedIndex = 0; // 未選択状態

            comboBoxItem.Enabled = comboBoxItem.Items.Count > 1;

        }

        /// <summary>
        /// 素材名が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnMaterialNameChanged(object sender, EventArgs evt)
        {
            Object selItem = comboBoxItem.SelectedItem;
            if (selItem.Equals(ItemNoSelect))
            {
                model.MaterialName = "";
            }
            else
            {
                model.MaterialName = (selItem != null) ? selItem.ToString() : "";
            }
        }



        /// <summary>
        /// 調整ボタンがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonAdjustClick(object sender, EventArgs e)
        {
            toolStripDropDown.Show(Cursor.Position);
        }


        /// <summary>
        /// コンボボックスで項目が描画されるときに通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
