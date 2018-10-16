using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Stomatoloska.Webforms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ2NTdAMzEzNjJlMzMyZTMwQWpRbUFDRUp2VXIwSVFJNk9RNFNvVW1QNTdNcG5DRDlGMHp2MmdKNnllOD0=");
        }
    }
}