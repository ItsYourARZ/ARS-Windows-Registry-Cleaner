# Windows Registry Cleaner (Console)

## Description
This is a simple **Windows Registry Cleaner** built in **C#**. It scans specific registry locations for invalid or obsolete entries and allows users to delete them manually. The tool also provides an option to create a registry backup before making changes.

## ⚠️ WARNING ⚠️
**Modifying the Windows Registry can be dangerous!**
- Incorrect changes may cause system instability or failure.
- Only use this tool if you understand how the Windows Registry works.
- Always create a backup before making changes.
- The creator of this tool is **NOT responsible** for any damage or data loss.

## Features
- ✅ Scans Windows registry for invalid keys.
- ✅ Asks for user confirmation before deleting entries.
- ✅ Allows users to specify a backup location.
- ✅ Saves a backup before making changes.

## Prerequisites
- Windows OS (Tested on Windows 10/11)
- .NET SDK (for compiling the source code)

## How to Build
### Using .NET CLI:
1. Open a terminal or Command Prompt.
2. Navigate to the project folder.
3. Run the following command to build:
   ```sh
   dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
   ```
4. The `RegistryCleaner.exe` will be in:
   ```sh
   bin\Release\netX.X\win-x64\publish\RegistryCleaner.exe
   ```
   *(Replace `netX.X` with your .NET version, e.g., `net8.0`)*

## How to Use
1. **Run the .exe file as Administrator** (Required for registry modifications).
2. **Enter a backup file location** when prompted (e.g., `C:\backup.reg`).
3. **Confirm deletions** when invalid registry keys are found.
4. **Review the log messages** to track changes.

## Known Issues
- The tool currently only scans `SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall`.
- Requires Administrator privileges to make registry changes.

## Future Improvements
- 🔹 Auto-detection of more registry issues.
- 🔹 Option for automatic deletion of invalid keys.
- 🔹 Detailed logging system.

## License
This project is open-source and free to use. However, use it **at your own risk**.

