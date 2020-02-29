using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model
{
    /// <summary>
    /// CharaChipGenのジェネレート設定を扱うためのモデル。
    /// </summary>
    public class GeneratorSetting
    {
        // キャラチップデータモデル
        private Character[] charactors;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public GeneratorSetting()
        {
            charactors = new Character[9];
            for (int i = 0; i < charactors.Length; i++)
            {
                charactors[i] = new Character();
            }
            ExportSetting = new ExportSetting();
        }

        /// <summary>
        /// キャラクタを得る。
        /// </summary>
        /// <param name="index">キャラクター番号(0≦index＜GetCharactorCount())</param>
        /// <returns>Charactorオブジェクトが返る</returns>
        public Character GetCharactor(int index)
        {
            if ((index < 0) || (index >= charactors.Length))
            {
                throw new IndexOutOfRangeException("index is out of range. [" + index + "]");
            }

            return charactors[index];
        }

        /// <summary>
        /// キャラクタの数を得る。
        /// </summary>
        /// <returns>キャラクタの数</returns>
        public int GetCharactorCount() => charactors.Length;

        /// <summary>
        /// エクスポート設定
        /// </summary>
        public ExportSetting ExportSetting { get; private set; }

        public void CopyTo(GeneratorSetting setting)
        {
            for (int i = 0; i < setting.GetCharactorCount(); i++)
            {
                Character src = GetCharactor(i);
                Character dst = setting.GetCharactor(i);
                src.CopyTo(dst);
            }

            // エクスポート設定
            ExportSetting.CopyTo(setting.ExportSetting);
        }
    }
}
