using CharaChipGen.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CharaChipGen
{
    static class Program
    {
        // ファイルパス
        private static List<string> filePaths;
        // 素材ルートディレクトリ（iniファイルにしたいなあ）
        private static string materialDirectory;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            filePaths = new List<string>();

            try
            {
                ParseArgs();
                Initialize();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Properties.Resources.DialogTitleError);
                return;
            }

            if (filePaths.Count == 0)
            {
                RunWindowApplication();
            }
            else
            {
                RunGenerate();
            }
        }

        /// <summary>
        /// ウィンドウアプリケーションモード
        /// </summary>
        private static void RunWindowApplication()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm.MainForm());
        }

        /// <summary>
        /// ファイル出力モード
        /// </summary>
        private static void RunGenerate()
        {
            try
            {
                GeneratorSettingReader reader = new GeneratorSettingReader();
                foreach (string path in filePaths)
                {
                    GeneratorSetting setting = reader.Read(path);
                    CharaChipExporter.ExportCharaChip(setting);
                }
                MessageBox.Show(Properties.Resources.MessageExported,
                    Properties.Resources.DialogTitleInformation);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Properties.Resources.DialogTitleError);
            }

        }

        /// <summary>
        /// 引数を解析する。
        /// </summary>
        private static void ParseArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg[0] != '-')
                {
                    if (arg.EndsWith(".xml"))
                    {
                        filePaths.Add(arg);
                    }
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
        }

        /// <summary>
        /// 初期化する。
        /// </summary>
        private static void Initialize()
        {
            AppData data = AppData.Instance;

            if ((materialDirectory == null) || !data.Initialize(materialDirectory))
            {
                // マテリアルディレクトリが指定されていないか、
                // 指定したディレクトリで初期化できない。
                string defaultMaterialDirectory = GetDefaultMaterialDirectory();

                if (!data.Initialize(defaultMaterialDirectory))
                {
                    // カレントディレクトリで試したが初期化できない。
                    string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string dir = System.IO.Path.GetDirectoryName(assemblyLocation);
                    if (!data.Initialize(dir))
                    {
                        // アセンブリのディレクトリで試したが初期化できない。
                        throw new Exception(Properties.Resources.MessageMaterialDirectoryNotFound);
                    }
                }
            }
        }

        /// <summary>
        /// 素材ディレクトリを得る。
        /// </summary>
        /// <returns>素材ディレクトリ</returns>
        private static string GetDefaultMaterialDirectory()
        {
            string dir = Properties.Settings.Default.MaterialDirectory;
            if (!string.IsNullOrEmpty(dir) && System.IO.Directory.Exists(dir))
            {
                return dir;
            }
            else
            {
                return System.IO.Directory.GetCurrentDirectory();
            }
        }
    }
}
