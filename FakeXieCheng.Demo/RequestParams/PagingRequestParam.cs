using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.RequestParams
{
    public class PagingRequestParam
    {
        private int pageNumber = 1;
        private int pageSize = 5;

        public int PageNumber
        {
            get { return pageNumber; }
            set
            {
                if (pageNumber > 0)
                {
                    pageNumber = value;
                }
            }
        }

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (pageSize > 0 && pageSize <= 50)
                {
                    pageSize = value;
                }
            }
        }

    }
}
