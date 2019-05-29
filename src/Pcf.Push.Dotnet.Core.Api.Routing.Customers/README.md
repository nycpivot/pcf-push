# PCF PUSH


## Context Path Routing

This project is meant to be deployed with [Pcf.Push.Dotnet.Core.Api.Routing.Products](https://github.com/nyc-pivot/pcf-push-dotnet-src/tree/master/Pcf.Push.Dotnet.Core.Api.Routing.Products).

For an explanation of context path routing, click [here](https://www.cloudfoundry.org/blog/context-path-routing/).

### ASP.NET Core 2.2 (Windows & Linux)
	Pcf.Push.Dotnet.Core.Empty
	Pcf.Push.Dotnet.Core.Mvc.Linux
	Pcf.Push.Dotnet.Core.Mvc.Windows

### ASP.NET Framework 4.7 (Windows)
	Pcf.Push.Dotnet.Framework.Mvc.Windows
	Pcf.Push.Dotnet.Framework.WebForms.Windows

### Context Path Routing (Linux)
	Pcf.Push.Dotnet.Core.Api.Routing.Customers
	Pcf.Push.Dotnet.Core.Api.Routing.Products

### Background Process
	Pcf.Push.Dotnet.Core.Task

### Docker containers
	Pcf.Push.Dotnet.Core.Mvvm.Docker.Linux
	Pcf.Push.Dotnet.Core.Mvvm.Docker.Windows


## Instructions
1. Unzip the files to any location.
1. Navigate to the publish folder.

	.NET Core
	```
	bin\Release\netcoreapp2.2\publish
	```
	
	.NET Framework
	```
	bin\Release\publish
	```

1. Open a command prompt.
1. Execute `cf push`.


## Source code
	
https://github.com/nyc-pivot/pcf-push-dotnet-src
