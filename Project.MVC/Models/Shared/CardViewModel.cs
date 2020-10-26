using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Shared
{
    public class CardViewModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
    }
}
