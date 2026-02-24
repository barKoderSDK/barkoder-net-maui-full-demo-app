# barkoder_app_maui

`.NET MAUI` implementation of the Barkoder demo app, keeping the same general screen structure and scanner modes:

- Home
- Scanner
- Barcode Details
- Recent Scans (History)
- About

## Implemented Barkoder Features

- License key loading via `BARKODER_LICENSE_KEY` (`.env` packaged as `app.env` or environment variable)
- Native Barkoder view setup and handler registration (`BarkoderView`, `BarkoderViewHandler`)
- Live scanning (`StartScanning`, pause/resume flow, `StopScanning` when needed)
- Gallery image scanning (`ScanImage`) with image picker integration
- Barcode type enable/disable with mode-specific presets
- Preset modes: `1D`, `2D`, `Continuous`, `MultiScan`, `VIN`, `DPM`, `DeBlur`, `DotCode`, `AR`, `MRZ`, `Gallery`, `AnyScan`
- Runtime scanner settings (ROI, decoding speed, resolution, continuous scanning, duplicate threshold, AR options, etc.)
- Result callbacks via `IBarkoderDelegate` (`DidFinishScanning`)
- Scan history persistence (including saved preview images) and per-mode settings persistence

## Prerequisites

- .NET SDK `8.0.417` (see `global.json`)
- .NET MAUI workload (Android/iOS)
- Android Studio + Android SDK (for Android builds)
- Xcode (for iOS builds, macOS only)
- Barkoder license key

## Setup

1. Restore workloads (first time only):
   ```bash
   dotnet workload install maui maui-android maui-ios
   ```
2. Restore dependencies:
   ```bash
   dotnet restore barkoder_app_maui.sln
   ```
3. Create a `.env` file in the project root and set:
   ```env
   BARKODER_LICENSE_KEY=YOUR_BARKODER_LICENSE_KEY
   ```
4. Build for Android:
   ```bash
   dotnet build barkoder_app_maui.sln -f net8.0-android34.0
   ```
5. Build for iOS:
   ```bash
   dotnet build barkoder_app_maui.sln -f net8.0-ios18.0
   ```

## Useful Commands

- Run Android (connected device/emulator):
  ```bash
  dotnet build _TmpMaui.csproj -t:Run -f net8.0-android34.0
  ```
- Run iOS (macOS + simulator/device):
  ```bash
  dotnet build _TmpMaui.csproj -t:Run -f net8.0-ios18.0
  ```
- Clean:
  ```bash
  dotnet clean barkoder_app_maui.sln
  ```

## Notes

- Windows target is intentionally not included in this project because the Barkoder MAUI package used here does not support `net8.0-windows`.

## Reference Used

- Installation: https://barkoder.com/docs/v1/maui/net-maui-installation
- API: https://barkoder.com/docs/v1/maui/net-maui-api-reference
- Examples: https://barkoder.com/docs/v1/maui/net-maui-example
