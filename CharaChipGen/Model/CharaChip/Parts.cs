using System.ComponentModel;

namespace CharaChipGen.Model.CharaChip
{
    /// <summary>
    ///  1キャラクタの1つの部品を表すモデル
    /// </summary>
    public class Parts : INotifyPropertyChanged
    {
        /// <summary>
        /// デフォルトの色パラメータ名
        /// </summary>
        public const string DefaultColorPropertyName = nameof(Color1);
        // パラメータ名
        private string materialName;
        // オフセットX
        private int offsetX;
        // オフセットY
        private int offsetY;
        // 色1
        private readonly ColorSetting color1;
        // 色2
        private readonly ColorSetting color2;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="partsType">パーツ種類</param>
        public Parts(PartsType partsType)
        {
            PartsType = partsType;
            materialName = "";
            offsetX = 0;
            offsetY = 0;
            color1 = new ColorSetting();
            color1.PropertyChanged += OnColor1PropertyChanged;
            color2 = new ColorSetting();
            color2.PropertyChanged += OnColor2PropertyChanged;
        }

        /// <summary>
        /// Color1プロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColor1PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChange(nameof(Color1));

        /// <summary>
        /// Color2プロパティが変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnColor2PropertyChanged(object sender, PropertyChangedEventArgs e)
            => NotifyPropertyChange(nameof(Color2));


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
        public void CopyTo(Parts param)
        {
            if ((param.materialName.Equals(materialName))
                && (param.offsetX == offsetX)
                && (param.offsetY == offsetY)
                && param.color1.Equals(color1)
                && param.color2.Equals(color2))
            {
                // 同じデータ
                return;
            }

            param.MaterialName = MaterialName;
            param.OffsetX = OffsetX;
            param.OffsetY = OffsetY;
            color1.CopyTo(param.Color1);
            color2.CopyTo(param.Color2);
        }

        /// <summary>
        /// パラメータをリセットする
        /// </summary>
        public void Reset()
        {
            MaterialName = "";
            OffsetX = 0;
            OffsetY = 0;
            Color1.Reset();
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
        /// 色設定1（メインカラー）
        /// </summary>
        public ColorSetting Color1 {
            get {
                return color1;
            }
            set {
                if (color1.Equals(value))
                {
                    return; // 同値なので設定変更不要。
                }
                value.CopyTo(color1); // 変更入ったパラメータはここでイベントが飛ぶ。
            }
        }

        /// <summary>
        /// 色設定2（サブカラー）
        /// </summary>
        public ColorSetting Color2 {
            get {
                return color2;
            }
            set {
                if (color2.Equals(value))
                {
                    return; //同値なので設定変更不要。
                }
                value.CopyTo(color2); // 変更入ったパラメータはここでイベントが飛ぶ。
            }
        }

        /// <summary>
        /// 色設定を得る。
        /// </summary>
        /// <param name="colorPropertyName">色プロパティ名</param>
        /// <returns>色設定</returns>
        public ColorSetting GetColorSetting(string colorPropertyName)
        {
            switch (colorPropertyName)
            {
                case nameof(Color1):
                    return Color1;
                case nameof(Color2):
                    return Color2;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 指定可能な色設定名を得る。
        /// </summary>
        /// <returns>色設定名配列</returns>
        public static string[] GetColorSettingNames()
        {
            return new string[]
            {
                nameof(Color1), nameof(Color2)
            };
        }
    }
}
