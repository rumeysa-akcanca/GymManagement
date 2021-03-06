using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IWorkerContractService
    {
        List<WorkerContract> GetAll();
        WorkerContract GetById(int id);
        bool Create(WorkerContract model);
        bool Update(WorkerContract model, int id);
        bool Delete(int id);
    }
}
