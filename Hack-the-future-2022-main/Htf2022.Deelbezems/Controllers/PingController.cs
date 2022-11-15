using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Htf2022.Deelbezems.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGetAttribute]
        public IActionResult Index()
        {
            return Ok("pong");
        }
    }
}
