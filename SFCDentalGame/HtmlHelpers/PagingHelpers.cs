using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SFCDentalGame.Models;

namespace SFCDentalGame.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this HtmlHelper html, PaginationLogic paginationLogic, Func<int, string> pageUrl)
        {
            System.Text.StringBuilder result = new StringBuilder();
            for (int i = 1; i <= paginationLogic.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                //tag.InnerHtml = i.ToString();
                if (i == paginationLogic.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return HtmlString.Empty;
        }
    }
}
