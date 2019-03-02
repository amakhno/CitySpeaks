using CitySpeaks.WebUI.Models.Admin;
using CitySpeaks.WebUI.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Text;

namespace CitySpeaks.WebUI.Helpers.Html
{
    public static class AdminPagingHelpers
    {
        public static IHtmlContent AdminPageLinks(this IHtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder containerTag = new TagBuilder("div");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                if (i == pagingInfo.CurrentPage)
                {
                    tagBuilder.AddCssClass("selected");
                    tagBuilder.AddCssClass("btn-primary");
                    containerTag.InnerHtml.Append(tagBuilder.ToString());
                    continue;
                }
                tagBuilder.MergeAttribute("href", pageUrl(i));
                tagBuilder.AddCssClass("btn btn-default");
                containerTag.InnerHtml.Append(tagBuilder.ToString());
            }
            return containerTag;
        }
    }
}