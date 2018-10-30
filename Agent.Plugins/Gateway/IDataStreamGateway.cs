using System.IO;
using System.Threading.Tasks;

namespace Agent.Plugins.TestResultParser.Gateway
{
    interface IDataStreamGateway
    {
        /* Register all parsers which needs to parse the task console stream */
        void Initialize();

        /* Process the task output stream */
        Task ProcessDataAsync(Stream stream);
    }
}
