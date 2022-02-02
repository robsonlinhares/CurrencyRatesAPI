using Microsoft.AspNetCore.Mvc;

namespace CurrencyRates.Api.Controllers.V1.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {       

        [HttpGet()]
        public string Get()
        {
            return "Rob";
        }
    }
}
