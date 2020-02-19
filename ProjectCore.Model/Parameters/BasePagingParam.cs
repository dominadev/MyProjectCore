using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Model.Parameter
{
    public class BasePagingParam
    {
        public string SearchText { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortOrder { get; set; } = null;
        public string SortName { get; set; } = null;
        public int Offset { get { return (PageNumber - 1) * PageSize; } }
        public int Limit { get { return  PageSize; } }
        public int End { get { return (PageNumber) * PageSize; } }
    }
}
