using Project.MVC.Models.Shared.Enums;
using System.Collections.Generic;

namespace Project.MVC.Models.Shared.Navigation
{
    public class Navigation
    {
        public Navigation(AdministrationLink activeLink)
        {
            Links = CreateAdministrationLinks(activeLink);
        }

        public IEnumerable<NavigationLink> Links { get; set; }

        private IEnumerable<NavigationLink> CreateAdministrationLinks(AdministrationLink activeLink)
        {
            var rootRoute = "administration";
            var administrationLinks = new List<NavigationLink>
            {
                new NavigationLink {
                    Activity = activeLink == AdministrationLink.Vehicles ? ActivityState.active : ActivityState.inactive, 
                    Text = $"Vehicles preview",
                    Icon = "car", 
                    ControllerName = rootRoute, 
                    ControllerAction = "AdministrateVehicles" 
                },
                new NavigationLink { 
                    Activity = activeLink == AdministrationLink.Makes ? ActivityState.active : ActivityState.inactive,
                    Text = $"Makes {rootRoute}", 
                    Icon = "industry", 
                    ControllerName = rootRoute, 
                    ControllerAction = "AdministrateMakes" 
                },
                new NavigationLink {
                    Activity = activeLink == AdministrationLink.Models ? ActivityState.active : ActivityState.inactive,
                    Text = $"Models {rootRoute}", 
                    Icon = "car-side", 
                    ControllerName = rootRoute, 
                    ControllerAction = "AdministrateModels"
                }
            };

            return administrationLinks;
        }
    }
}
