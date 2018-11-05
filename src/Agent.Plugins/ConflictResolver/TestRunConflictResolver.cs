// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.TestResultParser.ConflictResolver
{
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using Agent.Plugins.TestResultParser.ConflictResolver.Interfaces;
    using System.Linq;

    /// <inheritdoc/>
    public class TestRunConflictResolver : ITestRunConflictResolver
    {
        /// <inheritdoc/>
        public TestRun Resolve(TestRun testRun)
        {
            if (testRun == null || testRun.TestRunSummary == null)
                return null;

            // TotalTests count should always be less than passed and failed test count combined
            if(testRun.TestRunSummary.TotalTests < testRun.TestRunSummary.TotalFailed + testRun.TestRunSummary.TotalPassed)
            {
                return null;
            }

            // Match the passed test count and clear the passed tests collection if mismatch occurs
            if(testRun.TestRunSummary.TotalPassed != testRun.PassedTests?.Count())
            {
                testRun.PassedTests = null;
            }

            // Match the failed test count and clear the failed tests collection if mismatch occurs
            if (testRun.TestRunSummary.TotalFailed != testRun.FailedTests?.Count())
            {
                testRun.FailedTests = null;
            }

            return testRun;
        }
    }
}
