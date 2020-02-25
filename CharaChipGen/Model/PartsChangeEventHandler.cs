using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 部品が変更されたときに通知を受け取るデリゲート。
    /// </summary>
    /// <param name="sender">送信元オブジェクト</param>
    /// <param name="e">イベントオブジェクト</param>
    public delegate void PartsChangeEventHandler(Object sender, PartsChangeEventArgs e);
}
