using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.ExerciseProgramViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ExerciseProgramController : ControllerBase
    {
        private readonly IExerciseProgramService _exerciseProgramService;

        public ExerciseProgramController(IExerciseProgramService exerciseProgramService)
        {
            _exerciseProgramService = exerciseProgramService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_exerciseProgramService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExerciseProgramCommandViewModel model)
        {

            if (_exerciseProgramService.Create(model))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ExerciseProgramCommandViewModel model, int id)
        {
            return _exerciseProgramService.Update(model, id) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _exerciseProgramService.Delete(id) ? Ok() : BadRequest();
    }
}
