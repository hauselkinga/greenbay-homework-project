namespace GreenBay_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpPost]
        public ActionResult Register()
        {
            return Ok("Hello World!");
        }
    }
}
