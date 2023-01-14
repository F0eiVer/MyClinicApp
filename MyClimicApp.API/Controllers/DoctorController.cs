using Microsoft.AspNetCore.Mvc;
using MyClimicApp.API.Views;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using MyClinicApp.Service.Implementations;
using MyClinicApp.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("doctorCreate")]
        public async Task<ActionResult<DoctorView>> Create(Doctor doctor)
        {
            if (doctor.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetDoctor;
                return Problem(statusCode: t, detail: "Не указан доктор");
            }

            var doctorRes = await doctorService.Create(doctor);

            if (doctorRes.Data.Equals(null))
            {
                return Problem(statusCode: 404, detail: doctorRes.Description);
            }

            return Ok(new DoctorView
            {
                ID = doctorRes.Data.ID,
                FullName = doctorRes.Data.FullName,
                Specialization = doctorRes.Data.Specialization,
            });
        }

        [HttpPost("doctorDelete")]
        public async Task<ActionResult<bool>> Delete(Doctor doctor)
        {
            if (doctor.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetDoctor;
                return Problem(statusCode: t, detail: "Не указан доктор");
            }

            return Ok(await doctorService.Delete(doctor));
        }

        [HttpGet("doctorGet")]
        public async Task<ActionResult<DoctorView>> Get(ulong id)
        {
            var doctorRes = await doctorService.Get(id);
            if (doctorRes.Equals(null))
            {
                return Problem(statusCode: 404, detail: doctorRes.Description);
            }

            return Ok(new DoctorView
            {
                ID = doctorRes.Data.ID,
                FullName = doctorRes.Data.FullName,
                Specialization = doctorRes.Data.Specialization,
            });
        }

        [HttpGet("doctors")]
        public async Task<ActionResult<IEnumerable<DoctorView>>> GetDoctors()
        {
            var doctors = await doctorService.GetDoctors();
            if (doctors.Equals(null))
            {
                return Problem(statusCode: 404, detail: doctors.Description);
            }
            else if (doctors.Data.Count() == 0)
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotFind;
                return Problem(statusCode: t, detail: doctors.Description);
            }

            List<DoctorView> doctorsRes = new List<DoctorView>();

            foreach (var doctor in doctors.Data)
            {
                doctorsRes.Add(new DoctorView
                {
                    ID = doctor.ID,
                    FullName = doctor.FullName,
                    Specialization = doctor.Specialization,
                });
            }

            return Ok(doctorsRes);
        }

        [HttpGet("spesialization")]
        public async Task<ActionResult<DoctorView>> GetDoctorBySpecialization(Specialization specialization)
        {
            if (specialization.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetSpecialization;
                return Problem(statusCode: t, detail: "Не указана специализация");
            }

            var doctorRes = await doctorService.GetDoctorBySpecialization(specialization);

            if(doctorRes.Data.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotFind;
                return Problem(statusCode: t, detail: doctorRes.Description);
            }

            return Ok(new DoctorView
            {
                ID = doctorRes.Data.ID,
                FullName = doctorRes.Data.FullName,
                Specialization = doctorRes.Data.Specialization,
            });
        }
    }
}
