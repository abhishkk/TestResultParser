using System;
using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    class TelemetryReportingGateway : ITelemetryReportingGateway
    {
        public Task PublishTelemetryAsync(TelemetryEvent telemetry)
        {
            throw new NotImplementedException();
        }
    }
}
