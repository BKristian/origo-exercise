using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

class Program
{
	public static void Main(string[] args)
	{
		var argsExist = args.Length > 0;
		if (argsExist && args[0] == "-rest")
            CreateHostBuilder().Build().Run();
		else
			Console.WriteLine(new ConsoleOutputMaker().MakeConsoleOutput(argsExist ? args[0] : ""));
	}

	public static IHostBuilder CreateHostBuilder() =>
	Host.CreateDefaultBuilder()
		 .ConfigureWebHostDefaults(webBuilder =>
		 {
			 webBuilder.UseStartup<Startup>();
		 });
}
