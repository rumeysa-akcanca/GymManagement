
using System.Collections.Generic;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ITrainerService
    {
        List<TrainerQueryViewModel> GetTrainersWithEmployeeDetail();
        //bool AddMemberExerciseProgram(string memberId);
        bool EquipmentMaintenanceControl(int equipmentId);
    }
}


