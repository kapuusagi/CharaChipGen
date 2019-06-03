using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharaChipGenUtility.Operations;
using CharaChipGenUtility.Imaging;

namespace CharaChipGenUtility
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class FormMain : Form
    {
        private OperationSettings settings; // オペレーション設定

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public FormMain()
        {
            settings = new OperationSettings();
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

                AbstractImageOperation operation = (AbstractImageOperation)(comboBoxOperation.SelectedItem);
                if (operation == null)
                {
                    return;
                }
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
                IOperation operation = (IOperation)(comboBoxOperation.SelectedItem);
                if (operation == null)
                {
                    return;
                }

                FormSetting formSetting = new FormSetting();
                formSetting.Setting = operation.Setting;
                formSetting.ShowDialog(this);

                if (formSetting.Setting != null)
                {
                    string data = formSetting.Setting.GetData();
                    settings[operation.Name] = data;

                    string dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    string fileName = "operation.setting";
                    string path = System.IO.Path.Combine(dir, fileName);
                    settings.Save(path);
                }
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
                string dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string path = System.IO.Path.Combine(dir, "operation.setting");
                if (System.IO.File.Exists(path))
                {
                    settings.Load(path);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            comboBoxOperation.Items.Clear();

            // オペレーションを追加
            AddOperations();

            // 設定値を適用する。
            foreach (var item in comboBoxOperation.Items)
            {
                IOperation operation = (IOperation)(item);
                IOperationSetting setting = operation.Setting;
                if (setting != null)
                {
                    setting.SetData(settings[operation.Name]);
                }
            }

            if (comboBoxOperation.Items.Count > 0)
            {
                comboBoxOperation.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// オペレーションを動的に構築してコンボボックスに追加する。
        /// </summary>
        /// <remarks>
        /// もしDLLとかでプラグインをやるならここを修正する。
        /// 但しその場合にはIOperation回りを基本DLLとして外部に出さないといけない。
        /// さもないとプラグイン側でこのアプリを参照して相互参照が発生してしまう。
        /// </remarks>
        private void AddOperations()
        {
            System.Reflection.Assembly asm
                = System.Reflection.Assembly.GetExecutingAssembly();
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
                        Object item = System.Activator.CreateInstance(type);
                        comboBoxOperation.Items.Add(item);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                    }
                }
            }

        }

    }
}
