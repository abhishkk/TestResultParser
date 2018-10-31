using Agent.Plugins.TestResultParser.Parser.Interfaces;
using System;
using System.Threading;

namespace Agent.Plugins.TestResultParser.Parser
{
    public class GenericTestResultParser : ITestResultParser
    {
        public void ParseData(string data)
        {
            Console.WriteLine("Receiving data: " + data);
            Thread.Sleep(1000);
        }
    }
}
