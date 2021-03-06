﻿using System;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// 部品が変更されたときに通知を受け取るデリゲート。
    /// </summary>
    /// <param name="sender">送信元オブジェクト</param>
    /// <param name="e">イベントオブジェクト</param>
    public delegate void PartsChangeEventHandler(Object sender, PartsChangeEventArgs e);
}
