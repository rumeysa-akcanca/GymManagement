using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.CampaignViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _campaignService.GetAll();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok( _campaignService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CampaignCommandViewModel model)
        {
            var result = _campaignService.Create(model);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CampaignCommandViewModel model,int id)
        {
            var result = _campaignService.Update(model, id);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _campaignService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}


