using System.Threading.Tasks;
using Agent.Plugins.TestResultParser.TestResult.Models;
using Agent.Plugins.TestResultParser.TestResult.Models.Interfaces;

namespace Agent.Plugins.TestResultParser.Gateway.Interfaces
{
    interface ITestReportingGateway
    {
        /* End point to publish Test run to Pipeline service */
        Task PublishTestRunAsync(ITcmTestRun tcmTestRun);
    }
}
