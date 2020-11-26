using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Administration.Grid;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration.VehicleMake
{
    public sealed class MakeAdministrationViewModel : AdministrationViewModelBase<ReadMakesDto>
    {
        public MakeAdministrationViewModel(IEnumerable<ReadMakesDto> source, string currentAction, string gridView)
        {
            Title = SetTitle();
            Navigation = SetNavigation(gridView);
            Grid = SetGrid(source, currentAction, gridView);
        }

        public static MakeAdministrationViewModel GetView(IEnumerable<ReadMakesDto> source, string currentAction, string gridView)
        {
            return new MakeAdministrationViewModel(source, currentAction, gridView);
        }

        public override GridViewModel<ReadMakesDto> SetGrid(IEnumerable<ReadMakesDto> source, string currentAction, string gridView)
        {
            return new GridViewModel<ReadMakesDto>(source, currentAction, gridView);
        }

        public override AdministrationNavigationViewModel SetNavigation(string gridView)
        {
            return new AdministrationNavigationViewModel(AdministrationLink.Makes, gridView);
        }

        public override string SetTitle()
        {
            return "Makes administration";
        }
    }
}
