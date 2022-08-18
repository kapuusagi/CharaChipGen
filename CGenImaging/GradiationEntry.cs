using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// グラディエーションデータを表すクラス。
    /// </summary>
    public class GradiationEntry
    {
        // 位置
        private float position;
        // 色
        private Color color;


        /// <summary>
        /// グラディエーションカラー
        /// </summary>
        /// <param name="position">位置</param>
        /// <param name="c">カラー</param>
        public GradiationEntry(float position, Color c)
        {
            this.position = position;
            this.color = c;
        }

        /// <summary>
        /// 位置が変更された
        /// </summary>
        public event EventHandler PositionChanged;

        /// <summary>
        /// 位置の変更を通知する。
        /// </summary>
        private void NotifyPositionChanged()
            => PositionChanged?.Invoke(this, EventArgs.Empty);
        /// <summary>
        /// 色が変更された
        /// </summary>
        public event EventHandler ColorChanged;
        /// <summary>
        /// カラーが変更されたことを通知する。
        /// </summary>
        private void NotifyColorChanged()
            => ColorChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// 位置
        /// </summary>
        public float Position { 
            get => position;
            set {
                if (position != value)
                {
                    position = value;
                    NotifyPositionChanged();
                }
            }
        }
        /// <summary>
        /// カラー
        /// </summary>
        public Color Color { 
            get => color;
            set {
                if (color != value)
                {
                    color = value;
                    NotifyColorChanged();
                }
            }
        }

        /// <summary>
        /// objと一致しているかどうかを判定する。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>一致している場合にtrue, それ以外はfalse.</returns>
        public override bool Equals(object obj)
        {
            return (obj is GradiationEntry entry)
                && (Position == entry.Position)
                && (EqualityComparer<Color>.Default.Equals(Color, entry.Color));
        }

        /// <summary>
        /// このオブジェクトのハッシュ値を得る。
        /// </summary>
        /// <returns>ハッシュ値</returns>
        public override int GetHashCode()
        {
            int hashCode = -866678350;
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return $"{Position}:({color.A},{color.R},{color.G},{color.B})";
        }


        /// <summary>
        /// 一致判定
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>一致している場合にtrue, それ以外はfalse.</returns>
        public static bool operator ==(GradiationEntry lhs, GradiationEntry rhs)
            => lhs?.Equals(rhs) // rhsが非nullならEquals()を返す。
            ?? rhs?.Equals(lhs) // lhsが非nullならEquals()を返す。
            ?? true; // lhs, rhs共にnull
        /// <summary>
        /// 不一致判定
        /// </summary>
        /// <param name="lhs">左辺</param>
        /// <param name="rhs">右辺</param>
        /// <returns>不一致の場合にtrue, それ以外はfalse</returns>
        public static bool operator !=(GradiationEntry lhs, GradiationEntry rhs)
            => !(lhs == rhs);

    }
}
