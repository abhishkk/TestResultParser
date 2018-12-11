using Agent.Plugins.Log.TestResultParser.Contracts;

namespace Agent.Plugins.Log.TestResultParser.Parser
{
    /// <summary>
    /// Base class for all state context objects
    /// </summary>
    public abstract class TestResultParserStateContext
    {
        public abstract void Initialize(TestRun testRun);

        // Extract out common properties here when enough parsers have been authored
    }
}
