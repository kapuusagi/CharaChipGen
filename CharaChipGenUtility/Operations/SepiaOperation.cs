using CGenImaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// セピア調への変更
    /// </summary>
    public class SepiaOperation : ImageOperationBase
    {
        private ImageOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public SepiaOperation()
        {
            setting = new ImageOperationSetting();
        }

        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る。</returns>
        public override ImageBuffer Process(ImageBuffer buffer)
        {
            return ImageProcessor.ProcessSepiaColorFilter(buffer);
        }

        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string Name { get => "SepiaColor"; }

        /// <summary>
        /// 操作の説明
        /// </summary>
        public override string Description { get => "セピア調に変換する。"; }


        /// <summary>
        /// 設定を得る。
        /// </summary>
        public override IOperationSetting Setting {
            get { return setting; }
        }

        /// <summary>
        /// 出力ディレクトリを得る。
        /// </summary>
        /// <returns>出力ディレクトリ</returns>
        protected override string GetOutputDirectory()
        {
            return setting.OutputDirectory;
        }
    }
}
