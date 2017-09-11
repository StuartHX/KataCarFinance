using System.Web.Http;

namespace Carfinance.Phoenix.Kata.Angular.Controllers
{
    [Route("")]
    public class AliveController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}