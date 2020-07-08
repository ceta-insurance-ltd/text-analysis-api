namespace TextAnalysisApi.Models
{
    public class LineResult
    {
        public int LineNumber { get; set; }

        public LetterResult[] LetterOccurrences { get; set; }
    }
}