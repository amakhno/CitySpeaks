using CitySpeaks.WebUI.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;

namespace CitySpeaks.WebUI.Helpers.Html
{
    public static class AdminPagingHelpers
    {
        public static IHtmlContent AdminPageLinks(this IHtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder containerTag = new TagBuilder("ul");
            containerTag.AddCssClass("pagination");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder liTag = new TagBuilder("li");
                TagBuilder aTag = new TagBuilder("a");
                aTag.InnerHtml.Append(i.ToString());
                aTag.AddCssClass("page");
                if (i == pagingInfo.CurrentPage)
                {
                    aTag.AddCssClass("active");
                } else
                {
                    aTag.MergeAttribute("href", pageUrl(i));
                }
                aTag.AddTo(liTag);
                liTag.AddTo(containerTag);
            }
            return containerTag;
        }
    }

    internal static class TagBuilderHelpers
    {
        public static void AddTo(this TagBuilder tagBuilder, TagBuilder destinationTag)
        {
            using (var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, HtmlEncoder.Default);
                destinationTag.InnerHtml.AppendHtml(writer.ToString());
            }
        }
    }
}