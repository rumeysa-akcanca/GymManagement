using System;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.ViewModels.TrainerViewModel
{
    public class TrainerCommandViewModel
    {
        public EmployeeDetail EmployeeDetail { get; set; }
        public WorkerContract WorkerContract { get; set; }
    }
}
