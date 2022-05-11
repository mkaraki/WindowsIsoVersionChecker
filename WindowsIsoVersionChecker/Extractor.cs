﻿using DiscUtils.Registry;
using DiscUtils.Udf;
using SevenZipExtractor;

namespace WindowsIsoVersionChecker
{
    internal class Extractor
    {
        private static string HIVEFILEPATH = @"Windows\System32\config\SOFTWARE";

        public void ExtractFromIso(string isoPath)
        {
            using FileStream iso = File.Open(isoPath, FileMode.Open, FileAccess.Read);

            UdfReader cd = new(iso);
            string useImage = string.Empty;
            string usingSources = "sources\\";

            if (!cd.DirectoryExists("sources") && (cd.DirectoryExists("x64") || cd.DirectoryExists("x86")))
            {
                usingSources = "x64\\sources\\";

                List<string> archs = new();
                if (cd.DirectoryExists("x64"))
                    archs.Add("x64");
                else if (cd.DirectoryExists("x86"))
                    archs.Add("x86");
                Architectures = archs.ToArray();
            }

            if (cd.FileExists(usingSources + "install.wim"))
                useImage = usingSources + "install.wim";
            else if (cd.FileExists(usingSources + "install.esd"))
                useImage = usingSources + "install.esd";
            else
                throw new Exception("No supported image found");

            using (var image = cd.OpenFile(useImage, FileMode.Open))
                ExtractFromWim(image);
        }

        private void ExtractFromWim(Stream wimStream)
        {
            string temp_hive_path = string.Empty;
            using var wimArchive = new ArchiveFile(wimStream, SevenZipFormat.Wim);
            {
                string wimPrefix;

                if (wimArchive.Entries.Any(v => v.FileName == "Windows"))
                    wimPrefix = string.Empty;
                else if (wimArchive.Entries.Any(v => v.FileName == "1\\Windows"))
                    wimPrefix = "1\\";
                else
                    throw new Exception("Unable to find Windows Image");

                if (!wimArchive.Entries.Any(v => v.FileName == wimPrefix + HIVEFILEPATH))
                    throw new Exception("hive not found");

                temp_hive_path = Path.GetTempFileName();
                wimArchive.Entries.First(v => v.FileName == wimPrefix + HIVEFILEPATH).Extract(temp_hive_path);

                if (Architectures.Length == 0)
                    Architectures = new string[1] { (wimArchive.Entries.Any(v => v.FileName == wimPrefix + "Program Files (x86)") ? "x64" : "x86") };
            }

            try
            {
                ExtractFromRegistry(temp_hive_path);
            }
            finally
            {
                File.Delete(temp_hive_path);
            }
        }

        private void ExtractFromRegistry(string hivefile)
        {
            using (FileStream hiveFileStream = File.Open(hivefile, FileMode.Open, FileAccess.Read))
            using (var hive = new RegistryHive(hiveFileStream))
            {
                var rh_Microsoft_WinNT_CurVer = hive.Root.OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey("CurrentVersion");
                var prodname = (string)rh_Microsoft_WinNT_CurVer.GetValue("ProductName");
                var dispver = (string)(rh_Microsoft_WinNT_CurVer.GetValue("DisplayVersion") ?? rh_Microsoft_WinNT_CurVer.GetValue("ReleaseId") ?? rh_Microsoft_WinNT_CurVer.GetValue("CSDVersion"));
                var buildver = (string)rh_Microsoft_WinNT_CurVer.GetValue("CurrentBuild");
                var buildlabex = (string)rh_Microsoft_WinNT_CurVer.GetValue("BuildLabEx");

                if (dispver == null && prodname.StartsWith("Windows 10") && int.TryParse(buildver, out int buildver_int) && buildver_int < 10586)
                {
                    dispver = "1507 (Initial Release)";
                }

                ProductName = prodname;
                ProductVersion = dispver;
                Build = buildver;
                BuildInfo = buildlabex;
            }
        }

        public string[] Architectures { get; private set; } = Array.Empty<string>();

        public string? ProductName { get; private set; }

        public string? ProductVersion { get; private set; }

        public string? Build { get; private set; }

        public string? BuildInfo { get; private set; }
    }
}