using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGenImaging
{
    /// <summary>
    /// RGBからYPbPrへ変換するマトリクス係数
    /// </summary>
    /// <remarks>
    /// <para>うんちく</para>
    /// <para>YPbPrはデジタル表現。アナログ信号はYCbCrになる。逆かも。</para>
    /// <para>注意点</para>
    /// <para>白レベル、黒レベルの処理は加味されず、あくまで(0.0-1.0)に対するマトリクス係数である。</para>
    /// </remarks>
    public struct MatrixRGBtoYPbPr
    {
        /// <summary>
        /// BT709の変換係数
        /// </summary>
        public static readonly MatrixRGBtoYPbPr BT709
            = new MatrixRGBtoYPbPr(new float[3, 3] {
                { 0.2126f,    0.7152f,  0.0722f },
                { -0.1146f,   -0.3854f, 0.5000f },
                { 0.5000f,    -0.4542f, -0.0458f }
        });

        private float[,] coefficients;

        /// <summary>
        /// 指定されたマトリクス係数で新しいインスタンスを構築する。
        /// <para>マトリクス係数の割り当て</para>
        /// </summary>
        /// <param name="matrix">マトリクス係数</param>
        public MatrixRGBtoYPbPr(float[,] matrix)
        {
            if ((matrix.GetLength(0) < 3) || (matrix.GetLength(1) < 3))
            {
                throw new ArgumentException($"Matrix dimension not supported. [{matrix.GetLength(0)},{matrix.GetLength(1)}]");
            }

            coefficients = new float[3, 3]
            {
                {  matrix[0, 0], matrix[0, 1], matrix[0, 2] },
                {  matrix[1, 0], matrix[1, 1], matrix[1, 2] },
                {  matrix[2, 0], matrix[2, 1], matrix[2, 2] }
            };

        }
        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        /// <param name="r2y">Yを計算する際のRの係数</param>
        /// <param name="g2y">Yを計算する際のGの係数</param>
        /// <param name="b2y">Yを計算する際のBの係数</param>
        /// <param name="r2pb">Pbを計算する際のRの係数</param>
        /// <param name="g2pb">Pbを計算する際のGの係数</param>
        /// <param name="b2pb">Pbを計算する際のBの係数</param>
        /// <param name="r2pr">Prを計算する際のRの係数</param>
        /// <param name="g2pr">Prを計算する際のRの係数</param>
        /// <param name="b2pr">Prを計算する際のRの係数</param>
        public MatrixRGBtoYPbPr(
            float r2y, float g2y, float b2y,
            float r2pb, float g2pb, float b2pb,
            float r2pr, float g2pr, float b2pr) 
        {
            coefficients = new float[3, 3] {
                { r2y, g2y, b2y },
                {r2pb, g2pb, b2pb },
                {r2pr, g2pr, b2pr } 
            };
        }

        /// <summary>
        /// マトリクス係数にアクセスする。
        /// </summary>
        /// <param name="y">行</param>
        /// <param name="x">列</param>
        /// <returns></returns>
        public float this[int y, int x] {
            get => coefficients[y, x];
        }

        /// <summary>
        /// Yを計算する際のRの係数
        /// </summary>
        public float R2Y { get => coefficients[0, 0]; }
        /// <summary>
        /// Yを計算する際のGの係数
        /// </summary>
        public float G2Y { get => coefficients[0, 1]; }
        /// <summary>
        /// Yを計算する際のBの係数
        /// </summary>
        public float B2Y { get => coefficients[0, 2]; }
        /// <summary>
        /// PBを計算する際のRの係数
        /// </summary>
        public float R2PB { get => coefficients[1, 0]; }
        /// <summary>
        /// PBを計算する際のGの係数
        /// </summary>
        public float G2PB { get => coefficients[1, 1]; }
        /// <summary>
        /// PBを計算する際のBの係数
        /// </summary>
        public float B2PB { get => coefficients[1, 2]; }
        /// <summary>
        /// PRを計算する際のRの係数
        /// </summary>
        public float R2PR { get => coefficients[2, 0]; }
        /// <summary>
        /// PRを計算する際のGの係数
        /// </summary>
        public float G2PR { get => coefficients[2, 1]; }
        /// <summary>
        /// PRを計算する際のBの係数
        /// </summary>
        public float B2PR { get => coefficients[2, 2]; }

        /// <summary>
        /// このオブジェクトがobjと等しいかどうかを判定する。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>等しい場合にはtrue, それ以外はfalse.</returns>
        public override bool Equals(object obj)
        {
            return obj is MatrixRGBtoYPbPr pr &&
                   EqualityComparer<float[,]>.Default.Equals(coefficients, pr.coefficients);
        }

        /// <summary>
        /// このオブジェクトのハッシュ値を得る。
        /// </summary>
        /// <returns>ハッシュ値</returns>
        public override int GetHashCode()
        {
            return 1112971371 + EqualityComparer<float[,]>.Default.GetHashCode(coefficients);
        }



        /// <summary>
        /// このオブジェクトの文字列表現を得る。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('{');
            for (int y = 0; y < 3; y++)
            {
                sb.Append(" { ");
                for (int x = 0; x < 3; x++)
                {
                    sb.Append(coefficients[y, x].ToString("0.0000")).Append(',');
                    if ((x + 1) < 3)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append('}');
                if ((y + 1) < 3)
                {
                    sb.Append(", ");
                }
            }
            sb.Append('}');
            return sb.ToString();
        }
    }
}
