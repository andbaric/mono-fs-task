using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models.Administration.VehicleModel;
using Project.MVC.Models.Administration;
using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.Service.Services;
using Project.Service.Utils.PropertyMappingService;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.MVC.Models.ViewModels.Administration.VehicleMake;

namespace Project.MVC.Controllers
{
    [Route("administration")]
    public class AdministrationController : Controller
    {
        private readonly IVehicleAdministrationService _vehicleAdministrationService;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        private readonly IPropertyMappingService _propertyMappingService;

        public AdministrationController(IVehicleAdministrationService vehicleAdministrationService, IMapper mapper, IUrlHelper urlHelper, 
            IPropertyMappingService propertyMappingService)
        {
            _vehicleAdministrationService = vehicleAdministrationService;
            _mapper = mapper;
            _urlHelper = urlHelper;
            _propertyMappingService = propertyMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> AdministrateVehicles(string gridView)
        {
            var vehicles = (await _vehicleAdministrationService.ReadVehicles()).Value;
            var vehiclesAdministrationView = vehicles.GetAdministrationView("", gridView);
            
            return View("~/Views/Administration/Administration.cshtml", vehiclesAdministrationView);
        }

        [HttpGet("makes")]
        public async Task<IActionResult> AdministrateMakes(string gridView)
        {
            var makes = (await _vehicleAdministrationService.ReadVehicleMakes()).Value;
            var makesAdministrationView = makes.GetAdministrationView("makes", gridView);

            return View("~/Views/Administration/Administration.cshtml", makesAdministrationView);
        }

        [HttpGet("makes/{id}")]
        public async Task<IActionResult> ReadMake(int id)
        {
            var vehicleMake = (await _vehicleAdministrationService.ReadVehicleMake(id)).Value;

            if (vehicleMake == null) return NotFound();

            return View("~/Views/Administration/VehicleMake/ReadMake.cshtml", vehicleMake);
        }

        [Route("makes/create")]
        public IActionResult CreateMake(CreateMakeViewModel createMakeViewModelState)
        {
            return View("~/Views/Administration/VehicleMake/CreateMake.cshtml", createMakeViewModelState);
        }

        [HttpPost("makes/create")]
        public async Task<IActionResult> CreateMake(CreateMakeDto newVehicleMake)
        {
            //simplify message, create ViewModels
            var crudAction = CRUDActions.Create;
            if (ModelState.IsValid)
            {
                var createdVehicleMake = (await _vehicleAdministrationService.CreateVehicleMake(newVehicleMake)).Value;
                var messageType = FeedbackMessageType.Sucess;
                var sucessCreateViewModel = new CreateMakeViewModel()
                {
                    MessageType = messageType,
                    MessageText = IFeedbackMessage.CRUDMessage(messageType, crudAction, createdVehicleMake.Name)
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

        [HttpGet("makes/edit/{id}")]
        public async Task<IActionResult> EditMake(int id)
        {
            var vehicleMakeTarget = (await _vehicleAdministrationService.ReadVehicleMake(id)).Value;

            if (vehicleMakeTarget == null) return NotFound();

            var makeToUpdate = _mapper.Map<UpdateMakeDto>(vehicleMakeTarget);

            return View("~/Views/Administration/VehicleMake/EditMake.cshtml", makeToUpdate);
        }

        [HttpPost("makes/edit/{id}")]
        public async Task<IActionResult> UpdateMake(UpdateMakeDto updatedVehicleMake)
        {
            var crudAction = CRUDActions.Update;
            if (ModelState.IsValid)
            {
                await _vehicleAdministrationService.UpdateVehicleMake(updatedVehicleMake);

                return RedirectToAction("ReadMake", new { id = updatedVehicleMake.Id });
            }
            else
            {
                var messageType = FeedbackMessageType.Failed;
                var failedCreateViewModel = new CreateMakeViewModel()
                {
                    MessageType = messageType,
                    MessageText = FeedbackMessageBase.CRUDMessage(messageType, crudAction, updatedVehicleMake.Name)
                };

                return View("~/Views/Administration/VehicleMake/EditMake.cshtml", updatedVehicleMake);
            }
        }

        [HttpGet("makes/delete/{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var targetMake = (await _vehicleAdministrationService.ReadVehicleMake(id)).Value;

            if (targetMake == null) return NotFound();

            return View("~/Views/Administration/VehicleMake/DeleteMake.cshtml", targetMake);
        }

        [HttpPost("makes/delete/{id}")]
        public async Task<IActionResult> DeleteMake(int id, IFormCollection form)
        {
            await _vehicleAdministrationService.DeleteVehicleMake(id);

            return RedirectToAction("AdministrateMakes");
        }
        
        [HttpGet("models")]
        public async Task<IActionResult> AdministrateModels(string gridView)
        {
            var models = (await _vehicleAdministrationService.ReadVehicleModels()).Value;
            var modelsAdministrationView = models.GetAdministrationView("models", gridView);

            return View("~/Views/Administration/Administration.cshtml", modelsAdministrationView);
        }

        [HttpGet("models/{id}")]
        public async Task<IActionResult> ReadModel(int id)
        {
            var vehicleModel = (await _vehicleAdministrationService.ReadVehicleModel(id)).Value;

            if (vehicleModel == null) return NotFound();

            return View("~/Views/Administration/VehicleModel/ReadModel.cshtml", vehicleModel);
        }

/*        [Route("models/create")]
        public async Task<IActionResult> CreateModel(CreateModelViewModel createModelState)
        {
            var vehicleMakes = (await _vehicleAdministrationService.GetAvailableMakes()).Value;
            var createModelView = _mapper.Map<CreateModelViewModel>(vehicleMakes);
            var availableVehicleMakes = vehicleMakes.Select(make => new { make.Id, make.Name }).ToDictionary(make => make.Id, make => make.Name);
            createModelState.AvailableMakes = vehicleMakes;
            ViewBag.AvailableMakes = new SelectList(vehicleMakes, "Key", "Value");

            return View("~/Views/Administration/VehicleModel/CreateModel.cshtml", createModelView);
        }*/

        /*[HttpPost("models/create")]
        public async Task<IActionResult> CreateModel(VehicleModel newVehicleModel)
        {
            var crudAction = CRUDActions.Create;

            if (ModelState.IsValid)
            {
                *//*var createdVehicleModel = (await _vehicleAdministrationService.CreateVehicleModel(newVehicleModel)).Value;*//*
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
*/

        // UPDATE MODEL
        /*      [HttpGet("models/edit/{id}")]
              public async Task<IActionResult> EditModel(int id)
              {
                  var vehicleMakes = (await _vehicleAdministrationService.GetVehicleMakes()).Value;
                  var availableVehicleMakes = vehicleMakes.Select(make => new { make.Id, make.Name }).ToDictionary(make => make.Id, make => make.Name);
                  ViewBag.AvailableMakes = new SelectList(availableVehicleMakes, "Key", "Value");
                  var vehicleMakeGetResult = (await _vehicleAdministrationService.GetVehicleModel(id)).Value;

                  if (vehicleMakeGetResult == null) return NotFound();

                  return View("~/Views/Administration/VehicleModel/EditModel.cshtml", vehicleMakeGetResult);
              }*/

        /*        [HttpPost("models/edit")]
                public async Task<IActionResult> UpdateModel(VehicleModel updatedVehicleModel)
                {
                    if (ModelState.IsValid)
                    {
                        await _vehicleAdministrationService.UpdateVehicleModel(updatedVehicleModel.Id, updatedVehicleModel);

                        return RedirectToAction("ReadModel", new { id = updatedVehicleModel.Id });
                    }

                    return View("~/Views/Administration/VehicleModel/EditModel.cshtml", updatedVehicleModel);
                }

        */
        // DELETE MODEL
/*        [HttpGet("models/delete/{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var targetModel = (await _vehicleAdministrationService.GetVehicleModel(id)).Value;

            if (targetModel == null) return View("Not found");

            return View("~/Views/Administration/VehicleModel/DeleteModel.cshtml", targetModel);
        }

        [HttpPost("models/delete/{id}")]
        public async Task<IActionResult> DeleteModel(int id, IFormCollection form)
        {
            await _vehicleAdministrationService.DeleteVehicleModel(id);

            return RedirectToAction("AdministrateModels");
        }*/


    }
}
