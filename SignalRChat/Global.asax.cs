using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SignalRChat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            try
            {
                var windowsDir = Environment.GetEnvironmentVariable("windir");
                var command = System.IO.Path.Combine(windowsDir, @"System32\inetsrv\appcmd.exe set config / section:system.webserver / serverRuntime / appConcurrentRequestLimit:10000");
                var command1 = System.IO.Path.Combine(windowsDir, @"System32\inetsrv\appcmd.exe");

                var processStartInfo = new ProcessStartInfo()
                {
                    Arguments = "set config / section:system.webserver / serverRuntime / appConcurrentRequestLimit:10000",
                    FileName = command1,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
