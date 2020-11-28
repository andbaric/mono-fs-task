using Project.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Project.Service.Models.Entities;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.Mapper;
using System.Linq;

namespace Project.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _context;
        public VehicleService(VehicleDbContext context)
        {
            _context = context;
        }

        // Make
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake(VehicleMake newVehicleMake)
        {
            _context.VehicleMakes.Add(newVehicleMake);
            await _context.SaveChangesAsync();

            return newVehicleMake;
        }

        public async Task<ActionResult<VehicleMake>> GetVehicleMake(int makeId)
        {
            try
            {
                return await _context.VehicleMakes.Where(make => make.Id == makeId).SingleOrDefaultAsync();
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

        public async Task<ActionResult<VehicleMake>> UpdateVehicleMake(VehicleMake updatedMake)
        {
            var targetMake = await _context.VehicleMakes.Where(make => make.Id == updatedMake.Id).SingleAsync();
            
            if (targetMake != null)
            {
                _context.Entry(targetMake).CurrentValues.SetValues(updatedMake);
                await _context.SaveChangesAsync();
            }

            return updatedMake;
        }
        public async Task<ActionResult<VehicleMake>> DeleteVehicleMake(int makeId)
        {
            var targetMake = (await GetVehicleMake(makeId)).Value;

            if (targetMake != null)
            {
                _context.VehicleMakes.Remove(targetMake);
                await _context.SaveChangesAsync();
            }

            return targetMake;
        }

        // Model
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel(VehicleModel newVehicleModel)
        {
            _context.VehicleModels.Add(newVehicleModel);
            await _context.SaveChangesAsync();

            return newVehicleModel;
        }

        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int modelId)
        {
            var query = _context.VehicleModels.AsQueryable();

            try
            {
                return await query.SingleOrDefaultAsync(p => p.Id == modelId);
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            return await _context.VehicleModels.ToListAsync();
        }

        public async Task<ActionResult<VehicleModel>> UpdateVehicleModel(int modelId, VehicleModel updatedVehicleModel)
        {
            var existingModel = (await GetVehicleModel(modelId)).Value;
            _context.Entry(existingModel).CurrentValues.SetValues(updatedVehicleModel);
            await _context.SaveChangesAsync();

            return existingModel;
        }

        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int modelId)
        {
            var targetModel = (await GetVehicleModel(modelId)).Value;

            if (targetModel != null)
            {
                _context.VehicleModels.Remove(targetModel);
                await _context.SaveChangesAsync();
            }

            return targetModel;
        }
    }
}
