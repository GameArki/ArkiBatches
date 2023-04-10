using System;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GitDownloadApp {

    public class GitDownloadApp {

        public static void Main(string[] args) {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "git";
            start.Arguments = "clone ssh://git@github.com/GameArki/FPMath.git FPMath";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.CreateNoWindow = true;
            start.WorkingDirectory = Environment.CurrentDirectory;
            Process process = Process.Start(start);
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.WriteLine(process.StandardError.ReadToEnd());
            process.Close();

            // 删除文件夹: 1. 先把文件夹下的文件全设成可写(需要递归文件夹下的文件夹); 2. 再删除文件夹
            string path = "FPMath";
            SetDirWritable(path);
            Directory.Delete(path, true);
        }

        static void SetDirWritable(string dir) {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.Exists) {
                dirInfo.Attributes = FileAttributes.Normal;
                foreach (FileInfo file in dirInfo.GetFiles()) {
                    file.Attributes = FileAttributes.Normal;
                }
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories()) {
                    SetDirWritable(subDir.FullName);
                }
            }
        }

    }

}