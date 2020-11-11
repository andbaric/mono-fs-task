using Project.MVC.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Administration.VehicleMake
{
    public class CreateMakeViewModel : FeedbackMessageBase
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
