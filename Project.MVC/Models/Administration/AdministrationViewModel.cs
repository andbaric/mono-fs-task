using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration
{
    public class AdministrationViewModel
    {
        public AdministrationViewModel(IEnumerable<Vehicle> data)
        {
            AdministrationNavigation = new Navigation(AdministrationLink.Vehicles);
            Data = data;
        }

        public Navigation AdministrationNavigation { get; set; }
        public IEnumerable<Vehicle> Data { get; }
    }
}
