using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Learn_Programming_Malayalam.Helpers
{
     
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }
            public static int PageSize = 10;
            

        public PaginatedList(List<T> items, int count, int pageIndex)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                this.AddRange(items);
            }

            public bool HasPreviousPage
            {
                get
                {
                    return (PageIndex > 1);
                }
            }

            public bool HasNextPage
            {
                get
                {
                    return (PageIndex < TotalPages);
                }
            }

            public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex)
            {
                var count = await source.CountAsync();
                var items = await source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
                return new PaginatedList<T>(items, count, pageIndex);
            }
        }
    
}
