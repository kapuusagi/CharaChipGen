using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キーボード操作による動作を表すクラス
    /// </summary>
    public class KeyActionEntry
    {
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="modifiers">モディファイアキー</param>
        /// <param name="action">アクション</param>
        public KeyActionEntry(Keys key, Keys modifiers, Action action)
        {
            this.Key = key;
            this.Modifiers = modifiers;
            this.Action = action;
        }
        /// <summary>
        /// ショートカットキー
        /// </summary>
        public Keys Key { get; private set; }
        /// <summary>
        /// モディファイアキー
        /// </summary>
        public Keys Modifiers { get; private set; }
        /// <summary>
        /// アクション
        /// </summary>
        public Action Action { get; private set; }

        /// <summary>
        /// ショートカットがハンドルされるかどうかを判定する。
        /// モディファイアキー(Control/Shift/Alt)押下状態はControlクラスから取得する。
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>ハンドルされる場合にはtrue, それ以外はfalse</returns>
        public bool IsAccept(Keys key)
            => IsAccept(key, Control.ModifierKeys);

        /// <summary>
        /// ショートカットがハンドルされるかどうかを判定する。
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="modifiers">モディファイアキー</param>
        /// <returns>ハンドルされる場合にはtrue, それ以外はfalse</returns>
        public bool IsAccept(Keys key, Keys modifiers)
        {
            return (key == Key)
                && ((modifiers & Modifiers) == Modifiers);
        }

        /// <summary>
        /// アクションを実行する。
        /// </summary>
        public void Invoke()
        {
            Action.Invoke();
        }
    }
}
