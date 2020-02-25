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
        public const string ParamNameHead = "Head";
        public const string ParamNameEye = "Eye";
        public const string ParamNameHair = "Hair";
        public const string ParamNameBody = "Body";
        public const string ParamNameAccessory1 = "Accessory1";
        public const string ParamNameAccessory2 = "Accessory2";
        public const string ParamNameAccessory3 = "Accessory3";
        public const string ParamNameHeadAccessory1 = "HeadAccessory1";
        public const string ParamNameHeadAccessory2 = "HeadAccessory2";
        public const string ParamNameFace = "Face";

        public event PartsChangeEventHandler OnCharaChipParamChanged;
        public event EventHandler OnFaceParamChanged;

        private CharaChipPartsModel head;
        private CharaChipPartsModel eye;
        private CharaChipPartsModel hair;
        private CharaChipPartsModel body;
        private CharaChipPartsModel accessory1;
        private CharaChipPartsModel accessory2;
        private CharaChipPartsModel accessory3;
        private CharaChipPartsModel headAccessory1;
        private CharaChipPartsModel headAccessory2;
        private CharaChipPartsModel face;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipDataModel()
        {
            head = new CharaChipPartsModel(ParamNameHead);
            eye = new CharaChipPartsModel(ParamNameEye);
            hair = new CharaChipPartsModel(ParamNameHair);
            body = new CharaChipPartsModel(ParamNameBody);
            accessory1 = new CharaChipPartsModel(ParamNameAccessory1);
            accessory2 = new CharaChipPartsModel(ParamNameAccessory2);
            accessory3 = new CharaChipPartsModel(ParamNameAccessory3);
            headAccessory1 = new CharaChipPartsModel(ParamNameHeadAccessory1);
            headAccessory2 = new CharaChipPartsModel(ParamNameHeadAccessory2);
            face = new CharaChipPartsModel(ParamNameFace);

            PropertyChangedEventHandler handler
                = new PropertyChangedEventHandler((sender, e) =>
                {
                    OnOneParameterChanged(sender);
                });
            head.PropertyChanged += handler;
            eye.PropertyChanged += handler;
            hair.PropertyChanged += handler;
            body.PropertyChanged += handler;
            accessory1.PropertyChanged += handler;
            accessory2.PropertyChanged += handler;
            accessory3.PropertyChanged += handler;
            headAccessory1.PropertyChanged += handler;
            headAccessory2.PropertyChanged += handler;

            face.PropertyChanged += handler;
        }

        /// <summary>
        /// modelで指定されたモデルに設定値をコピーする。
        /// </summary>
        /// <param name="model">モデル</param>
        public void CopyTo(CharaChipDataModel model)
        {
            head.CopyTo(model.head);
            eye.CopyTo(model.eye);
            hair.CopyTo(model.hair);
            body.CopyTo(model.body);
            accessory1.CopyTo(model.accessory1);
            accessory2.CopyTo(model.accessory2);
            accessory3.CopyTo(model.accessory3);
            headAccessory1.CopyTo(model.headAccessory1);
            headAccessory2.CopyTo(model.headAccessory2);

            face.CopyTo(model.Face);
        }

        /// <summary>
        /// パラメータをリセットする。
        /// </summary>
        public void Reset()
        {
            head.Reset();
            eye.Reset();
            hair.Reset();
            body.Reset();
            accessory1.Reset();
            accessory2.Reset();
            accessory3.Reset();
            headAccessory1.Reset();
            headAccessory2.Reset();

            face.Reset();
        }

        /// <summary>
        /// 頭の設定
        /// </summary>
        public CharaChipPartsModel Head
        {
            get { return this.head; }
        }
        /// <summary>
        /// 目の設定
        /// </summary>
        public CharaChipPartsModel Eye
        {
            get { return this.eye; }
        }

        /// <summary>
        /// 髪型の設定
        /// </summary>
        public CharaChipPartsModel Hair
        {
            get { return hair; }
        }

        /// <summary>
        /// 体の設定
        /// </summary>
        public CharaChipPartsModel Body
        {
            get { return body; }
        }
        /// <summary>
        /// アクセサリ1の設定
        /// </summary>
        public CharaChipPartsModel Accessory1
        {
            get { return accessory1; }
        }
        /// <summary>
        /// アクセサリ2の設定
        /// </summary>
        public CharaChipPartsModel Accessory2
        {
            get { return accessory2; }
        }
        /// <summary>
        /// アクセサリ3の設定
        /// </summary>
        public CharaChipPartsModel Accessory3
        {
            get { return accessory3; }
        }

        /// <summary>
        /// ヘッドアクセサリ1の設定
        /// </summary>
        public CharaChipPartsModel HeadAccessory1
        {
            get { return headAccessory1; }
        }
        /// <summary>
        /// ヘッドアクセサリ2の設定
        /// </summary>
        public CharaChipPartsModel HeadAccessory2
        {
            get { return headAccessory2; }
        }
        /// <summary>
        /// 顔の設定
        /// </summary>
        public CharaChipPartsModel Face
        {
            get { return face; }
        }

        /// <summary>
        /// 各モデルの設定が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        private void OnOneParameterChanged(Object sender)
        {
            if ((sender == head) || (sender == eye) 
                || (sender == hair) || (sender == body)
                || (sender == accessory1) || (sender == accessory2)
                || (sender == accessory3)
                || (sender == headAccessory1) || (sender == headAccessory2))
            {
                PartsType type = (PartsType)(Enum.Parse(typeof(PartsType),
                    ((CharaChipPartsModel)(sender)).ParameterName));
                OnCharaChipParamChanged?.Invoke(this, new PartsChangeEventArgs(type));
            }
            else if (sender == face)
            {
                OnFaceParamChanged?.Invoke(this, new EventArgs());
            }
        }


    }
}
