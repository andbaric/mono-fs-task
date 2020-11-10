using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration.VehicleModel
{
    public class AdministrateModelsViewModel
    {
        public AdministrateModelsViewModel(IEnumerable<ModelTableDataViewModel> tableData)
        {
            ModelsAdministrationNavigation = new Navigation(AdministrationLink.Models);
            TableData = tableData;
        }

        public Navigation ModelsAdministrationNavigation { get; set; }
        public IEnumerable<ModelTableDataViewModel> TableData { get; }
    }
}
