// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Agent.Plugins.Log.TestResultParser.Contracts;

namespace Agent.Plugins.Log.TestResultParser.Parser
{
    public class JestExpectingTestResults : JestParserStateBase
    {
        public override IEnumerable<RegexActionPair> RegexsToMatch { get; }

        /// <inheritdoc />
        public JestExpectingTestResults(ParserResetAndAttemptPublish parserResetAndAttemptPublish, ITraceLogger logger, ITelemetryDataCollector telemetryDataCollector)
            : base(parserResetAndAttemptPublish, logger, telemetryDataCollector)
        {
            RegexsToMatch = new List<RegexActionPair>
            {
                new RegexActionPair(JestRegexs.PassedTestCase, PassedTestCaseMatched),
                new RegexActionPair(JestRegexs.FailedTestCase, FailedTestCaseMatched),
                new RegexActionPair(JestRegexs.StackTraceStart, StackTraceStartMatched),
                new RegexActionPair(JestRegexs.SummaryStart, SummaryStartMatched),
                new RegexActionPair(JestRegexs.TestRunStart, TestRunStartMatched),
                new RegexActionPair(JestRegexs.FailedTestsSummaryIndicator, FailedTestsSummaryIndicatorMatched)
            };
        }

        private Enum PassedTestCaseMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            var testResult = PrepareTestResult(TestOutcome.Passed, match);
            jestStateContext.TestRun.PassedTests.Add(testResult);

            // Used for telemetry for identifying how many runs are using --verbose option
            jestStateContext.VerboseOptionEnabled = true;

            return JestParserStates.ExpectingTestResults;
        }

        private Enum FailedTestCaseMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            // Used for telemetry for identifying how many runs are using --verbose option
            jestStateContext.VerboseOptionEnabled = true;

            // TODO: Revisit if we even need to match these, expcept for telemtry no other use
            // No-op as we would like to pick up failed test cases in the stack traces state

            return JestParserStates.ExpectingTestResults;
        }

        private Enum StackTraceStartMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            // In non verbose mode console out appears as a failed test case
            // Only difference being it's not colored red
            if (match.Groups[RegexCaptureGroups.TestCaseName].Value == "Console")
            {
                return JestParserStates.ExpectingStackTraces;
            }

            var testResult = PrepareTestResult(TestOutcome.Failed, match);
            jestStateContext.TestRun.FailedTests.Add(testResult);

            return JestParserStates.ExpectingStackTraces;
        }

        private Enum SummaryStartMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            jestStateContext.LinesWithinWhichMatchIsExpected = 1;
            jestStateContext.NextExpectedMatch = "tests summary";

            return JestParserStates.ExpectingTestRunSummary;
        }

        private Enum TestRunStartMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            // Do we want to use PASS/FAIL information here?

            return JestParserStates.ExpectingTestResults;
        }

        private Enum FailedTestsSummaryIndicatorMatched(Match match, TestResultParserStateContext stateContext)
        {
            var jestStateContext = stateContext as JestParserStateContext;

            jestStateContext.FailedTestsSummaryIndicatorEncountered = true;

            return JestParserStates.ExpectingStackTraces;
        }
    }
}
