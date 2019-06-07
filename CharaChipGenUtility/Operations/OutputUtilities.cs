using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CGenImaging;

namespace CharaChipGenUtility.Operations
{
    /// <summary>
    /// 出力ユーティリティ
    /// </summary>
    public static class OutputUtilities
    {
        /// <summary>
        /// 連番名を付けて画像を書き出す。
        /// {dir}\{baseName}XXXXX.png のようなファイル名で書き出しを行う。
        /// </summary>
        /// <param name="dir">書き出し先ディレクトリ</param>
        /// <param name="baseName">ファイル名のベース</param>
        /// <param name="image">画像</param>
        public static void WriteImageWithNewName(string dir, string baseName, ImageBuffer image)
        {
            string path = GeneratePathNotExists(dir, baseName, ".png");
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            using (Image im = image.GetImage())
            {
                im.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        /// <summary>
        /// 存在しないパスを生成する。
        /// </summary>
        /// <param name="dir">出力ディレクトリ</param>
        /// <param name="baseName">ベース名</param>
        /// <param name="suffix">拡張子</param>
        /// <returns>パスが返る。</returns>
        private static string GeneratePathNotExists(string dir, string baseName, string suffix)
        {
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                string path = System.IO.Path.Combine(dir, $"{baseName}{i}{suffix}");
                if (!System.IO.File.Exists(path))
                {
                    return path;
                }
            }

            // Int32.MaxValueで判定しているので、
            // 1つのディレクトリ下にここまで多い数が並ぶことはないはずである。
            throw new Exception($"File is too meny in output directory. {dir}");
        }
    }
}
