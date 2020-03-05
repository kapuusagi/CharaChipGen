using CharaChipGenUtility.Operations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class FormMain : Form
    {
        private List<IOperation> operationList;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            operationList = new List<IOperation>();
            InitializeComponent();
        }

        /// <summary>
        /// D&Dにてドラッグされてきたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnPanelAcceptDragEnter(object sender, DragEventArgs evt)
        {
            if (evt.Data.GetDataPresent(DataFormats.FileDrop))
            {
                evt.Effect = DragDropEffects.Copy;
            }
            else
            {
                evt.Effect = DragDropEffects.None;
            }

        }

        /// <summary>
        /// D&Dにて放り込まれた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnPanelAcceptDragDrop(object sender, DragEventArgs evt)
        {
            try
            {
                string[] fileNames = (string[])(evt.Data.GetData(DataFormats.FileDrop, false));

                ComboBoxItem item = (ComboBoxItem)(comboBoxOperation.SelectedItem);
                if (item == null)
                {
                    return;
                }
                IOperation operation = item.Operation;
                Task.Run(() => operation.Process(fileNames));
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(this, ae.InnerException.Message, "エラー");
                System.Diagnostics.Debug.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// メニューボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnButtonMenuClick(object sender, EventArgs evt)
        {
            try
            {
                ComboBoxItem item = (ComboBoxItem)(comboBoxOperation.SelectedItem);
                if (item == null)
                {
                    return;
                }
                IOperation operation = item.Operation;
                FormSetting formSetting = new FormSetting();
                formSetting.Setting = operation.Setting;
                formSetting.ShowDialog(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
            }
        }

        /// <summary>
        /// 画面が表示された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs evt)
        {
            try
            {
                LoadOperations();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            // オペレーションを更新
            UpdateComboboxItems();

            // 設定値を適用する。
            try
            {
                string dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string path = System.IO.Path.Combine(dir, "operation.setting");
                if (System.IO.File.Exists(path))
                {
                    OperationSettingUtility.Load(path, operationList.ToArray());
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// オペレーションを動的に構築してロードする。
        /// </summary>
        /// <remarks>
        /// もしDLLとかでプラグインをやるならここを修正する。
        /// 但しその場合にはIOperation回りを基本DLLとして外部に出さないといけない。
        /// さもないとプラグイン側でこのアプリを参照して相互参照が発生してしまう。
        /// </remarks>
        private void LoadOperations()
        {
            operationList.Clear();

            System.Reflection.Assembly[] loadedAssemblies
                = AppDomain.CurrentDomain.GetAssemblies();
            foreach (System.Reflection.Assembly asm in loadedAssemblies)
            {
                try
                {
                    LoadOperationsFromAssembly(asm);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// 指定したアセンブリからIOperationを構築してリストに追加する。
        /// </summary>
        /// <param name="asm"></param>
        private void LoadOperationsFromAssembly(System.Reflection.Assembly asm)
        {
            Type[] types = asm.GetTypes();
            Type operationType = typeof(IOperation);
            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }
                if (operationType.IsAssignableFrom(type))
                {
                    // 割り当て可能なら
                    try
                    {
                        IOperation item
                            = (IOperation)(System.Activator.CreateInstance(type));
                        operationList.Add(item);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                }
            }
        }


        /// <summary>
        /// コンボボックスに追加する。
        /// </summary>
        private void UpdateComboboxItems()
        {
            comboBoxOperation.Items.Clear();
            foreach (IOperation operation in operationList)
            {
                comboBoxOperation.Items.Add(new ComboBoxItem(operation));
            }
            if (comboBoxOperation.Items.Count > 0)
            {
                comboBoxOperation.SelectedIndex = 0;
            }
        }

        private class ComboBoxItem
        {
            public ComboBoxItem(IOperation operation)
            {
                Operation = operation;
            }
            public IOperation Operation { get; set; }
            public override string ToString()
            {
                return Operation.Name;
            }
        }

        /// <summary>
        /// フォームがクローズされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs evt)
        {
            try
            {
                string dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string fileName = "operation.setting";
                string path = System.IO.Path.Combine(dir, fileName);
                OperationSettingUtility.Save(path, operationList.ToArray());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e);
            }

        }
    }
}
