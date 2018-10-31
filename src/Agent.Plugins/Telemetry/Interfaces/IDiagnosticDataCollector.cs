using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry.Interfaces
{
    interface IDiagnosticDataCollector
    {
        /* Publish diagnostic data to Pipeline service (eg: Build) */
        Task PublishDiagnosticDataAsync();
    }
}
