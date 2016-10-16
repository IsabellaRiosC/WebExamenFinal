using System;
using System.Web;
using System.Web.Mvc;

namespace WebExamenFinal.Helpers
{
    public static class CustomHelper
    {
        public static IHtmlString GetDate(this HtmlHelper helper, string text)
        {            
            return new HtmlString($"<h1>{text} - {DateTime.Now.ToShortDateString()}</h1>");
        }
    }
}