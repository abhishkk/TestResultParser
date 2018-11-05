// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.TestResultParser.ConflictResolver.Interfaces
{
    using Agent.Plugins.TestResultParser.TestResult.Models;

    /// <summary>
    /// Sanitizes the TestRun data
    /// </summary>
    public interface ITestRunConflictResolver
    {
        /// <summary>
        /// Resolves the conflicts for the TestRun
        /// </summary>
        /// <param name="testRun">Input Test run information</param>
        /// <returns>Sanitized test run</returns>
        TestRun Resolve(TestRun testRun);
    }
}
