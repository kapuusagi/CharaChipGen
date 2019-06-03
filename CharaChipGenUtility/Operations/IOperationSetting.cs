using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 処理に対する設定を行うためのインタフェース。
    /// </summary>
    public interface IOperationSetting
    {
        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        Control GetControl();

        /// <summary>
        /// 保存した文字列表現からデータを復元する。
        /// </summary>
        /// <param name="s">文字列</param>
        void SetData(string s);

        /// <summary>
        /// 保存用に文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        string GetData();
    }
}
