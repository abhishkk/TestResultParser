namespace Agent.Plugins.TestResultParser.Telemetry.Interfaces
{
    public interface IDiagnosticDataCollector
    {
        /// <summary>
        /// Verbose diagnostics.
        /// </summary>
        /// <param name="text">Diagnostics text.</param>
        void Verbose(string text);

        /// <summary>
        /// Info diagnostics.
        /// </summary>
        /// <param name="text">Diagnostics text.</param>
        void Info(string text);

        /// <summary>
        /// Warning diagnostics.
        /// </summary>
        /// <param name="text">Diagnostics text.</param>
        void Warning(string text);

        /// <summary>
        /// Error diagnostics.
        /// </summary>
        /// <param name="text">Diagnostics text.</param>
        void Error(string error);
    }
}
