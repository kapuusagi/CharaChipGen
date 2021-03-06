﻿using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 単色化処理
    /// </summary>
    public class MonoColorOperation : ImageOperationBase
    {
        // 設定
        private MonoColorOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを構築する。
        /// </summary>
        public MonoColorOperation()
        {
            setting = new MonoColorOperationSetting();
        }

        /// <summary>
        /// 処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public override ImageBuffer Process(ImageBuffer buffer)
        {
            return ImageProcessor.ProcessMonoricColorFilter(buffer, setting.Color);
        }

        /// <summary>
        /// 名前を取得する。
        /// </summary>
        /// <returns>文字列</returns>
        public override string Name { get => "MonoricColor"; }

        /// <summary>
        /// 操作の説明
        /// </summary>
        public override string Description { get => "指定した色と同じ色相に変換して出力します。"; }


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
