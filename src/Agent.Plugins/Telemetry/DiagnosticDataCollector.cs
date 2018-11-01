using System;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;
using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    public class DiagnosticDataCollector : IDiagnosticDataCollector
    {
        private static IDiagnosticDataCollector instance;

        /// <summary>
        /// Gets the singleton instance of diagnostics data collector.
        /// </summary>
        public static IDiagnosticDataCollector Instance
        {
            get => instance ?? (instance = new DiagnosticDataCollector());
            internal set => instance = value;
        }

        /// <inheritdoc />
        public void Error(string error)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Info(string text)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task PublishDiagnosticDataAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Verbose(string text)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Warning(string text)
        {
            throw new NotImplementedException();
        }
    }
}
