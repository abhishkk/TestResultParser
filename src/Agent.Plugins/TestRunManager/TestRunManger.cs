// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.TestResultParser.TestRunManger
{
    using Agent.Plugins.TestResultParser.Publish.Interfaces;
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using Agent.Plugins.TestResultParser.Validator;
    using Agent.Plugins.TestResultParser.Validator.Interfaces;

    /// <inheritdoc/>
    public class TestRunManger : ITestRunManager
    {
        ITestRunPublisher publisher;

        ITestRunValidator validator;

        /// <summary>
        /// Construct the TestRunManger
        /// </summary>
        /// <param name="testRunPublisher"></param>
        public TestRunManger(ITestRunPublisher testRunPublisher)
            : this(testRunPublisher, new TestRunValidator())
        {
        }

        /// <summary>
        /// Construct the TestRunManger
        /// </summary>
        /// <param name="testRunPublisher"></param>
        public TestRunManger(ITestRunPublisher testRunPublisher, ITestRunValidator testRunValidator)
        {
            publisher = testRunPublisher;
            validator = testRunValidator;
        }

        /// <inheritdoc/>
        public void Publish(TestRun testRun)
        {
            var validatedTestRun = validator.Validate(testRun);
            publisher.Publish(validatedTestRun);
        }
    }
}
