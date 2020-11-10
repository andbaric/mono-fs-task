using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Administration.VehicleModel
{
    public class CreateModelViewModel
    {
        public CreateModelViewModel(IEnumerable<string> availableVehicleMakes)
        {
            AvailableMakesNames = availableVehicleMakes;
        }
        // Dictionary key value pairs
        public IEnumerable<string> AvailableMakesNames { get; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string FeedBackMessage { get; set; }
    }
}
