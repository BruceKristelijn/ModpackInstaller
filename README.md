# ModpackInstaller
Simple EXE for installing forge + all mods % settings for our server.

Uses ForgeCLI so users only have to wait for the installation.

# Requirements
A folder called `assets` with the following files: <br>
`version_logo.png` - A png 128 x 128 for your version <br>
`forge-cli.jar` - Renamed JAR of https://github.com/TeamKun/ForgeCLI <br>
`forge-installer.jar` - The installer JAR for forge <br>
`mods.zip` - A zip containing all you modpacks mods <br>
`shaders.zip` - A zip containing all your shaders you want to include <br>
`scripts.zip` - A zip containing all you scripts to include (recipes etc.) <br>
`config.zip` - A zip containing all configs to include <br>
`servers.dat` - A file which contains the servers are added <br>

# Hacky
This is a hacky solution, uses never have the right java installed. Found two folders that come delivered with MC, one for the new and one for the older version.

# Publish / build
Run the following command:
>`dotnet build --self-contained true --runtime win-x86`
