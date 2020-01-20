using System.Linq;
using System.Collections.Generic;

public class Repository
{
	private NetworkRetriever _retriever;

	public Repository()
	{
		_retriever = new NetworkRetriever();
	}

	public IEnumerable<StationInformation> GetStationInformations()
	{
		return _retriever
			.GetFromApi<OrigoResponse<StationInformation>>(Constants.INFORMATION_URL).data.stations;
	}

	public IEnumerable<StationStatus> GetStationStatuses()
	{
		return _retriever
			.GetFromApi<OrigoResponse<StationStatus>>(Constants.STATUS_URL).data.stations;
	}

	public StationInformation GetStationInformationById(string id)
	{
		return GetStationInformations().Where(x => x.station_id == id).FirstOrDefault();
	}

	public StationStatus GetStationStatusById(string id)
	{
		return GetStationStatuses().Where(x => x.station_id == id).FirstOrDefault();
	}
}
