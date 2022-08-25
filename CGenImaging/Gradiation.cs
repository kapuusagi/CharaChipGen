using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// 単一方向のグラディエーションを表すクラス。
    /// </summary>
    public class Gradiation : IEnumerable<GradiationEntry>
    {
        // エントリ
        private List<GradiationEntry> entries = new List<GradiationEntry>();

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public Gradiation()
        {
        }

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="entries">グラディエーションを校正する色情報</param>
        public Gradiation(GradiationEntry[] entries)
        {
            foreach (var entry in entries)
            {
                entry.PositionChanged += OnEntryPositionChanged;
                entry.ColorChanged += OnEntryColorChanged;
                this.entries.Add(entry);
            }
            SortEntries();
        }


        /// <summary>
        /// グラディエーションが変更された
        /// </summary>
        public event EventHandler GradiationChanged;

        /// <summary>
        /// グラディエーションが変更されたときに通知する。
        /// </summary>
        private void NotifyGradiationChanged()
            => GradiationChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// エントリをソートする。
        /// </summary>
        private void SortEntries()
        {
            entries.Sort((lhs, rhs) =>
            {
                float diff = lhs.Position - rhs.Position;
                if (diff > 0.0f)
                {
                    return 1; // 左辺は右辺より大
                }
                else if (diff < 0.0f)
                {
                    return -1; // 左辺は右辺より小
                }
                else
                {
                    return 0;
                }
            });
            NotifyGradiationChanged();
        }

        /// <summary>
        /// エントリを追加する。
        /// </summary>
        /// <param name="entry">エントリ</param>
        public void Add(GradiationEntry entry)
        {
            entry.PositionChanged += OnEntryPositionChanged;
            entry.ColorChanged += OnEntryColorChanged;
            entries.Add(entry);
            SortEntries();
        }

        /// <summary>
        /// エントリの位置が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnEntryPositionChanged(object sender, EventArgs e)
        {
            SortEntries();
        }

        /// <summary>
        /// エントリの色が変更されたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnEntryColorChanged(object sender, EventArgs e)
        {
            NotifyGradiationChanged();
        }

        /// <summary>
        /// indexで指定される番号のエントリを削除する。
        /// </summary>
        /// <param name="index">インデックス</param>
        public void RemoveAt(int index)
        {
            var entry = Get(index);
            if (entry != null)
            {
                entries.RemoveAt(index);
                entry.PositionChanged -= OnEntryPositionChanged;
            }
        }

        /// <summary>
        /// 要素の位置を得る。
        /// </summary>
        /// <param name="entry">要素</param>
        /// <returns>位置</returns>
        public int IndexOf(GradiationEntry entry)
            => entries.IndexOf(entry);

        /// <summary>
        /// beginIndex以降の要素の位置を得る。
        /// </summary>
        /// <param name="entry">エントリ</param>
        /// <param name="beginIndex">開始インデックス</param>
        /// <returns></returns>
        public int IndexOf(GradiationEntry entry, int beginIndex)
            => entries.IndexOf(entry, beginIndex);

        /// <summary>
        /// エントリの数
        /// </summary>
        public int Count { get => entries.Count; }

        /// <summary>
        /// 要素にアクセスする
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns></returns>
        public GradiationEntry this[int index] {
            get => Get(index);
            set {
                if (entries[index] != value)
                {
                    if (value != null)
                    {
                        entries[index] = value;
                    }
                    else
                    {
                        RemoveAt(index);
                    }
                }
            }
        }

        /// <summary>
        /// indexの位置にあるエントリを得る。
        /// </summary>
        /// <param name="index">インデックス番号</param>
        /// <returns>エントリ。indexが範囲外の場合にはnull</returns>
        public GradiationEntry Get(int index)
        {
            if ((index >= 0) && (index < entries.Count))
            {
                return entries[index];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// position を超えない位置にある、最もpositionに近いエントリを返す。
        /// </summary>
        /// <param name="position">位置</param>
        /// <returns>エントリ。positionを超えないエントリがない婆いにはnull</returns>
        public GradiationEntry GetLeftEntry(float position)
        {
            GradiationEntry leftEntry = null;

            // position を超えない位置にある、最もpositionに近いエントリを返す。
            foreach (var entry in entries)
            {
                if (entry.Position <= position)
                {
                    leftEntry = entry;
                }
                else
                {
                    break;
                }
            }
            return leftEntry;
        }
        /// <summary>
        /// Position 以上の位置にある、最も position に近いエントリを返す。
        /// </summary>
        /// <param name="position">位置</param>
        /// <returns>エントリ。position以上の位置にあるエントリが無い場合にはnull</returns>
        public GradiationEntry GetRightEntry(float position)
        {
            // Position 以上の位置にある、最も position に近いエントリを返す。
            foreach (var entry in entries)
            {
                if (entry.Position >= position)
                {
                    return entry;
                }
            }

            return null;
        }

        /// <summary>
        /// 位置に対応する色を得る。
        /// </summary>
        /// <param name="position">位置(0.0-1.0)</param>
        /// <returns>色。positionが範囲外の場合には透過色が返る</returns>
        public Color GetColor(float position)
        {
            if ((position >= 0.0f) && (position <= 1.0f))
            {
                var left = GetLeftEntry(position);
                var right = GetRightEntry(position);
                return GetColor(left, right, position);


            }
            else
            {
                return Color.Transparent;
            }
        }

        /// <summary>
        /// 要素にアクセスする列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// 要素にアクセスする列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<GradiationEntry> GetEnumerator()
            => entries.GetEnumerator();

        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var entry in entries)
            {
                sb.Append('[').Append(entry.Position).Append(' ').Append(entry.Color).Append(']');
            }

            return sb.ToString();
        }

        /// <summary>
        /// left, rightで指定される範囲内にある、positionに相当する色を得る。
        /// </summary>
        /// <param name="left">position以下の位置にある、positionに最も近い色</param>
        /// <param name="right">position以上の位置にある、positionに最も近い色</param>
        /// <param name="position">位置</param>
        /// <returns>対応する色</returns>
        public static Color GetColor(GradiationEntry left, GradiationEntry right, float position)
        {
            if ((left != null) && (right != null)
                && (position >= left.Position)
                && (position <= right.Position))
            {
                if (left.Color.Equals(right.Color))
                {
                    return left.Color;
                }
                float leftRate;
                float rightRate;
                var range = right.Position - left.Position;
                if (range > 0.0f)
                {
                    rightRate = (position - left.Position) / range;
                    leftRate = 1.0f - rightRate;
                }
                else
                {
                    rightRate = 0.5f;
                    leftRate = 0.5f;
                }
                // 位置に対する割合を返す。
                float r = left.Color.R * leftRate + right.Color.R * rightRate + 0.5f;
                float g = left.Color.G * leftRate + right.Color.G * rightRate + 0.5f;
                float b = left.Color.B * leftRate + right.Color.B * rightRate + 0.5f;
                float a = left.Color.A * leftRate + right.Color.A * rightRate + 0.5f;

                return Color.FromArgb(
                    ColorUtility.Clamp((int)(a), 0, 255),
                    ColorUtility.Clamp((int)(r), 0, 255),
                    ColorUtility.Clamp((int)(g), 0, 255),
                    ColorUtility.Clamp((int)(b), 0, 255));
            }
            else if ((left != null) && (position >= left.Position))
            {
                return left.Color;
            }
            else if ((right != null) && (position <= right.Position))
            {
                return right.Color;
            }    
            else
            {
                // 左側、右側の色なし。（つまりグラディエーション上のエントリデータなし)
                return Color.Transparent;
            }
        }
    }
}
