using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Administration.Grid;
using Project.Service.Models.DTOs.VehicleAdministration;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration
{
    public sealed class VehiclesAdministrationViewModel : AdministrationViewModelBase<ReadVehiclesDto>
    {
        public VehiclesAdministrationViewModel(IEnumerable<ReadVehiclesDto> source, string currentAction, string gridView)
        {
            Title = SetTitle();
            Navigation = SetNavigation(gridView);
            Grid = SetGrid(source, currentAction, gridView);
        }

        public static VehiclesAdministrationViewModel GetView(IEnumerable<ReadVehiclesDto> source, string currentAction, string gridView)
        {
            return new VehiclesAdministrationViewModel(source, currentAction, gridView);
        }

        public override GridViewModel<ReadVehiclesDto> SetGrid(IEnumerable<ReadVehiclesDto> source, string currentAction, string gridView)
        {
            return new GridViewModel<ReadVehiclesDto>(source, currentAction, gridView);
        }

        public override AdministrationNavigationViewModel SetNavigation(string currentGridView)
        {
            return new AdministrationNavigationViewModel(AdministrationLink.Vehicles, currentGridView);
        }

        public override string SetTitle()
        {
            return "Vehicles preview";
        }
    }
}
