using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    /// 色変更設定（H,S,V,不透明度変更）
    /// </summary>
    public class ColorSetting : INotifyPropertyChanged
    {
        // 色相調整値
        private int hue;
        //  彩度調整値
        private int saturation;
        // 輝度調整値
        private int value;
        // 不透明度（高いほど不透明） = アルファチャンネル
        private int opacity;

        /// <summary>
        /// 色設定を構築する。
        /// </summary>
        public ColorSetting()
        {
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
        /// <param name="setting">パラメータ</param>
        public void CopyTo(ColorSetting setting)
        {
            if ((setting.hue == hue)
                && (setting.saturation == saturation)
                && (setting.value == value)
                && (setting.opacity == opacity))
            {
                // 同じデータ
                return;
            }

            setting.Hue = Hue;
            setting.Saturation = Saturation;
            setting.Value = Value;
            setting.Opacity = Opacity;
        }

        /// <summary>
        /// パラメータをリセットする
        /// </summary>
        public void Reset()
        {
            if ((hue == 0)
                && (saturation == 0)
                && (value == 0)
                && (opacity == 100))
            {
                return;
            }
            Hue = 0;
            Saturation = 0;
            Value = 0;
            Opacity = 100;
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

        /// <summary>
        /// settingで指定されるオブジェクトと一致しているかどうかを判定して返す。
        /// </summary>
        /// <param name="setting">設定</param>
        /// <returns>一致している場合にはtrue, それ以外はfalse</returns>
        public bool Equals(ColorSetting setting)
        {
            return (hue == setting.hue)
                && (saturation == setting.saturation)
                && (value == setting.value)
                && (opacity == setting.opacity);
        }

        /// <summary>
        /// objで指定されるオブジェクトと一致しているかどうかを判定して返す。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>一致している場合にはtrue, それ以外はfalse</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorSetting setting)
            {
                return Equals(setting);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// このオブジェクトのハッシュ値を得る。
        /// </summary>
        /// <returns>ハッシュ値</returns>
        public override int GetHashCode()
        {
            int hashCode = -1524062934;
            hashCode = hashCode * -1521134295 + hue.GetHashCode();
            hashCode = hashCode * -1521134295 + saturation.GetHashCode();
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            hashCode = hashCode * -1521134295 + opacity.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        public override string ToString()
        {
            return $"{hue},{saturation},{value},{opacity}";
        }

        /// <summary>
        /// textをパースしてColorSettingオブジェクトを構築する。
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <returns>ColorSettingオブジェクト。パース失敗時は例外</returns>
        public static ColorSetting Parse(string text)
        {
            if (TryParse(text, out ColorSetting setting))
            {
                return setting;
            }
            else
            {
                throw new ArgumentException("ColorSetting.Parse failure. : " + text);
            }
        }

        /// <summary>
        /// textをパースしてColorSettingオブジェクトを構築する。
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="setting">ColorSettingオブジェクト。パース失敗時はnull</param>
        /// <returns>パース成功時はtrue、それ以外はfalse</returns>
        public static bool TryParse(string text,  out ColorSetting setting)
        {
            string[] tokens = text.Split(',');
            if ((tokens.Length == 4)
                && int.TryParse(tokens[0], out int h)
                && int.TryParse(tokens[1], out int s)
                && int.TryParse(tokens[2], out int v)
                && int.TryParse(tokens[3], out int o))
            {
                setting = new ColorSetting() { 
                    Hue = h, Saturation = s, Value = v, Opacity = o
                };
                return true;
            }
            else
            {
                setting = null;
                return false;
            }
        }
    }
}
