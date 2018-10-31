using System;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;
using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    class DiagnosticDataCollector : IDiagnosticDataCollector
    {
        public Task PublishDiagnosticDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
