using System.Web.Mvc;

namespace WebExamenFinal.Areas.Maestro
{
    public class MaestroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Maestro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Maestro_default",
                "Maestro/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}