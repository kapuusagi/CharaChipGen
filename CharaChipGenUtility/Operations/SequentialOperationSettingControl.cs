using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 順番に複数の処理を行う設定をするためのUI
    /// </summary>
    public partial class SequentialOperationSettingControl : UserControl
    {
        private SequentialOperationSetting model;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SequentialOperationSettingControl()
        {
            InitializeComponent();
            InitToolboxItems();
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public SequentialOperationSetting Model {
            get => model;
            set {
                if ((model == value) || ((model != null) && model.Equals(value)))
                {
                    return;
                }

                if (model != null)
                {
                    model.PropertyChanged -= OnModelPropertyChanged;
                }
                model = value;
                if (model != null)
                {
                    model.PropertyChanged += OnModelPropertyChanged;
                }
                ModelToUI();
            }
        }

        /// <summary>
        /// モデルのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SequentialOperationSetting.OutputDirectory):
                    selectDirectoryControl.Directory = Model?.OutputDirectory ?? "";
                    break;
                case nameof(SequentialOperationSetting.Operations):
                    listBoxOperations.Items.Clear();
                    if (Model != null)
                    {
                        listBoxOperations.Items.AddRange(Model.Operations.ToArray());
                    }
                    break;
            }
        }

        /// <summary>
        /// モデルの設定をUIに反映させる。
        /// </summary>
        private void ModelToUI()
        {
            selectDirectoryControl.Directory = Model?.OutputDirectory ?? "";
            listBoxOperations.Items.Clear();
            if (Model != null)
            {
                listBoxOperations.Items.AddRange(Model.Operations.ToArray());
            }

        }



        /// <summary>
        /// 処理
        /// </summary>
        public List<IImageOperation> Operations {
            set {
                listBoxOperations.Items.Clear();
                listBoxOperations.Items.AddRange(value.ToArray());
            }
            get {
                return listBoxOperations.Items.Cast<IImageOperation>().ToList();
            }
        }

        /// <summary>
        /// ツールボックスの項目を初期化する。
        /// </summary>
        private void InitToolboxItems()
        {
            listBoxTool.Items.Clear();
            System.Reflection.Assembly asm
                = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();
            Type operationType = typeof(IImageOperation);
            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }
                if (operationType.IsAssignableFrom(type))
                {
                    IImageOperation operation
                        = (IImageOperation)(System.Activator.CreateInstance(type));
                    listBoxTool.Items.Add(operation);
                }
            }
        }

        /// <summary>
        /// 項目を描画する必要があるときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnListBoxToolDrawItem(object sender, DrawItemEventArgs evt)
        {
            ListBox list = (ListBox)(sender);

            evt.DrawBackground();

            string text = "";
            if ((evt.Index >= 0) && (evt.Index < list.Items.Count))
            {
                IImageOperation item = (IImageOperation)(list.Items[evt.Index]);
                text = item.Name;
            }

            using (Font font = new Font(text, list.Font.Size))
            using (Brush brush = new SolidBrush(evt.ForeColor))
            {
                float ym = (evt.Bounds.Height - evt.Graphics.MeasureString(text, font).Height) / 2;
                evt.Graphics.DrawString(text, font, brush, evt.Bounds.X, evt.Bounds.Y + ym);
            }

            evt.DrawFocusRectangle();
        }

        /// <summary>
        /// ツール欄で選択が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnListBoxToolSelectedValueChanged(object sender, EventArgs evt)
        {
            ListBox listBox = (ListBox)(sender);
            buttonAdd.Enabled = (listBox.SelectedIndex >= 0);
        }

        /// <summary>
        /// 処理欄で選択が変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnListBoxOperationsSelectedValueChanged(object sender, EventArgs evt)
        {
            ListBox listBox = (ListBox)(sender);
            buttonRemove.Enabled = (listBox.SelectedIndex >= 0);
            buttonUp.Enabled = (listBox.SelectedIndex >= 0);
            buttonDown.Enabled = (listBox.SelectedIndex >= 0);
        }

        /// <summary>
        /// 追加ボタンが押された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonAddClick(object sender, EventArgs evt)
        {
            IImageOperation item = (IImageOperation)(listBoxTool.SelectedItem);

            // インスタンスを生成して追加する必要がある。
            // じゃないとコピーしか格納されない。
            // 今は処理ごとの設定はサポートしていないのでそれでもいいんだけど、
            // 将来的にサポートした場合に問題が発生するのでこのようにする。
            // 
            IImageOperation operation
                = (IImageOperation)(System.Activator.CreateInstance(item.GetType()));
            listBoxOperations.Items.Add(operation);
            if (Model != null)
            {
                Model.Operations.Add(operation);
            }
        }

        /// <summary>
        /// 削除ボタンが押された
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonRemoveClick(object sender, EventArgs evt)
        {
            int selectedIndex = listBoxOperations.SelectedIndex;
            listBoxOperations.Items.RemoveAt(selectedIndex);
            if (Model != null)
            {
                Model.Operations.RemoveAt(selectedIndex);
            }
            if (selectedIndex < listBoxOperations.Items.Count)
            {
                listBoxOperations.SelectedIndex = selectedIndex;
            }
            else
            {
                listBoxOperations.SelectedIndex = listBoxOperations.Items.Count - 1;
            }
        }

        /// <summary>
        /// 上に移動ボタンが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void OnButtonUpClick(object sender, EventArgs evt)
        {
            int selectedIndex = listBoxOperations.SelectedIndex;
            if (selectedIndex <= 0)
            {
                // これ以上、上にいかない。
                return;
            }

            object item = listBoxOperations.Items[selectedIndex];
            listBoxOperations.Items.RemoveAt(selectedIndex);
            listBoxOperations.Items.Insert(selectedIndex - 1, item);
            if (Model != null)
            {
                Model.Operations.RemoveAt(selectedIndex);
                Model.Operations.Insert(selectedIndex - 1, (IImageOperation)(item));
            }
            listBoxOperations.SelectedIndex = selectedIndex - 1;


        }

        /// <summary>
        /// 下に移動ボタンが押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evt"></param>
        private void OnButtonDownClick(object sender, EventArgs evt)
        {
            int selectedIndex = listBoxOperations.SelectedIndex;
            if (selectedIndex >= (listBoxOperations.Items.Count - 1))
            {
                // これ以上、下にいかない。
                return;
            }

            object item = listBoxOperations.Items[selectedIndex];
            listBoxOperations.Items.RemoveAt(selectedIndex);
            listBoxOperations.Items.Insert(selectedIndex + 1, item);

            if (Model != null)
            {
                Model.Operations.RemoveAt(selectedIndex);
                Model.Operations.Insert(selectedIndex, (IImageOperation)(item));
            }
            listBoxOperations.SelectedIndex = selectedIndex + 1;
        }

        /// <summary>
        /// フォルダ選択コントロールでプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case nameof(selectDirectoryControl.Directory):
                    if (Model != null)
                    {
                        Model.OutputDirectory = selectDirectoryControl.Directory;
                    }
                    break;
            }
        }


    }
}
