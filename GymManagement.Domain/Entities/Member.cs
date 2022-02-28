namespace GymManagement.Domain.Entities
{
    public class Member:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public double Dept { get; set; }
        public bool IsPaymentStatus { get; set; }
        public ExerciseProgram exerciseProgram { get; set; }
        public int CampaignId { get; set; }
       
        //public int MyProperty { get; set; }

    }
}
