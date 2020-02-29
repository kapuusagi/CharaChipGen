using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CharaChipGen.MainForm;

namespace CharaChipGen
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            try
            {
                ParseArgs();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "エラー");
                return;
            }

            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CharaChipGen.MainForm.MainForm());
        }

        private static void ParseArgs()
        {
            AppData data = AppData.Instance;

            string materialDirectory = null;

            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg[0] != '-')
                {
                    continue;
                }
                if (arg == "-data-directory")
                {
                    if ((i + 1) < args.Length)
                    {
                        materialDirectory = args[i + 1];
                        i++;
                    }

                }
            }

            if ((materialDirectory == null) || !data.LoadMatrialList(materialDirectory))
            {
                // マテリアルディレクトリが指定されていないか、
                // 指定したディレクトリで初期化できない。
                if (!data.LoadMatrialList(System.IO.Directory.GetCurrentDirectory()))
                {
                    // カレントディレクトリで試したが初期化できない。
                    string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string dir = System.IO.Path.GetDirectoryName(assemblyLocation);
                    if (!data.LoadMatrialList(dir))
                    {
                        // アセンブリのディレクトリで試したが初期化できない。
                        throw new Exception("素材ディレクトリが見つかりませんでした");
                    }
                }
            }
        }
    }
}
