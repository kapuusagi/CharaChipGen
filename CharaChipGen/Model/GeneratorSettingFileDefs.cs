using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクタチップジェネレータ設定ファイルで使用される定義。
    /// </summary>
    public static class GeneratorSettingFileDefs
    {
        /// <summary>
        /// ルートノード
        /// </summary>
        public const string NodeCharaChipGen = "charachip-gen";
        /// <summary>
        /// キャラクターセットノード
        /// </summary>
        /// <remarks>
        /// 複数のキャラクターノードを持つ。
        /// </remarks>
        public const string NodeCharacters = "characters";
        /// <summary>
        /// キャラクターノード
        /// </summary>
        public const string NodeCharacter = CharacterFileDefs.NodeCharacter;
        /// <summary>
        /// キャラクター属性：番号
        /// </summary>
        public const string CharacterAttrNumber = "number";
        /// <summary>
        /// 部品種別名ノード
        /// </summary>
        public const string NodeParts = CharacterFileDefs.NodeParts;
        /// <summary>
        /// 部品属性：部品名
        /// </summary>
        public const string PartsAttrName = CharacterFileDefs.PartsAttrName;
        /// <summary>
        /// 部品属性：素材名
        /// </summary>
        public const string PartsAttrMaterialName = CharacterFileDefs.PartsAttrMaterialName;
        /// <summary>
        /// 部品属性：Xオフセット
        /// </summary>
        public const string PartsAttrOffsetX = CharacterFileDefs.PartsAttrOffsetX;
        /// <summary>
        /// 部品属性：Yオフセット
        /// </summary>
        public const string PartsAttrOffsetY = CharacterFileDefs.PartsAttrOffsetY;
        /// <summary>
        /// 部品属性：色差
        /// </summary>
        public const string PartsAttrHue = CharacterFileDefs.PartsAttrHue;
        /// <summary>
        /// 部品属性：彩度
        /// </summary>
        public const string PartsAttrSaturation = CharacterFileDefs.PartsAttrSaturation;
        /// <summary>
        /// 部品属性：輝度
        /// </summary>
        public const string PartsAttrBrightness = CharacterFileDefs.PartsAttrBrightness;
        /// <summary>
        /// 部品属性：透過度
        /// </summary>
        public const string PartsAttrOpacity = CharacterFileDefs.PartsAttrOpacity;
        /// <summary>
        /// 出力設定ノードタグ名
        /// </summary>
        public const string NodeExportSetting = "export-setting";
        /// <summary>
        /// エクスポートパスノード
        /// </summary>
        public const string NodeExportPath = "export-path";
        /// <summary>
        /// キャラクターチップサイズノード
        /// </summary>
        public const string NodeCharaChipSize = "charachip-size";
    }
}
