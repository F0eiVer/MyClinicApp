using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Service.Implementations;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService;

        public DoctorController(DoctorService _doctorService)
        {
            doctorService = _doctorService;
        }
    }
}
