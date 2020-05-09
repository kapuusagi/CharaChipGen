using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 空のオペレーション。
    /// </summary>
    public class EmptyOperation : ImageOperationBase
    {
        private ImageOperationSetting setting;

        /// <summary>
        /// 新しいインスタンスを作成する。
        /// </summary>
        public EmptyOperation()
        {
            setting = new ImageOperationSetting();
        }


        /// <summary>
        /// オペレーション名
        /// </summary>
        public override string Name { get => "Empty"; }

        /// <summary>
        /// 操作の説明
        /// </summary>
        public override string Description { get => "空のオペレーション。そのまま入力画像を出力に渡します。"; }

        /// <summary>
        /// このオペレーション設定を得る
        /// </summary>
        public override IOperationSetting Setting {
            get { return setting; }
        }

        /// <summary>
        /// 出力ディレクトリを得る。
        /// </summary>
        /// <returns></returns>
        protected override string GetOutputDirectory()
        {
            return setting.OutputDirectory;
        }


        /// <summary>
        /// 画像に処理を行う。
        /// </summary>
        /// <param name="buffer">画像バッファ</param>
        /// <returns>処理結果が返る</returns>
        public override ImageBuffer Process(ImageBuffer buffer)
        {
            return buffer;
        }


    }
}
