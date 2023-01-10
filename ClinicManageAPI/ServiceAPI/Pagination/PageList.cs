using ClinicManageAPI.ServiceAPI.Interface;
using System.Linq;
using System.Net;

namespace ClinicManageAPI.ServiceAPI.Pagination
{
    public class PageList<T> : IPagination
    {
        public PageList(IQueryable<T> query, int? pageIndex = null, int? pageSize = null,
            string message = "Request Succesfully",
                                  HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Message = message;
            StatusCode = httpStatusCode;
            PageIndex = pageIndex <= 1 ? 1 : pageIndex ?? 1;
            PageSize = (!pageSize.HasValue || pageSize == 0)
                ? ApplicationSettings.DefaultValues.PageSize : pageSize.Value;
            TotalItems = query.Count();
            TotalPages = TotalItems / PageSize;
            HasPreviousPage = PageIndex > 0;
            HasNextPage = PageIndex < TotalPages;
            if (TotalItems % PageSize > 0)
            {
                TotalPages++;
            }

            Data = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToArray();
        }
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
        public int PageIndex { get; }

        public int PageSize { get; }
        public int TotalItems { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }

        public T[] Data { get; }

        public class ApplicationSettings
        {
            public class DefaultValues
            {
                public const string ShortDateFormat = "dd/MM/yyyy";
                public const int PageSize = 15;
            }
        }
    }
}
