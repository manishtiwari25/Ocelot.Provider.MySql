English | [Release Notes](ReleaseNotes.md)
# Ocelot.Provider.SqlServer
Repo for store configuration in Microsoft SqlServer with [Ocelot](http://threemammals.com/ocelot)
# Ocelot

[<img src="http://threemammals.com/images/ocelot_logo.png">](http://threemammals.com/ocelot)

[![Build status](https://ci.appveyor.com/api/projects/status/jmkqqg6i24dx1crc?svg=true)](https://ci.appveyor.com/project/TomPallister/ocelot-provider-consul)
Windows (AppVeyor)
[![Build Status](https://travis-ci.org/ThreeMammals/Ocelot.Provider.Consul.svg?branch=develop)](https://travis-ci.org/ThreeMammals/Ocelot.Provider.Consul) Linux & OSX (Travis)



This package adds Microsoft SQL Server support to Ocelot configuration.

## How to install

Install Ocelot.Provider.MySql and it's dependencies using NuGet. 

`Install-Package Ocelot.Provider.MySql`

Or via the .NET Core CLI:

`dotnet add package Ocelot.Provider.MySql`

All versions can be found [here](https://www.nuget.org/packages/Ocelot.Provider.MySql/)

## How to Run
- Lunch Project OcelotApiGw
- Edit ConnectionString
- open Package manager console
- Update-Database -verbose

# Thanks
Get some ideas from [Ocelot.Provider.Consul](https://github.com/ThreeMammals/Ocelot.Provider.Consul)

## Special Thanks To @niyw for (https://github.com/niyw/Ocelot.Provider.SqlServer)
