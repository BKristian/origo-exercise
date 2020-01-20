using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("")]
public class StationInformationController : ControllerBase
{
	Repository _repo;

	public StationInformationController()
	{
		_repo = new Repository();
	}

	[HttpGet("information")]
	public ActionResult<List<StationInformation>> ListStationInformations()
	{
		return _repo.GetStationInformations().ToList();
	}

	[HttpGet("status")]
	public ActionResult<List<StationStatus>> ListStationStatus()
	{
		return _repo.GetStationStatuses().ToList();
	}

	[HttpGet("information/{id}")]
	public ActionResult<StationInformation> GetStationInformationById(string id)
	{
		var station = _repo.GetStationInformationById(id);
		if (station == null) return NotFound();
		return station;
	}

	[HttpGet("status/{id}")]
	public ActionResult<StationStatus> GetStationStatusById(string id)
	{
		var station = _repo.GetStationStatusById(id);
		if (station == null) return NotFound();
		return station;
	}

	[HttpGet("information/search/{search}")]
	public ActionResult<List<StationInformation>> SearchStationInformation(string search)
	{
		var stations = _repo.GetStationInformations()
			.Where(x => x.name.ToLower().Contains(search.ToLower()));
		if (stations == null) return NotFound();
		return stations.ToList();
	}
}
