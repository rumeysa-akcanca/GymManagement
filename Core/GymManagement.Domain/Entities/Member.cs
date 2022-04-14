using Microsoft.AspNetCore.Identity;

namespace GymManagement.Domain.Entities
{
    public class Member : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Debt { get; set; }
        public bool IsPaymentStatus { get; set; }
        public int? ExerciseProgramId { get; set; }
        public int? CampaignId { get; set; }
        public byte[] PasswordSaltMvc { get; set; }
        public byte[] PasswordHashtMvc { get; set; }
    }
}
