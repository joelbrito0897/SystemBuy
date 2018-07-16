using BuySystem.Models.Const;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ventas.Models;

namespace Ventas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApplicationDbContext db = new ApplicationDbContext();

            //Crear los Roles
            CreateRoles(db);
            db.Dispose();
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!roleManager.RoleExists(RoleName.Admin))
            {
                roleManager.Create(new IdentityRole(RoleName.Admin));
            }
            if (!roleManager.RoleExists(RoleName.Vendedor))
            {
                roleManager.Create(new IdentityRole(RoleName.Vendedor));
            }
            if (!roleManager.RoleExists(RoleName.User))
            {
                roleManager.Create(new IdentityRole(RoleName.User));
            }
        }
    }
}
