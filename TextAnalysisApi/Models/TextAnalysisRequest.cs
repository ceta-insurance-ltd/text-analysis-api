using System.ComponentModel.DataAnnotations;

namespace TextAnalysisApi.Models
{
    public class TextAnalysisRequest
    {
        [Required]
        public string Text { get; set; }
    }
}