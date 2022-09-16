using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Helper
{
    public class PagedList<T>
    {
        public List<T> DataItems { get; set; } = new List<T>();
        private PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            this.DataItems.AddRange(items);
        }

        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasPrevios => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var items=new List<T>();
            if (pageNumber == 0)
            {
                items = source.Skip(0).Take(pageSize).ToList();
            }
            else
            {
                items = source.Skip((pageNumber )* pageSize).Take(pageSize).ToList();
            }
           
          
            return new PagedList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
