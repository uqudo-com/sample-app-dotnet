# Uqudo SDK - .NET iOS Sample App

A sample application demonstrating how to integrate the [Uqudo SDK](https://docs.uqudo.com) into a .NET 8 iOS application.

## Prerequisites

- .NET 8 SDK or later
- Visual Studio for Mac / JetBrains Rider / VS Code with C# Dev Kit
- Xcode 15+ (for iOS build toolchain)
- iOS device or simulator (arm64)

## NuGet Source Setup

The Uqudo SDK packages are hosted on a private NuGet repository. The included `NuGet.Config` already configures the source:

```
https://rm.dev.uqudo.io/repository/nuget-hosted/
```

## Getting Started

1. Clone this repository
2. Open `UqudoSampleApp.sln` in your IDE
3. Replace `YOUR_ACCESS_TOKEN_HERE` in `AppDelegate.cs` with your Uqudo access token
4. Build and run on a device or simulator

## Project Structure

| File | Description |
|------|-------------|
| `AppDelegate.cs` | Main entry point with UI setup and enrollment flow |
| `EnrollmentDelegate.cs` | Handles enrollment completion/failure callbacks |
| `BuilderControllerDelegate.cs` | Handles builder controller lifecycle callbacks |
| `Tracer.cs` | Analytics tracer for SDK event logging |
| `SceneDelegate.cs` | iOS scene lifecycle management |

## SDK Packages

| Package | Version |
|---------|---------|
| `UqudoSDK.DotNet.iOS` | 3.7.0 |
| `UqudoSDK.DotNet.OpenSSL` | 3.3.3001 |
| `UqudoSDK.DotNet.ShieldPtr` | 1.5.55 |

## Documentation

- [Plugin Installation](https://docs.uqudo.com/docs/kyc/uqudo-sdk/integration/xamarin/plugin-installation)
- [Enrolment Flow](https://docs.uqudo.com/docs/kyc/uqudo-sdk/integration/xamarin/enrolment-flow)
- [Analytics](https://docs.uqudo.com/docs/kyc/uqudo-sdk/integration/xamarin/analytics)
