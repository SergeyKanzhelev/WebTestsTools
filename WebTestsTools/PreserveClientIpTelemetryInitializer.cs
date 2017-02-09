using System;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace WebTestsTools
{
    internal class PreserveClientIpTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (!string.IsNullOrEmpty(telemetry.Context.Location.Ip))
            {
                telemetry.Context.Properties["ClientIP"] = telemetry.Context.Location.Ip;
            }
        }
    }
}