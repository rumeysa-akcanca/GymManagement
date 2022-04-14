using AutoMapper;
using GymManagement.Application.ViewModels.EquipmentViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Mapping
{
    public class EquipmentMappingProfile : Profile
    {
        public EquipmentMappingProfile()
        {
            CreateMap<Equipment, EquipmentQueryViewModel>().ReverseMap();
        }
    }
}
