using System.Web.Mvc;
using System.Web.Routing;

namespace PSM_ConsultameV2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DatosAcademicos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
