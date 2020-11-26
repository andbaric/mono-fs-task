using Project.MVC.Models.ViewModels.Administration.Grid;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration
{
    public abstract class AdministrationViewModelBase<TSource>
    {
        public string Title { get; set; }
        public AdministrationNavigationViewModel Navigation { get; set; }
        public GridViewModel<TSource> Grid { get; set; }

        public abstract string SetTitle();
        public abstract AdministrationNavigationViewModel SetNavigation(string currentGridView);
        public abstract GridViewModel<TSource> SetGrid(IEnumerable<TSource> source, string currentAction, string gridView);
    }
}
