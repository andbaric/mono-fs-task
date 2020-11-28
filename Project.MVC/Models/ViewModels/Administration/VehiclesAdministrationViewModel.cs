using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Administration.Grid;
using Project.Service.Models.DTOs.VehicleAdministration;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration
{
    public sealed class VehiclesAdministrationViewModel : AdministrationViewModelBase<ReadOnlyVehiclesDto>
    {
        public VehiclesAdministrationViewModel(IEnumerable<ReadOnlyVehiclesDto> source, string currentAction, string gridView)
        {
            Title = SetTitle();
            Navigation = SetNavigation(gridView);
            Grid = SetGrid(source, currentAction, gridView);
        }

        public static VehiclesAdministrationViewModel GetView(IEnumerable<ReadOnlyVehiclesDto> source, string currentAction, string gridView)
        {
            return new VehiclesAdministrationViewModel(source, currentAction, gridView);
        }

        public override GridViewModel<ReadOnlyVehiclesDto> SetGrid(IEnumerable<ReadOnlyVehiclesDto> source, string currentAction, string gridView)
        {
            return new GridViewModel<ReadOnlyVehiclesDto>(source, currentAction, gridView);
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
