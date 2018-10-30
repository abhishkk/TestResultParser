using System;

namespace Agent.Plugins.TestResultParser.ParserConfig
{
    class TestRunnerParserConfiguration : ITestRunnerParserConfiguration
    {
        public string GetSuccessResultPattern()
        {
            throw new NotImplementedException();
        }

        public string GetFailureResultPattern()
        {
            throw new NotImplementedException();
        }

        public string GetTestSummaryPattern()
        {
            throw new NotImplementedException();
        }
    }
}
