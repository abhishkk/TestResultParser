using Agent.Plugins.TestResultParser.TestResult.Models;

namespace Agent.Plugins.TestResultParser.TestResult.Converter
{
    interface ITestRunToTcmRunConverter
    {
        void Convert(TestRun testRun, ITcmTestRun tcmTestRun);
    }
}
