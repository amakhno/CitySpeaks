using CitySpeaks.Domain.Models;
using CitySpeaks.WebUI.Models.Helpers;
using System.Collections.Generic;

namespace CitySpeaks.WebUI.Models.Admin
{
    public class AdminCategoryList
    {
        public IEnumerable<ProgramCategory> Category { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}