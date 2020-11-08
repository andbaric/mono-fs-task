using Project.MVC.Models.Enums;
using System.Collections.Generic;

namespace Project.MVC.Models.Shared
{
    public class Navigation
    {
        public Navigation(IEnumerable<NavLink> navLinks)
        {
            NavLinks = navLinks;
        }
        public IEnumerable<NavLink> NavLinks { get; set; }
    }

    public class NavLink
    {
        private ActivityState _activityDefaultState = ActivityState.inactive;

        private string _iconDefault = "question";

        public ActivityState Activity { get { return _activityDefaultState; } set { _activityDefaultState = value; } }
        public string Icon { get { return _iconDefault; } set { _iconDefault = value; } }
        public string Text { get; set; }
        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
    }
}
