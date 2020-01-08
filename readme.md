# Exercise from Oslo Origo

This console application takes one argument, which is used to filter the stations by checking if the station name contains the input (e.g. `dotnet run våls` returns Ullevålsalléen and Ullevålsveien). If left blank, it returns all.

## Build and run
Install .NET Core from https://dotnet.microsoft.com/download

Navigate to the folder in your terminal

To build, enter `dotnet build`. To build and run, enter `dotnet run`.

I haven't tested on Linux, but you might need to specify your runtime, e.g. `dotnet build --runtime ubuntu.19.04-x64` or `dotnet build --runtime linux-x64`
