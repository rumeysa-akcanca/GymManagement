using System.Linq;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Domain.Entities;
using GymManagement.Infrastructure.Contexts;

namespace GymManagement.Infrastructure.Repositories
{
    public class MemberRepository :IMemberRepository
    {
        private readonly GymManagementDbContext _context;

        public MemberRepository(GymManagementDbContext context)
        {
            _context = context;
        }

        public Member GetById(string memberId)
        {
            return _context.Members.SingleOrDefault(x => x.Id == memberId);
        }

        public Member FindByEmail(string email)
        {
            return _context.Members.SingleOrDefault(m => m.Email == email);
        }

        public bool CreateMember(Member member)
        {
            _context.Members.Add(member);
            return _context.SaveChanges() > 0;
        }
    }
}
