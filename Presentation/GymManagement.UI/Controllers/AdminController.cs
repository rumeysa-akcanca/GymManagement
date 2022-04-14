using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.MemberViewModel;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly ITrainerService _trainerService;
        private readonly IMissionService _missionService;
        private readonly IEquipmentService _equipmentService;
        private readonly IMemberService _memberService;

        public AdminController( IManagerService managerService, ITrainerService trainerService, IMissionService missionService, IEquipmentService equipmentService, IMemberService memberService)
        {
            
            _managerService = managerService;
            _trainerService = trainerService;
            _missionService = missionService;
            _equipmentService = equipmentService;
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModel model)
        {
            if (_memberService.Login(model))
            {
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Email,model.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Dashboard");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
           var members =  _managerService.GetAll();

           if (members is null)
           {
               return NotFound();
           }

           return View(members);
        }
        public IActionResult Members()
        {
            var members = _managerService.GetAll();
            return View(members);
        }

        [Authorize]
        public IActionResult Trainers()
        {
            var trainers = _trainerService.GetTrainersWithEmployeeDetail();
            TrainerMissionViewModel model = new TrainerMissionViewModel();
            model.Trainers = _trainerService.GetTrainersWithEmployeeDetail();
            model.Missions = _missionService.GetAll().Take(11);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddTrainer(TrainerCommandViewModel model)
        {
            if (model is not null)
            {
                _managerService.CreateTrainer(model);
            }
            return View("Trainers");
        }

        [HttpGet]
        public IActionResult AddTrainer()
        {
            return View();
        }

        public IActionResult Billign()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Equipment()
        {
            var equipments = _equipmentService.GetEquipmentsWithTrainer();

            return View(equipments);
        }
    }
}
