using DiscUtils.Registry;
using DiscUtils.Udf;
using SevenZipExtractor;

const string hiveFilePath = @"Windows\System32\config\SOFTWARE";

if (args.Length < 1 || !File.Exists(args[0]))
{
    Console.Error.WriteLine("No file found");
    Environment.Exit(1);
}

Console.WriteLine($"ISO Image:\t{args[0]}");
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

    Console.WriteLine($"Wim Image:\t{useImage}");

    using (var image = cd.OpenFile(useImage, FileMode.Open))
    using (var wimArchive = new ArchiveFile(image, SevenZipFormat.Wim))
    {
        string wimPrefix = string.Empty;
        if (!wimArchive.Entries.Any(v => v.FileName == "Windows") && wimArchive.Entries.Any(v => v.FileName == "1"))
        {
            wimPrefix = "1\\";
        }

        if (!wimArchive.Entries.Any(v => v.FileName == wimPrefix + hiveFilePath))
        {
            Console.Error.WriteLine("No SOFTWARE hive found.");
            Environment.Exit(4);
        }

        Console.WriteLine($"Hive Path:\t{wimPrefix}");

        var temp_hive_path = Path.GetTempFileName();

        wimArchive.Entries.First(v => v.FileName == wimPrefix + hiveFilePath).Extract(temp_hive_path);

        Console.WriteLine($"Temp Hive Path:\t{temp_hive_path}");

        using (FileStream hiveFileStream = File.Open(temp_hive_path, FileMode.Open, FileAccess.Read))
        using (var hive = new RegistryHive(hiveFileStream))
        {
            var rh_Microsoft_WinNT_CurVer = hive.Root.OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion");
            var dispver = (string)rh_Microsoft_WinNT_CurVer.GetValue("DisplayVersion");
            var buildver = (string)rh_Microsoft_WinNT_CurVer.GetValue("CurrentBuild");
            var prodname = (string)rh_Microsoft_WinNT_CurVer.GetValue("ProductName");
            Console.WriteLine($"Product Name:\t{prodname}");
            Console.WriteLine($"Version:\t{dispver}");
            Console.WriteLine($"Build:\t{buildver}");
        }

        File.Delete(temp_hive_path);
    }
}
