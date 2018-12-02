using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharaChipGen.Model
{
    /// <summary>
    /// 1名のキャラクタチップを生成するための設定モデル
    /// </summary>
    public class CharaChipDataModel
    {
        public const string ParamNameHead = "Head";
        public const string ParamNameEye = "Eye";
        public const string ParamNameFrontHair = "FrontHair";
        public const string ParamNameHair = "Hair";
        public const string ParamNameBody = "Body";
        public const string ParamNameCostume = "Costume";
        public const string ParamNameAccessory1 = "Accessory1";
        public const string ParamNameAccessory2 = "Accessory2";
        public const string ParamNameAccessory3 = "Accessory3";
        public const string ParamNameHeadAccessory1 = "HeadAccessory1";
        public const string ParamNameHeadAccessory2 = "HeadAccessory2";
        public const string ParamNameFace = "Face";

        public delegate void ParamChangeHandler(Object sender, string name);
        public event ParamChangeHandler OnCharaChipParamChanged;
        public event ParamChangeHandler OnFaceParamChanged;

        private CharaChipParameterModel head;
        private CharaChipParameterModel eye;
        private CharaChipParameterModel frontHair;
        private CharaChipParameterModel hair;
        private CharaChipParameterModel costume;
        private CharaChipParameterModel body;
        private CharaChipParameterModel accessory1;
        private CharaChipParameterModel accessory2;
        private CharaChipParameterModel accessory3;
        private CharaChipParameterModel headAccessory1;
        private CharaChipParameterModel headAccessory2;
        private CharaChipParameterModel face;

        public CharaChipDataModel()
        {
            head = new CharaChipParameterModel(ParamNameHead);
            eye = new CharaChipParameterModel(ParamNameEye);
            frontHair = new CharaChipParameterModel(ParamNameFrontHair);
            hair = new CharaChipParameterModel(ParamNameHair);
            costume = new CharaChipParameterModel(ParamNameCostume);
            body = new CharaChipParameterModel(ParamNameBody);
            accessory1 = new CharaChipParameterModel(ParamNameAccessory1);
            accessory2 = new CharaChipParameterModel(ParamNameAccessory2);
            accessory3 = new CharaChipParameterModel(ParamNameAccessory3);
            headAccessory1 = new CharaChipParameterModel(ParamNameHeadAccessory1);
            headAccessory2 = new CharaChipParameterModel(ParamNameHeadAccessory2);
            face = new CharaChipParameterModel(ParamNameFace);

            CharaChipParameterModel.ValueChangeHandler handler
                = new CharaChipParameterModel.ValueChangeHandler((Object sender) =>
                {
                    OnOneParameterChanged(sender);
                });
            head.ValueChanged += handler;
            eye.ValueChanged += handler;
            frontHair.ValueChanged += handler;
            hair.ValueChanged += handler;
            costume.ValueChanged += handler;
            body.ValueChanged += handler;
            accessory1.ValueChanged += handler;
            accessory2.ValueChanged += handler;
            accessory3.ValueChanged += handler;
            headAccessory1.ValueChanged += handler;
            headAccessory2.ValueChanged += handler;

            face.ValueChanged += handler;
        }

        /// <summary>
        /// modelで指定されたモデルに設定値をコピーする。
        /// </summary>
        /// <param name="model">モデル</param>
        public void CopyTo(CharaChipDataModel model)
        {
            head.CopyTo(model.head);
            eye.CopyTo(model.eye);
            frontHair.CopyTo(model.frontHair);
            hair.CopyTo(model.hair);
            costume.CopyTo(model.costume);
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
            frontHair.Reset();
            hair.Reset();
            body.Reset();
            costume.Reset();
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
        public CharaChipParameterModel Head
        {
            get { return this.head; }
        }
        /// <summary>
        /// 目の設定
        /// </summary>
        public CharaChipParameterModel Eye
        {
            get { return this.eye; }
        }
        /// <summary>
        /// 前髪の設定
        /// </summary>
        public CharaChipParameterModel FrontHairStyle
        {
            get { return frontHair; }
        }

        /// <summary>
        /// 髪型の設定
        /// </summary>
        public CharaChipParameterModel Hair
        {
            get { return hair; }
        }

        /// <summary>
        /// 衣装
        /// </summary>
        public CharaChipParameterModel Costume
        {
            get { return costume; }
        }

        /// <summary>
        /// 体の設定
        /// </summary>
        public CharaChipParameterModel Body
        {
            get { return body; }
        }
        /// <summary>
        /// アクセサリ1の設定
        /// </summary>
        public CharaChipParameterModel Accessory1
        {
            get { return accessory1; }
        }
        /// <summary>
        /// アクセサリ2の設定
        /// </summary>
        public CharaChipParameterModel Accessory2
        {
            get { return accessory2; }
        }
        /// <summary>
        /// アクセサリ3の設定
        /// </summary>
        public CharaChipParameterModel Accessory3
        {
            get { return accessory3; }
        }

        /// <summary>
        /// ヘッドアクセサリ1の設定
        /// </summary>
        public CharaChipParameterModel HeadAccessory1
        {
            get { return headAccessory1; }
        }
        /// <summary>
        /// ヘッドアクセサリ2の設定
        /// </summary>
        public CharaChipParameterModel HeadAccessory2
        {
            get { return headAccessory2; }
        }
        /// <summary>
        /// 顔の設定
        /// </summary>
        public CharaChipParameterModel Face
        {
            get { return face; }
        }

        /// <summary>
        /// 各モデルの設定が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender"></param>
        private void OnOneParameterChanged(Object sender)
        {
            if ((sender == head) || (sender == eye) || (sender == frontHair)
                || (sender == hair) || (sender == body)
                || (sender == costume)
                || (sender == accessory1) || (sender == accessory2)
                || (sender == accessory3)
                || (sender == headAccessory1) || (sender == headAccessory2))
            {
                OnCharaChipParamChanged?.Invoke(this, ((CharaChipParameterModel)(sender)).ParameterName);
            }
            else if (sender == face)
            {
                OnFaceParamChanged?.Invoke(this,   face.ParameterName);
            }
        }


    }
}
