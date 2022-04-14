using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.MemberViewModel;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMemberService _memberService;


        public AuthenticateController(IAuthService authService, IMemberService memberService)
        {
            _authService = authService;
            _memberService = memberService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] MemberLoginViewModel model)
        { 
            var token =  await _authService.Login(model);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] MemberRegisterViewModel model)
        {
            await _authService.Register(model);
            return Ok("Kayıt başarılı");
        }

        [HttpPost("mvcmemberlogin")]
        public  IActionResult MemberPasswordControl([FromBody] MemberLoginViewModel model)
        {
            var result =  _memberService.Login(model);
            if (result)
            {
                return Ok("Tebrikler girdiniz");
            }

            return BadRequest("Seneye görüşürüz");
        }

        [HttpPost("mvcmemberRegister")]
        public IActionResult MemberPasswordControl([FromBody] MemberRegisterViewModel model)
        {
            var result = _memberService.Register(model);
            if (result)
            {
                return Ok("Tebrikler girdiniz");
            }

            return BadRequest("Seneye görüşürüz");
        }

    }
}
