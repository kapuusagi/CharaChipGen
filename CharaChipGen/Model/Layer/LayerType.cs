namespace CharaChipGen.Model.Layer
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
        /// アクセサリ4表
        /// </summary>
        Accessory4Front,
        /// <summary>
        /// アクセサリ3表
        /// </summary>
        Accessory3Front,
        /// <summary>
        /// 頭アクセサリ2表
        /// </summary>
        HeadAccessory2Front,
        /// <summary>
        /// 頭アクセサリ1表
        /// </summary>
        HeadAccessory1Front,
        /// <summary>
        /// 目
        /// </summary>
        Eye,
        /// <summary>
        /// 耳(サイドビュー用)
        /// </summary>
        HeadEar,
        /// <summary>
        /// ヘアスタイル表
        /// </summary>
        HairStyleFront,
        /// <summary>
        /// アクセサリ2表
        /// </summary>
        Accessory2Front,
        /// <summary>
        /// アクセサリ1表
        /// </summary>
        Accessory1Front,
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
        /// アクセサリ1後
        /// </summary>
        Accessory1Back,
        /// <summary>
        /// アクセサリ2後
        /// </summary>
        Accessory2Back,
        /// <summary>
        /// 頭アクセサリ1後
        /// </summary>
        HeadAccessory1Back,
        /// <summary>
        /// 頭アクセサリ2後
        /// </summary>
        HeadAccessory2Back,
        /// <summary>
        /// アクセサリ3後
        /// </summary>
        /// <remarks>3,4は背負い品など前後を覆う系統に使用する</remarks>
        Accessory3Back,
        /// <summary>
        /// アクセサリ4後
        /// </summary>
        Accessory4Back
    }
}
