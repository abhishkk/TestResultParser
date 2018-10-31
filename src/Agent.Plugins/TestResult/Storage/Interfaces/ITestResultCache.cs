using Agent.Plugins.TestResultParser.TestResult.Models;

namespace Agent.Plugins.TestResultParser.TestResult.Storage
{
    interface ITestResultCache
    {
        /* Publish test result to Cache service to aggregate test results per runner */
        void AddTestResult(string parserName, Models.TestResult testResult);

        /* Publish test summary to Cache service per runner */
        void AddTestSummary(string parserName, TestSummary testSummary);

        /* Signal test cache storage to publish test run for runner with available details */
        void PublishTestRun(string parserName);
    }
}
