using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;

static class Repository
{
	private static readonly HttpClient _client = new HttpClient();

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
		throw new HttpRequestException($"Network error. {(int)response.StatusCode}: {response.ReasonPhrase}");
	}
}
