using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.MemberViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;


namespace GymManagement.UI.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
            
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
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
