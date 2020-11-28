using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Administration.Grid;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration.VehicleModel
{
    public sealed class ModelAdministrationViewModel : AdministrationViewModelBase<ReadModelsDto>
    {
        public ModelAdministrationViewModel(IEnumerable<ReadModelsDto> source, string currentAction, string gridView)
        {
            Title = SetTitle();
            Navigation = SetNavigation(gridView);
            Grid = SetGrid(source, currentAction, gridView);
        }

        public static ModelAdministrationViewModel GetView(IEnumerable<ReadModelsDto> source, string currentAction, string gridView)
        {
            return new ModelAdministrationViewModel(source, currentAction, gridView);
        }

        public override GridViewModel<ReadModelsDto> SetGrid(IEnumerable<ReadModelsDto> source, string currentAction, string gridView)
        {
            return new GridViewModel<ReadModelsDto>(source, currentAction, gridView);
        }

        public override AdministrationNavigationViewModel SetNavigation(string gridView)
        {
            return new AdministrationNavigationViewModel(AdministrationLink.Models, gridView);
        }

        public override string SetTitle()
        {
            return "Models administration";
        }
    }
}
