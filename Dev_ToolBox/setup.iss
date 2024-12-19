[Setup]
AppName=Dev ToolBox
AppVersion=1.0
DefaultDirName={pf}\Dev ToolBox
DefaultGroupName=Dev ToolBox
OutputBaseFilename=Dev_ToolBox_Setup
OutputDir=Dev_toolBox\Installer
Compression=lzma
SolidCompression=yes

[Files]
Source: "bin\Release\net8.0-windows10.0.19041.0\*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Dev ToolBox"; Filename: "{app}\Dev_ToolBox.exe"
