using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    interface IDiagnosticDataCollector
    {
        /* Publish diagnostic data to Pipeline service (eg: Build) */
        Task PublishDiagnosticDataAsync();
    }
}
