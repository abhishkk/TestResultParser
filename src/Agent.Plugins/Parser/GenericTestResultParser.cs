namespace Agent.Plugins.TestResultParser.Parser
{
    using System;
    using System.Threading;
    using Agent.Plugins.TestResultParser.Parser.Interfaces;

    public class GenericTestResultParser : ITestResultParser
    {
        public void ParseData(string data)
        {
            Console.WriteLine("Receiving data: " + data);
            Thread.Sleep(1000);
        }
    }
}
