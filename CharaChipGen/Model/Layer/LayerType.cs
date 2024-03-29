﻿namespace CharaChipGen.Model.Layer
{
    /// <summary>
    /// レイヤー種別。
    /// </summary>
    /// <remarks>
    /// 下から順番に描画するよ。
    /// </remarks>
    public enum LayerType
    {
        /// <summary>
        /// 外部アクセサリ表
        /// </summary>
        /// <remarks>
        /// 外部アクセサリレイヤーは背負い品など前後を覆う系統に使用する
        /// </remarks>
        ExtAccessoryFront,
        /// <summary>
        /// 頭アクセサリ表
        /// </summary>
        HeadAccessoryFront,
        /// <summary>
        /// 耳(サイドビュー用)
        /// </summary>
        /// <remarks>
        /// エルフ耳など、ヘアスタイルの上にレンダリングしたいボディパーツで使用する。
        /// 飛び出ない耳は基本的にBodyレイヤーで完結する想定。
        /// </remarks>
        HeadEar,
        /// <summary>
        /// ヘアスタイル表
        /// </summary>
        HairStyleFront,
        /// <summary>
        /// 目
        /// </summary>
        Eye,
        /// <summary>
        /// アクセサリ1表
        /// </summary>
        AccessoryFront,
        /// <summary>
        /// 衣装
        /// </summary>
        Costume,
        /// <summary>
        /// 体
        /// </summary>
        Body,
        /// <summary>
        /// 髪型後
        /// </summary>
        HairStyleBack,
        /// <summary>
        /// アクセサリ後
        /// </summary>
        AccessoryBack,
        /// <summary>
        /// 頭アクセサリ後
        /// </summary>
        HeadAccessoryBack,
        /// <summary>
        /// 外部アクセサリ後
        /// </summary>
        /// <remarks>
        /// 外部アクセサリレイヤーは背負い品など前後を覆う系統に使用する
        /// </remarks>
        ExtAccessoryBack,
    }
}
