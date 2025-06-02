# Minimum Requirements

To set up and run this project, make sure the following tools are installed:

## 1. Visual Studio Code
- Lightweight code editor
- Download: [https://code.visualstudio.com/](https://code.visualstudio.com/)

> Recommended Extensions:
> - C# for Visual Studio Code (powered by OmniSharp)
> - MySQL extension (optional)

## 2. .NET SDK 8.0
- Required to build and run the application
- Download: [https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

> Verify installation:
> ```bash
> dotnet --version
> ```

## 3. MySQL Server
- Required if the project uses a MySQL database
- Download: [https://dev.mysql.com/downloads/installer/](https://dev.mysql.com/downloads/installer/)

> Ensure MySQL is running and accessible. Update your connection string in `appsettings.json` or secrets file.
