using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MVC.Models;
using Project.MVC.Models.Administration;
using Project.MVC.Models.Administration.VehicleMake;
using Project.MVC.Models.Administration.VehicleModel;
using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.Service.Models;
using Project.Service.Services;

namespace Project.MVC.Controllers
{
    [Route("administration")]
    public class AdministrationController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public AdministrationController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> AdministrateVehicles()
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

            return View("~/Views/Administration/AdministrateVehicles.cshtml", vehiclesAdministrationView);
        }

        [HttpGet("makes")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> AdministrateMakes()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var mappedEntityToTableDataView = _mapper.Map<IEnumerable<MakeTableDataViewModel>>(vehicleMakes);
            var vehicleMakesAdministrationView = new AdministrateMakesViewModel(mappedEntityToTableDataView);

            return View("~/Views/Administration/VehicleMake/AdministrateMakes.cshtml", vehicleMakesAdministrationView);
        }

        [Route("makes/create")]
        public IActionResult CreateMake(CreateMakeViewModel createMakeState)
        {
            return View("~/Views/Administration/VehicleMake/CreateMake.cshtml", createMakeState);
        }

        [HttpPost("makes/create")]
        public async Task<ActionResult> CreateMake(VehicleMake newVehicleMake)
        {
            var crudAction = CRUDActions.Create;
            if (ModelState.IsValid)
            {
                var createdVehicleMake = (await _vehicleService.CreateVehicleMake(newVehicleMake)).Value;
                var messageType = FeedbackMessageType.Sucess;
                var sucessCreateViewModel = new CreateMakeViewModel() { 
                    MessageType = messageType, MessageText = FeedbackMessageBase.GeneratreFeedbackMessage(messageType, crudAction, createdVehicleMake.Name) 
                };
  
                return RedirectToAction("CreateMake", sucessCreateViewModel);
            }
            else
            {
                var messageType = FeedbackMessageType.Failed;
                var failedCreateViewModel = new CreateMakeViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.GeneratreFeedbackMessage(messageType, crudAction, newVehicleMake.Name)
                };

                return View("~/Views/Administration/VehicleMake/CreateMake.cshtml", failedCreateViewModel);
            }
        }

        [HttpGet("makes/{id}")]
        public async Task<ActionResult> ReadMake(int id)
        {
            var vehicleMake = (await _vehicleService.GetVehicleMake(id)).Value;

            return View("~/Views/Administration/VehicleMake/ReadMake.cshtml", vehicleMake);
        }

        [HttpGet("makes/edit/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> EditMake(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleMake(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return View("~/Views/Administration/VehicleMake/EditMake.cshtml", vehicleMakeGetResult);
        }


        [HttpPatch("makes/{id}")]
        public async Task<ActionResult<VehicleMake>> UpdateMake(int id, [FromBody] JsonPatchDocument<VehicleMake> makePatch)
        {
            if (makePatch != null)
            {
         
                var targetMake = (await _vehicleService.GetVehicleMake(id)).Value;

                if (targetMake == null) return NotFound();

                makePatch.ApplyTo(targetMake, ModelState);

                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _vehicleService.UpdateVehicleMake(id, targetMake);

                return Json(targetMake);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("makes/delete/{id}")]
        public async Task<ActionResult> DeleteMake(int id)
        {
            var targetMake = (await _vehicleService.GetVehicleMake(id)).Value;

            if (targetMake == null) return View("NotFound");

            return View("~/Views/Administration/VehicleMake/DeleteMake.cshtml", targetMake);
        }

        [HttpPost("makes/delete/{id}")]
        public async Task<ActionResult> DeleteMake(int id, IFormCollection form)
        {
            await _vehicleService.DeleteVehicleMake(id);

            return RedirectToAction("AdministrateMakes");
        }
        



        [HttpGet("models")]
        public async Task<IActionResult> AdministrateModels()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
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

            return View("~/Views/Administration/VehicleModel/AdministrateModels.cshtml",vehicleModelsAdministrationView);
        }

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
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var crudAction = CRUDActions.Create;

            if (ModelState.IsValid)
            {
                var createdVehicleModel = (await _vehicleService.CreateVehicleModel(newVehicleModel)).Value;
                var messageType = FeedbackMessageType.Sucess;
                var sucessCreateViewModel = new CreateModelViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.GeneratreFeedbackMessage(messageType, crudAction, createdVehicleModel.Name)
                };

                return RedirectToAction("CreateModel", sucessCreateViewModel);
            }
            else
            {
                var messageType = FeedbackMessageType.Failed;
                var failedCreateViewModel = new CreateModelViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.GeneratreFeedbackMessage(messageType, crudAction, "")
                };

                return RedirectToAction("CreateVehicleModel", failedCreateViewModel);
            }
        }

        [HttpGet("models/{id}")]
        public async Task<ActionResult> ReadModel(int id)
        {
            var vehicleModel = (await _vehicleService.GetVehicleModel(id)).Value;

            return View("~/Views/Administration/VehicleModel/ReadModel.cshtml", vehicleModel);
        }

        [HttpGet("models/edit/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> EditModel(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleModel(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return View("~/Views/Administration/VehicleModel/EditModel.cshtml", vehicleMakeGetResult);
        }

        [HttpPatch("models/{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateModel(int id, [FromBody] JsonPatchDocument<Service.Models.VehicleModel> modelPatch)
        {
            if (modelPatch != null)
            {

                var targetModel = (await _vehicleService.GetVehicleModel(id)).Value;

                if (targetModel == null) return NotFound();

                modelPatch.ApplyTo(targetModel, ModelState);

                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _vehicleService.UpdateVehicleModel(id, targetModel);

                return Json(targetModel);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("models/delete/{id}")]
        public async Task<ActionResult> DeleteModel(int id)
        {
            var targetModel = (await _vehicleService.GetVehicleModel(id)).Value;

            if (targetModel == null) return View("Not found");

            return View("~/Views/Administration/VehicleModel/DeleteModel.cshtml", targetModel);
        }

        [HttpPost("models/delete/{id}")]
        public async Task<ActionResult> DeleteModel(int id, IFormCollection form)
        {
            await _vehicleService.DeleteVehicleModel(id);

            return RedirectToAction("AdministrateModels");
        }
    }
}
