using System.Text.RegularExpressions;

namespace Agent.Plugins.TestResultParser.Parser.Node.Mocha
{
    public class MochaTestResultParserRegularExpressions
    {
        public static Regex PassedTestCaseMatcher { get; } = new Regex("  ΓêÜ (.*)");

        public static Regex PassedTestCaseOKMatcher { get; } = new Regex("    OK (.*)");

        public static Regex PassedTestCaseUnicodeMatcher { get; } = new Regex("  ✓ (.*)");

        public static Regex FailedTestCaseMatcher { get; } = new Regex("  [1-9][0-9]*\\) (.*)");

        public static Regex PassedTestsSummaryMatcher { get; } = new Regex("  (0|[1-9][0-9]*) passing \\(([1-9][0-9]*)(ms|s|m|h)\\)$");

        public static Regex FailedTestsSummaryMatcher { get; } = new Regex("  (0|[1-9][0-9]*) failing$");
    }
}
