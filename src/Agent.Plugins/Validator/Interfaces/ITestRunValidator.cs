// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.TestResultParser.Validator.Interfaces
{
    using Agent.Plugins.TestResultParser.TestResult.Models;

    /// <summary>
    /// Validates if the TestRun data is consistent
    /// </summary>
    public interface ITestRunValidator
    {
        /// <summary>
        /// Validates and returns a valid TestRun
        /// </summary>
        /// <param name="testRun">Input Test run information</param>
        /// <returns>Valid Test run</returns>
        TestRun Validate(TestRun testRun);
    }
}
