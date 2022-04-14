using System.Threading.Tasks;
using GymManagement.Application.Jwt;
using GymManagement.Application.ViewModels.MemberViewModel;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IMemberService
    {
        bool Register(MemberRegisterViewModel registerViewModel);
        bool Login(MemberLoginViewModel loginViewModel);
    }
}
