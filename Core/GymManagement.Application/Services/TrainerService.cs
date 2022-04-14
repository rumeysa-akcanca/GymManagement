using System.Collections.Generic;
using GymManagement.Application.Extensions;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Interfaces.UnitOfWorks;
using GymManagement.Application.ViewModels.TrainerViewModel;

namespace GymManagement.Application.Services
{
    public class TrainerService :ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail()
        {
            var result = _unitOfWork.Trainers.GetTrainersWithEmployeeDetail();
            return result;
        }

        public bool EquipmentMaintenanceControl(int equipmentId)
        {
            var equipment = _unitOfWork.Equipments.GetById(equipmentId);

            equipment.IfIsNullThrowNotFoundException("Equipment", equipmentId);

            equipment.IsActive = false;
            _unitOfWork.Equipments.Update(equipment);

            return _unitOfWork.SaveChanges();
        }
    }
}
