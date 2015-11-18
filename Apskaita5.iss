; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
AppName=Apskaita5
AppID=Apskaita5MD
AppVerName=Apskaita5 v. 2.0
AppPublisher=Marius Dagys
AppPublisherURL=http://www.tax.lt/
AppSupportURL=http://www.tax.lt/
AppUpdatesURL=http://www.tax.lt/
DefaultDirName={pf}\Apskaita5
DisableDirPage=yes
DefaultGroupName=Apskaita5
DisableProgramGroupPage=yes
OutputDir=D:\My Documents\Inno Output
OutputBaseFilename=Apskaita5_setup_full
MinVersion=0,5.0
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Apskaita5.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccDataAccessLayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccControls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccWebCrawler.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\HtmlAgilityPack.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\ApskaitaObjects.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\AccCommon.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Csla.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Microsoft.ReportViewer.ProcessingObjectModel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Microsoft.ReportViewer.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MySql.Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\ExcelApi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\NetOffice.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\OfficeApi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\VBIDEApi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\InvoiceInfo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Microsoft.Office.Interop.Excel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\sqlite3.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\AccMigration\bin\x86\Release\AccMigration.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FFData\*"; DestDir: "{app}\FFData"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MXFD\*"; DestDir: "{app}\MXFD"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\Reports\*"; DestDir: "{app}\Reports"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\SqlDepositories\*"; DestDir: "{app}\SqlDepositories"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\DbStructure\*"; DestDir: "{app}\DbStructure"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\zalsva.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\CommonSettings.xmls"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\tsp.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\WorkTime.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\PublicHolidays.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\FinancialStatements_Short.str"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\CommonCodes.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\WTClasses.dat"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\LastUpdateA5.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\My Documents\My Projects\Apskaita5\Apskaita3\Apskaita\bin\x86\Release\MySQL_accsecurity.sql"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Dirs]
Name: "{app}\Data"; Flags: uninsneveruninstall; Permissions: users-modify

[Icons]
Name: "{group}\Apskaita5"; Filename: "{app}\Apskaita5.exe"
Name: "{group}\AccMigration"; Filename: "{app}\AccMigration.exe"
Name: "{group}\{cm:UninstallProgram,Apskaita5}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Apskaita5"; Filename: "{app}\Apskaita5.exe"; Tasks: desktopicon; IconFilename: "{app}\zalsva.ico"

[Run]
Filename: "{app}\Apskaita5.exe"; Description: "{cm:LaunchProgram,Apskaita5}"; Flags: nowait postinstall skipifsilent

[Code]
function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1.4322'     .NET Framework 1.1
//    'v2.0.50727'    .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key: string;
    install, release, serviceCount: cardinal;
    check45, success: boolean;
begin
    // .NET 4.5 installs as update to .NET 4.0 Full
    if version = 'v4.5' then begin
        version := 'v4\Full';
        check45 := true;
    end else
        check45 := false;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + version;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0/4.5 uses value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 uses additional value Release
    if check45 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= 378389);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;
