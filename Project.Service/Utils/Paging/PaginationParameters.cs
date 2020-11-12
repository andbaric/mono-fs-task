using Project.Service.Utils.Filtering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Utils.Paging
{
    public class PaginationParameters : IFilterable
    {
        private int _pageSize = 10;
        const int maxPageSize = 20;

        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string Name { get; set; }
        public string Abrv { get; set; }
        public string MakeName { get; set; }
    }
}
