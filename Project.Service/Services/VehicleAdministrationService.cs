using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;
using Project.Service.Models.DTOs.VehicleAdministration;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using Project.Service.Models.Entities;
using Project.Service.Utils.Paging;
using Project.Service.Utils.PropertyMappingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class VehicleAdministrationService : IVehicleAdministrationService
    {
        private readonly VehicleDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        public VehicleAdministrationService(VehicleDbContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context;
            _propertyMappingService = propertyMappingService;
        }

        // Make
        public async Task<ActionResult<CreateMakeDto>> CreateVehicleMake(CreateMakeDto newVehicleMake)
        {
            // use mapper
            _context.VehicleMakes.Add( new VehicleMake { Name = newVehicleMake.Name, Abrv = newVehicleMake.Abrv } );
            await _context.SaveChangesAsync();

            return newVehicleMake;
        }
        public async Task<ActionResult<ReadMakeDto>> ReadVehicleMake(int makeId)
        {
            var targetMakeQuery = _context.VehicleMakes.AsQueryable();

            try
            {
                await targetMakeQuery.SingleOrDefaultAsync(make => make.Id == makeId);
                var targetMake = await targetMakeQuery.Select(make => new ReadMakeDto { Id = make.Id, Name = make.Name, Abrv = make.Abrv }).SingleAsync();

                return targetMake;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<ReadMakesDto>>> ReadVehicleMakes()
        {
            var makes = await _context.VehicleMakes.Select(make => new ReadMakesDto { Name = make.Name, Abrv = make.Abrv }).ToListAsync();

            return makes;
        }

        public async Task<ActionResult<PagedList<ReadMakesDto>>> ReadVehicleMakes(PaginationParameters makesPaginationPatameters)
        {
            var vehicleMakes = await _context.VehicleMakes.Select(make => new ReadMakesDto { Name = make.Name, Abrv = make.Abrv } ).ToListAsync();
            var vehicleMakesQuery = vehicleMakes.AsQueryable();

            //Sorter
            //if (!string.IsNullOrEmpty(makesPaginationPatameters.OrderBy))
            //{
            //    vehicleMakesQuery = vehicleMakesQuery.ApplySort(makesPaginationPatameters.OrderBy, _propertyMappingService.GetPropertyMapping<VehicleMakeDto, VehicleMake>());
            //}

            //Filter
            if (!string.IsNullOrEmpty(makesPaginationPatameters.Name))
            {
                var namesForFilter = makesPaginationPatameters.Name.Trim().ToLower();
                vehicleMakesQuery = vehicleMakesQuery.Where(make => make.Name.ToLower() == namesForFilter);
            }

            //Pager
            var pagedList = (ActionResult<PagedList<ReadMakesDto>>)await PagedList<ReadMakesDto>.Create(vehicleMakesQuery, makesPaginationPatameters.PageSize, makesPaginationPatameters.PageNumber).AsQueryable().ToListAsync();
            
            return pagedList;
        }

        public async Task<ActionResult<ReadMakeDto>> UpdateVehicleMake(int makeId, UpdateMakeDto updatedMake)
        {
            var targetMake = (await ReadVehicleMake(makeId)).Value;

            if (targetMake != null)
            {
                _context.Entry(targetMake).CurrentValues.SetValues(updatedMake);
                await _context.SaveChangesAsync();
            }
               
            return targetMake;
        }

        public async Task<ActionResult<ReadMakeDto>> DeleteVehicleMake(int makeId)
        {
            var targetMake = (await ReadVehicleMake(makeId)).Value;

            if (targetMake != null)
            {
                
                _context.VehicleMakes.Remove(new VehicleMake { Id = makeId });
                await _context.SaveChangesAsync();
            }

            return targetMake;
        }


        // Model
        public async Task<ActionResult<CreateModelDto>> CreateVehicleModel(CreateModelDto newVehicleModel)
        {
            var vehicleModelsQuery = await(
                                     from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new CreateModelDto { MakeId = make.Id, Name = model.Name, Abrv = model.Abrv }
                                     ).SingleAsync();

            var newModel = new VehicleModel { MakeId = vehicleModelsQuery.MakeId, Name = vehicleModelsQuery.Name, Abrv = vehicleModelsQuery.Abrv };
            _context.VehicleModels.Add(newModel);
            await _context.SaveChangesAsync();

            return vehicleModelsQuery;
        }
        public async Task<ActionResult<ReadModelDto>> ReadVehicleModel(int modelId)
        {
            var vehicleModelsQuery = await(
                                     from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new ReadModelDto { Id = model.Id, Name = model.Name, Abrv = model.Abrv, MakeId = make.Id, MakeName = make.Name }
                                     ).SingleAsync();

            return vehicleModelsQuery;
        }

        public async Task<ActionResult<IEnumerable<ReadModelsDto>>> ReadVehicleModels()
        {
            var vehicleModelsQuery = await(
                                     from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new ReadModelsDto { Name = model.Name, Abrv = model.Abrv, MakeName = make.Name }
                                     ).ToListAsync();

            return vehicleModelsQuery;
        }

        public async Task<ActionResult<PagedList<ReadModelsDto>>> ReadVehicleModels(PaginationParameters modelsPaginationPatameters)
        {
            var vehicleModelsQuery = from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new ReadModelsDto { MakeName = make.Name, Name = model.Name, Abrv = model.Abrv };

            if (!string.IsNullOrEmpty(modelsPaginationPatameters.Name))
            {
                var namesForFilter = modelsPaginationPatameters.Name.Trim().ToLower();
                vehicleModelsQuery = vehicleModelsQuery.Where(n => n.Name.ToLower() == namesForFilter);
            }
            //await
            var pagedList = (ActionResult<PagedList<ReadModelsDto>>)await PagedList<ReadModelsDto>.Create(vehicleModelsQuery, modelsPaginationPatameters.PageSize, modelsPaginationPatameters.PageNumber).AsQueryable().ToListAsync();

            return pagedList;
        }

        public async Task<ActionResult<ReadModelDto>> UpdateVehicleModel(int modelId, UpdateModelDto updatedModel)
        {
            var targetModel = (await ReadVehicleModel(modelId)).Value;

            if (targetModel != null)
            {
                _context.Entry(targetModel).CurrentValues.SetValues(updatedModel);
                await _context.SaveChangesAsync();
            }

            return targetModel;
        }


        public async Task<ActionResult<ReadModelDto>> DeleteVehicleModel(int modelId)
        {
            var targetModel = (await ReadVehicleModel(modelId)).Value;

            if (targetModel != null)
            {

                _context.VehicleModels.Remove(new VehicleModel { Id = modelId });
                await _context.SaveChangesAsync();
            }

            return targetModel;
        }

        // Vehicles
        public async Task<ActionResult<IEnumerable<ReadVehiclesDto>>> ReadVehicles()
        {
            var vehiclesQuery = await (
                                     from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new ReadVehiclesDto { MakeName = make.Name, MakeAbrv = make.Abrv, ModelName = model.Name, ModelAbrv = model.Abrv }
                                     ).ToListAsync();
            return vehiclesQuery;
        }
    }
}
