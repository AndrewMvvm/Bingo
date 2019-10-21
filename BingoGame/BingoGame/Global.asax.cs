using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NinjectDI;

namespace BingoGame
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule module = new BingoGameNinjectModule();
            var kernel = new StandardKernel(module);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
