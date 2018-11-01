using System;
using System.Collections.Generic;
using System.Text;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;

namespace Agent.Plugins.TestResultParser.Telemetry
{
    class TelemetryPublisher : ITelemetryPublisher
    {
        /// <inheritdoc />
        public void PublishTelemetry(IDictionary<string, object> properties)
        {
            throw new NotImplementedException();
        }
    }
}
