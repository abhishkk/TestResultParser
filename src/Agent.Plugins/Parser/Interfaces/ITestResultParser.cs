namespace Agent.Plugins.TestResultParser.Parser.Interfaces
{
    public interface ITestResultParser
    {
        /// <summary>
        /// Parse task output line by line to detect the test result
        /// </summary>
        /// <param name="data">Data to be parsed.</param>
        void ParseData(string data);
    }
}
