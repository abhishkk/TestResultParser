using System;
using System.Collections.Generic;
using Agent.Plugins.TestResultParser.ParserConfig.Interfaces;

namespace Agent.Plugins.TestResultParser.ParserConfig
{
    class TestRunnerParserCache : ITestRunnerParserCache
    {
        public IEnumerable<ITestRunnerParserConfiguration> GetConfigurations()
        {
            throw new NotImplementedException();
        }
    }
}
