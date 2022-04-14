using GymManagement.Domain.Entities;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        Member GetById(string memberId);
        Member FindByEmail(string email);
        bool CreateMember(Member member);
    }
}

