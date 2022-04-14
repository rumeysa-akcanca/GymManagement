using AutoMapper;
using GymManagement.Application.ViewModels.MissionViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Mapping
{
    public class MissionMappingProfile  :Profile
    {
        public MissionMappingProfile()
        {
            CreateMap<Mission, MissionQueryViewModel>().ReverseMap();
            CreateMap<Mission, MissionCommandViewModel>().ReverseMap();

        }
    }
}
