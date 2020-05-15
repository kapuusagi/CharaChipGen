using CharaChipGen.Model.CharaChip;
using System;

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
        public GeneratorSetting()
        {
            characters = new Character[9];
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = new Character();
            }
            ExportSetting = new ExportSetting();
        }

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
            for (int i = 0; i < setting.GetCharacterCount(); i++)
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
