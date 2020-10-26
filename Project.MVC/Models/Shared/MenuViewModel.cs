using System.Collections.Generic;

namespace Project.MVC.Models.Shared
{
    public class MenuViewModel
    {
        public IEnumerable<CardViewModel> MenuItems { get; set; }
    }
}
