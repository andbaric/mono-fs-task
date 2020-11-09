using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.MVC.Models.Administration
{
    public class ModelsAdministrationViewModel
    {
        public ModelsAdministrationViewModel(IQueryable<VehicleModel> data)
        {
            AdministrationNavigation = new Navigation(AdministrationLink.Models);
            Data = data;
        }

        public Navigation AdministrationNavigation { get; set; }
        public IQueryable<VehicleModel> Data { get; }
    }
}
