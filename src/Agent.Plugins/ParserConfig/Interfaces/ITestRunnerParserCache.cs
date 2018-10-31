using System.Collections.Generic;

namespace Agent.Plugins.TestResultParser.ParserConfig.Interfaces
{
    interface ITestRunnerParserCache
    {
        /* Get parsing configurations which can be used by parsers to detect test result information */
        IEnumerable<ITestRunnerParserConfiguration> GetConfigurations();
    }
}
