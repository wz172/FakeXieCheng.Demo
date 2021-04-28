using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Util
{
    public class PagingList<T>:List<T>
    {
        public int TotalPage { get;private set; }
        public int TotalCount { get; private set; }
        public int CurrentPageNu { get; private set; }
        public bool HasPrevious => CurrentPageNu > 1;
        public bool HasNextPage => CurrentPageNu < TotalCount;

        public int PageSize { get; private set; }

        public PagingList(int pageNu,int pageSize,List<T> ts,int totalCount)
        {
            this.CurrentPageNu = pageNu;
            this.PageSize = pageSize;
            AddRange(ts);
            this.TotalCount = totalCount;
            TotalPage = (int)Math.Ceiling(totalCount * 1.0 / pageSize);
        }
        public async static Task<PagingList<T>> CreatePagelistAsync(int pageNu, int pageSize, IQueryable<T> queryable)
        {
            queryable = queryable.Skip((pageNu - 1) * pageSize).Take(pageSize);
            var ls = await queryable.ToListAsync();
            int totalCount = await queryable.CountAsync();
            var paging = new PagingList<T>(pageNu, pageSize, ls, totalCount);
            return paging;
        }
    }
}
