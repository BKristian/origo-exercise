using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System;

class Program
{
	private static readonly HttpClient _client = new HttpClient();

	static void Main(string[] args)
	{
		var output = string.Empty;
		try {
		output = MakeConsoleOutput(args.Length > 0 ? args[0].ToLower() : "");
		} catch (Exception e) {
			output = e.Message;
		}
		Console.WriteLine(output);
	}

	public static string MakeConsoleOutput(string filter)
	{
		var info = GetStationInformation().OrderBy(x => x.name).Where(x => x.name.ToLower().Contains(filter));
		var status = GetStationStatus().ToDictionary(x => x.station_id);
		var res = string.Concat(info
			.Select(x => $"\n{x.name}\n\tLedige parkeringer: {status[x.station_id].num_docks_available}\t Ledige sykler: {status[x.station_id].num_bikes_available}\n"));
		return res;
	}

	public static IEnumerable<StationInformation> GetStationInformation()
	{
		return GetFromApi<OrigoResponse<StationInformation>>("station_information.json").data.stations;
	}

	public static IEnumerable<StationStatus> GetStationStatus()
	{
		return GetFromApi<OrigoResponse<StationStatus>>("station_status.json").data.stations;
	}

	private static T GetFromApi<T>(string url)
	{
		var raw = SendRequest(url).Result;
		var deserialized = JsonSerializer.Deserialize<T>(raw);
		return deserialized;
	}

	private async static Task<string> SendRequest(string tail)
	{
		var request = new HttpRequestMessage
		{
			RequestUri = new Uri($"https://gbfs.urbansharing.com/oslobysykkel.no/{tail}"),
			Method = HttpMethod.Get,
			Headers = { { "Client-Identifier", "OsloOrigoOppgave" } }
		};
		var response = await _client.SendAsync(request);
		if (response.IsSuccessStatusCode) return response.Content.ReadAsStringAsync().Result;
		// TODO: Handle failure better.
		throw new HttpRequestException($"Network error. {(int)response.StatusCode}: {response.ReasonPhrase}");
	}
}

public class StationInformation
{
	public string station_id { get; set; }
	public string name { get; set; }
	public string address { get; set; }
	public double lat { get; set; }
	public double lon { get; set; }
	public int capacity { get; set; }
}

public class StationStatus
{
	public string station_id { get; set; }
	public int is_installed { get; set; }
	public int is_renting { get; set; }
	public int is_returning { get; set; }
	public int last_reported { get; set; }
	public int num_bikes_available { get; set; }
	public int num_docks_available { get; set; }
}

public class Data<T>
{
	public IEnumerable<T> stations { get; set; }
}

public class OrigoResponse<T>
{
	public int last_updated { get; set; }
	public int ttl { get; set; }
	public Data<T> data { get; set; }
}
