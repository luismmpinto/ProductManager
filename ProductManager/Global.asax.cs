using System.Web.Http;
using System.Web.Routing;

namespace ProductManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteTable.Routes.MapHttpRoute(
                      name: "ProductsApi",
                      routeTemplate: "api/{controller}/{id}",
                      defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );
        }
    }
}