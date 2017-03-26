using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models
{
    public class AdminNewsList
    {
        public IEnumerable<News> News { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}