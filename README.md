# SimpleWeather web
Blazor Webassembly application for fetching current weather in chosen city using OpenWeatherMap API. App also uses SASS CSS-compiler.  
IMPORTANT UPDATE: Unfortunately this was illegal so you won't see the second task on the same technology stack :(
## Deployment tutorial
To compile application on your device you should download .NET Core 3.0 SDK from [dot.net](https://dot.net). Any IDE is not required since you can compile and run applications via command line.  
For the best experience you can work with solution in Visual Studio on Windows or Mac. Make sure you use 16.3 version or higher on Windows and 8.3 version or higher on Mac since older versions don't support .NET Core 3.0.  
SASS compilation of "Styles/site.scss" can be done via Visual Studio Web Compiler extension. This extension generates appropriate CSS-file and its minified version.  
Another way is to download [Dart Sass](https://github.com/sass/dart-sass/releases/tag/1.23.0) for your OS and put it in the SimpleWeather.Web folder. Then you must run "sass Styles/site.scss wwwroot/css/site.css" If you use this approach you must include neccessary using for generated file in wwwroot/index.html since Dart Sass doesn't create minified version.
### CLI commands
 1. Verify whether the CLI is installed properly using "dotnet --list-sdks".
 2. Change your working directory to "SimpleWeather.Web" you can find in repository,
 3. To restore NuGet packages use "dotnet restore".
 4. To build the solution use "dotnet build".
 5. The last thing you need is to run the application using "dotnet run".
