namespace Agent.Plugins.TestResultParser.Parser.Node.Mocha
{
    using System.Collections.Generic;
    using Agent.Plugins.TestResultParser.Parser.Interfaces;
    using TestResult = TestResult.Models.TestResult;

    public class MochaTestResultParser : ITestResultParser
    {
        public List<TestResult> TestResults = new List<TestResult> { };

        public void ParseData(string data)
        {
            
        }
    }
}
