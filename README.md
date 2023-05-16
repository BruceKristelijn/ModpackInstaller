# ModpackInstaller
Simple EXE for installing forge + all mods % settings for our server.

Uses ForgeCLI so users only have to wait for the installation.

# Requirements
A folder called `assets` with the following files:
`version_logo.png` - A png 128 x 128 for your version
`forge-cli.jar` - Renamed JAR of https://github.com/TeamKun/ForgeCLI
`forge-installer.jar` - The installer JAR for forge
`mods.zip` - A zip containing all you modpacks mods
`shaders.zip` - A zip containing all your shaders you want to include
`scripts.zip` - A zip containing all you scripts to include (recipes etc.)
`config.zip` - A zip containing all configs to include

# Hacky
This is a hacky solution, uses never have the right java installed. Found two folders that come delivered with MC, one for the new and one for the older version.

# Publish / build
Run the following command:
>`dotnet build --self-contained true --runtime win-x86`
