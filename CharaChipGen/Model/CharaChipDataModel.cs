using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 1名のキャラクタチップを生成するための設定モデル
    /// </summary>
    public class CharaChipDataModel
    {
        /// <summary>
        /// パーツが変更された場合。
        /// </summary>
        public event PartsChangeEventHandler OnCharaChipParamChanged;

        /// <summary>
        /// 部品
        /// </summary>
        private Dictionary<PartsType, CharaChipPartsModel> charaChipParts;


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipDataModel()
        {
            charaChipParts = new Dictionary<PartsType, CharaChipPartsModel>();

            PropertyChangedEventHandler handler
                = new PropertyChangedEventHandler((sender, e) =>
                {
                    OnOneParameterChanged(sender as CharaChipPartsModel, e.PropertyName);
                });

            PartsType[] partsTypes = (PartsType[])(Enum.GetValues(typeof(PartsType)));
            foreach (PartsType partsType in partsTypes)
            {
                CharaChipPartsModel partsModel = new CharaChipPartsModel(partsType);
                partsModel.PropertyChanged += handler;
                charaChipParts.Add(partsType, partsModel);
            }
        }

        /// <summary>
        /// modelで指定されたモデルに設定値をコピーする。
        /// </summary>
        /// <param name="model">モデル</param>
        public void CopyTo(CharaChipDataModel model)
        {
            foreach (var partsEntry in charaChipParts)
            {
                if (model.charaChipParts.ContainsKey(partsEntry.Key))
                {
                    partsEntry.Value.CopyTo(charaChipParts[partsEntry.Key]);
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
        public CharaChipPartsModel Head { get => charaChipParts[PartsType.Head]; }
        /// <summary>
        /// 目の設定
        /// </summary>
        public CharaChipPartsModel Eye { get => charaChipParts[PartsType.Eye]; }

        /// <summary>
        /// 髪型の設定
        /// </summary>
        public CharaChipPartsModel Hair { get => charaChipParts[PartsType.HairStyle]; }

        /// <summary>
        /// 体の設定
        /// </summary>
        public CharaChipPartsModel Body { get => charaChipParts[PartsType.Body]; }

        /// <summary>
        /// アクセサリ1の設定
        /// </summary>
        public CharaChipPartsModel Accessory1 { get => charaChipParts[PartsType.Accessory1]; }

        /// <summary>
        /// アクセサリ2の設定
        /// </summary>
        public CharaChipPartsModel Accessory2 { get => charaChipParts[PartsType.Accessory2]; }

        /// <summary>
        /// アクセサリ3の設定
        /// </summary>
        public CharaChipPartsModel Accessory3 { get => charaChipParts[PartsType.Accessory3]; }

        /// <summary>
        /// ヘッドアクセサリ1の設定
        /// </summary>
        public CharaChipPartsModel HeadAccessory1 { get => charaChipParts[PartsType.HeadAccessory1]; }

        /// <summary>
        /// ヘッドアクセサリ2の設定
        /// </summary>
        public CharaChipPartsModel HeadAccessory2 { get => charaChipParts[PartsType.HeadAccessory2]; }

        /// <summary>
        /// 部品を得る。
        /// </summary>
        /// <param name="partsType">部品種類</param>
        /// <returns>該当するCharaChipPartsModelが返る。</returns>
        public CharaChipPartsModel GetParts(PartsType partsType)
            => charaChipParts[partsType];

        /// <summary>
        /// 各モデルの設定が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="model">送信元モデル</param>
        /// <param name="propertyName">プロパティ名</param>
        private void OnOneParameterChanged(CharaChipPartsModel model, string propertyName)
        {
            if (charaChipParts.ContainsValue(model))
            {
                PartsType type = model.PartsType;
                OnCharaChipParamChanged?.Invoke(this, new PartsChangeEventArgs(type, propertyName));
            }
        }
    }
}
