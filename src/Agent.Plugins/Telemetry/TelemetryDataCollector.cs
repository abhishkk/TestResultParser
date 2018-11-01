using System;
using System.Threading.Tasks;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    public class TelemetryDataCollector : ITelemetryDataCollector
    {
        private static ITelemetryDataCollector instance;

        /// <summary>
        /// Gets the singleton instance of telemetry data collector.
        /// </summary>
        public static ITelemetryDataCollector Instance {
            get => instance ?? (instance = new TelemetryDataCollector());
            internal set => instance = value;
        }

        /// <inheritdoc />
        public void AddProperty(string key, object value, bool aggregate = false)
        {
            throw new NotImplementedException();
        }
    }
}
