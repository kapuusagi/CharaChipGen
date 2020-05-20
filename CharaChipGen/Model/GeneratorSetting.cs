using CharaChipGen.Model.CharaChip;
using System;
using System.Runtime.InteropServices;

namespace CharaChipGen.Model
{
    /// <summary>
    /// CharaChipGenのジェネレート設定を扱うためのモデル。
    /// </summary>
    public class GeneratorSetting
    {
        // キャラチップデータモデル
        private Character[] characters;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public GeneratorSetting() : this(4, 2)
        {
        }

        /// <summary>
        /// 指定したキャラクタ数で新しいインスタンスを構築する。
        /// </summary>
        public GeneratorSetting(int horizontalCount, int verticalCount)
        {
            int count = horizontalCount * verticalCount;
            if (count <= 0)
            {
                throw new ArgumentException("Character count is invalid.");
            }
            HorizontalCount = horizontalCount;
            VerticalCount = verticalCount;
            characters = new Character[count];
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = new Character();
            }
            ExportSetting = new ExportSetting();
        }

        /// <summary>
        /// 横方向キャラクタ数
        /// </summary>
        public int HorizontalCount { get; private set; }
        /// <summary>
        /// 縦方向キャラクタ数
        /// </summary>
        public int VerticalCount { get; private set; }

        /// <summary>
        /// キャラクタを得る。
        /// </summary>
        /// <param name="index">キャラクター番号(0≦index＜GetCharacterCount())</param>
        /// <returns>Characterオブジェクトが返る</returns>
        public Character GetCharacter(int index)
        {
            if ((index < 0) || (index >= characters.Length))
            {
                throw new IndexOutOfRangeException("index is out of range. [" + index + "]");
            }

            return characters[index];
        }

        /// <summary>
        /// キャラクタの数を得る。
        /// </summary>
        /// <returns>キャラクタの数</returns>
        public int GetCharacterCount() => characters.Length;

        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting ExportSetting { get; private set; }

        /// <summary>
        /// settingsに設定をコピーする。
        /// </summary>
        /// <param name="setting">コピー先のオブジェクト</param>
        public void CopyTo(GeneratorSetting setting)
        {
            int copyCount = Math.Min(GetCharacterCount(), setting.GetCharacterCount());
            for (int i = 0; i < copyCount; i++)
            {
                Character src = GetCharacter(i);
                Character dst = setting.GetCharacter(i);
                src.CopyTo(dst);
            }

            // エクスポート設定
            ExportSetting.CopyTo(setting.ExportSetting);
        }

        /// <summary>
        /// この設定をリセットし、初期状態にする。
        /// </summary>
        public void Reset()
        {
            foreach (Character character in characters)
            {
                character.Reset();
            }
            ExportSetting = new ExportSetting();
        }
    }
}
