using CitySpeaks.WebUI.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Text;

namespace CitySpeaks.WebUI.Helpers.Html
{
    public static class UserPagingHelpers
    {
        public static IHtmlContent UserPageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int page = pagingInfo.CurrentPage;
            TagBuilder tag = null;
            if (page > 1)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(page - 1));
                tag.InnerHtml.Append("Назад");
                result.Append(tag.ToString());
            }
            tag.InnerHtml.Append(string.Format(" Страница: {0} ", page.ToString()));
            if (page < pagingInfo.TotalPages)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(page + 1));
                tag.InnerHtml.Append("Вперед");
                result.Append(tag.ToString());

            }
            return tag;
        }
    }
}