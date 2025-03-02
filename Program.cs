using System;
using Microsoft.Win32;
using System.IO;

class RegistryCleaner
{
    static void Main()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("     ARS WINDOWS REGISTRY CLEANER - CONSOLE");
        Console.WriteLine("==============================================");
        Console.WriteLine("WARNING: Modifying the Windows Registry can cause serious issues!");
        Console.WriteLine("Proceed ONLY if you know what you're doing.");
        Console.WriteLine("A backup will be created before any changes are made.");
        Console.WriteLine("The creator of this tool is NOT responsible for any damages.");
        Console.WriteLine("Use at your own risk.");
        Console.WriteLine("==============================================\n");

        Console.Write("Do you want to continue? (yes/no): ");
        string confirmation = Console.ReadLine()?.ToLower();
        if (confirmation != "yes")
        {
            Console.WriteLine("Operation canceled.");
            return;
        }

        Console.Write("\nEnter the path to save the registry backup (e.g., C:\\backup.reg): ");
        string backupPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(backupPath))
        {
            Console.WriteLine("Invalid path. Exiting...");
            return;
        }

        BackupRegistry(backupPath);
        ScanAndCleanRegistry();

        Console.WriteLine("\nCleaning complete! A backup has been saved at: " + backupPath);
    }

    static void BackupRegistry(string backupPath)
    {
        try
        {
            string command = $"reg export HKLM\\Software \"{backupPath}\" /y";
            System.Diagnostics.Process.Start("cmd.exe", "/c " + command);
            Console.WriteLine("Registry backup completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Backup failed: " + ex.Message);
        }
    }

    static void ScanAndCleanRegistry()
    {
        string[] registryPaths = {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

        foreach (string path in registryPaths)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path, true))
            {
                if (key != null)
                {
                    foreach (string subKey in key.GetSubKeyNames())
                    {
                        using (RegistryKey sub = key.OpenSubKey(subKey))
                        {
                            if (sub != null && sub.GetValue("DisplayName") == null)
                            {
                                Console.WriteLine($"Found invalid key: {path}\\{subKey}");
                                Console.Write("Delete? (y/n): ");
                                if (Console.ReadLine()?.ToLower() == "y")
                                {
                                    key.DeleteSubKey(subKey);
                                    Console.WriteLine("Deleted.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
