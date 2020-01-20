using Moq;
using System.Linq;
using NUnit.Framework;
using System.Text.Json;

[TestFixture]
public class Tests
{
	private readonly string stationStatusExerpt = "{\"last_updated\": 1579289952, \"ttl\": 10, \"data\": {\"stations\": [{\"station_id\": \"1755\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 33}, {\"station_id\": \"1101\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 24}, {\"station_id\": \"1023\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 12}, {\"station_id\": \"1009\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 10}, {\"station_id\": \"970\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 25}, {\"station_id\": \"787\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 12}, {\"station_id\": \"627\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 30}, {\"station_id\": \"623\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 21}, {\"station_id\": \"624\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 20}, {\"station_id\": \"626\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 23}, {\"station_id\": \"614\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 24}, {\"station_id\": \"616\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 15}, {\"station_id\": \"618\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 41}, {\"station_id\": \"621\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 27}, {\"station_id\": \"622\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 30}, {\"station_id\": \"613\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 27}, {\"station_id\": \"620\", \"is_installed\": 1, \"is_renting\": 1, \"is_returning\": 1, \"last_reported\": 1579289952, \"num_bikes_available\": 0, \"num_docks_available\": 40}]}}\n";
	private readonly string stationInformationExerpt = "{\"last_updated\": 1579290204, \"ttl\": 10, \"data\": {\"stations\": [{\"station_id\": \"1755\", \"name\": \"Aker Brygge\", \"address\": \"Aker Brygge\", \"lat\": 59.91118372188379, \"lon\": 10.730034556850455, \"capacity\": 33}, {\"station_id\": \"1101\", \"name\": \"Stortingstunellen\", \"address\": \"R\\u00e5dhusgata 34\", \"lat\": 59.91065301806209, \"lon\": 10.737365277561025, \"capacity\": 24}, {\"station_id\": \"1023\", \"name\": \"Professor Aschehougs plass\", \"address\": \"Professor Aschehougs plass\", \"lat\": 59.9147672, \"lon\": 10.740971, \"capacity\": 12}, {\"station_id\": \"1009\", \"name\": \"Borgenveien\", \"address\": \"Borgenveien\", \"lat\": 59.942742106473666, \"lon\": 10.703833031254021, \"capacity\": 10}, {\"station_id\": \"970\", \"name\": \"Enerhaugen\", \"address\": \"ved S\\u00f8rligata\", \"lat\": 59.91320242563816, \"lon\": 10.767579386407874, \"capacity\": 25}, {\"station_id\": \"787\", \"name\": \"Kirkegata 15\", \"address\": \"Kirkegata 15, Oslo\", \"lat\": 59.91015615055511, \"lon\": 10.743456971511705, \"capacity\": 12}, {\"station_id\": \"627\", \"name\": \"Sk\\u00f8yen Stasjon\", \"address\": \"Sk\\u00f8yen Stasjon\", \"lat\": 59.9226729, \"lon\": 10.6788129, \"capacity\": 30}, {\"station_id\": \"623\", \"name\": \"7 Juni Plassen\", \"address\": \"7 Juni Plassen\", \"lat\": 59.9150596, \"lon\": 10.7312715, \"capacity\": 21}, {\"station_id\": \"624\", \"name\": \"D\\u00e6lenenggata\", \"address\": \"D\\u00e6lenenggata ved Fagerheimgata\", \"lat\": 59.928716, \"lon\": 10.7675618, \"capacity\": 20}, {\"station_id\": \"626\", \"name\": \"Drammensveien\", \"address\": \"Drammensveien 119\", \"lat\": 59.9204038, \"lon\": 10.691147, \"capacity\": 24}, {\"station_id\": \"614\", \"name\": \"Sinsen T-bane\", \"address\": \"Sinsen t-bane\", \"lat\": 59.938808, \"lon\": 10.780445, \"capacity\": 24}, {\"station_id\": \"616\", \"name\": \"Salt\", \"address\": \"Salt ved Langkaia\", \"lat\": 59.9069066, \"lon\": 10.7466245, \"capacity\": 15}, {\"station_id\": \"618\", \"name\": \"Bak Niels Treschows hus s\\u00f8r\", \"address\": \"Bak Niels Treschows hus s\\u00f8r\", \"lat\": 59.9424323, \"lon\": 10.723903, \"capacity\": 42}, {\"station_id\": \"621\", \"name\": \"Torshovdalen \\u00f8st\", \"address\": \"Torshovdalen \\u00f8st\", \"lat\": 59.9328069, \"lon\": 10.7774484, \"capacity\": 27}, {\"station_id\": \"622\", \"name\": \"Pilestredet 63\", \"address\": \"Pilestredet 63\", \"lat\": 59.9238826, \"lon\": 10.7313627, \"capacity\": 30}, {\"station_id\": \"613\", \"name\": \"Schives gate\", \"address\": \"Schives gate\", \"lat\": 59.9208044, \"lon\": 10.7140544, \"capacity\": 27}, {\"station_id\": \"620\", \"name\": \"Bislettgata\", \"address\": \"Bislettgata\", \"lat\": 59.9238336, \"lon\": 10.7346377, \"capacity\": 40}]}}\n";
	private OrigoResponse<StationStatus> _stationStatus;
	private OrigoResponse<StationInformation> _stationInformation;
	// Mocking the retriever so we're not dependant on the internet for running tests
	private Mock<INetworkRetriever> _net;
	private Repository _repo;

	[SetUp]
	public void SetUp()
	{
		_repo = new Repository();
		_stationStatus = JsonSerializer
			.Deserialize<OrigoResponse<StationStatus>>(stationStatusExerpt);
		_stationInformation = JsonSerializer
			.Deserialize<OrigoResponse<StationInformation>>(stationInformationExerpt);
		_net = new Mock<INetworkRetriever>();
		_net.Setup(x => x.GetFromApi<OrigoResponse<StationInformation>>(Constants.INFORMATION_URL)).Returns(_stationInformation);
		_net.Setup(x => x.GetFromApi<OrigoResponse<StationStatus>>(Constants.STATUS_URL)).Returns(_stationStatus);
	}

	[Test]
	public void Get_Status_By_ID()
	{
		var id = "600";
		var status = _repo.GetStationStatusById(id);
		Assert.AreEqual(status.station_id, id);
	}

	[Test]
	public void Get_Single_Information()
	{
		var id = "600";
		var status = _repo.GetStationInformationById(id);
		Assert.AreEqual(status.station_id, id);
	}

	[Test]
	public void Bikes_Are_Printed_To_Console()
	{
		var res = new ConsoleOutputMaker().MakeConsoleOutput();
		Assert.IsTrue(res.Contains("Vålerenga\n\tLedige parkeringer: 21\tLedige sykler: 0"));
	}

	[Test]
	public void Station_Status_Serialization_Works()
	{
		var stationStatus = JsonSerializer
			.Deserialize<OrigoResponse<StationStatus>>(stationStatusExerpt).data.stations;
		Assert.IsTrue(stationStatus
			.All(x => !string.IsNullOrWhiteSpace(x.station_id)));
	}

	[Test]
	public void Station_Information_Serialization_Works()
	{
		var stationInformation = JsonSerializer
			.Deserialize<OrigoResponse<StationInformation>>(stationInformationExerpt).data.stations;
		Assert.IsTrue(stationInformation.All(x => !string.IsNullOrWhiteSpace(x.station_id)));
		Assert.IsTrue(stationInformation.All(x => !string.IsNullOrWhiteSpace(x.name)));
	}
}
