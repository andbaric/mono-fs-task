using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Administration.VehicleMake
{
    public class CreateMakeViewModel
    {
        public List<string> AvailableMakes { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string FeedBackMessage { get; set; }
    }
}
