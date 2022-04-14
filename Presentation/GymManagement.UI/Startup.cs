using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazored.LocalStorage;
using GymManagement.Application.DependencyContainers;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Services;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using GymManagement.Infrastructure.DependencyContainers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace GymManagement.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddScoped<IMemberService, MemberService>();

            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme
            ).AddCookie(x =>
                {
                    x.LoginPath = "/Admin/Login";
                }

            );


            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IExerciseProgramService, ExerciseProgramService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IMissionService, MissionService>();

            services.AddBlazoredLocalStorage();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
