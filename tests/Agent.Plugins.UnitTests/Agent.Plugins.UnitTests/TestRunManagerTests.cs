// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.UnitTests
{
    using Agent.Plugins.TestResultParser.Publish.Interfaces;
    using Agent.Plugins.TestResultParser.Telemetry.Interfaces;
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using Agent.Plugins.TestResultParser.TestRunManger;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using TestResult = Agent.Plugins.TestResultParser.TestResult.Models.TestResult;

    [TestClass]
    public class TestRunManagerTests
    {
        private TestRunManager testRunManager;
        private Mock<ITestRunPublisher> publisher;
        private Mock<IDiagnosticDataCollector> diagnosticDataCollector;
        private Mock<ITelemetryDataCollector> telemetryDataCollector;

        TestRunSummary invalidSummary = new TestRunSummary
        {
            TotalTests = 4,
            TotalPassed = 2,
            TotalFailed = 3
        };

        TestRunSummary validSummary = new TestRunSummary
        {
            TotalTests = 5,
            TotalPassed = 2,
            TotalFailed = 1,
            TotalExecutionTime = new System.TimeSpan(0, 0, 0, 1, 50)
        };

        public TestRunManagerTests()
        {
            this.publisher = new Mock<ITestRunPublisher>();
            this.diagnosticDataCollector = new Mock<IDiagnosticDataCollector>();
            this.telemetryDataCollector = new Mock<ITelemetryDataCollector>();
            this.testRunManager = new TestRunManager(publisher.Object, diagnosticDataCollector.Object, telemetryDataCollector.Object);
        }

        [TestMethod]
        public void PublishForNullTestRunShouldReturnNull()
        {
            this.testRunManager.Publish(null);
            this.diagnosticDataCollector.Verify(x => x.Error("TestRunManger.ValidateAndPrepareForPublish : TestRun or TestRunSummary is null."));
        }

        [TestMethod]
        public void PublishForTestRunWithNullTestSummaryShouldReturnNull()
        {
            TestRun testRun = new TestRun();
            this.testRunManager.Publish(testRun);
            this.diagnosticDataCollector.Verify(x => x.Error("TestRunManger.ValidateAndPrepareForPublish : TestRun or TestRunSummary is null."));
        }

        [TestMethod]
        public void PublishForTestRunWithInvalidTestSummaryShouldReturnNull()
        {
            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.invalidSummary;

            this.testRunManager.Publish(testRun);

            this.diagnosticDataCollector.Verify(x=>x.Error("TestRunManger.ValidateAndPrepareForPublish : Total test count reported is less than sum of passed and failed tests."));
        }

        [TestMethod]
        public void PublishForTestRunWithNoResultsAndValidTestSummaryShouldReturnTestRun()
        {
            TestRun testRun = new TestRun() { TestRunSummary = this.validSummary };

            this.testRunManager.Publish(testRun);

            this.publisher.Verify(x => x.Publish(testRun), Times.Once);
        }

        [TestMethod]
        public void PublishForTestRunWithMismatchedFailedTestResultsAndTestSummaryShouldReturnTestRunWithFailedTestsCleared()
        {
            TestResult passedTest = new TestResult() { Name = "Test1", Outcome = TestOutcome.Passed };
            TestResult passedTest2 = new TestResult() { Name = "Test2", Outcome = TestOutcome.Passed };
            TestResult failedTest = new TestResult() { Name = "FailingTest", Outcome = TestOutcome.Failed };
            TestResult failedTest2 = new TestResult() { Name = "FailingTest2", Outcome = TestOutcome.Failed };

            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.validSummary;
            testRun.PassedTests = new List<TestResult>() { passedTest, passedTest2};
            testRun.FailedTests = new List<TestResult>() { failedTest, failedTest2 };

            TestRun resultTestRun = null;
            this.publisher.Setup(x => x.Publish(It.IsAny<TestRun>())).Callback((TestRun t) => resultTestRun = t);

            this.testRunManager.Publish(testRun);

            this.diagnosticDataCollector.Verify(x => x.Warning("TestRunManger.ValidateAndPrepareForPublish : Failed test count does not match the Test summary."));
            
            Assert.AreEqual(testRun.PassedTests, resultTestRun.PassedTests);
            Assert.AreEqual(null, resultTestRun.FailedTests);
            Assert.AreEqual(this.validSummary, resultTestRun.TestRunSummary);
        }

        [TestMethod]
        public void ResolveForTestRunWithMisMatchedPassedTestResultsAndTestSummaryShouldReturnTestRunWithPassedTestsCleared()
        {
            TestResult passedTest = new TestResult() { Name = "Test1", Outcome = TestOutcome.Passed };
            TestResult failedTest = new TestResult() { Name = "FailingTest", Outcome = TestOutcome.Failed };

            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.validSummary;
            testRun.PassedTests = new List<TestResult>() { passedTest };
            testRun.FailedTests = new List<TestResult>() { failedTest };

            TestRun resultTestRun = null;
            this.publisher.Setup(x => x.Publish(It.IsAny<TestRun>())).Callback((TestRun t) => resultTestRun = t);

            this.testRunManager.Publish(testRun);

            this.diagnosticDataCollector.Verify(x => x.Warning("TestRunManger.ValidateAndPrepareForPublish : Passed test count does not match the Test summary."));

            Assert.AreEqual(null, resultTestRun.PassedTests);
            Assert.AreEqual(testRun.FailedTests, resultTestRun.FailedTests);
            Assert.AreEqual(this.validSummary, resultTestRun.TestRunSummary);
        }

        [TestMethod]
        public void ResolveForTestRunWithNoFailedTestResultsAndTestSummaryContainingFailuresShouldReturnTestRunWithFailedTestsCleared()
        {
            TestResult passedTest = new TestResult() { Name = "Test1", Outcome = TestOutcome.Passed };
            TestResult passedTest2 = new TestResult() { Name = "Test2", Outcome = TestOutcome.Passed };

            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.validSummary;
            testRun.PassedTests = new List<TestResult>() { passedTest, passedTest2 };

            TestRun resultTestRun = null;
            this.publisher.Setup(x => x.Publish(It.IsAny<TestRun>())).Callback((TestRun t) => resultTestRun = t);

            this.testRunManager.Publish(testRun);

            Assert.AreEqual(testRun.PassedTests, resultTestRun.PassedTests);
            Assert.AreEqual(null, resultTestRun.FailedTests);
            Assert.AreEqual(this.validSummary, resultTestRun.TestRunSummary);
        }

        [TestMethod]
        public void ResolveForTestRunWithValidTestResultsAndTestSummaryShouldReturnTestRun()
        {
            TestResult passedTest = new TestResult() { Name = "Test1", Outcome = TestOutcome.Passed };
            TestResult passedTest2 = new TestResult() { Name = "Test2", Outcome = TestOutcome.Passed };
            TestResult failedTest = new TestResult() { Name = "FailingTest", Outcome = TestOutcome.Failed };

            TestRun testRun = new TestRun();
            testRun.PassedTests = new List<TestResult>() { passedTest, passedTest2 };
            testRun.FailedTests = new List<TestResult>() { failedTest };
            testRun.TestRunSummary = this.validSummary;

            TestRun resultTestRun = null;
            this.publisher.Setup(x => x.Publish(It.IsAny<TestRun>())).Callback((TestRun t) => resultTestRun = t);

            this.testRunManager.Publish(testRun);

            Assert.AreEqual(testRun, resultTestRun);
        }
    }
}
