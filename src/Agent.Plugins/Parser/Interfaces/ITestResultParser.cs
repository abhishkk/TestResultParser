namespace Agent.Plugins.TestResultParser.Parser.Interfaces
{
    public interface ITestResultParser
    {
        /* Parse task output line by line to detect the test result */
        void ParseData(string data);
    }
}
