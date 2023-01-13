using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Service.Implementations;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("timetable")]
    public class TimetableController : ControllerBase
    {
        private readonly TimetableService timetableService;

        public TimetableController(TimetableService _timetableService)
        {
            timetableService = _timetableService;
        }
    }
}
