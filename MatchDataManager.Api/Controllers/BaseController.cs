using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T>: ControllerBase, IController<T> where T : class, new()
    {

    }
}
