﻿using DiscUtils.Iso9660;
using DiscUtils.Wim;
using DiscUtils.Registry;
using DiscUtils.Udf;

const string hiveFilePath = @"Windows\System32\config\SOFTWARE";

if (args.Length < 1 || !File.Exists(args[0]))
{
    Console.Error.WriteLine("No file found");
    Environment.Exit(1);
}

using (FileStream iso = File.Open(args[0], FileMode.Open, FileAccess.Read))
{
    UdfReader cd = new(iso);
    string useImage = string.Empty;
    string usingSources = "sources\\";

    if (!cd.DirectoryExists("sources") && (cd.DirectoryExists("x64") || cd.DirectoryExists("x86")))
    {
        usingSources = "x64\\sources\\";
    }

    if (cd.FileExists(usingSources + "install.wim"))
        useImage = usingSources + "install.wim";
    else if (cd.FileExists(usingSources + "install.esd"))
        useImage = usingSources + "install.esd";
    else
    {
        Console.Error.WriteLine("No supported image file found");
        Environment.Exit(2);
    }

    using (var image = cd.OpenFile(useImage, FileMode.Open))
    {
        var wimFile = image;
        WimFile wimContainer = new WimFile(wimFile);
        if (wimContainer.ImageCount < 1)
        {
            Console.Error.WriteLine("No image to open");
            Environment.Exit(3);
        }
        var wimImage = wimContainer.GetImage(0);
        Console.WriteLine($"Target Image:\t0");

        if (!wimImage.Exists(hiveFilePath))
        {
            Console.Error.WriteLine("No SOFTWARE hive found.");
            Environment.Exit(4);
        }

        using (var hiveFile = wimImage.OpenFile(hiveFilePath, FileMode.Open))
        using (var hive = new RegistryHive(hiveFile))
        {
            var rh_Microsoft_WinNT_CurVer = hive.Root.OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion");
            var dispver = (string)rh_Microsoft_WinNT_CurVer.GetValue("DisplayVersion");
            var buildver = (string)rh_Microsoft_WinNT_CurVer.GetValue("CurrentBuild");
            var prodname = (string)rh_Microsoft_WinNT_CurVer.GetValue("ProductName");
            Console.WriteLine($"Product Name:\t{prodname}");
            Console.WriteLine($"Version:\t{dispver}");
            Console.WriteLine($"Build:\t{buildver}");
        }
    }
}
