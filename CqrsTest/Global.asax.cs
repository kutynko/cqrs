using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CqrsTest
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
			AutofacConfig.Register();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteTable.Routes.MapMvcAttributeRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}