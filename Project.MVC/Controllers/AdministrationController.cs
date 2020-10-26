using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models.Shared;
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

        public IActionResult Index()
        {
            var menu = new MenuViewModel
            {
                MenuItems = new List<CardViewModel>
                {
                    new CardViewModel { Title = "Manage vehicle makes", ImageUrl = "images/vehicleMake.png", Description = "CRUD vehicle makes", ControllerName = "administration", ControllerAction = "makes" },
                    new CardViewModel { Title = "Manage vehicle models", ImageUrl = "images/vehicleModel.png", Description = "CRUD vehicle models", ControllerName = "administration", ControllerAction = "models" }
                }
            };
            return View(menu);
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
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            return await _vehicleService.GetVehicleModels();
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
