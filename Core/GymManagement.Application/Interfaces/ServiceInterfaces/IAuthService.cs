using System.Threading.Tasks;
using GymManagement.Application.Jwt;
using GymManagement.Application.ViewModels.MemberViewModel;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<bool> Register(MemberRegisterViewModel registerViewModel);
        Task<Token> Login(MemberLoginViewModel loginViewModel);
    }
}
