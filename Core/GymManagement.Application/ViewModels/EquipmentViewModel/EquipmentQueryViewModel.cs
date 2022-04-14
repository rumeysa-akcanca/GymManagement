using System;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.ViewModels.EquipmentViewModel
{
    public class EquipmentQueryViewModel
    {
        public string Name { get; set; }
        public DateTime MaintenancePeriod { get; set; }
        public bool IsActive { get; set; }
        public string TrainerName { get; set; }
    }
}
