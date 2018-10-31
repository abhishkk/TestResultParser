namespace Agent.Plugins.TestResultParser.ParserConfig
{
    interface ITestRunnerParserConfiguration
    {
        /* Pattern to detect successful/passed test result */
        string GetSuccessResultPattern();
        /* Pattern to detect failed test result */
        string GetFailureResultPattern();
        /* Pattern to detect test summary */
        string GetTestSummaryPattern();
    }
}
