namespace Agent.Plugins.TestResultParser.Telemetry.Interfaces
{
    interface IDiagnosticDataPublisher
    {
        /// <summary>
        /// Publish diagnostic data to Pipeline service (eg: Build)
        /// </summary>
        void PublishDiagnosticData();
    }
}
