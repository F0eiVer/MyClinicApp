using Microsoft.AspNetCore.Mvc;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
