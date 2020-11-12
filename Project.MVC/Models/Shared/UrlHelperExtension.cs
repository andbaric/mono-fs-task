using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models.Shared.Enums;
using Project.Service.Utils.Paging;

namespace Project.MVC.Models.Shared
{
    public static class UrlHelperExtensions
    {
        public static string GeneratePaginatedResourceUrl(this IUrlHelper urlHelper, string srcRoute, PaginationParameters paginationParameters, PagedResourceUrlType pagedResourceType)
        {

            switch(pagedResourceType)
            {
                case PagedResourceUrlType.PreviousPage:
                    return urlHelper.Link(srcRoute,
                            new
                            {
                                name = paginationParameters.Name,
                                pageSize = paginationParameters.PageSize,
                                pageNumber = paginationParameters.PageNumber - 1
                            });
                case PagedResourceUrlType.NextPage:
                    return urlHelper.Link(srcRoute,
                            new
                            {
                                name = paginationParameters.Name,
                                pageSize = paginationParameters.PageSize,
                                pageNumber = paginationParameters.PageNumber + 1
                            });
                default:
                    return urlHelper.Link(srcRoute,
                            new
                            {
                                name = paginationParameters.Name,
                                pageSize = paginationParameters.PageSize,
                                pageNumber = paginationParameters.PageNumber
                            }); ;
            }
        }
    }
}
