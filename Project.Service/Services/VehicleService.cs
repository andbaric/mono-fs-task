
using Project.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Project.Service.Utils.Paging;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _context;
        public VehicleService(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake newVehicleMake)
        {
            _context.VehicleMakes.Add(newVehicleMake);
            await _context.SaveChangesAsync();

            return newVehicleMake;
        }

        public async Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel newVehicleModel)
        {
            _context.VehicleModels.Add(newVehicleModel);
            await _context.SaveChangesAsync();

            return newVehicleModel;
        }

        public async Task<ActionResult<VehicleMake>> DeleteVehicleMake(int id)
        {
            var targetMake = (await GetVehicleMake(id)).Value;

            if (targetMake != null)
            {
                _context.VehicleMakes.Remove(targetMake);
                await _context.SaveChangesAsync();
            }

            return targetMake;
        }

        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id)
        {
            var targetModel = (await GetVehicleModel(id)).Value;

            if (targetModel != null)
            {
                _context.VehicleModels.Remove(targetModel);
                await _context.SaveChangesAsync();
            }
            
            return targetModel;
        }

        public async Task<ActionResult<VehicleMake>> GetVehicleMake(int id)
        {
            var query = _context.VehicleMakes.AsQueryable();

            try
            {
                return await query.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakes()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            var query = _context.VehicleModels.AsQueryable();

            try
            {
                return await query.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<PagedList<VehicleMake>>> GetVehicleMakes(PaginationParameters makesPaginationPatameters)
        {
            var vehicleMakes = await _context.VehicleMakes.ToListAsync();
            var vehicleMakesQuery = vehicleMakes.AsQueryable();

            if (!string.IsNullOrEmpty(makesPaginationPatameters.Name))
            {
                var namesForFilter = makesPaginationPatameters.Name.Trim().ToLower();
                vehicleMakesQuery = vehicleMakesQuery.Where(n => n.Name.ToLower() == namesForFilter);
            }

            return PagedList<VehicleMake>.Create(
                                            vehicleMakesQuery,
                                            makesPaginationPatameters.PageSize,
                                            makesPaginationPatameters.PageNumber
                                            );
        }

        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            return await _context.VehicleModels.ToListAsync();
        }


        public async Task<ActionResult<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updatedVehicleMake)
        {
            var existingMake = (await GetVehicleMake(id)).Value;
            _context.Entry(existingMake).CurrentValues.SetValues(updatedVehicleMake);
            await _context.SaveChangesAsync();

            return existingMake;
        }

        public async Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, VehicleModel updatedVehicleModel)
        {
            var existingModel = (await GetVehicleModel(id)).Value;
            _context.Entry(existingModel).CurrentValues.SetValues(updatedVehicleModel);
            await _context.SaveChangesAsync();

            return existingModel;
        }

        public async Task<ActionResult<PagedList<VehicleModel>>> GetVehicleModels(PaginationParameters modelsPaginationPatameters)
        {
            var vehicleModels = await _context.VehicleModels.ToListAsync();
            var vehicleModelsQuery = vehicleModels.AsQueryable();

            if (!string.IsNullOrEmpty(modelsPaginationPatameters.Name))
            {
                var namesForFilter = modelsPaginationPatameters.Name.Trim().ToLower();
                vehicleModelsQuery = vehicleModelsQuery.Where(n => n.Name.ToLower() == namesForFilter);
            }

            return PagedList<VehicleModel>.Create(
                                            vehicleModelsQuery, 
                                            modelsPaginationPatameters.PageSize, 
                                            modelsPaginationPatameters.PageNumber
                                            );
        }
    }
}
