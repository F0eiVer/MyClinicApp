using Microsoft.AspNetCore.Mvc;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("timetable")]
    public class TimetableController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
