// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.TestResultParser.TestRunManger
{
    using Agent.Plugins.TestResultParser.Publish.Interfaces;
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using Agent.Plugins.TestResultParser.ConflictResolver;
    using Agent.Plugins.TestResultParser.ConflictResolver.Interfaces;

    /// <inheritdoc/>
    public class TestRunManger : ITestRunManager
    {
        ITestRunPublisher publisher;

        ITestRunConflictResolver conflictResolver;

        /// <summary>
        /// Construct the TestRunManger
        /// </summary>
        /// <param name="testRunPublisher"></param>
        public TestRunManger(ITestRunPublisher testRunPublisher)
            : this(testRunPublisher, new TestRunConflictResolver())
        {
        }

        /// <summary>
        /// Construct the TestRunManger
        /// </summary>
        /// <param name="testRunPublisher"></param>
        public TestRunManger(ITestRunPublisher testRunPublisher, ITestRunConflictResolver testRunConflictResolver)
        {
            publisher = testRunPublisher;
            conflictResolver = testRunConflictResolver;
        }

        /// <inheritdoc/>
        public void Publish(TestRun testRun)
        {
            var validatedTestRun = conflictResolver.Resolve(testRun);
            publisher.Publish(validatedTestRun);
        }
    }
}
