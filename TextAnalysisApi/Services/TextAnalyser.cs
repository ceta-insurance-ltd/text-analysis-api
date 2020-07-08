using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TextAnalysisApi.Models;

namespace TextAnalysisApi.Services
{
    public class TextAnalyser : ITextAnalyser
    {
        private const string LogPath = "C:\\text-analyser-logs";

        public async Task<TextAnalysisResult> Analyse(string text)
        {
            var logId = Guid.NewGuid();
            await LogAnalysis(logId, "input", text);

            var lines = text.Split("\r\n");

            var lines2 = lines.Select(l => new
            {
                LineNo = Array.FindIndex(lines, l2 => ReferenceEquals(l2, l)),
                Words = l.Split(" ")
            });

            var lines3 = lines2.Select(lww => new
            {
                lww.LineNo,
                ContainsA = lww.Words.Where(w => w.ToUpper().Contains('A') && w.ToUpper().IndexOf('A') == 1),
                ContainsE = lww.Words.Where(w => w.ToUpper().Contains('E') && w.ToUpper().IndexOf('E') == 1),
            });

            var lineResults = lines3
                .Where(lwc => lwc.ContainsA.Any() || lwc.ContainsE.Any())
                .Select(lwc => new LineResult
                {
                    LineNumber = lwc.LineNo,
                    LetterOccurrences = new[]
                    {
                        new LetterResult
                        {
                            Letter = "A",
                            Words = lwc.ContainsA.ToArray(),
                        },

                        new LetterResult
                        {
                            Letter = "B",
                            Words = lwc.ContainsE.ToArray()
                        }
                    }
                });

            var result = new TextAnalysisResult
            {
                LineResults = lineResults.ToArray()
            };

            await LogAnalysis(logId, "output", lineResults);

            return result;
        }

        private async Task LogAnalysis(Guid logId, string name, object logContent)
        {
            var logFileName = logId.ToString() + "." + name + ".txt";
            var logFilePath = LogPath + "\\" + logFileName;
            var file = File.OpenWrite(logFilePath);

            var json = JsonSerializer.Serialize(logContent);
            var bytes = Encoding.UTF8.GetBytes(json);
            await file.WriteAsync(bytes);
            file.Close();
        }

        public Task<TextAnalysisResult> Analyse(TextReader reader) =>
            throw new NotImplementedException();
    }
}