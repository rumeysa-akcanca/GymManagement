using System;

namespace GymManagement.Domain.Entities
{
    public class Equipment:BaseEntity
    {
        public string Name { get; set; }
        public DateTime MaintenancePeriod { get; set; }//bakım periyotu 6 aylık
        public byte  Duration { get; set; }//bakım geçerlilik süresi ay süresi
        public bool IsActive { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
