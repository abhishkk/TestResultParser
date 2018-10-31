using System.Threading.Tasks;
using Agent.Plugins.TestResultParser.TestResult.Models;

namespace Agent.Plugins.TestResultParser.Gateway
{
    interface ITestReportingGateway
    {
        /* End point to publish Test run to Pipeline service */
        Task PublishTestRunAsync(ITcmTestRun tcmTestRun);
    }
}
