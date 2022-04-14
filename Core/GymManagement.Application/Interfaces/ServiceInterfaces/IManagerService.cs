using System.Collections.Generic;
using GymManagement.Application.ViewModels.TrainerViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IManagerService
    {
        bool CreateTrainer(TrainerCommandViewModel model);
        bool AddMissionToTrainer(int missionId, int trainerId);
        List<Member> GetAll();
    }
}
