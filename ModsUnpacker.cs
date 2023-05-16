using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ModpackInstaller
{
    class ModsUnpacker
    {
        private string minecraftInstallationPath;
        private string projectfolder, zipPath;
        private string[] folders = new string[] { "mods", "config", "scripts", "shaders" };
        public ModsUnpacker(string minecraftInstallationPath)
        {
            this.minecraftInstallationPath = minecraftInstallationPath;
            this.projectfolder = Path.Combine(minecraftInstallationPath, Config.ProfileRelativePath);
            this.zipPath = Path.Combine(Config.ExecutingPath, "assets");

            foreach (var folder in folders)
            {
                if (!Directory.Exists(Path.Combine(this.projectfolder, folder)))
                {
                    Directory.CreateDirectory(Path.Combine(this.projectfolder, folder));
                }
            }
        }

        public void UnpackMods()
        {
            foreach (var folder in folders)
            {
                // First delete (old) mods & files
                DirectoryInfo di = new DirectoryInfo(Path.Combine(this.projectfolder, folder));

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                // Unzip the mods.zip
                using (ZipArchive zip = ZipFile.Open(Path.Combine(this.zipPath, folder + ".zip"), ZipArchiveMode.Read))
                {
                    zip.ExtractToDirectory(Path.Combine(this.projectfolder, folder));
                }
            }
        }
    }
}
