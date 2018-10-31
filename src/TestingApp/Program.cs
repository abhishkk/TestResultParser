using System;
using System.IO;
using System.Text;
using Agent.Plugins.TestResultParser.Bus;
using Agent.Plugins.TestResultParser.Gateway;
using Agent.Plugins.TestResultParser.Parser;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
           new Program().Run();
        }

        private async void Run()
        {
            string path = @"C:\Users\nigurr.FAREAST\Desktop\sample.txt";
            var bus = new DataStreamGateway();

            // Automatic handler subscription
            bus.Subscribe<GenericTestResultParser>();
            
            
            using (var fileStream = File.OpenRead(path))
            {
                await bus.ProcessDataAsync(fileStream);
            }

            bus.Complete();
        }
    }
}
