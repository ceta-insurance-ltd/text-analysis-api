using System.IO;
using System.Threading.Tasks;
using TextAnalysisApi.Models;

namespace TextAnalysisApi.Services
{
    public interface ITextAnalyser
    {
        Task<TextAnalysisResult> Analyse(string text);

        Task<TextAnalysisResult> Analyse(TextReader reader);
    }
}