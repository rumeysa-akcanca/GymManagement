using System.Collections.Generic;
using GymManagement.Application.ViewModels.EquipmentViewModel;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEquipmentService
    {
        public List<EquipmentQueryViewModel> GetEquipmentsWithTrainer();
        bool Create(EquipmentCommandViewModel model);
        bool Update(EquipmentCommandViewModel model, int id);
        bool Delete(int id);
    }
}

