using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Models;
using Project.Service.Services;

namespace Project.MVC.Controllers
{
    [Route("api/[Controller]")]
    public class AdministrationController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public AdministrationController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("makes")]
        [EnableQuery(AllowedOrderByProperties = "Name,Abrv")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakes()
        {
            return await _vehicleService.GetVehicleMakes();
        }

        [HttpGet("makes/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMake(int id)
        {
            var makeResult = await _vehicleService.GetVehicleMake(id);

            return Json(makeResult.Value);
        }

        [HttpPost("makes")]
        public async Task<ActionResult<VehicleMake>> CreateVehicleMake([FromBody] VehicleMake newVehicleMake)
        {
            var createdMake = await _vehicleService.CreateVehicleMake(newVehicleMake);

            return Json(createdMake.Value);
        }

        [HttpPatch("makes/{id}")]
        public async Task<ActionResult<VehicleMake>> UpdateVehicleMake(int id, [FromBody] JsonPatchDocument<VehicleMake> makePatch)
        {
            if (makePatch == null) return BadRequest(ModelState);

            var updatedMake = (await _vehicleService.GetVehicleMake(id)).Value;

            makePatch.ApplyTo(updatedMake);

            await _vehicleService.UpdateVehicleMake(id, updatedMake);

            return Json(updatedMake);
        }

        [HttpDelete("makes/{id}")]
        public async Task<ActionResult<VehicleMake>> DeleteVehicleMake(int id)
        {
            var deletedMake = (await _vehicleService.DeleteVehicleMake(id)).Value;

            return Json(deletedMake);
        }


        [HttpGet("models")]
        [EnableQuery(AllowedOrderByProperties = "Name,Abrv")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            return await _vehicleService.GetVehicleModels();
        }

        [HttpGet("models/{id}")]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModel(int id)
        {
            var modelResult = await _vehicleService.GetVehicleModel(id);

            return Json(modelResult.Value);
        }

        [HttpPost("models")]
        public async Task<ActionResult<VehicleModel>> CreateVehicleModel([FromBody] VehicleModel newVehicleModel)
        {
            var createdModel = await _vehicleService.CreateVehicleModel(newVehicleModel);

            return Created($"/api/models/{createdModel.Value.Id}" , createdModel.Value);
        }

        [HttpPatch("models/{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicleModel(int id, [FromBody] JsonPatchDocument<VehicleModel> modelPatch)
        {
            if (modelPatch == null) return BadRequest(ModelState);

            var updatedModel = (await _vehicleService.GetVehicleModel(id)).Value;

            modelPatch.ApplyTo(updatedModel);

            await _vehicleService.UpdateVehicleModel(id, updatedModel);

            return Json(updatedModel);
        }

        [HttpDelete("models/{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id)
        {
            var deletedModel = (await _vehicleService.DeleteVehicleModel(id)).Value;

            return deletedModel;
        }
    }
}
