using System;
using Agent.Plugins.TestResultParser.TestResult.Converter.Interfaces;
using Agent.Plugins.TestResultParser.TestResult.Models;
using Agent.Plugins.TestResultParser.TestResult.Models.Interfaces;

namespace Agent.Plugins.TestResultParser.TestResult.Converter
{
    class TestRunToTcmRunConverter : ITestRunToTcmRunConverter
    {
        public void Convert(TestRun testRun, ITcmTestRun tcmTestRun)
        {
            if (testRun == null)
            {
                throw new ArgumentNullException(nameof(testRun));
            }

            throw new NotImplementedException();
        }
    }
}
