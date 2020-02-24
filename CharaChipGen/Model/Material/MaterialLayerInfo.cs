using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharaChipGen.Model.Layer;

namespace CharaChipGen.Model.Material
{
    /// <summary>
    /// 素材のレイヤー情報を表すモデル
    /// </summary>
    public class MaterialLayerInfo
    {
        private LayerType? attributeType;
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="name">レイヤー名</param>
        public MaterialLayerInfo(string name)
        {
            Name = name;
            attributeType = null;
        }

        public string Name { get; private set; }

        /// <summary>
        /// レイヤーファイル名
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 描画対象レイヤー
        /// </summary>
        public LayerType LayerType { get; set; }

        /// <summary>
        /// 適用する属性
        /// </summary>
        public LayerType AttributeType {
            get => attributeType ?? LayerType;
            set => attributeType = value;
        }

        /// <summary>
        /// このレイヤーデータが有効データを持つかどうか。
        /// </summary>
        public bool IsValid() {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Path);
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Layer.").Append(Name).Append(' ');
            sb.Append(LayerType).Append(' ');
            sb.Append('(').Append(AttributeType).Append(") ");
            sb.Append(Path);

            return sb.ToString();
        }
    }
}
