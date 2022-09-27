using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers
{
    public interface IController<T>
    {
        IActionResult GetAllData();
        public IActionResult GetDataById(Guid id);

        IActionResult Add(T data);
        IActionResult Update(T data);
        IActionResult Delete(T data);
    }
}
