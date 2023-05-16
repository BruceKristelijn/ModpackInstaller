using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ModpackInstaller
{
    abstract class Config
    {
        public static string ExecutingPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public const string MinecraftFolderName = ".minecraft";
        public const string LauncherProfilesFilename = "launcher_profiles.json";

        public const string ProfileName = "CreateMon";
        public const string ServerDataFileName = "servers.dat";
        public const string ProfileImageName = "version_logo.png";
        public const string ForgeInstallerFilename = "forge-installer.jar";
        public const string ForgeCLIFilename = "forge-cli.jar";
        public const string ForgeVersionname = "1.19.2-forge-43.2.0";

        public const string ProfileRelativePath = "directories/" + ProfileName + "/";
    }
}
