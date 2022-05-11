# Windows ISO Version Checker

## Requirements

- dotnet 6.0 SDK

## Usage

Check iso file:
```
dotnet run image.iso
```

Check DVD:
```
dotnet run D:\
```

You have to run in `WindowsIsoVersionChecker` directory.

## Supported Image

We tested:
- Windows Vista SP2 x64
- Windows 7 SP1 x64
- Windows 10 1507 (Initial Release) x86,64 combined
- Windows 10 1511 x64
- Windows 10 1607 x64
- Windows 10 20H1 x64, x86
- Windows 10 21H1 x64, x86
- Windows 11 21H2

These images are not supported:
- Windows XP or older
