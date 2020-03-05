using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 画像処理を表すインタフェース
    /// </summary>
    public interface IImageOperation
    {
        /// <summary>
        /// このオペレーションの名前
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 画像に処理する
        /// </summary>
        /// <param name="src">画像データ</param>
        /// <returns>処理した画像</returns>
        ImageBuffer Process(ImageBuffer src);
    }
}
