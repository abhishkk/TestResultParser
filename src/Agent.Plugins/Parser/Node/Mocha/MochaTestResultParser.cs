namespace Agent.Plugins.TestResultParser.Parser.Node.Mocha
{
    using System.Collections.ObjectModel;
    using Agent.Plugins.TestResultParser.Parser.Interfaces;
    using Agent.Plugins.TestResultParser.Parser.Models;
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using TestResult = TestResult.Models.TestResult;

    public class MochaTestResultParser : ITestResultParser
    {
        public TestRun TestRun = new TestRun { };

        /// <inheritdoc/>
        public void Parse(LogLineData testResultsLine)
        {

        }
    }
}
