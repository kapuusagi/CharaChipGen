using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 配置オペレーション設定
    /// </summary>
    public class LineupOperationSetting : IOperationSetting
    {
        public const int DIRECTION_HORIZONTAL = 0;
        public const int DIRECTION_VERTICAL = 1;

        private string outputDirectory;
        private int direction;
        private LineupOperationSettingControl control;

        public LineupOperationSetting()
        {
            outputDirectory = "";
            direction = 0;
            control = null;
        }

        /// <summary>
        /// 設定を行うためのUIを返す。
        /// </summary>
        /// <returns>UI</returns>
        public System.Windows.Forms.Control GetControl()
        {
            if (control == null)
            {
                control = new LineupOperationSettingControl();
                control.OutputDirectory = outputDirectory;
                control.Direction = direction;
                control.PropertyChanged += OnControlPropertyChanged;
            }

            return control;
        }

        /// <summary>
        /// 出力ディレクトリ設定
        /// </summary>
        public string OutputDirectory {
            set {
                if ((value == null) || outputDirectory.Equals(value))
                {
                    return;
                }
                outputDirectory = value;
                if (control != null)
                {
                    control.OutputDirectory = outputDirectory;
                }
            }
            get {
                return outputDirectory;
            }
        }

        /// <summary>
        /// 方向を設定する。
        /// </summary>
        public int Direction {
            get {
                return direction;
            }
            set {
                if (direction == value)
                {
                    return;
                }
                if ((direction != DIRECTION_HORIZONTAL)
                    && (direction != DIRECTION_VERTICAL))
                {
                    throw new ArgumentException($"Invalid direction. {value}");
                }
                direction = value;
                if (control != null)
                {
                    control.Direction = value;
                }
            }
        }

        /// <summary>
        /// コントロールのプロパティが変更された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="evt">イベントオブジェクト</param>
        private void OnControlPropertyChanged(object sender, PropertyChangedEventArgs evt)
        {
            switch (evt.PropertyName)
            {
                case "OutputDirectory":
                    OutputDirectory = control.OutputDirectory;
                    break;
                case "Direction":
                    Direction = control.Direction;
                    break;
            }
        }
    }
}
