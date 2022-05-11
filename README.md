# WindowsIsoVersionChecker

## Requirements

- dotnet 6.0 SDK

## Usage

```
dotnet run image.iso
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

These images are not supported
- Windows XP or older

These images are unable to extract. It's bug.
- Windows 11, Shows like `Windows 10`
