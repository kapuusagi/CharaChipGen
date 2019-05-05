using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharaChipGen.Model
{
    /// <summary>
    ///  1つのキャラクタチップの1つの
    ///  要素の生成パラメータを表すモデル
    /// </summary>
    public class CharaChipParameterModel
    {
        private string parameterName; // パラメータ名
        private string materialName; // 選択されているマテリアル名
        private int offset; // オフセット
        private int hue; // 色相調整価
        private int saturation; //  彩度調整値
        private int value; // 輝度調整価
        private int opacity; // 不透明度（高いほど不透明） = アルファチャンネル

        public delegate void ValueChangeHandler(Object sender); // 設定価が変更されたときのハンドラ
        public event ValueChangeHandler ValueChanged; // 設定値が変更されたときのイベント

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="paramName">パラメータ名</param>
        public CharaChipParameterModel(string paramName)
        {
            this.parameterName = paramName;
            materialName = "";
            offset = 0;
            hue = 0;
            saturation = 0;
            value = 0;
            opacity = 100;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipParameterModel()
        {
            this.parameterName = "";
            materialName = "";
            offset = 0;
            hue = 0;
            saturation = 0;
            value = 0;
            opacity = 100;
        }

        /// <summary>
        /// パラメータを指定されたモデルにコピーする
        /// </summary>
        /// <param name="param">パラメータ</param>
        public void CopyTo(CharaChipParameterModel param)
        {
            if ((param.materialName == materialName)
                && (param.offset == offset)
                && (param.hue == hue)
                && (param.saturation == saturation)
                && (param.value == value)
                && (param.opacity == opacity))
            {
                // 同じデータ
                return;
            }

            param.materialName = this.materialName;
            param.offset = this.offset;
            param.hue = this.hue;
            param.saturation = this.saturation;
            param.value = this.value;
            param.opacity = this.opacity;
            param.ValueChanged?.Invoke(param);
        }

        /// <summary>
        /// パラメータをリセットする
        /// </summary>
        public void Reset()
        {
            if ((this.materialName == "")
                && (this.offset == 0)
                && (hue == 0)
                && (saturation == 0)
                && (value == 0)
                && (opacity == 100))
            {
                return;
            }
            this.materialName = "";
            this.offset = 0;
            this.hue = 0;
            this.saturation = 0;
            this.value = 0;
            this.opacity = 100;
            ValueChanged?.Invoke(this);
        }

        /// <summary>
        /// このパラメータの名前
        /// </summary>
        public string ParameterName {
            get { return parameterName; }
        }

        /// <summary>
        /// 選択されている素材名
        /// パスではないので注意。
        /// 未選択時には空文字列が返る。
        /// </summary>
        public string MaterialName {
            get { return materialName; }
            set {
                if (materialName == value)
                {
                    return; // 同値なので設定変更不要。
                }
                materialName = value;
                ValueChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// 素材のオフセット。
        /// 上方向が正数。下方向は負数。
        /// </summary>
        public int Offset {
            get { return offset; }
            set {
                if (offset == value)
                {
                    return; // 同値なので設定変更不要。
                }
                offset = value;
                ValueChanged?.Invoke(this);
            }
        }


        /// <summary>
        /// 色相調整値(-180 - 0)
        /// </summary>
        public int Hue {
            get { return hue; }
            set {
                if (hue == value)
                {
                    return; // 同値なので設定変更不要。
                }
                hue = value;
                ValueChanged?.Invoke(this); // これは if (ValueChanged != null) ValueChanged(this)と同値。
            }
        }

        /// <summary>
        /// 彩度の調整値
        /// </summary>
        public int Saturation {
            get { return saturation; }
            set {
                if (saturation == value)
                {
                    return; // 同値なので設定変更不要。
                }
                saturation = value;
                ValueChanged?.Invoke(this);
            }
        }
        /// <summary>
        /// 輝度の調整値
        /// </summary>
        public int Value {
            get { return value; }
            set {
                if (this.value == value)
                {
                    return;
                }
                this.value = value;
                ValueChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// 不透明度
        /// </summary>
        public int Opacity {
            get { return opacity; }
            set {
                if (this.opacity == value)
                {
                    return;
                }
                this.opacity = value;
                ValueChanged?.Invoke(this);
            }
        }
    }
}
