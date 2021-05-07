using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStacker
{

    /// <summary>
    /// レイヤーイベントデリゲート
    /// </summary>
    /// <param name="sender">送信元オブジェクト</param>
    /// <param name="e">イベントオブジェクト</param>
    public delegate void LayerEventHandler(object sender, LayerEventArgs e);
}
