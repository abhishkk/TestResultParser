using System.Threading.Tasks;
using Agent.Plugins.TestResultParser.Gateway;
using Agent.Sdk;
using Pipelines = Microsoft.TeamFoundation.DistributedTask.Pipelines;

namespace Agent.Plugins.TestResultParser.Plugin
{
    public class AgentLogPlugin : IAgentLogPlugin
    {
        public AgentLogPlugin()
        {
            _inputDataParser = new DataStreamGateway();
            _inputDataParser.Initialize();
        }

        public Task ProcessAsync(IAgentLogPluginContext context, Pipelines.TaskStepDefinitionReference step, string output)
        {
            return _inputDataParser.ProcessDataAsync(output);
        }

        public Task FinalizeAsync(IAgentLogPluginContext context)
        {
            _inputDataParser.Complete();
            return Task.CompletedTask;
        }

        public string FriendlyName => "Test Result Log Parser";

        private readonly DataStreamGateway _inputDataParser;
    }
}
