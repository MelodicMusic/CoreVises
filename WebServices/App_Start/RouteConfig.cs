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

            // map Products
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
                name: "UpdateProduct",
                url: "update_product",
                defaults: new
                {
                    controller = "MMProduct",
                    action = "Update"
                }
             );

            routes.MapRoute(
                name: "Products",
                url: "products",
                defaults: new
                {
                    controller = "MMProduct",
                    action = "Products"
                }
             );

            routes.MapRoute(
               name: "RetrieveProduct",
               url: "retrieve_products",
               defaults: new
               {
                   controller = "MMProduct",
                   action = "Retrieve"
               }
            );






            //map Users


            routes.MapRoute(
               name: "Users",
               url: "users",
               defaults: new
               {
                   controller = "MMUser",
                   action = "Users"
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
            name: "DeleteUser",
            url: "delete_user",
            defaults: new
            {
                controller = "MMUser",
                action = "Delete"
            }
         );

            routes.MapRoute(
          name: "RetrieveUser",
          url: "retrieve_user",
          defaults: new
          {
              controller = "MMUser",
              action = "Retrieve"
          }
       );







            //map reports
            routes.MapRoute(
                name: "Reports",
                url: "reports",
                defaults: new
                {
                    controller = "MMUser",
                    action = "Reports"
                }
             );


            routes.MapRoute(
                name: "ClientsReport",
                url: "client_report",
                defaults: new
                {
                    controller = "MMUser",
                    action = "ClientReport"
                }
             );


            routes.MapRoute(
                name: "ProductsReport",
                url: "product_report",
                defaults: new
                {
                    controller = "MMUser",
                    action = "ProductsReports"
                }
             );


            routes.MapRoute(
               name: "Login",
               url: "login",
               defaults: new
               {
                   controller = "Home",
                   action = "Login"
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
