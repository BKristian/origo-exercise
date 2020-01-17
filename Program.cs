using System.Linq;
using System;

class Program
{
	static void Main(string[] args)
	{
		var output = string.Empty;
		try
		{
			output = MakeConsoleOutput(args.Length > 0 ? args[0].ToLower() : "");
		}
		catch (Exception e)
		{
			output = e.Message;
		}
		Console.WriteLine(output);
	}

	public static string MakeConsoleOutput(string filter)
	{
		var info = Repository.GetStationInformation().OrderBy(x => x.name).Where(x => x.name.ToLower().Contains(filter));
		var status = Repository.GetStationStatus().ToDictionary(x => x.station_id);
		var res = string.Concat(info
			.Select(x => $"\n{x.name}\n\tLedige parkeringer: {status[x.station_id].num_docks_available}\t Ledige sykler: {status[x.station_id].num_bikes_available}\n"));
		return res;
	}
}
