using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExamenFinal.Filters
{
    public class AuditControl: ActionFilterAttribute
    {

        private static ILog Log { get; set; }

        ILog log = LogManager.GetLogger
        (
          System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Message(filterContext, "OnActionExecuted");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            /* Message(
                 filterContext.RouteData.Values["controller"].ToString(),
                 filterContext.RouteData.Values["action"].ToString(), "OnResultExecuted");*/
            Message(filterContext, "OnResultExecuted");
        }
        
        /*private void Message(string controller,string action,string filterMethod)
        {
            log.Info($"{controller} in action {action} on {filterMethod}");
        }*/

        private void Message(ControllerContext context, string filterMethod)
        {
            var controller = context.RouteData.Values["controller"].ToString();
            var action = context.RouteData.Values["action"].ToString();
            log.Info($"{controller} in action {action} on {filterMethod}");
        }

    }
}