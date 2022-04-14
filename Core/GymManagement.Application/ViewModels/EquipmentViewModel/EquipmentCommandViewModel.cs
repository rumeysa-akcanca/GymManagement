
namespace GymManagement.Application.ViewModels.EquipmentViewModel
{
    public class EquipmentCommandViewModel
    {
        public string Name { get; set; }
        public byte Duration { get; set; }
        public bool IsActive { get; set; }
        public int TrainerId { get; set; }
    }
}
