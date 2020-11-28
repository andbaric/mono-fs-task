using AutoMapper;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using Project.Service.Models.Entities;

namespace Project.Service.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReadMakeDto, VehicleMake>();
            CreateMap<ReadMakesDto, VehicleMake>();
            CreateMap<CreateMakeDto, VehicleMake>();
            CreateMap<UpdateMakeDto, VehicleMake>();
            CreateMap<DeleteMakeDto, VehicleMake>();

            CreateMap<ReadMakeDto, UpdateMakeDto>();

            CreateMap<VehicleMake, UpdateMakeDto>();
            CreateMap<VehicleMake, ReadMakeDto>();
            CreateMap<VehicleMake, ReadMakesDto>();


            CreateMap<VehicleModel, ReadModelDto>();
            CreateMap<CreateModelDto, VehicleModel>();
        }
    }
}
