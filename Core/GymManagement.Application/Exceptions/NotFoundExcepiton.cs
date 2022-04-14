using System;

namespace GymManagement.Application.Exceptions
{
    public class NotFoundExcepiton : Exception
    {
        public NotFoundExcepiton(string name, object key = null)
            :base($"Entity {name} {key} was not found.")
        {
        }
    }
}
