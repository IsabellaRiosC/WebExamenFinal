using LightInject;
using System;
using System.Reflection;

namespace WebExamenFinal
{
    public partial class Startup
    {
        public void ConfigInjector()
         {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("WebExamenFinal.Model*.dll");
            container.RegisterAssembly("WebExamenFinal.Repository*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }


    }
}