using AutoMapper;
using Project.MVC.Models.Administration.VehicleModel;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;

namespace Project.MVC.Models.MapperProfiles
{
    public class VehicleModelsProfiles : Profile
    {
        public VehicleModelsProfiles()
        {
            CreateMap<ReadMakesDto, CreateModelViewModel>();
        }
    }
}
