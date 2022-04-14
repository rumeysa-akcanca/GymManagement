using AutoMapper;
using GymManagement.Application.ViewModels.MemberViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Mapping
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<Member, MemberRegisterViewModel>().ReverseMap();
            CreateMap<Member, MemberLoginViewModel>().ReverseMap();
        }
    }
}
