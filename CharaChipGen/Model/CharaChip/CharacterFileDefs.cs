namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// Characterをファイル化したときのアトリビュート名
    /// </summary>
    public static class CharacterFileDefs
    {
        /// <summary>
        /// キャラクターノード
        /// </summary>
        public const string NodeCharacter = "character";
        /// <summary>
        /// 部品種別名ノード
        /// </summary>
        public const string NodeParts = "parts";
        /// <summary>
        /// 部品属性：部品名
        /// </summary>
        public const string PartsAttrName = "name";
        /// <summary>
        /// 部品属性：素材名
        /// </summary>
        public const string PartsAttrMaterialName = "material-name";
        /// <summary>
        /// 部品属性：Xオフセット
        /// </summary>
        public const string PartsAttrOffsetX = "x-offset";
        /// <summary>
        /// 部品属性：Yオフセット
        /// </summary>
        public const string PartsAttrOffsetY = "y-offset";
        /// <summary>
        /// 部品属性：色1
        /// </summary>
        public const string PartsAttrColor1 = "color1";
        /// <summary>
        /// 部品属性：色2
        /// </summary>
        public const string PartsAttrColor2 = "color2";
    }
}
