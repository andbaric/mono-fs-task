using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration.VehicleMake
{
    public class AdministrateMakesViewModel
    {
        public AdministrateMakesViewModel(IEnumerable<MakeTableDataViewModel> tableData)
        {
            MakesAdministrationNavigation = new Navigation(AdministrationLink.Makes);
            TableData = tableData;
        }

        public Navigation MakesAdministrationNavigation { get; set; }
        public IEnumerable<MakeTableDataViewModel> TableData { get; }
    }
}
