using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using Project.MVC.Models.Administration;
using Project.MVC.Models.Administration.VehicleMake;
using Project.MVC.Models.Administration.VehicleModel;
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

            return View("~/Views/AdministrateVehicles.cshtml", vehiclesAdministrationView);
        }

        [HttpGet("makes")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> AdministrateMakes()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var mappedEntityToTableDataView = _mapper.Map<IEnumerable<MakeTableDataViewModel>>(vehicleMakes);
            var vehicleMakesAdministrationView = new AdministrateMakesViewModel(mappedEntityToTableDataView);

            return View("~/Views/Administration/VehicleMake/AdministrateMakesView.cshtml", vehicleMakesAdministrationView);
        }

        [Route("makes/create")]
        public async Task<ActionResult> CreateVehicleMakeView()
        {
            return View("~/Views/Administration/VehicleMake/CreateMakeView.cshtml");
        }

        [HttpPost("makes/create")]
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake([FromBody] VehicleMake newVehicleMake)
        {
            var createdMake = (await _vehicleService.CreateVehicleMake(newVehicleMake)).Value;

            return Created($"/administration/makes/{createdMake.Id}", createdMake);
        }

        [HttpGet("makes/edit/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> EditVehicleMake(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleMake(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return View(vehicleMakeGetResult);
        }


        [HttpPatch("makes/{id}")]
        public async Task<ActionResult<VehicleMake>> UpdateVehicleMake(int id, [FromBody] JsonPatchDocument<VehicleMake> makePatch)
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

        [HttpDelete("makes/{id}")]
        public async Task<ActionResult<VehicleMake>> DeleteVehicleMake(int id)
        {
            var targetMake = (await _vehicleService.DeleteVehicleMake(id)).Value;

            if (targetMake == null) return NotFound();

            return NoContent();
        }


        [HttpGet("models")]
        public async Task<IActionResult> AdministrateModels()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
            var vehiclesModelsTableData = from make in vehicleMakes
                                        join model in vehicleModels on make.Id equals model.MakeId
                                        select new ModelTableDataViewModel
                                        {
                                            ModelId = model.Id,
                                            MakeAbrv = make.Abrv,
                                            ModelName = model.Name,
                                            ModelAbrv = model.Abrv
                                        };
            var vehicleModelsAdministrationView = new AdministrateModelsViewModel(vehiclesModelsTableData);

            return View("~/Views/Administration/VehicleModel/AdministrateModelsView.cshtml",vehicleModelsAdministrationView);
        }

        [Route("models/create")]
        public async Task<ActionResult> CreateVehicleModel()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var availableVehicleMakes = vehicleMakes.Select(name => name.Name).ToList();
            var createModelView = new CreateModelViewModel(availableVehicleMakes);

            return View("~/Views/Administration/VehicleModel/CreateModelView.cshtml", createModelView);
        }

        [HttpGet("models/edit/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> EditVehicleModel(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleModel(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return View(vehicleMakeGetResult);
        }

        [HttpPost("models")]
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel([FromBody] VehicleModel newVehicleModel)
        {
            var createdModel = (await _vehicleService.CreateVehicleModel(newVehicleModel)).Value;

            return Created($"/administration/models/{createdModel.Id}" , createdModel);
        }

        [HttpPatch("models/{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, [FromBody] JsonPatchDocument<Service.Models.VehicleModel> modelPatch)
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

        [HttpDelete("models/{id}")]
        public async Task<ActionResult<Service.Models.VehicleModel>> DeleteVehicleModel(int id)
        {
            var targetModel = (await _vehicleService.DeleteVehicleModel(id)).Value;

            if (targetModel == null) return NotFound();

            return NoContent();
        }
    }
}
