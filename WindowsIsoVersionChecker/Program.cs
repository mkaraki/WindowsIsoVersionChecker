using WindowsIsoVersionChecker;

Extractor extractor = new();

if (args.Length < 1)
{
    Console.Error.WriteLine(@"Invalid usage.");
    Environment.Exit(1);
}

if (File.Exists(args[0]))
{
    Console.WriteLine($"ISO Image:\t{args[0]}");
    try
    {
        extractor.ExtractFromIso(args[0]);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.ToString());
        Environment.Exit(2);
    }
}
else if (Directory.Exists(args[0]))
{
    Console.WriteLine($"Directory:\t{args[0]}");
    try
    {
        extractor.ExtractFromDirectory(args[0]);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.ToString());
        Environment.Exit(2);
    }
}
else
{
    Console.Error.WriteLine("No file/directory found.");
    Environment.Exit(1);
}


// Results

if (extractor.ProductName != null)
    Console.WriteLine($"Product Name:\t{extractor.ProductName}");

if (extractor.Architectures.Length > 0)
{
    Console.Write("Architecture:\t");
    foreach(var i in extractor.Architectures)
        Console.Write(i + ' ');
    Console.WriteLine();
}

if (extractor.ProductVersion != null)
    Console.WriteLine($"Version:\t{extractor.ProductVersion}");

if (extractor.Build != null)
    Console.WriteLine($"Build:\t{extractor.Build}");

if (extractor.BuildInfo != null)
    Console.WriteLine($"BuildLabEx:\t{extractor.BuildInfo}");