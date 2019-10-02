# SimpleWeather web
Blazor Webassembly application for fetching current weather in chosen city using OpenWeatherMap API. App also uses SASS CSS-compiler.
## Deployment tutorial
To compile application on your device you should download .NET Core 3.0 SDK from dot.net. Any IDE is not required since you can compile and run applications via command line.  
For the best experience you can work with solution in Visual Studio on Windows or Mac. Make sure you use 16.3 version or higher on Windows and 8.3 version or higher on Mac since older version don't support .NET Core 3.0.  
SASS compilation of "Styles/site.scss" is included in build tasks via NuGet package and generate appropriate CSS-file and its minified version in wwwroot folder when you build solution. You can check and change its compilation options in "compilerconfig.json.defaults".
### CLI commands
 1. Verify whether the CLI is installed properly using "dotnet --list-sdks".
 2. Change your working directory to "SimpleWeather.Web" you can find in repository,
 3. To restore NuGet packages use "dotnet restore".
 4. To build the solution use "dotnet build".
 5. The last thing you need is to run the application using "dotnet run".
