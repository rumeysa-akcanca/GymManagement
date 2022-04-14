using Microsoft.AspNetCore.Mvc;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.EquipmentViewModel;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        [HttpGet]
        public IActionResult GetEquipmentsWithTrainer()
        {
            var result = _equipmentService.GetEquipmentsWithTrainer();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EquipmentCommandViewModel model)
        {
            var result = _equipmentService.Create(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Update([FromBody] EquipmentCommandViewModel model, int id)
        {
            var result = _equipmentService.Update(model, id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var result = _equipmentService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
