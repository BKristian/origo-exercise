# Exercise from Oslo Origo

This console application takes one argument, which is used to filter the stations by checking if the station name contains the input (e.g. `dotnet run våls` returns Ullevålsalléen and Ullevålsveien). If left blank, it returns all.

## REST API
To start the API, just run `dotnet start -rest`. The program functions identically to the previous version if you don't use the `-rest` flag.

After the API has started, you can go to `https://localhost:5001/status` to see all statuses. `status/{id}` lets you see just a single status. The same applies to `/information` and `/information/{id}`. You can also search by name using `/search/{name}`. http is supported on port 5000. The ports are set in `./Properties/launchSettings.json`.

One thing I considered was an about-page that would contain links to these pages, but decided not to since it's outside the scope of the assignment. This is my first time making a REST API, so if you spot anything obvious that's wrong, please be a bit lenient.

## Build and run
Install .NET Core from https://dotnet.microsoft.com/download

Navigate to the folder in your terminal.

To build, enter `dotnet build`. To build and run, enter `dotnet run`.

I haven't tested on Linux, but you might need to specify your runtime, e.g. `dotnet build --runtime ubuntu.19.04-x64` or `dotnet build --runtime linux-x64`

## Dependencies
Running `dotnet restore` should add all the packages below. They're all used for the tests.

`dotnet add package Microsoft.NET.Test.Sdk`

`dotnet add package moq`

`dotnet add package nunit`

`dotnet add package NUnit3TestAdapter`
