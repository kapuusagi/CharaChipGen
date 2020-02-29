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
        // パラメータ名
        private string materialName;
        // オフセットX
        private int offsetX;
        // オフセットY
        private int offsetY;
        // 色相調整値
        private int hue;
        //  彩度調整値
        private int saturation;
        // 輝度調整値
        private int value;
        // 不透明度（高いほど不透明） = アルファチャンネル
        private int opacity; 

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="partsType">パーツ種類</param>
        public CharaChipPartsModel(PartsType partsType)
        {
            PartsType = partsType;
            materialName = "";
            offsetX = 0;
            offsetY = 0;
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
            if ((param.materialName.Equals(materialName))
                && (param.offsetX == offsetX)
                && (param.offsetY == offsetY)
                && (param.hue == hue)
                && (param.saturation == saturation)
                && (param.value == value)
                && (param.opacity == opacity))
            {
                // 同じデータ
                return;
            }

            param.MaterialName = MaterialName;
            param.OffsetX = OffsetX;
            param.OffsetY = OffsetY;
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
                && (this.offsetX == 0)
                && (this.offsetY == 0)
                && (hue == 0)
                && (saturation == 0)
                && (value == 0)
                && (opacity == 100))
            {
                return;
            }
            MaterialName = "";
            OffsetX = 0;
            OffsetY = 0;
            Hue = 0;
            Saturation = 0;
            Value = 0;
            Opacity = 100;
        }

        /// <summary>
        /// この部品の名前
        /// </summary>
        public PartsType PartsType {
            get; private set;
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
        /// 素材のオフセット
        /// 左方向が正数、右方向は負数
        /// </summary>
        public int OffsetX {
            get { return offsetX; }
            set {
                if (offsetX == value)
                {
                    return;
                }
                offsetX = value;
                NotifyPropertyChange(nameof(OffsetX));
            }
        }

        /// <summary>
        /// 素材のオフセット。
        /// 上方向が正数。下方向は負数。
        /// </summary>
        public int OffsetY {
            get { return offsetY; }
            set {
                if (offsetY == value)
                {
                    return; // 同値なので設定変更不要。
                }
                offsetY = value;
                NotifyPropertyChange(nameof(OffsetY));
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
