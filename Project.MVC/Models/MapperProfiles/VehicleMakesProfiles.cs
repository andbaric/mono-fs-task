using AutoMapper;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;

namespace Project.MVC.Models.MapperProfiles
{
    public class VehicleMakesProfiles : Profile
    {
        public VehicleMakesProfiles()
        {
            CreateMap<ReadMakeDto, UpdateMakeDto>();
        }
    }
}
