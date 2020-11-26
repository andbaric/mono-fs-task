using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.Shared.Navigation;

namespace Project.MVC.Models.ViewModels.Shared
{
    public class LinkViewModel : Link
    {
        public ActivityState Activity { get; set; }
        public string Text { get; set; }
        public FaIcon Icon { get; set; }
    }
}
