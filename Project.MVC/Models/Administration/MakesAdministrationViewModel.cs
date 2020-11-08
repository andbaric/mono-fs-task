using Project.MVC.Models.Shared;
using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.MVC.Models.Administration
{
    public class MakesAdministrationViewModel
    {
        public MakesAdministrationViewModel(IQueryable<VehicleMake> data)
        {
            AdministrationNav = new Navigation(
                new List<NavLink>
                {
                    new NavLink { Activity = Enums.ActivityState.active, Text = "Makes administration", Icon = "industry", ControllerName = "administration", ControllerAction = "makes" },
                    new NavLink { Text = "Models administration", Icon = "car", ControllerName = "administration", ControllerAction = "models" }
                }
            ); ;
            Data = data;
        }

        public Navigation AdministrationNav { get; set; }
        public IQueryable<VehicleMake> Data { get; }
    }
}
