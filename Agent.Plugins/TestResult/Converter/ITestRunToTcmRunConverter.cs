using Agent.Plugins.TestResultParser.TestResult.Models;

namespace Agent.Plugins.TestResultParser.TestResult.Converter
{
    interface ITestRunToTcmRunConverter
    {
        void Convert(ITestRun testRun, ITcmTestRun tcmTestRun);
    }
}
