
using Project.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _context;
        public VehicleService(VehicleDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake newVehicleMake)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel newVehicleModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> DeleteVehicleMake(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> FilterVehicleMake(string filterBy)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> FilterVehicleModels(string filterBy)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> GetVehicleMake(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakes()
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> PaginateVehicleMake(int pageNum)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> PaginateVehicleModels(int pageNum)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<VehicleMake>>> SortVehicleMakes(string sortBy)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<VehicleMake>>> SortVehicleModels(string sortBy)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updatedVehicleMake)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, VehicleModel updatedVehicleModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
