using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ModpackInstaller
{
    class ForgeInstaller
    {
        private string minecraftInstallationPath;
        private string forgeInstallerPath;
        private string forgeCLIPath;

        private string[] javaLocations = new string[] {
            Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "../Local/Packages/Microsoft.4297127D64EC6_8wekyb3d8bbwe/LocalCache/Local/runtime/java-runtime-gamma/windows-x64/java-runtime-gamma/bin/java.exe")),
            "C:/Program Files (x86)/Minecraft Launcher/runtime/jre-x64/bin/java.exe"
        };

        public ForgeInstaller(string minecraftInstallationPath)
        {
            this.minecraftInstallationPath = minecraftInstallationPath;
            this.forgeInstallerPath = Path.Combine(Config.ExecutingPath, "assets", Config.ForgeInstallerFilename);
            this.forgeCLIPath = Path.Combine(Config.ExecutingPath, "assets", Config.ForgeCLIFilename);
        }

        /// <summary>
        /// Installs the require forge version.
        /// </summary>
        internal void InstallForge()
        {
            string command = $"-jar \"{ this.forgeCLIPath}\" --installer \"{this.forgeInstallerPath}\" --target \"{this.minecraftInstallationPath}\"";

            Process process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = GetJavaLocation();
            process.StartInfo.Arguments = command;
            process.Start();
            process.WaitForExit();
        }

        private string GetJavaLocation()
        {
            // Find availible JRE's installed with MC
            foreach (var loc in javaLocations)
            {
                Console.WriteLine($"Checking \n {loc} \n");
                if (File.Exists(loc))
                    return loc;
            }

            // Joke to user.
            Console.WriteLine("No JAVA found. Big L.");
            while (true) { }
            return "derp";
        }

        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(javaKey))
            {
                string currentVersion = rk.GetValue("CurrentVersion").ToString();
                using (RegistryKey key = rk.OpenSubKey(currentVersion))
                {
                    return key.GetValue("JavaHome").ToString();
                }
            }
        }
    }
}
