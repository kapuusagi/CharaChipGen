using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CharaChipGen.Model
{
    /// <summary>
    ///  1つのキャラクタチップの1つの
    ///  要素の生成パラメータを表すモデル
    /// </summary>
    public class CharaChipPartsModel : INotifyPropertyChanged
    {
        private string parameterName; // パラメータ名
        private string materialName; // 選択されているマテリアル名
        private int offset; // オフセット
        private int hue; // 色相調整価
        private int saturation; //  彩度調整値
        private int value; // 輝度調整価
        private int opacity; // 不透明度（高いほど不透明） = アルファチャンネル


        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public CharaChipPartsModel() : this("")
        {
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="paramName">パラメータ名</param>
        public CharaChipPartsModel(string paramName)
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
        /// プロパティが変更された場合。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたことを通知する。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void NotifyPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// パラメータを指定されたモデルにコピーする
        /// </summary>
        /// <param name="param">パラメータ</param>
        public void CopyTo(CharaChipPartsModel param)
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

            param.MaterialName = MaterialName;
            param.Offset = Offset;
            param.Hue = Hue;
            param.Saturation = Saturation;
            param.Value = Value;
            param.Opacity = Opacity;
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
            MaterialName = "";
            Offset = 0;
            Hue = 0;
            Saturation = 0;
            Value = 0;
            Opacity = 100;
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
                NotifyPropertyChange(nameof(MaterialName));
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
                NotifyPropertyChange(nameof(Offset));
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
                NotifyPropertyChange(nameof(Hue));
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
                NotifyPropertyChange(nameof(Saturation));
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
                NotifyPropertyChange(nameof(Value));
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
                NotifyPropertyChange(nameof(Opacity));
            }
        }
    }
}
