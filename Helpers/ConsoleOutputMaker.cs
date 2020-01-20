using System.Linq;
using System;
public class ConsoleOutputMaker
{
	public string MakeConsoleOutput(string search = "")
	{
		var output = string.Empty;
		try
		{
			output = MakeBikeStationString(search.ToLower());
		}
		catch (Exception e)
		{
			output = e.Message;
		}
		return output;
	}

	private string MakeBikeStationString(string filter)
	{
		var _repo = new Repository();
		var info = _repo.GetStationInformations().OrderBy(x => x.name).Where(x => x.name.ToLower().Contains(filter));
		var status = _repo.GetStationStatuses().ToDictionary(x => x.station_id);
		var res = string.Concat(info
			.Select(x => $"\n{x.name}\n\tLedige parkeringer: {status[x.station_id].num_docks_available}\tLedige sykler: {status[x.station_id].num_bikes_available}\n"));
		return res;
	}
}
