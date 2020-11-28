using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;
using Project.Service.Models.DTOs.VehicleAdministration;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using Project.Service.Models.Entities;
using Project.Service.Models.Mapper;
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

        // Makes
        public async Task<ActionResult<CreateMakeDto>> CreateVehicleMake(CreateMakeDto newVehicleMake)
        {
            var newMakeEntity = Mapping.Mapper.Map<VehicleMake>(newVehicleMake);

            _context.VehicleMakes.Add(newMakeEntity);
            await _context.SaveChangesAsync();

            return newVehicleMake;
        }
        public async Task<ActionResult<ReadMakeDto>> ReadVehicleMake(int makeId)
        {
            var query = _context.VehicleMakes.AsQueryable().AsNoTracking();
            try
            {
                var targetMake = await query.Where(make => make.Id == makeId).SingleOrDefaultAsync();
                var readtMakeDto = Mapping.Mapper.Map<ReadMakeDto>(targetMake);

                return readtMakeDto;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
        public async Task<ActionResult<IEnumerable<ReadMakesDto>>> ReadVehicleMakes()
        {
            var readMakesDto = await Mapping.Mapper.ProjectTo<ReadMakesDto>(_context.VehicleMakes).ToListAsync();

            return readMakesDto;
        }
        public async Task<ActionResult<IEnumerable<ReadOnlyMakesDto>>> ReadOnlyVehicleMakes()
        {
            var readOnlyMakesDto = await Mapping.Mapper.ProjectTo<ReadOnlyMakesDto>(_context.VehicleMakes).ToListAsync();

            return readOnlyMakesDto;
        }

        public async Task<ActionResult<PagedList<ReadMakesDto>>> ReadVehicleMakes(PaginationParameters makesPaginationPatameters)
        {
            var vehicleMakes = await _context.VehicleMakes.Select(make => Mapping.Mapper.Map<ReadMakesDto>(make)).ToListAsync();
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
        public async Task<ActionResult<UpdateMakeDto>> UpdateVehicleMake(UpdateMakeDto updatedMake)
        {
            try
            {
                var targetMake = await _context.VehicleMakes.Where(make => make.Id == updatedMake.Id).SingleOrDefaultAsync();

                _context.Entry(targetMake).CurrentValues.SetValues(updatedMake);
                await _context.SaveChangesAsync();

                return updatedMake;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
        public async Task<ActionResult<DeleteMakeDto>> DeleteVehicleMake(int id)
        {
            var targetMake = (await ReadVehicleMake(id)).Value;

            if (targetMake != null)
            {
                var emakeToDelete = Mapping.Mapper.Map<VehicleMake>(targetMake);
                _context.VehicleMakes.Remove(emakeToDelete);
                await _context.SaveChangesAsync();
            }

            var test = new DeleteMakeDto { Id = 0 };
            return test;
        }
        public async Task<ActionResult<Dictionary<int, string>>> GetAvailableMakes()
        {
            var availableMakesDto = await Mapping.Mapper.ProjectTo<AvailableMakeDto>(_context.VehicleMakes)
                .ToDictionaryAsync(make => make.Id, make => make.Name);
            
            return availableMakesDto;
        }


        // Models
        public async Task<ActionResult<CreateModelDto>> CreateVehicleModel(CreateModelDto newVehicleModel)
        {
            var vehicleModel = await(
                                     from model in _context.VehicleModels
                                     join make in _context.VehicleMakes on model.MakeId equals make.Id
                                     select new CreateModelDto { MakeId = make.Id, Name = model.Name, Abrv = model.Abrv }
                                     ).SingleOrDefaultAsync();
            var newModelEntity = Mapping.Mapper.Map<VehicleModel>(newVehicleModel);

            _context.VehicleModels.Add(newModelEntity);
            await _context.SaveChangesAsync();

            return newVehicleModel;
        }

        public async Task<ActionResult<ReadModelDto>> ReadVehicleModel(int modelId)
        {
            try
            {
                var vehicleModelsQuery = await (
                    from model in _context.VehicleModels.Where(model => model.Id == modelId)
                    join make in _context.VehicleMakes on model.MakeId equals make.Id
                    select new ReadModelDto { Id = model.Id, Name = model.Name, Abrv = model.Abrv, MakeId = make.Id, MakeName = make.Name })
                    .SingleOrDefaultAsync();

                return vehicleModelsQuery;
            }
            catch(InvalidOperationException ex)
            {
                return null;
            }     
        }
        public async Task<ActionResult<IEnumerable<ReadModelsDto>>> ReadVehicleModels()
        {
            var vehicleModelsQuery = await (
                from model in _context.VehicleModels
                join make in _context.VehicleMakes on model.MakeId equals make.Id
                select new ReadModelsDto { Id =model.Id, Name = model.Name, Abrv = model.Abrv, MakeId = make.Id, MakeName = make.Name })
                .ToListAsync();

            return vehicleModelsQuery;
        }
        public async Task<ActionResult<IEnumerable<ReadOnlyModelsDto>>> ReadOnlyVehicleModels()
        {
            var vehicleModelsQuery = await(
                from model in _context.VehicleModels
                join make in _context.VehicleMakes on model.MakeId equals make.Id
                select new ReadOnlyModelsDto { Name = model.Name, Abrv = model.Abrv, MakeName = make.Name })
                .ToListAsync();

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
        public async Task<ActionResult<ReadModelDto>> UpdateVehicleModel(UpdateModelDto updatedModel)
        {
            var targetModel = (await ReadVehicleModel(updatedModel.Id)).Value;

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
        

        //Vehicles
        public async Task<ActionResult<IEnumerable<ReadOnlyVehiclesDto>>> ReadVehicles()
        {
            var vehiclesQuery = await (
                from model in _context.VehicleModels
                join make in _context.VehicleMakes on model.MakeId equals make.Id
                select new ReadOnlyVehiclesDto { MakeName = make.Name, MakeAbrv = make.Abrv, ModelName = model.Name, ModelAbrv = model.Abrv })
                .ToListAsync();

            return vehiclesQuery;
        }
    }
}
