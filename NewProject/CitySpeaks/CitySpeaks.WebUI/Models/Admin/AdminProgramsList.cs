using CitySpeaks.WebUI.Models.Helpers;
using System.Collections.Generic;

namespace CitySpeaks.WebUI.Models.Admin
{
    public class AdminProgramsList
    {
        public IEnumerable<Domain.Models.Program> Programs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}