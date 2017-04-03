using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models.Admin
{
    public class AdminCustomPageList
    {
        public IEnumerable<CustomPage> CustomPage { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}