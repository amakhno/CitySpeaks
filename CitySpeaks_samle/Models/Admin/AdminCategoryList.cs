using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models.Admin
{
    public class AdminCategoryList
    {
        public IEnumerable<ProgramCategories> Category { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}