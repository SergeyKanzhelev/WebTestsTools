using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebTestsTools
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new PreserveClientIpTelemetryInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
