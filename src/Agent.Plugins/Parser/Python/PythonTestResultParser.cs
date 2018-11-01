using System;
using Agent.Plugins.TestResultParser.Parser.Interfaces;
using Agent.Plugins.TestResultParser.Telemetry;
using Agent.Plugins.TestResultParser.Telemetry.Interfaces;

namespace Agent.Plugins.TestResultParser.Parser.Python
{
    /// <summary>
    /// Python test result parser.
    /// </summary>
    public class PythonTestResultParser : ITestResultParser
    {
        private ITelemetryDataCollector telemetryDataCollector;
        private IDiagnosticDataCollector diagnosticDataCollector;
        private ParserState state;
        private IResultParser testResultParser;
        private IRunSummaryParser testRunSummaryParser;

        public PythonTestResultParser() : this(TelemetryDataCollector.Instance, DiagnosticDataCollector.Instance, new ResultParser(), new RunSummaryParser())
        {
        }

        public PythonTestResultParser(ITelemetryDataCollector telemetryCollector, IDiagnosticDataCollector diagnosticsCollector, IResultParser testResultParser, IRunSummaryParser testRunSummaryParser)
        {
            this.telemetryDataCollector = telemetryCollector;
            this.diagnosticDataCollector = diagnosticsCollector;
            this.testResultParser = testResultParser;
            this.testRunSummaryParser = testRunSummaryParser;
            this.state = ParserState.Waiting;
        }

        /// <summary>
        /// Parses input data to detect python test result.
        /// </summary>
        /// <param name="data">Data to be parsed.</param>
        public void ParseData(string data)
        {
            throw new NotImplementedException();
        }]
    }
}
