namespace Agent.Plugins.TestResultParser.Parser.Node.Mocha
{
    public enum MochaTestResultParserStateModel
    {
        ParsingTestResults,
        SummaryEncountered,
        ParsingStackTracesPostSummary
    }
}
