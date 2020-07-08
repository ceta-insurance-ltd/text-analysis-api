using Microsoft.AspNetCore.Mvc;
using TextAnalysisApi.Models;
using TextAnalysisApi.Services;

namespace TextAnalysisApi.Controllers
{
    [ApiController]
    [Route("api/analyse")]
    public class TextAnalysisController : ControllerBase
    {
        private readonly TextAnalyser _textAnalyser;

        public TextAnalysisController(TextAnalyser textAnalyser)
        {
            _textAnalyser = textAnalyser;
        }

        [HttpPost]
        public IActionResult AnalyseText(TextAnalysisRequest textAnalysisRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (textAnalysisRequest.Text.Length > 1000)
            {
                return new StatusCodeResult(404);
            }

            var analyser = new TextAnalyser();
            var result = analyser.Analyse(textAnalysisRequest.Text).Result;
            return new OkObjectResult(result);
        }
    }
}