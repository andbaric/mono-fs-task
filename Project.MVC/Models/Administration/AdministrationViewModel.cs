using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration
{
    public class AdministrationViewModel
    {
        public AdministrationViewModel(IEnumerable<VehicleViewModel> tableData)
        {
            AdministrationNavigation = new Navigation(AdministrationLink.Vehicles);
            TableData = tableData;
        }

        public Navigation AdministrationNavigation { get; set; }
        public IEnumerable<VehicleViewModel> TableData { get; }
    }
}
