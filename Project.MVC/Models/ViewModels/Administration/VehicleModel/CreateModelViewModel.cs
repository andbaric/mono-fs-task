using Project.MVC.Models.Shared;
using System.Collections.Generic;

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
