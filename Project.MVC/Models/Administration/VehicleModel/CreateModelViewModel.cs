using Project.MVC.Models.Shared;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Administration.VehicleModel
{
    public class CreateModelViewModel : FeedbackMessageBase
    {
        public IDictionary<int, string> AvailableMakes { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string FeedBackMessage { get; set; }
    }
}
