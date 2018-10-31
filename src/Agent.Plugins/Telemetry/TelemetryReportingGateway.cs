using System;
using System.Threading.Tasks;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;

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
