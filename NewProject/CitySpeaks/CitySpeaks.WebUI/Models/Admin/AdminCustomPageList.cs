using CitySpeaks.Domain.Models;
using CitySpeaks.WebUI.Models.Helpers;
using System.Collections.Generic;

namespace CitySpeaks.WebUI.Models.Admin
{
    public class AdminCustomPageList
    {
        public IEnumerable<CustomPage> CustomPage { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}