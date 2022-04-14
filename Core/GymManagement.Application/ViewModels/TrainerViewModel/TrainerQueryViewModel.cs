using System;

namespace GymManagement.Application.ViewModels.TrainerViewModel
{
    public class TrainerQueryViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool WorkerContractIsActive { get; set; }
    }
}
