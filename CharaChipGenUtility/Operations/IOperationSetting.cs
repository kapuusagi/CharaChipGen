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
        /// プロパティの値を文字列表現にしたものを得る。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>値</returns>
        string GetPropertyValue(string propertyName);

        /// <summary>
        /// プロパティの値を設定する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="value">プロパティの値</param>
        void SetPropertyValue(string propertyName, string value);
    }
}
