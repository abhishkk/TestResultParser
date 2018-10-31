using System;
using Agent.Plugins.TestResultParser.TestResult.Models;
using Agent.Plugins.TestResultParser.TestResult.Models.Interfaces;

namespace Agent.Plugins.TestResultParser.TestResult.Storage
{
    class TestResultCache : ITestResultCache
    {
        public void AddTestResult(string parserName, ITestResult testResult)
        {
            throw new NotImplementedException();
        }

        public void AddTestSummary(string parserName, ITestSummary testSummary)
        {
            throw new NotImplementedException();
        }

        public void PublishTestRun(string parserName)
        {
            throw new NotImplementedException();
        }
    }
}
