using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebServices
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "InsertProduct",
                url: "insert_product",
                defaults: new
                {
                    controller = "MMProduct",
                    action = "Insert"
                }
             );

            routes.MapRoute(
                name: "DeleteProduct",
                url: "delete_product",
                defaults: new
                {
                    controller = "MMProduct",
                    action = "Delete"
                }
             );








            routes.MapRoute(
                name: "UpdateUser",
                url: "update_user",
                defaults: new
                {
                    controller = "MMUser",
                    action = "Update"
                }
             );

            routes.MapRoute(
                name: "CreateUser",
                url: "create_user",
                defaults: new
                {
                    controller = "MMUser",
                    action = "Create"
                }
             );

            routes.MapRoute(
                name: "ClientsReport",
                url: "report_user",
                defaults: new
                {
                    controller = "MMUser",
                    action = "Reports"
                }
             );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
