using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IEmployeeDetailService
    {
        EmployeeDetail GetById(int id);
        bool Create(EmployeeDetail model);
        bool Update(EmployeeDetail model, int id);
        bool Delete(int id);
    }
}
