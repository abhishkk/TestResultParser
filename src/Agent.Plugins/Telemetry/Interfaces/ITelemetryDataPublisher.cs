namespace Agent.Plugins.TestResultParser.Telemetry.Interfaces
{
    using System.Collections.Generic;

    interface ITelemetryDataPublisher
    {
        /// <summary>
        /// Publish telemetry properties to pipeline telemetry service.
        /// </summary>
        /// <param name="properties">Properties to publish.</param>
        void PublishTelemetry(IDictionary<string, object> properties);
    }
}
