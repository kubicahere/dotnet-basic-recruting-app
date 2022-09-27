using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T>: ControllerBase, IController<T> where T : class, new()
    {
        protected readonly IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public virtual IActionResult Add(T figure)
        {
            if (figure is null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.Add(figure))
            {
                ModelState.AddModelError("", "Save error occured!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete]
        public virtual IActionResult Delete(T figure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.Delete(figure))
            {
                ModelState.AddModelError("", "Delete error occured!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
        [HttpGet]
        public virtual IActionResult GetAllData()
        {
            var locations = _repository.GetAllData();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(locations);
        }

        [HttpGet("{id:guid}")]
        public virtual IActionResult GetDataById(Guid id)
        {
            var location = _repository.GetDataById(id);
            if (location is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(location);
        }

        [HttpPut]
        public virtual IActionResult Update(T figure)
        {
            if (figure is null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.Update(figure))
            {
                ModelState.AddModelError("", "Update error ocurred!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }
    }
}
