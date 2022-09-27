using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

public class TeamsController : BaseController<Team>
{
    TeamsController(IRepository<Team> repository) : base(repository)
    {

    }
}