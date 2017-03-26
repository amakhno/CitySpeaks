using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models
{
    public class AdminProgramsList
    {
        public IEnumerable<Programs> Programs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}