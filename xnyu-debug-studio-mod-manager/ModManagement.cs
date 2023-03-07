using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xnyu_debug_studio_mod_manager
{
    public static class ModManagement
    {
        public static void InstallMod(string zip, string historyName, string historyDir, bool deleteZip)
        {
            string originalTemplatePath = Directory.GetCurrentDirectory() + @"\templates\";
            string originalModsPath = Directory.GetCurrentDirectory() + @"\mods\";

            string historyFileContent = "";
            string tmpDir = historyDir + @"\" + GenerateRandomNumberString(10);

            Directory.CreateDirectory(tmpDir);

            ZipFile.ExtractToDirectory(zip, tmpDir);
            if (Directory.Exists(tmpDir + @"\templates"))
            {
                string[] files = Directory.GetFiles(tmpDir + @"\templates");
                for (int i = 0; i < files.Length; i++)
                {
                    string name = files[i].Split('\\')[files[i].Split('\\').Length - 1];
                    historyFileContent = historyFileContent + "/templates/" + name + "\n";
                    File.Copy(files[i], originalTemplatePath + name);
                }
            }
            if (Directory.Exists(tmpDir + @"\mods"))
            {
                string[] dirs = Directory.GetDirectories(tmpDir + @"\mods");
                for (int i = 0; i < dirs.Length; i++)
                {
                    string name = dirs[i].Split('\\')[dirs[i].Split('\\').Length - 1];
                    historyFileContent = historyFileContent + "/mods/" + name + "\n";
                    Directory.Move(dirs[i], originalModsPath + name);
                }
            }
            Directory.Delete(tmpDir, true);
            if (deleteZip) File.Delete(zip);

            File.WriteAllText(historyDir + @"\" + historyName + ".his", historyFileContent);
        }

        public static void UninstallMod(string historyName, string historyDir)
        {
            string[] files = File.ReadAllLines(historyDir + @"\" + historyName + ".his");

            for (int i = 0; i < files.Length; i++)
            {
                string dest = Directory.GetCurrentDirectory() + files[i].Replace("/", "\\");
                if (files[i].Contains("."))
                {
                    File.Delete(dest);
                }
                else
                {
                    Directory.Delete(dest, true);
                }
            }

            File.Delete(historyDir + @"\" + historyName + ".his");
        }

        public static string GenerateRandomNumberString(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

}
