using Microsoft.AspNetCore.Mvc;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
