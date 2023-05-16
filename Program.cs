using Microsoft.Win32;
using System;
using System.IO;

namespace ModpackInstaller
{
    class Program
    {
        static string minecraftInstallationPath;

        static void Main(string[] args)
        {
            minecraftInstallationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Config.MinecraftFolderName);

            //shell: AppsFolder
            Console.WriteLine("Preparing installation.");
            ForgeInstaller forgeInstaller = new ForgeInstaller(minecraftInstallationPath);
            LauncherProfilesChanger launcherProfilesChanger = new LauncherProfilesChanger(minecraftInstallationPath);
            ModsUnpacker modsUnpacker = new ModsUnpacker(minecraftInstallationPath);

            Console.WriteLine("Installing forge");
            forgeInstaller.InstallForge();
            Console.WriteLine("Applying profile");
            launcherProfilesChanger.ApplyProfile();
            Console.WriteLine("Unpacking mods");
            modsUnpacker.UnpackMods();

            Console.WriteLine("Done :)");
        }
    }
}
