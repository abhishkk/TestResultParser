using Microsoft.VisualStudio.Services.WebApi;

namespace Agent.Plugins.TestResultParser.Client
{
    interface IClientFactory
    {
        T GetClient<T>() where T : VssHttpClientBase;
    }
}
