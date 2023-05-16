using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModpackInstaller
{
    class LauncherProfilesChanger
    {
        private string minecraftInstallationPath;
        private string profilesJsonPath;
        private string profileImagePath;
        public LauncherProfilesChanger(string minecraftInstallationPath)
        {
            this.minecraftInstallationPath = minecraftInstallationPath;
            this.profilesJsonPath = Path.Combine(minecraftInstallationPath, Config.LauncherProfilesFilename);
            this.profileImagePath = Path.Combine(Config.ExecutingPath, "assets", Config.ProfileImageName);
        }

        public void ApplyProfile()
        {
            JObject jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(File.ReadAllText(profilesJsonPath));

            // Make sure profile exists
            Dictionary<string, LauncherProfile> profiles = jsonData["profiles"].ToObject<Dictionary<string, LauncherProfile>>();
            if (!profiles.ContainsKey(Config.ProfileName))
            {
                profiles[Config.ProfileName] = new LauncherProfile()
                {
                    name = Config.ProfileName,
                    type = "custom",
                    lastVersionId = Config.ForgeVersionname
                };
            }

            // Change / re-apply settings
            LauncherProfile profile = profiles[Config.ProfileName];
            profile.icon = "data:image/png;base64," + GetBase64StringForImage(this.profileImagePath);
            profile.gameDir = Path.Combine(minecraftInstallationPath, Config.ProfileRelativePath);

            profiles[Config.ProfileName] = profile;

            // Create a new JObject to write.
            JObject newJsonData = new JObject();
            newJsonData["profiles"] = JObject.FromObject(profiles);
            newJsonData["settings"] = jsonData["settings"];
            newJsonData["version"] = jsonData["version"];

            // Save new data to the profile settings file.
            File.WriteAllText(this.profilesJsonPath, JsonConvert.SerializeObject(newJsonData));
        }

        private static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
