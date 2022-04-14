using Microsoft.EntityFrameworkCore;
using GymManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Contexts
{
    public class GymManagementDbContext : IdentityDbContext<Member>
    {
        public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) 
            :base(options)
        {
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ExerciseProgram> ExercisePrograms { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<WorkerContract> WorkerContracts { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
