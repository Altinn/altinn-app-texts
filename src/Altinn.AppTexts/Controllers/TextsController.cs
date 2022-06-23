using Microsoft.AspNetCore.Mvc;

namespace Altinn.AppTexts.Controllers
{
    [ApiController]
    [Route("texts/api/v1/texts")]
    public class TextsController : ControllerBase
    {
        
        public TextsController()
        {
        }

        public async Task<ActionResult<Dictionary<string, string>>> Get()
        {
            var texts = new Dictionary<string, string>();

            return texts;
        }
    }
}