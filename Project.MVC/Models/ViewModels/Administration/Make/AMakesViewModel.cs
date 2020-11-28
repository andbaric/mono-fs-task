/*using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using Project.MVC.Models.ViewModels.Shared;
using System.Collections.Generic;
using Project.Service.Models.Entities;
using Project.MVC.Models.Administration.Make;

namespace Project.MVC.Models.ViewModels.Administration.Make
{
    public class AMakesViewModel : AdministrationV<MakeTableDataViewModel>
    {
        public AMakesViewModel(IEnumerable<MakeTableDataViewModel> dataSource)
        {
            Navigation = SetNavigation(AdministrationLink.Makes);
            Grid = SetGrid(dataSource);
        }

        public override Navigation SetNavigation(AdministrationLink activeLink)
        {
            return new Navigation(AdministrationLink.Makes);
        }

        public override Grid<MakeTableDataViewModel> SetGrid(IEnumerable<MakeTableDataViewModel> dataSource)
        {
            return new Grid<MakeTableDataViewModel> { Type = GridType.Mvc, DataSource = dataSource };
        }
    }
}
*/