﻿using System;
using System.Linq;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// オペレーション設定ユーティリティ
    /// </summary>
    public static class OperationSettingUtility
    {
        /// <summary>
        /// 設定を保存する。
        /// </summary>
        /// <param name="path">パス</param>
        /// <param name="operations">保存するデータ</param>
        public static void Save(string path, IOperation[] operations)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenWrite(path);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(stream))
                {
                    stream = null;

                    foreach (IOperation operation in operations)
                    {
                        WriteOperationSetting(sw, operation);
                    }
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }

        /// <summary>
        /// 設定を書き込む
        /// </summary>
        /// <param name="sw">書き込み先ストリーム</param>
        /// <param name="operation">オペレーション</param>
        private static void WriteOperationSetting(System.IO.StreamWriter sw, IOperation operation)
        {
            // オペレーション名
            sw.WriteLine($"[{operation.Name}]");

            IOperationSetting setting = operation.Setting;
            if (setting != null)
            {
                System.Reflection.PropertyInfo[] propInfos
                    = setting.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo pi in propInfos)
                {
                    if (!pi.CanRead || !pi.CanWrite)
                    {
                        continue;
                    }
                    string value = setting.GetPropertyValue(pi.Name);
                    sw.WriteLine($"{pi.Name} = {value}");
                }
            }
            sw.WriteLine();
        }

        /// <summary>
        /// 設定を読み出す。
        /// </summary>
        /// <param name="path">パス</param>
        /// <param name="operations">読み出した値を適用するデータ</param>
        public static void Load(string path, IOperation[] operations)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenRead(path);
                using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                {
                    stream = null;

                    // 読出処理(こっちはセクション区切りがあるのでちょっと面倒)
                    string textData = sr.ReadToEnd();
                    string[] lines = textData.Split('\n');
                    IOperationSetting setting = null;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        try
                        {
                            string line = lines[i].Trim();
                            if (line.StartsWith("[") && line.EndsWith("]"))
                            {
                                // セクション名
                                string sectionName = line.Substring(1, line.Length - 2);
                                setting = GetOperationSetting(operations, sectionName);
                            }
                            else
                            {
                                // 設定値（多分）
                                int index = line.IndexOf('=');
                                if (index > 0)
                                {
                                    string key = line.Substring(0, index).Trim();
                                    string value = line.Substring(index + 1).Trim();
                                    if (setting != null)
                                    {
                                        setting.SetPropertyValue(key, value);
                                    }
                                }

                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine($"line{i + 1}:{e.Message}");
                        }
                    }
                }

            }
            finally
            {
                stream?.Dispose();
            }

        }

        /// <summary>
        /// nameで指定されるオペレーションの設定を取得する。
        /// </summary>
        /// <param name="operations">オペレーションリスト</param>
        /// <param name="name">オペレーション名</param>
        /// <returns>設定が返る。</returns>
        private static IOperationSetting GetOperationSetting(
            IOperation[] operations, string name)
        {
            IOperation operation = operations.First((x) => x.Name.Equals(name));
            if (operation != null)
            {
                return operation.Setting;
            }

            return null;
        }
    }
}
