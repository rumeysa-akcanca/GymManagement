using GymManagement.Application.Exceptions;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Extensions
{
    public static class IsNullExtensions
    {
        public static void IfIsNullThrowNotFoundException(this BaseEntity entity,string name,object key = null)
        {
            if (entity is null)
            {
                throw new NotFoundExcepiton(name, key);
            }
        }

    }
}
