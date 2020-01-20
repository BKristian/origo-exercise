using System.Collections.Generic;

// If there were more models necessary I would consider splitting this into multiple files

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
