// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Agent.Plugins.TestResultParser.Client;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using TestRun = Agent.Plugins.TestResultParser.TestResult.Models.TestRun;

namespace Agent.Plugins.TestResultParser.Publish
{
    public class PipelineTestRunPublisher : ITestRunPublisher
    {
        public PipelineTestRunPublisher(ClientFactory clientFactory)
        {
            _httpClient = clientFactory.GetClient<TestManagementHttpClient>();
        }

        public void Publish(TestRun testRun)
        {
            throw new System.NotImplementedException();
        }

        private TestManagementHttpClient _httpClient;
    }
}
