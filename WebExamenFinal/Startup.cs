using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebExamenFinal.Startup))]
namespace WebExamenFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           ConfigInjector();
        }
    }
}
