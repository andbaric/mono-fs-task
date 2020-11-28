using Project.MVC.Models.ViewModels.Administration;
using Project.MVC.Models.ViewModels.Administration.VehicleMake;
using Project.MVC.Models.ViewModels.Administration.VehicleModel;
using Project.Service.Models.DTOs.VehicleAdministration;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleMakes;
using Project.Service.Models.DTOs.VehicleAdministration.VehicleModels;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration
{
    public static class AdministationExtensions
    {
        public static VehiclesAdministrationViewModel GetAdministrationView(this IEnumerable<ReadOnlyVehiclesDto> source, string currentAction, string gridView)
        {
            return VehiclesAdministrationViewModel.GetView(source, currentAction, gridView);
        }
        public static MakeAdministrationViewModel GetAdministrationView(this IEnumerable<ReadMakesDto> source, string currentAction, string gridView)
        {
            return MakeAdministrationViewModel.GetView(source, currentAction, gridView);
        }
        public static ModelAdministrationViewModel GetAdministrationView(this IEnumerable<ReadModelsDto> source, string currentAction, string gridView)
        {
            return ModelAdministrationViewModel.GetView(source, currentAction, gridView);
        }
    }
}
