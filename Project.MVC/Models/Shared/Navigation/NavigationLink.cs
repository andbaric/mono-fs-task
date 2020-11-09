using Project.MVC.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Models.Shared.Navigation
{
    public class NavigationLink
    {
        private string _iconDefault = "question";

        public ActivityState Activity { get; set; }
        public string Icon { get { return _iconDefault; } set { _iconDefault = value; } }
        public string Text { get; set; }
        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
    }
}
