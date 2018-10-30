using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    interface ITelemetryReportingGateway
    {
        /* Publish telemetry event to pipeline telemetry service */
        Task PublishTelemetryAsync(TelemetryEvent telemetry);
    }
}
