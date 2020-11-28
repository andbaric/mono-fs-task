using Microsoft.AspNetCore.Mvc;
using Project.Service.Models.DTOs.VehicleAdministration;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using Project.Service.Models.Entities;
using Project.Service.Utils.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public interface IVehicleAdministrationService
    {
        Task<ActionResult<CreateMakeDto>> CreateVehicleMake(CreateMakeDto newVehicleMake);
        Task<ActionResult<ReadMakeDto>> ReadVehicleMake(int makeId);
        Task<ActionResult<IEnumerable<ReadOnlyMakesDto>>> ReadOnlyVehicleMakes();
        Task<ActionResult<IEnumerable<ReadMakesDto>>> ReadVehicleMakes();
        Task<ActionResult<PagedList<ReadMakesDto>>> ReadVehicleMakes(PaginationParameters makesPaginationPatameters);
        Task<ActionResult<UpdateMakeDto>> UpdateVehicleMake(UpdateMakeDto updatedMake);
        Task<ActionResult<DeleteMakeDto>> DeleteVehicleMake(int id);
        Task<ActionResult<Dictionary<int, string>>> GetAvailableMakes();

        Task<ActionResult<CreateModelDto>> CreateVehicleModel(CreateModelDto newVehicleModel);
        Task<ActionResult<ReadModelDto>> ReadVehicleModel(int modelId);
        Task<ActionResult<IEnumerable<ReadOnlyModelsDto>>> ReadOnlyVehicleModels();
        Task<ActionResult<IEnumerable<ReadModelsDto>>> ReadVehicleModels();
        Task<ActionResult<PagedList<ReadModelsDto>>> ReadVehicleModels(PaginationParameters modelsPaginationPatameters);
        Task<ActionResult<ReadModelDto>> UpdateVehicleModel(UpdateModelDto updatedVehicleModel);
        Task<ActionResult<ReadModelDto>> DeleteVehicleModel(int modelId);


        Task<ActionResult<IEnumerable<ReadOnlyVehiclesDto>>> ReadVehicles();
    }
}
