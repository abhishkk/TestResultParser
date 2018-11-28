using System;
using Agent.Plugins.TestResultParser.TestResult.Models;

namespace Agent.Plugins.TestResultParser.TestResult.Storage
{
    class TestResultCache : ITestResultCache
    {
        public void AddTestResult(string parserName, Models.TestResult testResult)
        {
            throw new NotImplementedException();
        }

        public void AddTestSummary(string parserName, TestRunSummary testSummary)
        {
            throw new NotImplementedException();
        }

        public void PublishTestRun(string parserName)
        {
            throw new NotImplementedException();
        }
    }
}
