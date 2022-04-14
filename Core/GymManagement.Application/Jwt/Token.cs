using System;

namespace GymManagement.Application.Jwt
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
