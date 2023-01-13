using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Service.Implementations;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService appointmentService;

        public AppointmentController(AppointmentService _appointmentService)
        {
            appointmentService = _appointmentService;
        }
    }
}
