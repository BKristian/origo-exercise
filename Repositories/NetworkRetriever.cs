using System.Net.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

class NetworkRetriever : INetworkRetriever
{
	private HttpClient _client;

	public NetworkRetriever()
	{
		_client = new HttpClient();
	}

	public T GetFromApi<T>(string url)
	{
		var raw = SendRequest(url).Result;
		var deserialized = JsonSerializer.Deserialize<T>(raw);
		return deserialized;
	}

	private async Task<string> SendRequest(string tail)
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
