using AutoMapper;
using Project.MVC.Models.Administration.VehicleMake;
using Project.Service.Models.Entities;

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
