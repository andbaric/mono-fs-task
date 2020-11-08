using Project.MVC.Models.Shared;
using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.MVC.Models.Administration
{
    public class ModelsAdministrationViewModel
    {
        public ModelsAdministrationViewModel(IQueryable<VehicleModel> data)
        {
            AdministrationNav = new Navigation(
                new List<NavLink>
                {
                        new NavLink { Text = "Makes administration", Icon = "industry", ControllerName = "administration", ControllerAction = "makes" },
                        new NavLink { Activity = Enums.ActivityState.active, Text = "Models administration", Icon = "car", ControllerName = "administration", ControllerAction = "models" }
                }
            );
            Data = data;
        }

        public Navigation AdministrationNav { get; set; }
        public IQueryable<VehicleModel> Data { get; }
    }
}
