using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [HttpGet]
        [HttpOptions]
        public void Index([FromBody]JObject body)
        {
            var name = body["name"].ToString();
            var temp = HttpContext.Request.Body;
        }
    }
}
