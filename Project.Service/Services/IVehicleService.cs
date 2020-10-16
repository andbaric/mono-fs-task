using Microsoft.AspNetCore.Mvc;
using Project.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public interface IVehicleService
    {
        Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakes();
        Task<ActionResult<VehicleMake>> GetVehicleMake(int id);
        Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake newVehicleMake);
        Task<ActionResult<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updatedVehicleMake);
        Task<ActionResult<VehicleMake>> DeleteVehicleMake(int id);

        Task<ActionResult<IEnumerable<VehicleMake>>> SortVehicleMakes(string sortBy);
        Task<ActionResult<VehicleMake>> FilterVehicleMake(string filterBy);
        Task<ActionResult<VehicleMake>> PaginateVehicleMake(int pageNum);


        Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels();
        Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel newVehicleModel);
        Task<ActionResult<VehicleModel>> GetVehicleModel(int id);
        Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, VehicleModel updatedVehicleModel);
        Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id);

        Task<ActionResult<IEnumerable<VehicleMake>>> SortVehicleModels(string sortBy);
        Task<ActionResult<VehicleMake>> FilterVehicleModels(string filterBy);
        Task<ActionResult<VehicleMake>> PaginateVehicleModels(int pageNum);
    }
}
