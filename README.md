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
- Windows 7 x64
- Windows 10 20H1 x64, x86
- Windows 10 21H1 x64, x86

These images are not supported
- Windows XP or older

These images are unable to extract. It's bug.
- Windows 10 20H1 or older, Unable to show version like `20H1`
- Windows 11, Shows like `Windows 10`
