using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// シーケンシャルオペレーションの設定
    /// </summary>
    public class SequentialOperationSetting : IOperationSetting
    {
        // コントロール
        private SequentialOperationSettingControl control;
        // イメージオペレーションリスト
        private List<IImageOperation> operations;
        // 出力ディレクトリ
        private string outputDirectory;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SequentialOperationSetting()
        {
            control = null;
            operations = new List<IImageOperation>();
        }

        /// <summary>
        /// イメージオペレーションリスト
        /// </summary>
        public List<IImageOperation> Operations {
            get {
                return operations;
            }
            set {
                operations = value;
                if (control == null)
                {
                    control.Operations = operations;
                }
            }
        }

        /// <summary>
        /// 出力ディレクトリ
        /// </summary>
        public string OutputDirectory {
            get { return outputDirectory; }
            set {
                if ((value == null) || (outputDirectory == value))
                {
                    return;
                }
                outputDirectory = value;
                if (control != null)
                {
                    control.OutputDirectory = OutputDirectory;
                }
            }
        }


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public System.Windows.Forms.Control GetControl()
        {
            if (control == null)
            {
                control = new SequentialOperationSettingControl();
                control.Operations = Operations;
                control.OutputDirectory = OutputDirectory;

                control.PropertyChanged += OnControlPropertyChanged;
            }
            return control;
        }

        /// <summary>
        /// コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "OutputDirectory":
                    OutputDirectory = control.OutputDirectory;
                    break;
                case "Operations":
                    Operations = control.Operations;
                    break;
            }
            
        }
        /// <summary>
        /// プロパティの値を文字列表現にしたものを得る。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>値</returns>
        public string GetPropertyValue(string propertyName)
        {
            switch (propertyName)
            {
                case "OutputDirectory":
                    return OutputDirectory;
                case "Operations":
                    return GetOperationsAsString();
                default:
                    return "";
            }

        }

        /// <summary>
        /// 処理リストを文字列に変換する。
        /// </summary>
        /// <returns></returns>
        public string GetOperationsAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IImageOperation operation in operations)
            {
                sb.Append(operation.GetType().FullName).Append(',');
            }

            return sb.ToString();
        }

        /// <summary>
        /// プロパティの値を設定する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="value">プロパティの値</param>
        public void SetPropertyValue(string propertyName, string value)
        {
            switch (propertyName)
            {
                case "OutputDirectory":
                    OutputDirectory = value;
                    break;
                case "Operations":
                    Operations = GetOperationsByString(value);
                    break;
            }
        }

        /// <summary>
        /// 文字列を展開して処理リストに変換して返す。
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>IImageOperationリスト</returns>
        private List<IImageOperation> GetOperationsByString(string value)
        {
            List<IImageOperation> ops = new List<IImageOperation>();
            string[] classNames = value.Split(',');
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (string className in classNames)
            {
                try
                {
                    object inst = asm.CreateInstance(className);
                    if (inst is IImageOperation op)
                    {
                        ops.Add(op);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            return ops;
        }
    }
}
