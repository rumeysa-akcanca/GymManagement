using System.Collections.Generic;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IManagerRepository : IRepositoryBase<Manager>
    {
        bool AddMissionToTrainer(int missionId, int trainerId);

        List<Member> GetAllMembers();
    }
}