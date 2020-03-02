using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// シーケンシャルオペレーションの設定
    /// </summary>
    public class SequentialOperationSetting : IOperationSetting, INotifyPropertyChanged
    {
        // イメージオペレーションリスト
        private BindingList<IImageOperation> operations;
        // 出力ディレクトリ
        private string outputDirectory;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SequentialOperationSetting()
        {
            operations = new BindingList<IImageOperation>();
            operations.ListChanged += (sender, e) => { NotifyPropertyChanged(nameof(Operations)); };
        }

        /// <summary>
        /// プロパティが変更された。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたときに通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// イメージオペレーションリスト
        /// </summary>
        public BindingList<IImageOperation> Operations {
            get {
                return operations;
            }
            set {
                if (operations.Equals(value))
                {
                    return;
                }
                operations = value;
                NotifyPropertyChanged(nameof(Operations));

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
                NotifyPropertyChanged(nameof(OutputDirectory));
            }
        }


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public System.Windows.Forms.Control GetControl()
        {
            return new SequentialOperationSettingControl() { Model = this };
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
                case nameof(OutputDirectory):
                    return OutputDirectory;
                case nameof(Operations):
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
                case nameof(OutputDirectory):
                    OutputDirectory = value;
                    break;
                case nameof(Operations):
                    Operations = GetOperationsByString(value);
                    break;
            }
        }

        /// <summary>
        /// 文字列を展開して処理リストに変換して返す。
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>IImageOperationリスト</returns>
        private BindingList<IImageOperation> GetOperationsByString(string value)
        {
            BindingList<IImageOperation> ops = new BindingList<IImageOperation>();
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
