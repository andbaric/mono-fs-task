using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;
using Project.MVC.Models.ViewModels.Shared;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration.Grid
{
    public class GridMenuViewModel : Navigation<LinkViewModel>
    {
        public GridMenuViewModel(string currentAction, GridLink activeLink)
        {   
            Links = SetNavigationLinks(currentAction, activeLink);
        }
        public List<LinkViewModel> SetNavigationLinks(string currentAction, GridLink activeLink)
        {
            var controllerName = "administration";
            var gridMenuLinks = new List<LinkViewModel>
            {
                new LinkViewModel {
                    Activity = activeLink == GridLink.Custom ? ActivityState.active : ActivityState.inactive,
                    Text = $"Custom grid",
                    Icon = new FaIcon("th-large"),
                    ControllerName = controllerName,
                    ControllerAction = currentAction,
                    RouteParams = ""
                },
                new LinkViewModel {
                    Activity = activeLink == GridLink.Mvc ? ActivityState.active : ActivityState.inactive,
                    Text = $"MVC grid",
                    Icon = new FaIcon("border-all"),
                    ControllerName = controllerName,
                    ControllerAction = currentAction,
                    RouteParams = "mvc"
                }
            };

            return gridMenuLinks;
        }
    }
}
