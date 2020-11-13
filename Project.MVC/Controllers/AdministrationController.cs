using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MVC.Models;
using Project.MVC.Models.Administration;
using Project.MVC.Models.Administration.VehicleMake;
using Project.MVC.Models.Administration.VehicleModel;
using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.Service.Models.Entities;
using Project.Service.Services;
using Project.Service.Utils.Paging;
using Project.Service.Utils.PropertyMappingService;

namespace Project.MVC.Controllers
{
    [Route("administration")]
    public class AdministrationController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        private readonly IPropertyMappingService _propertyMappingService;

        public AdministrationController(IVehicleService vehicleService, IMapper mapper, IUrlHelper urlHelper, IPropertyMappingService propertyMappingService)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
            _urlHelper = urlHelper;
            _propertyMappingService = propertyMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> AdministrateVehicles(string gridView)
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
            var vehiclesData = from make in vehicleMakes
                               join model in vehicleModels on make.Id equals model.MakeId
                               select new VehicleViewModel
                               {
                                   MakeName = make.Name,
                                   MakeAbrv= make.Abrv,
                                   ModelName = model.Name,
                                   ModelAbrv = model.Abrv
                               };
            var vehiclesAdministrationView = new AdministrationViewModel(vehiclesData);
            ViewBag.GridView = gridView;

            return View("~/Views/Administration/AdministrateVehicles.cshtml", vehiclesAdministrationView);
        }

        // READ MAKES
        [HttpGet("makes")]
        public async Task<ActionResult<VehicleMake>> AdministrateMakes()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var mappedEntityToTableDataView = _mapper.Map<IEnumerable<MakeTableDataViewModel>>(vehicleMakes);
            var vehicleMakesAdministrationView = new AdministrateMakesViewModel(mappedEntityToTableDataView);

            return View("~/Views/Administration/VehicleMake/AdministrateMakes.cshtml", vehicleMakesAdministrationView);
        }

        [HttpGet("makess")]
        public async Task<ActionResult<PagedList<VehicleMake>>> AdministrateMakes(PaginationParameters makePaginationParameters)
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes(makePaginationParameters)).Value;
            var vehicleMakesQuery = vehicleMakes.AsQueryable();

            var paginatedVehicleMakes = PagedList<VehicleMake>.Create(
                                                            vehicleMakesQuery,
                                                            makePaginationParameters.PageSize,
                                                            makePaginationParameters.PageNumber
                                                           );

            var previousPageLink = paginatedVehicleMakes.HasPreviousPage ?
                _urlHelper.GeneratePaginatedResourceUrl("administration/makess",
                                makePaginationParameters, PagedResourceUrlType.PreviousPage) : null;
            var nextPageLink = paginatedVehicleMakes.HasNextPage ?
                _urlHelper.GeneratePaginatedResourceUrl("administration/makess",
                                makePaginationParameters, PagedResourceUrlType.PreviousPage) : null;

            return Ok(paginatedVehicleMakes);
        }

        [HttpGet("makes/{id}")]
        public async Task<ActionResult> ReadMake(int id)
        {
            var vehicleMake = (await _vehicleService.GetVehicleMake(id)).Value;

            return View("~/Views/Administration/VehicleMake/ReadMake.cshtml", vehicleMake);
        }


        //CREATE MAKE
        [Route("makes/create")]
        public ActionResult CreateMake(CreateMakeViewModel createMakeState)
        {
            return View("~/Views/Administration/VehicleMake/CreateMake.cshtml", createMakeState);
        }

        [HttpPost("makes/create")]
        public async Task<IActionResult> CreateMake(VehicleMake newVehicleMake)
        {
            var crudAction = CRUDActions.Create;
            if (ModelState.IsValid)
            {
                var createdVehicleMake = (await _vehicleService.CreateVehicleMake(newVehicleMake)).Value;
                var messageType = FeedbackMessageType.Sucess;
                var sucessCreateViewModel = new CreateMakeViewModel() { 
                    MessageType = messageType, MessageText = FeedbackMessageBase.CRUDMessage(messageType, crudAction, createdVehicleMake.Name) 
                };
  
                return RedirectToAction("CreateMake", sucessCreateViewModel);
            }
            else
            {
                var messageType = FeedbackMessageType.Failed;
                var failedCreateViewModel = new CreateMakeViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.CRUDMessage(messageType, crudAction, newVehicleMake.Name)
                };

                return View("~/Views/Administration/VehicleMake/CreateMake.cshtml", failedCreateViewModel);
            }
        }

        // UPDATE MAKE
        [HttpGet("makes/edit/{id}")]
        public async Task<IActionResult> EditMake(int id)
        {
            var vehicleMakeTarget = (await _vehicleService.GetVehicleMake(id)).Value;

            if (vehicleMakeTarget == null) return NotFound();

            return View("~/Views/Administration/VehicleMake/EditMake.cshtml", vehicleMakeTarget);
        }

        [HttpPost("makes/edit")]
        public async Task<ActionResult> UpdateMake(VehicleMake updatedVehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.UpdateVehicleMake(updatedVehicleMake.Id, updatedVehicleMake);

                return RedirectToAction("ReadMake", new { id = updatedVehicleMake.Id });
            }

            return View("~/Views/Administration/VehicleMake/EditMake.cshtml", updatedVehicleMake);
        }


        // DELETE MAKE
        [HttpGet("makes/delete/{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var targetMake = (await _vehicleService.GetVehicleMake(id)).Value;

            if (targetMake == null) return NotFound();

            return View("~/Views/Administration/VehicleMake/DeleteMake.cshtml", targetMake);
        }

        [HttpPost("makes/delete/{id}")]
        public async Task<ActionResult> DeleteMake(int id, IFormCollection form)
        {
            await _vehicleService.DeleteVehicleMake(id);

            return RedirectToAction("AdministrateMakes");
        }
        

        // READ MODEL
        [HttpGet("models")]
        public async Task<ActionResult> AdministrateModels()
        {
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehiclesModelsTableData = from make in vehicleMakes
                                          join model in vehicleModels on make.Id equals model.MakeId
                                          select new ModelTableDataModelViewModel
                                          {
                                              ModelId = model.Id,
                                              MakeAbrv = make.Abrv,
                                              ModelName = model.Name,
                                              ModelAbrv = model.Abrv
                                          };
            var vehicleModelsAdministrationView = new AdministrateModelsViewModel(vehiclesModelsTableData);

            return View("~/Views/Administration/VehicleModel/AdministrateModels.cshtml", vehicleModelsAdministrationView);
        }

        [HttpGet("modelss")]
        public async Task<ActionResult<PagedList<VehicleModel>>> AdministrateModels(PaginationParameters modelPaginationParameters)
        {
            var vehicleModels = (await _vehicleService.GetVehicleModels(modelPaginationParameters)).Value;
            var vehicleModelsQuery = vehicleModels.AsQueryable();

            var pagedVehicleModels = PagedList<VehicleModel>.Create(
                                                            vehicleModelsQuery,
                                                            modelPaginationParameters.PageSize,
                                                            modelPaginationParameters.PageNumber
                                                           );
            return Ok(pagedVehicleModels);
        }

        [HttpGet("models/{id}")]
        public async Task<ActionResult> ReadModel(int id)
        {
            var vehicleModel = (await _vehicleService.GetVehicleModel(id)).Value;

            return View("~/Views/Administration/VehicleModel/ReadModel.cshtml", vehicleModel);
        }


        // CREATE MODEL
        [Route("models/create")]
        public async Task<ActionResult> CreateModel(CreateModelViewModel createModelState)
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var availableVehicleMakes = vehicleMakes.Select(make => new { make.Id, make.Name }).ToDictionary(make => make.Id, make => make.Name);
            createModelState.AvailableMakes = availableVehicleMakes;
            ViewBag.AvailableMakes = new SelectList(availableVehicleMakes, "Key", "Value");

            return View("~/Views/Administration/VehicleModel/CreateModel.cshtml", createModelState);
        }

        [HttpPost("models/create")]
        public async Task<ActionResult> CreateModel(VehicleModel newVehicleModel)
        {
            var crudAction = CRUDActions.Create;

            if (ModelState.IsValid)
            {
                var createdVehicleModel = (await _vehicleService.CreateVehicleModel(newVehicleModel)).Value;
                var messageType = FeedbackMessageType.Sucess;
                var sucessCreateViewModel = new CreateModelViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.CRUDMessage(messageType, crudAction, createdVehicleModel.Name)
                };

                return RedirectToAction("CreateModel", sucessCreateViewModel);
            }
            else
            {
                var messageType = FeedbackMessageType.Failed;
                var failedCreateViewModel = new CreateModelViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.CRUDMessage(messageType, crudAction, "")
                };

                return RedirectToAction("CreateVehicleModel", failedCreateViewModel);
            }
        }


        // UPDATE MODEL
        [HttpGet("models/edit/{id}")]
        public async Task<IActionResult> EditModel(int id)
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var availableVehicleMakes = vehicleMakes.Select(make => new { make.Id, make.Name }).ToDictionary(make => make.Id, make => make.Name);
            ViewBag.AvailableMakes = new SelectList(availableVehicleMakes, "Key", "Value");
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleModel(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return View("~/Views/Administration/VehicleModel/EditModel.cshtml", vehicleMakeGetResult);
        }

        [HttpPost("models/edit")]
        public async Task<IActionResult> UpdateModel(VehicleModel updatedVehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.UpdateVehicleModel(updatedVehicleModel.Id, updatedVehicleModel);

                return RedirectToAction("ReadModel", new { id = updatedVehicleModel.Id });
            }

            return View("~/Views/Administration/VehicleModel/EditModel.cshtml", updatedVehicleModel);
        }


        // DELETE MODEL
        [HttpGet("models/delete/{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var targetModel = (await _vehicleService.GetVehicleModel(id)).Value;

            if (targetModel == null) return View("Not found");

            return View("~/Views/Administration/VehicleModel/DeleteModel.cshtml", targetModel);
        }

        [HttpPost("models/delete/{id}")]
        public async Task<IActionResult> DeleteModel(int id, IFormCollection form)
        {
            await _vehicleService.DeleteVehicleModel(id);

            return RedirectToAction("AdministrateModels");
        }


    }
}
