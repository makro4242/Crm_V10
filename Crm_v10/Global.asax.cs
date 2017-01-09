using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Crm_v10
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static string connection = "";
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }
        public void Session_Start(object sender, EventArgs e)
        {
            Session.Add(" KullaniciID", new int());
            Session.Add(" KullaniciAd", "");
        }
    }
}
