using Microsoft.AspNetCore.Mvc;

namespace Crupt.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        public CreditCardController() { }

        [HttpGet]
        public string[] GetStrings()
        {
            var name = Environment.GetEnvironmentVariable("NAME");
            return [name!];
        }
    }
}
