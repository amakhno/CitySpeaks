using CitySpeaks.WebUI.Models.Helpers;
using System.Collections.Generic;

namespace CitySpeaks.WebUI.Models.User
{
    public class UserProgramsList
    {
        public IEnumerable<Domain.Models.Program> Programs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}