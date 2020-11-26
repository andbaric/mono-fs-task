using Microsoft.AspNetCore.Mvc;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.Entities;
using Project.Service.Utils.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public interface IVehicleService
    {
        Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake newVehicleMake);
        Task<ActionResult<VehicleMake>>GetVehicleMake(int makeId);
        Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakes();
        Task<ActionResult<VehicleMake>> UpdateVehicleMake(int makeId, VehicleMake updatedMake);
        Task<ActionResult<VehicleMake>> DeleteVehicleMake(int makeId);

        Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel newVehicleModel);
        Task<ActionResult<VehicleModel>> GetVehicleModel(int modelId);
        Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels();
        Task<ActionResult<VehicleModel>> UpdateVehicleModel(int modelId, VehicleModel updatedVehicleModel);
        Task<ActionResult<VehicleModel>> DeleteVehicleModel(int modelId);
    }
}
