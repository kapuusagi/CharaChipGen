namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 処理を行うインタフェース。
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// このオペレーションの名前
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 処理設定
        /// </summary>
        IOperationSetting Setting { get; }

        /// <summary>
        /// 処理を行う。
        /// </summary>
        void Process(string[] fileNames);
    }
}
