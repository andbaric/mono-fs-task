using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using Project.MVC.Models.ViewModels.Shared;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration
{
    public class AdministrationNavigationViewModel : Navigation<LinkViewModel>
    {
        public AdministrationNavigationViewModel(AdministrationLink activeLink, string currentGridView)
        {
            Links = SetNavigationLinks(activeLink, currentGridView);
        }
        public List<LinkViewModel> SetNavigationLinks(AdministrationLink activeLink, string currentGridView)
        {
            var controllerName = "administration";
            var routeParams = currentGridView == "mvc" ? "mvc" : "";
            var administrationLinks = new List<LinkViewModel>
            {
                new LinkViewModel {
                    Activity = activeLink == AdministrationLink.Vehicles ? ActivityState.active : ActivityState.inactive,
                    Text = $"Vehicles preview",
                    Icon = new FaIcon("car"),
                    ControllerName = controllerName,
                    ControllerAction = "AdministrateVehicles",
                    RouteParams= routeParams
                },
                new LinkViewModel {
                    Activity = activeLink == AdministrationLink.Makes ? ActivityState.active : ActivityState.inactive,
                    Text = $"Makes {controllerName}",
                    Icon = new FaIcon("industry"),
                    ControllerName = controllerName,
                    ControllerAction = "AdministrateMakes",
                    RouteParams = routeParams
                },
                new LinkViewModel {
                    Activity = activeLink == AdministrationLink.Models ? ActivityState.active : ActivityState.inactive,
                    Text = $"Models {controllerName}",
                    Icon = new FaIcon("car-side"),
                    ControllerName = controllerName,
                    ControllerAction = "AdministrateModels",
                    RouteParams = routeParams
                }
            };

            return administrationLinks;
        }
    }
}
