using Microsoft.AspNetCore.Identity;

namespace GymManagement.Application.Jwt
{
    public class RoleGenerator
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleGenerator(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public  void CreateRoles()
        {
            string[] roleNames = {"Admin", "Manager", "Trainer", "Member"};

            foreach (var role in roleNames)
            {
                var roleExist =  _roleManager.RoleExistsAsync(role);

                if (!roleExist.Result)
                {
                    _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
