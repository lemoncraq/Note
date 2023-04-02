#define MyAppName "NoteApp"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Makovskiy Nikita"
#define MyAppURL "https://github.com/pelemew/Note"
#define MyAppExeName "NoteApp.UI.exe"
#define UninstallName "unins000.exe"
#define StartMenuFolderName "NoteApp"
#define AppIconName "NoteIcon.ico"

[Setup]
AppId = {{93331FE0-E1CC-409F-A52F-354CE94D108F}
AppName = {#MyAppName}
AppVersion = {#MyAppVersion}
;AppVerName = {#MyAppName} {#MyAppVersion}
AppPublisher = {#MyAppPublisher}
AppPublisherURL = {#MyAppURL}
AppSupportURL = {#MyAppURL}
AppUpdatesURL = {#MyAppURL}
DefaultDirName = {autopf}\{#MyAppName}
DefaultGroupName = {#MyAppName}
ChangesAssociations = yes
DisableProgramGroupPage = yes
OutputDir = Installers
OutputBaseFilename = NoteAppSetup {#SetupSetting("MyAppVersion") + GetDateTimeString('dd-mm-yyyy hh-nn-ss', '-', ':')}
SetupIconFile = "..\..\NoteApp.UI\{#AppIconName}"
Compression = lzma
SolidCompression = yes
WizardStyle = modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Dirs]
Name: "{commonstartmenu}\{#StartMenuFolderName}"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\NoteApp.UI\{#AppIconName}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonstartmenu}\{#StartMenuFolderName}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename:"{app}\{#AppIconName}"
Name: "{commonstartmenu}\{#StartMenuFolderName}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{app}\{#UninstallName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFileName: "{app}\{#AppIconName}";  Tasks:desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

