using CitySpeaks.Domain.Models;
using CitySpeaks.WebUI.Models.Helpers;
using System.Collections.Generic;

namespace CitySpeaks.WebUI.Models.User
{
    public class UserNewsList
    {
        public IEnumerable<News> News { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}