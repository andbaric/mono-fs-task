using Microsoft.AspNetCore.Mvc;
using Project.Service.Models.DTOs.VehicleAdministration;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using Project.Service.Utils.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public interface IVehicleAdministrationService
    {
        Task<ActionResult<CreateMakeDto>> CreateVehicleMake(CreateMakeDto newVehicleMake);
        Task<ActionResult<ReadMakeDto>> ReadVehicleMake(int makeId);
        Task<ActionResult<IEnumerable<ReadMakesDto>>> ReadVehicleMakes();
        Task<ActionResult<PagedList<ReadMakesDto>>> ReadVehicleMakes(PaginationParameters makesPaginationPatameters);
        Task<ActionResult<ReadMakeDto>> UpdateVehicleMake(int makeId, UpdateMakeDto updatedMake);
        Task<ActionResult<ReadMakeDto>> DeleteVehicleMake(int makeId);

        Task<ActionResult<CreateModelDto>> CreateVehicleModel(CreateModelDto newVehicleModel);
        Task<ActionResult<ReadModelDto>> ReadVehicleModel(int modelId);
        Task<ActionResult<IEnumerable<ReadModelsDto>>> ReadVehicleModels();
        Task<ActionResult<PagedList<ReadModelsDto>>> ReadVehicleModels(PaginationParameters modelsPaginationPatameters);
        Task<ActionResult<ReadModelDto>> UpdateVehicleModel(int modelId, UpdateModelDto updatedVehicleModel);
        Task<ActionResult<ReadModelDto>> DeleteVehicleModel(int modelId);


        Task<ActionResult<IEnumerable<ReadVehiclesDto>>> ReadVehicles();
    }
}
