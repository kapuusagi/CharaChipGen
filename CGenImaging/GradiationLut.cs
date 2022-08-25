using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CGenImaging
{
    /// <summary>
    /// グラディエーションを処理するためのLUT
    /// </summary>
    public class GradiationLut : IEnumerable<Color>, ILut
    {
        /// <summary>
        /// グラディエーションからLUTを作製する。
        /// LUTの解像度は256になる。
        /// </summary>
        /// <param name="gradiation">グラディエーション</param>
        /// <returns>LUT</returns>
        public static GradiationLut CreateFrom(Gradiation gradiation)
            => CreateFrom(gradiation, byte.MaxValue + 1);

        /// <summary>
        /// グラディエーションからLUTを作製する。
        /// </summary>
        /// <param name="gradiation">グラディエーション</param>
        /// <param name="resolution">LUTの解像度</param>
        /// <returns>LUT</returns>
        public static GradiationLut CreateFrom(Gradiation gradiation, int resolution)
        {
            return new GradiationLut(gradiation, resolution);
        }


        // 色
        private Color[] colors;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="gradiation">グラディエーション</param>
        /// <param name="resolution">解像度</param>
        private GradiationLut(Gradiation gradiation, int resolution)
        {
            GenerateLut(gradiation, resolution);
        }

        /// <summary>
        /// 解像度を変更してLUTを生成する。
        /// </summary>
        /// <param name="gradiation">グラディエーション</param>
        /// <param name="resolution">解像度</param>
        public void GenerateLut(Gradiation gradiation, int resolution)
        {
            if (resolution <= 0)
            {
                throw new ArgumentException($"Invalid resolution. [{resolution}]");
            }
            colors = new Color[resolution];
            GenerateLut(gradiation);
        }

        /// <summary>
        /// LUTを生成する。
        /// </summary>
        /// <param name="gradiation">グラディエーション</param>
        public void GenerateLut(Gradiation gradiation)
        {
            GradiationEntry left = null;
            GradiationEntry right = null;

            int index = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                float position = (float)(i) / (float)(colors.Length - 1);

                bool isRightNull = right == null;
                bool isRightOver = (right != null) && (position > right.Position);

                if ((right == null) // 右側がnull？
                    || ((right != null) && (position > right.Position))) // 右側が右側の位置にいない？
                {
                    // 次のエントリを探す。
                    left = right;
                    right = null;
                    while (index < gradiation.Count)
                    {
                        right = gradiation.Get(index);
                        index++;
                        if ((right != null) && (right.Position >= position)) {
                            // right 確定
                            break;
                        }
                    }
                }

                colors[i] = Gradiation.GetColor(left, right, position);
            }
        }

        /// <summary>
        /// indexに対応する色を得る。
        /// </summary>
        /// <param name="index">インデックス(0≦index＜Resolution-1)</param>
        /// <returns>色</returns>
        public Color this[int index] {
            get => Get(index);
        }


        /// <summary>
        /// indexに対応する色を得る。
        /// </summary>
        /// <param name="index">インデックス(0≦index＜Resolution-1)</param>
        /// <returns>色</returns>
        public Color Get(int index)
        {
            return colors[index];
        }

        /// <summary>
        /// LUTの解像度を得る。
        /// </summary>
        public int Resolution {
            get => colors.Length;
        }

        /// <summary>
        /// 要素にアクセスするための列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// 要素にアクセスするための列挙子を得る。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<Color> GetEnumerator()
        {
            foreach (var color in colors)
            {
                yield return color;
            }
        }
            
    }
}
