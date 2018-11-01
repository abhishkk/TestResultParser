using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Plugins.TestResultParser.Telemetry.Interfaces
{
    interface ITelemetryPublisher
    {
        /// <summary>
        /// Publish telemetry properties to pipeline telemetry service.
        /// </summary>
        /// <param name="properties">Properties to publish.</param>
        void PublishTelemetry(IDictionary<string, object> properties);
    }
}
