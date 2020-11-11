using AutoMapper;
using Project.MVC.Models.Administration.VehicleMake;
using Project.MVC.Models.Administration.VehicleModel;
using Project.Service.Models;

namespace Project.MVC.Models.MapperProfiles
{
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {
            CreateMap<VehicleMake, MakeTableDataViewModel>();
            CreateMap<VehicleMake, CreateMakeViewModel>();
        }
    }
}
