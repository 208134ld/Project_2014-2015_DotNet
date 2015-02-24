using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace p2groep11.Net
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Continents",
                url: "{SelectedYear}/Continents",
                defaults: new { controller = "Continent", action = "ListContinents", SelectedYear = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Countries",
                url: "{SelectedYear}/Continents/{continentId}/Countries",
                defaults: new { controller = "Continent", action = "ListCountries",
                                SelectedYear = UrlParameter.Optional,
                                continentId = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Locations",
                url: "{SelectedYear}/Continents/{continentId}/Countries/{countryId}/Locations",
                defaults: new
                {
                    controller = "Continent",
                    action = "ListLocations",
                    SelectedYear = UrlParameter.Optional,
                    continentId = UrlParameter.Optional,
                    countryId = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SchoolYear", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
