using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.MVC.Models.Administration
{
    public class MakesAdministrationViewModel
    {
        public MakesAdministrationViewModel(IQueryable<VehicleMake> data)
        {
            AdministrationNavigation = new Navigation(AdministrationLink.Makes);
            Data = data;
        }

        public Navigation AdministrationNavigation { get; set; }
        public IQueryable<VehicleMake> Data { get; }
    }
}
