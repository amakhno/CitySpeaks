using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public static class UserPagingHelpers
    {
        public static MvcHtmlString UserPageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int page = pagingInfo.CurrentPage;
            TagBuilder tag;
            if (page > 1)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(page - 1));
                tag.InnerHtml = "Назад";
                result.Append(tag.ToString());
            }
            result.Append(String.Format(" Страница: {0} ", page.ToString()));
            if (page < pagingInfo.TotalPages)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(page + 1));
                tag.InnerHtml = "Вперед";
                result.Append(tag.ToString());
                
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}