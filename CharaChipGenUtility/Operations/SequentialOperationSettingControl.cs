using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 順番に複数の処理を行う設定をするためのUI
    /// </summary>
    public partial class SequentialOperationSettingControl : UserControl
    {
        /// <summary>
        /// プロパティが変更された時に通知を受け取る。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SequentialOperationSettingControl()
        {
            InitializeComponent();
            InitToolboxItems();
        }

        /// <summary>
        /// 出力ディレクトリを選択する。
        /// </summary>
        public string OutputDirectory {
            set {
                selectDirectoryControl.Directory = value;
            }
            get {
                return selectDirectoryControl.Directory;
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
            NotifyPropertyChanged("Operations");
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
            if (selectedIndex < listBoxOperations.Items.Count)
            {
                listBoxOperations.SelectedIndex = selectedIndex;
            }
            else
            {
                listBoxOperations.SelectedIndex = listBoxOperations.Items.Count - 1;
            }

            NotifyPropertyChanged("Operations");
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
            listBoxOperations.SelectedIndex = selectedIndex - 1;
            NotifyPropertyChanged("Operations");
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
            listBoxOperations.SelectedIndex = selectedIndex + 1;
            NotifyPropertyChanged("Operations");
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
                case "Directory":
                    NotifyPropertyChanged("OutputDirectory");
                    break;
            }
        }

        /// <summary>
        /// プロパティの変更があったことを通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
