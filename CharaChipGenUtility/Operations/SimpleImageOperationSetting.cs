using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility.Operations
{
    class SimpleImageOperationSetting : IOperationSetting
    {
        private ControlSelectDirectory controlSelectDirectory = null;
        private string outputDirectory = "";


        /// <summary>
        /// この設定を行うのに最適なUIを取得する。
        /// </summary>
        /// <returns>ユーザーインタフェース</returns>
        public Control GetControl()
        {
            if (controlSelectDirectory == null)
            {
                controlSelectDirectory = new ControlSelectDirectory();
                controlSelectDirectory.SelectName = "出力フォルダ";
                controlSelectDirectory.DirectoryChanged += (dir) => {  };
            }
            return controlSelectDirectory;
        }

        /// <summary>
        /// 出力ディレクトリ設定
        /// </summary>
        public string OutputDirectory {
            set {
                outputDirectory = value ?? "";
            }
            get {
                if (string.IsNullOrEmpty(outputDirectory))
                {
                    return System.IO.Directory.GetCurrentDirectory();
                }
                else
                {
                    return outputDirectory;
                }
            }
        }

        /// <summary>
        /// 保存した文字列表現からデータを復元する。
        /// </summary>
        /// <param name="s">文字列</param>
        public void SetData(string s)
        {
            string[] tokens = s.Split(',');
            foreach (string token in tokens)
            {
                int index = token.IndexOf('=');
                if (index > 0)
                {
                    string key = token.Substring(0, index - 1).Trim();
                    string value = token.Substring(index + 1).Trim();
                    switch (key)
                    {
                        case "OutputDirectory":
                            outputDirectory = value;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 保存用に文字列表現を得る。
        /// </summary>
        /// <returns>文字列表現</returns>
        public string GetData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OutputDirectory=").Append(outputDirectory);
            return sb.ToString();
        }
    }
}
