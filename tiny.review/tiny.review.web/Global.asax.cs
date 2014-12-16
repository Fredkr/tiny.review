using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using tiny.review.web.App_Start;

namespace tiny.review.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var containerSetup = new DiContainerSetup();
            containerSetup.BuildContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
