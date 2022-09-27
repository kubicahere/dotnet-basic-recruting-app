using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

public class LocationsController : BaseController<Location>
{
    public LocationsController(IRepository<Location> repository) : base(repository)
    {

    }
}