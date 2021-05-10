using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStacker
{
    /// <summary>
    /// テキストユーティリティ
    /// </summary>
    public static class TextUtility
    {
        /// <summary>
        /// 文字列をデリミタで分割する。
        /// ダブルクォーテーションをつかった分割対応のためのメソッド。
        /// </summary>
        /// <param name="str">行</param>
        /// <param name="delimiters">デリミタ</param>
        /// <returns>分割された文字列が返る。</returns>
        public static string[] Split(string str, char[] delimiters)
        {
            List<string> tokens = new List<string>();

            int index = 0;
            int lineLength = str.Length;
            while (index < lineLength)
            {
                // 先頭位置探索：デリミタが出現しなくなるまでスキップ
                while ((index < lineLength) && delimiters.Contains(str[index]))
                {
                    index++;
                }
                if (index >= lineLength)
                {
                    break;
                }

                // 先頭位置検出
                int beginIndex = index;

                while (index < lineLength)
                {
                    if (str[index] == '\"')
                    {
                        // 次の\"までスキップ
                        int i = str.IndexOf('\"', index + 1);
                        index = (i >= 0) ? i + 1 : lineLength;
                    }
                    else if (index < lineLength)
                    {
                        if (!delimiters.Contains(str[index]))
                        {
                            index++;
                        }
                        else
                        {
                            // デリミタ検出
                            break;
                        }
                    }
                }

                int endIndex = index;

                string token = str.Substring(beginIndex, endIndex - beginIndex);
                // 空文字列が入る可能性があるが、
                // それはそれで有効とする。
                tokens.Add(token);
            }
            return tokens.ToArray();
        }
    }
}
