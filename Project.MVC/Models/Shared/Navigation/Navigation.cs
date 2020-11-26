using System.Collections.Generic;

namespace Project.MVC.Models.Shared.Navigation
{
    public abstract class Navigation<TLinkViewModel>
    {  
        public List<TLinkViewModel> Links { get; set; }
    }
}
