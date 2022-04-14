using System.Collections.Generic;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
    }
}
