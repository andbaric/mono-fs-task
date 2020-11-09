using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using Project.MVC.Models.Administration;
using Project.MVC.Models.Shared.Navigation;
using Project.Service.Models;
using Project.Service.Services;

namespace Project.MVC.Controllers
{
    [Route("[Controller]")]
    public class AdministrationController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public AdministrationController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Administration()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
            var vehiclesData = from make in vehicleMakes
                               join model in vehicleModels on make.Id equals model.MakeId
                               select new Vehicle
                               {
                                   MakeName = make.Name,
                                   MakeAbrv= make.Abrv,
                                   ModelName = model.Name,
                                   ModelAbrv = model.Abrv
                               };
            var vehiclesAdministrationView = new AdministrationViewModel(vehiclesData);

            return View(vehiclesAdministrationView);
        }

        [HttpGet("makes")]
        [EnableQuery(AllowedOrderByProperties = "Name,Abrv")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> AdministrateMakes()
        {
            var vehicleMakes = (await _vehicleService.GetVehicleMakes()).Value;
            var vehicleMakesData = vehicleMakes.AsQueryable();

            var vehicleMakesAdministrationView = new MakesAdministrationViewModel(vehicleMakesData);

            return View(vehicleMakesAdministrationView);
        }
        
        [HttpGet("makes/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMake(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleMake(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return Json(vehicleMakeGetResult);
        }

        [HttpPost("makes")]
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake([FromBody] VehicleMake newVehicleMake)
        {
            var createdMake = (await _vehicleService.CreateVehicleMake(newVehicleMake)).Value;

            return Created($"/administration/makes/{createdMake.Id}", createdMake);
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
        [EnableQuery(AllowedOrderByProperties = "Name,Abrv")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> AdministrateModels()
        {
            var vehicleModels = (await _vehicleService.GetVehicleModels()).Value;
            var vehicleModelsData = vehicleModels.AsQueryable();

            var vehicleModelsAdministrationView = new ModelsAdministrationViewModel(vehicleModelsData);

            return View(vehicleModelsAdministrationView);
        }

        [HttpGet("models/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModel(int id)
        {
            var vehicleMakeGetResult = (await _vehicleService.GetVehicleModel(id)).Value;

            if (vehicleMakeGetResult == null) return NotFound();

            return Json(vehicleMakeGetResult);
        }

        [HttpPost("models")]
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel([FromBody] VehicleModel newVehicleModel)
        {
            var createdModel = (await _vehicleService.CreateVehicleModel(newVehicleModel)).Value;

            return Created($"/administration/models/{createdModel.Id}" , createdModel);
        }

        [HttpPatch("models/{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, [FromBody] JsonPatchDocument<VehicleModel> modelPatch)
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
        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id)
        {
            var targetModel = (await _vehicleService.DeleteVehicleModel(id)).Value;

            if (targetModel == null) return NotFound();

            return NoContent();
        }
    }
}
