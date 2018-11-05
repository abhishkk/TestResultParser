// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Agent.Plugins.UnitTests
{
    using Agent.Plugins.TestResultParser.TestResult.Models;
    using Agent.Plugins.TestResultParser.ConflictResolver;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TestResult = Agent.Plugins.TestResultParser.TestResult.Models.TestResult;

    [TestClass]
    public class TestRunConflictResolverTests
    {
        TestRunConflictResolver testRunConflictResolver;

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

        public TestRunConflictResolverTests()
        {
            testRunConflictResolver = new TestRunConflictResolver();
        }

        [TestMethod]
        public void ResolveForNullTestRunShouldReturnNull()
        {
            var resultTestRun = testRunConflictResolver.Resolve(null);

            Assert.IsNull(resultTestRun);
        }

        [TestMethod]
        public void ResolveForTestRunWithNullTestSummaryShouldReturnNull()
        {
            TestRun testRun = new TestRun();

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

            Assert.IsNull(resultTestRun);
        }

        [TestMethod]
        public void ResolveForTestRunWithInValidTestSummaryShouldReturnNull()
        {
            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.invalidSummary;

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

            Assert.IsNull(resultTestRun);
        }

        [TestMethod]
        public void ResolveForTestRunWithNoResultsAndValidTestSummaryShouldReturnTestRun()
        {
            TestRun testRun = new TestRun() { TestRunSummary = this.validSummary };

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

            Assert.AreEqual(testRun, resultTestRun);
        }

        [TestMethod]
        public void ResolveForTestRunWithMisMatchedFailedTestResultsAndTestSummaryShouldReturnTestRunWithFailedTestsCleared()
        {
            TestResult passedTest = new TestResult() { Name = "Test1", Outcome = TestOutcome.Passed };
            TestResult passedTest2 = new TestResult() { Name = "Test2", Outcome = TestOutcome.Passed };
            TestResult failedTest = new TestResult() { Name = "FailingTest", Outcome = TestOutcome.Failed };
            TestResult failedTest2 = new TestResult() { Name = "FailingTest2", Outcome = TestOutcome.Failed };

            TestRun testRun = new TestRun();
            testRun.TestRunSummary = this.validSummary;
            testRun.PassedTests = new List<TestResult>() { passedTest, passedTest2};
            testRun.FailedTests = new List<TestResult>() { failedTest, failedTest2 };

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

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

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

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

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

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

            var resultTestRun = testRunConflictResolver.Resolve(testRun);

            Assert.AreEqual(testRun, resultTestRun);
        }
    }
}
