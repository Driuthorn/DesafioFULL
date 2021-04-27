using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Api.Controllers.v1
{
    [Route("api/v1/divida")]
    public class DividaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
