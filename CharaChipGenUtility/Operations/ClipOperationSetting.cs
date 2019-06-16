using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// クリッピング処理設定
    /// </summary>
    public class ClipOperationSetting : IOperationSetting
    {
        // 設定用UI
        private ClipOperationSettingControl control;
        // 出力ディレクトリ
        private string outputDirectory;
        // クリップ領域
        private System.Drawing.Rectangle clipBounds;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public ClipOperationSetting()
        {
            outputDirectory = "";
            control = null;
            clipBounds = new System.Drawing.Rectangle(0, 0, 192, 384);
        }

        /// <summary>
        /// 出力ディレクトリ
        /// </summary>
        public string OutputDirectory {
            get { return outputDirectory; }
            set {
                if ((value == null) || (value.Equals(outputDirectory)))
                {
                    return;
                }
                outputDirectory = value;
                if (control != null)
                {
                    control.OutputDirectory = value;
                }
            }
        }

        /// <summary>
        /// クリップ領域
        /// </summary>
        public System.Drawing.Rectangle ClipBounds {
            get { return clipBounds; }
            set {
                if (clipBounds.Equals(value))
                {
                    return;
                }
                clipBounds = value;
                if (control != null)
                {
                    control.ClipBounds = value;
                }

            }
        }

        /// <summary>
        /// 設定を操作するためのUIを得る。
        /// </summary>
        /// <returns>UIが返る。</returns>
        public System.Windows.Forms.Control GetControl()
        {
            if (control == null)
            {
                control = new ClipOperationSettingControl();
                control.OutputDirectory = OutputDirectory;
                control.ClipBounds = ClipBounds;
                control.PropertyChanged += OnControlPropertyChanged;
            }
            return control;
        }


        /// <summary>
        /// コントロールのプロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "OutputDirectory":
                    OutputDirectory = control.OutputDirectory;
                    break;
                case "ClipBounds":
                    ClipBounds = control.ClipBounds;
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
                case "ClipBounds":
                    return $"{clipBounds.X},{clipBounds.Y},{clipBounds.Width},{clipBounds.Height}";
                default:
                    return "";
            }
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
                case "ClipBounds":
                    {
                        string[] args = value.Split(',');
                        try
                        {
                            int x = Convert.ToInt32(args[0]);
                            int y = Convert.ToInt32(args[1]);
                            int width = Convert.ToInt32(args[2]);
                            int height = Convert.ToInt32(args[3]);
                            if ((x >= 0) && (y >= 0) && (width > 0) && (height > 0))
                            {
                                ClipBounds = new System.Drawing.Rectangle(x, y, width, height);
                            }

                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);
                        }

                    }
                    break;
            }

        }
    }
}
