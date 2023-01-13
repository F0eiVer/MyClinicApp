using Microsoft.AspNetCore.Mvc;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
