using Project.MVC.Models.Shared;
using Project.MVC.Models.Shared.Enums;
using System.Collections.Generic;

namespace Project.MVC.Models.ViewModels.Administration.Grid
{
    public class GridViewModel<TSource> : Grid<TSource>
    {
        public GridViewModel(IEnumerable<TSource> dataSource, string currentAction, string gridView)
        {
            Type = SetGridType(gridView);
            Menu = SetMenu(currentAction, gridView);
            DataSource = dataSource;
        }

        public GridMenuViewModel Menu { get; set; }
        public GridType Type { get; set; }

        public GridMenuViewModel SetMenu(string currentAction, string gridView)
        {
            var activeLink = gridView == "mvc" ? GridLink.Mvc : GridLink.Custom;

            return new GridMenuViewModel(currentAction, activeLink);
        }

        public GridType SetGridType(string gridView)
        {
            var gridType = gridView == "mvc" ? GridType.Mvc : GridType.Custom;

            return gridType;
        }
    }
}
