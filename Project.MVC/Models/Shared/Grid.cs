using System.Collections.Generic;

namespace Project.MVC.Models.Shared
{
    public abstract class Grid<TSource>
    {
        public IEnumerable<TSource> DataSource { get; set; }
    }
}
