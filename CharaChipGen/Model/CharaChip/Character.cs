using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// 1名のキャラクタチップを生成するための設定モデル
    /// </summary>
    public class Character
    {
        /// <summary>
        /// パーツが変更された場合。
        /// </summary>
        public event PartsChangeEventHandler OnCharaChipPartsChanged;

        /// <summary>
        /// 部品
        /// </summary>
        private Dictionary<PartsType, Parts> charaChipParts;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public Character()
        {
            charaChipParts = new Dictionary<PartsType, Parts>();

            PropertyChangedEventHandler handler
                = new PropertyChangedEventHandler((sender, e) =>
                {
                    OnPartsPropertyChanged(sender as Parts, e.PropertyName);
                });

            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                Parts partsModel = new Parts(partsType);
                partsModel.PropertyChanged += handler;
                charaChipParts.Add(partsType, partsModel);
            }
        }

        /// <summary>
        /// modelで指定されたモデルに設定値をコピーする。
        /// </summary>
        /// <param name="model">モデル</param>
        public void CopyTo(Character model)
        {
            foreach (var partsEntry in charaChipParts)
            {
                if (model.charaChipParts.ContainsKey(partsEntry.Key))
                {
                    partsEntry.Value.CopyTo(model.charaChipParts[partsEntry.Key]);
                }
            }
        }

        /// <summary>
        /// パラメータをリセットする。
        /// </summary>
        public void Reset()
        {
            foreach (var partsEntry in charaChipParts)
            {
                partsEntry.Value.Reset();
            }
        }

        /// <summary>
        /// 頭の設定
        /// </summary>
        public Parts Head { get => charaChipParts[PartsType.Head]; }
        /// <summary>
        /// 目の設定
        /// </summary>
        public Parts Eye { get => charaChipParts[PartsType.Eye]; }

        /// <summary>
        /// 髪型の設定
        /// </summary>
        public Parts Hair { get => charaChipParts[PartsType.HairStyle]; }

        /// <summary>
        /// 体の設定
        /// </summary>
        public Parts Body { get => charaChipParts[PartsType.Body]; }

        /// <summary>
        /// アクセサリ1の設定
        /// </summary>
        public Parts Accessory1 { get => charaChipParts[PartsType.Accessory1]; }

        /// <summary>
        /// アクセサリ2の設定
        /// </summary>
        public Parts Accessory2 { get => charaChipParts[PartsType.Accessory2]; }

        /// <summary>
        /// アクセサリ3の設定
        /// </summary>
        public Parts Accessory3 { get => charaChipParts[PartsType.Accessory3]; }

        /// <summary>
        /// ヘッドアクセサリ1の設定
        /// </summary>
        public Parts HeadAccessory1 { get => charaChipParts[PartsType.HeadAccessory1]; }

        /// <summary>
        /// ヘッドアクセサリ2の設定
        /// </summary>
        public Parts HeadAccessory2 { get => charaChipParts[PartsType.HeadAccessory2]; }

        /// <summary>
        /// 部品を得る。
        /// </summary>
        /// <param name="partsType">部品種類</param>
        /// <returns>該当するCharaChipPartsModelが返る。</returns>
        public Parts GetParts(PartsType partsType)
            => charaChipParts[partsType];

        /// <summary>
        /// 各部品の設定が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="model">送信元モデル</param>
        /// <param name="propertyName">プロパティ名</param>
        private void OnPartsPropertyChanged(Parts model, string propertyName)
        {
            if (charaChipParts.ContainsValue(model))
            {
                PartsType type = model.PartsType;
                OnCharaChipPartsChanged?.Invoke(this, new PartsChangeEventArgs(type, propertyName));
            }
        }
    }
}
