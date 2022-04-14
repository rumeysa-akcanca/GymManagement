using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace GymManagement.Infrastructure.Repositories
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        private readonly GymManagementDbContext _context;
        public EquipmentRepository(GymManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer()
        {
            var result = _context.Equipments.Select( equipment=> 
                new EquipmentQueryViewModel {
                    TrainerName = equipment.Trainer.EmployeeDetail.FirstName+" "+equipment.Trainer.EmployeeDetail.LastName,
                    Name = equipment.Name,
                    IsActive = equipment.IsActive,
                    MaintenancePeriod = equipment.MaintenancePeriod

                });

            return result.OrderByDescending(x => x.MaintenancePeriod).ToList();
        }
    }
}